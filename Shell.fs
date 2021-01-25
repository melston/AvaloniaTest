namespace NewApp

/// This is the main module of your application
/// here you handle all of your child pages as well as their
/// messages and their updates, useful to update multiple parts
/// of your application, Please refer to the `view` function
/// to see how to handle different kinds of "*child*" controls
module Shell =
    open Elmish
    open Avalonia
    open Avalonia.Controls
    open Avalonia.Input
    open Avalonia.FuncUI.DSL
    open Avalonia.FuncUI
    open Avalonia.FuncUI.Builder
    open Avalonia.FuncUI.Components.Hosts
    open Avalonia.FuncUI.Elmish
    open System

    type State =
        /// store the child state in your main state
        { AboutState: About.State; CounterState: Counter.State; 
          TableState: Table.State; TreeState: TreeStuff.State }

    type Msg =
        | AboutMsg of About.Msg
        | CounterMsg of Counter.Msg
        | TableMsg of Table.Msg
        | TreeMsg of TreeStuff.Msg
        | ExitMsg

    let init =
        let aboutState, aboutCmd = About.init
        let counterState = Counter.init
        let tableState = Table.init
        let treeState = TreeStuff.init
        { AboutState = aboutState; CounterState = counterState; 
          TableState = tableState; TreeState = treeState },
        /// If your children controls don't emit any commands
        /// in the init function, you can just return Cmd.none
        /// otherwise, you can use a batch operation on all of them
        /// you can add more init commands as you need
        Cmd.batch [ aboutCmd ]

    let update (msg: Msg) (state: State): State * Cmd<_> =
        match msg with
        | TreeMsg treemsg ->
            let treeMsg = TreeStuff.update treemsg state.TreeState
            { state with TreeState = treeMsg }, Cmd.none
        | TableMsg tblmsg ->
            let tblMsg = Table.update tblmsg state.TableState
            { state with TableState = tblMsg }, Cmd.none
        | CounterMsg countermsg ->
            let counterMsg =
                Counter.update countermsg state.CounterState
            { state with CounterState = counterMsg },
            /// map the message to the kind of message 
            /// your child control needs to handle
            Cmd.none
        | AboutMsg abtmsg ->
            let aboutState, cmd =
                About.update abtmsg state.AboutState
            { state with AboutState = aboutState },
            /// map the message to the kind of message 
            /// your child control needs to handle
            Cmd.map AboutMsg cmd
        | ExitMsg ->
            Environment.Exit 0 |> ignore
            state, Cmd.none

    // See https://github.com/AvaloniaCommunity/Avalonia.FuncUI/blob/954394599c8d2f6e0c4b1d4b89a6c62d54300e0a/src/Examples/Examples.MusicPlayer/Shell.fs#L149
    let menuBar (state: State) (dispatch: Msg -> unit) =
        Menu.create [
            Menu.dock Dock.Top
            Menu.viewItems [
                MenuItem.create [
                    MenuItem.header "Files"
                    MenuItem.viewItems [
                        MenuItem.create [
                            MenuItem.header "Exit"
                            MenuItem.onClick(fun _ -> dispatch ExitMsg)
                        ]
                    ]
                ]
            ]
        ]

    let view (state: State) (dispatch: Msg -> unit) =
        DockPanel.create [ 
            DockPanel.children [ 
                menuBar state dispatch
                TabControl.create [ 
                    TabControl.tabStripPlacement Dock.Top
                    TabControl.viewItems [ 
                        TabItem.create [ 
                            TabItem.header "Tree Sample"
                            TabItem.content (TreeStuff.view state.TreeState (TreeMsg >> dispatch)) ]
                        TabItem.create [ 
                            TabItem.header "Table Sample"
                            TabItem.content (Table.view state.TableState (TableMsg >> dispatch)) ]
                        TabItem.create [ 
                            TabItem.header "Counter Sample"
                            TabItem.content (Counter.view state.CounterState (CounterMsg >> dispatch)) ]
                        TabItem.create [ 
                            TabItem.header "About"
                            TabItem.content (About.view state.AboutState (AboutMsg >> dispatch)) ]
                    ] 
                ]
            ]
        ]

    /// This is the main window of your application
    /// you can do all sort of useful things here like setting heights and widths
    /// as well as attaching your dev tools that can be super useful when developing with
    /// Avalonia
    type MainWindow() as this =
        inherit HostWindow()
        do
            base.Title <- "Full App"
            base.Width <- 800.0
            base.Height <- 600.0
            base.MinWidth <- 800.0
            base.MinHeight <- 600.0

            //this.VisualRoot.VisualRoot.Renderer.DrawFps <- true
            //this.VisualRoot.VisualRoot.Renderer.DrawDirtyRects <- true

            Elmish.Program.mkProgram (fun () -> init) update view
            |> Program.withHost this
            |> Program.run
