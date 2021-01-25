namespace NewApp

module Table =
    open Books
    open Avalonia.Controls
    open Avalonia.FuncUI.DSL
    open Avalonia.FuncUI.Components
    open Avalonia.Layout
    
    type State = { Entries : StoryInfo list }

    let init = { Entries = Books.stories }

    type Msg = Add of StoryInfo | Remove of string

    let update (msg: Msg) (state: State) : State =
        match msg with
        | Add s -> { state with Entries = s :: state.Entries }
        | Remove s -> { 
            state with Entries = state.Entries 
                                 |> List.filter (fun v -> v.Name.Equals(s) |> not )}
    
    let private storyInfo (entry: StoryInfo) (dispatch: Msg -> unit) =
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
                    TextBlock.text entry.Name
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

    let private entryTemplate (entry: StoryInfo) (dispatch: Msg -> unit) =
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
                    TextBlock.text entry.Name
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

    let view (state: State) (dispatch: Msg -> unit) =
        ListBox.create [
            ListBox.dataItems state.Entries
            ListBox.itemTemplate (DataTemplateView<StoryInfo>.create(fun item -> entryTemplate item dispatch))
        ]