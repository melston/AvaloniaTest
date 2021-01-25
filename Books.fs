namespace NewApp

module Books =

    type StoryInfo = { Name: string; Date: System.DateTime }
    type BookInfo = { Name: string; Chapters: StoryInfo list }
    type AuthorStoriesInfo = { Name: string; Books: BookInfo list }

    // Stories by Rook-385
    let private frontierChapters = [
        { Name = "Frontier - Chapter 1"; Date = System.DateTime(2020, 9, 30, 0, 0, 0) }
        { Name = "Frontier - Chapter 2"; Date = System.DateTime(2020, 9, 30, 0, 0, 0) }
        { Name = "Frontier - Chapter 3"; Date = System.DateTime(2020, 9, 30, 0, 0, 0) }
        { Name = "Frontier - Chapter 4"; Date = System.DateTime(2020, 9, 30, 0, 0, 0) }
        { Name = "Frontier - Chapter 5"; Date = System.DateTime(2020, 9, 30, 0, 0, 0) }
        { Name = "Frontier - Chapter 6"; Date = System.DateTime(2020, 9, 30, 0, 0, 0) }
        { Name = "Frontier - Chapter 7"; Date = System.DateTime(2020, 9, 30, 0, 0, 0) }
        { Name = "Frontier - Chapter 8"; Date = System.DateTime(2020, 9, 30, 0, 0, 0) }
        { Name = "Frontier - Chapter 9"; Date = System.DateTime(2020, 9, 30, 0, 0, 0) }
        { Name = "Frontier - Chapter 10"; Date = System.DateTime(2020, 9, 30, 0, 0, 0) }
        { Name = "Frontier - Chapter 11"; Date = System.DateTime(2020, 9, 30, 0, 0, 0) }
        { Name = "Frontier - Chapter 12"; Date = System.DateTime(2020, 9, 30, 0, 0, 0) }
    ]
    let private frontierBook = { Name = "Frontier"; Chapters = frontierChapters }

    let private riseOfSolRepChaps = [
        { Name = "Rise of the Sol Republic"; Date = System.DateTime(2021, 1, 17, 0, 0, 0) }
    ]
    let private riseOfSolRepBook = { Name = "Rise of the Sol Republic"; Chapters = riseOfSolRepChaps }

    let private rookStories = { Name = "Rook-385"; Books = [
        frontierBook
        riseOfSolRepBook
    ]}

    // Stories by SassyArtichoke
    let private riseOfReyloChapters = [
        { Name = "The Rise of Reylo - Chapter 1"; Date = System.DateTime(2020, 12, 30, 0, 0, 0) }
        { Name = "The Rise of Reylo - Chapter 2"; Date = System.DateTime(2020, 12, 30, 0, 0, 0) }
        { Name = "The Rise of Reylo - Chapter 3"; Date = System.DateTime(2020, 12, 30, 0, 0, 0) }
        { Name = "The Rise of Reylo - Chapter 4"; Date = System.DateTime(2020, 12, 30, 0, 0, 0) }
    ]
    let private riseOfReyloBook = { Name = "The Rise of Reylo"; Chapters = riseOfReyloChapters }

    let private pushPullChapters = [
        { Name = "The Push and the Pull"; Date = System.DateTime(2020, 4, 26, 0, 0, 0) }
    ]
    let private pushPullBook = { Name = "The Push and the Pull"; Chapters = pushPullChapters }

    let private sassyArtichokeStories = { Name = "Sassy Artichoke"; Books = [
        riseOfReyloBook
        pushPullBook
    ]}

    let authStories = [
        rookStories
        sassyArtichokeStories
    ]


    let stories = [
        { Name = "abc"; Date = System.DateTime(2008,  3,  9,  1, 30, 0) };
        { Name = "def"; Date = System.DateTime(2009,  4, 10, 11, 30, 0) };
        { Name = "ghi"; Date = System.DateTime(2020, 12, 20, 14, 30, 0) }
    ]

