namespace NewApp

module TreeStuff =
    open Books
    open Avalonia.Controls
    open Avalonia.FuncUI.DSL
    open Avalonia.FuncUI.Components
    open Avalonia.Layout
    
    type StoryData =
        | Author of AuthorStoriesInfo
        | Book of BookInfo
        | Chapter of StoryInfo

    type State = { Entries : StoryData seq }

    let init = { Entries = (authStories |> Seq.map Author) }

    type Msg = Add of StoryInfo | Remove of string

    let update (msg: Msg) (state: State) : State =
        match msg with
        | Add s -> state
        | Remove s -> state
    
    // let private createChapterInfo (entry: StoryInfo) =
    //     Grid.create [
    //         Grid.showGridLines false
    //         Grid.columnDefinitions "Auto, 5*, Auto, 3*"
    //         Grid.children [
    //             TextBlock.create [
    //                 Grid.column 0
    //                 TextBlock.padding (0.0, 0.0, 5.0, 0.0)
    //                 TextBlock.text "Name: "
    //             ]
    //             TextBlock.create [
    //                 Grid.column 1
    //                 TextBlock.text entry.Name
    //             ]
    //             TextBlock.create [
    //                 Grid.column 2
    //                 TextBlock.padding (0.0, 0.0, 5.0, 0.0)
    //                 TextBlock.text "Date: "
    //             ]
    //             TextBlock.create [
    //                 Grid.column 3
    //                 TextBlock.text (entry.Date.ToString "yyyy-MM-dd")
    //             ]
    //         ]
    //     ]

    let private getChildren (inf: StoryData) : StoryData seq =
        match inf with
        | Author s -> s.Books |> Seq.map Book
        | Book b -> b.Chapters |> Seq.map Chapter
        | Chapter _ -> Seq.empty

    let private createView (dispatch: Msg -> unit) (d: StoryData) =
        match d with 
        | Author s -> TextBlock.create [ TextBlock.text s.Name]  // :> Avalonia.FuncUI.Types.IView
        | Book b -> TextBlock.create [ TextBlock.text b.Name]    // :> Avalonia.FuncUI.Types.IView
        | Chapter c -> TextBlock.create [ TextBlock.text c.Name] // createChapterInfo c :> Avalonia.FuncUI.Types.IView


    let view (state: State) (dispatch: Msg -> unit) =
        DockPanel.create [
            DockPanel.children [
                yield TreeView.create [
                    TreeView.dock Dock.Left
                    TreeView.dataItems state.Entries
                    TreeView.itemTemplate 
                        (DataTemplateView<StoryData>.create 
                            ( getChildren, createView dispatch)
                        )
                ]
            ]
        ]
