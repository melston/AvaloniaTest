namespace NewApp

module TreeStuff =
    open Books
    open Avalonia.Controls
    open Avalonia.FuncUI.DSL
    open Avalonia.FuncUI.Components
    open Avalonia.Layout
    
    type StoryData =
        | Author  of AuthorBooksInfo
        | Book    of BookInfo
        | Chapter of ChapterInfo

    type State = { Entries : StoryData list }

    let init = { Entries = (authStories |> List.map Author) }

    type Msg = Add of ChapterInfo | Remove of string

    let update (msg: Msg) (state: State) : State =
        // For now, no state changes since we are not sending these messages.
        match msg with
        | Add s -> state
        | Remove s -> state
    
    let private createAuthorView (entry: AuthorBooksInfo) =
        TextBlock.create [ TextBlock.text entry.AuthorName ]

    let private createBookView (entry: BookInfo) =
        TextBlock.create [ TextBlock.text entry.BookName ]

    let private createChapterView (entry: ChapterInfo) =
        Grid.create [
            Grid.showGridLines false
            Grid.columnDefinitions "Auto, 5*, Auto, 3*"
            Grid.children [
                TextBlock.create [
                    Grid.column 0
                    TextBlock.padding (0.0, 0.0, 5.0, 0.0)
                    TextBlock.text "Name: "
                ]
                TextBlock.create [
                    Grid.column 1
                    TextBlock.text entry.ChapterName
                ]
                TextBlock.create [
                    Grid.column 2
                    TextBlock.padding (0.0, 0.0, 5.0, 0.0)
                    TextBlock.text "Date: "
                ]
                TextBlock.create [
                    Grid.column 3
                    TextBlock.text (entry.Date.ToString "yyyy-MM-dd")
                ]
            ]
        ]

    let private createView (dispatch: Msg -> unit) (d: StoryData) :Avalonia.FuncUI.Types.IView =
        // For now, just create a TextBlock with Author/Book/Chapter name
        // Later we will make it more complicated - e.g. createChapterInfo
        match d with 
        | Author a  -> createAuthorView a  :> Avalonia.FuncUI.Types.IView
        | Book b    -> createBookView b    :> Avalonia.FuncUI.Types.IView
        | Chapter c -> createChapterView c :> Avalonia.FuncUI.Types.IView


    let private getChildren (inf: StoryData) : StoryData seq =
        match inf with
        | Author s  -> s.Books |> Seq.map Book
        | Book b    -> b.Chapters |> Seq.map Chapter
        | Chapter c -> Seq.empty  // No children for chapters

    let view (state: State) (dispatch: Msg -> unit) =
        DockPanel.create [
            DockPanel.children [
                yield TreeView.create [
                    TreeView.dock Dock.Left
                    TreeView.dataItems state.Entries
                    // If we comment this out we get a 'tree' of sorts but
                    // it isn't very useful.
                    TreeView.itemTemplate 
                        (DataTemplateView<StoryData>.create 
                            ( getChildren, createView dispatch )
                        )
                ]
            ]
        ]
