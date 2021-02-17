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
    
    let private createChapterView (dispatch: Msg -> unit) (entry: ChapterInfo) =
        let v = Grid.create [
                    Grid.showGridLines false
                    Grid.columnDefinitions "Auto, 3*, Auto, 2*"
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
        TreeViewItem.create [
            // TreeViewItem.header entry.ChapterName
            TreeViewItem.header v
        ]

    let private createBookView (dispatch: Msg -> unit) (entry: BookInfo) =
        TreeViewItem.create [
            TreeViewItem.header entry.BookName
            TreeViewItem.viewItems [
                for chapter in entry.Chapters do
                    createChapterView dispatch chapter
            ]
        ]

    let private createAuthorView (dispatch: Msg -> unit) (entry: AuthorBooksInfo) =
        TreeViewItem.create [
            TreeViewItem.header entry.AuthorName
            TreeViewItem.viewItems [
                for book in entry.Books do
                    createBookView dispatch book
            ]
        ]

    let private createView (dispatch: Msg -> unit) (d: StoryData) =
        match d with 
        | Author a  -> createAuthorView dispatch a
        | Book b    -> createBookView dispatch b
        | Chapter c -> createChapterView dispatch c


    let view (state: State) (dispatch: Msg -> unit) =
        DockPanel.create [
            DockPanel.children [
                yield TreeView.create [
                    TreeView.dock Dock.Left
                    TreeView.viewItems [
                        for entity in state.Entries do
                            createView dispatch entity
                    ]
                ]
            ]
        ]
