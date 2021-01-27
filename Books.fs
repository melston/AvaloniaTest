namespace NewApp

module Books =

    type ChapterInfo = { ChapterName: string; Date: System.DateTime }
    type BookInfo = { BookName: string; Chapters: ChapterInfo list }
    type AuthorBooksInfo = { AuthorName: string; Books: BookInfo list }

    // The following are sample story chapters/books from the Star Wars
    // fan fiction site.  This allows me to specify different types at 
    // different levels of nesting for purposes of playing with nested
    // data.  If you are interested go to 
    // https://www.fanfiction.net/movie/Star-Wars/.

    // Stories by Rook-385
    let private frontierChapters = [
        { ChapterName = "Frontier - Chapter 1"; Date = System.DateTime(2020, 9, 30, 0, 0, 0) }
        { ChapterName = "Frontier - Chapter 2"; Date = System.DateTime(2020, 9, 30, 0, 0, 0) }
        { ChapterName = "Frontier - Chapter 3"; Date = System.DateTime(2020, 9, 30, 0, 0, 0) }
        { ChapterName = "Frontier - Chapter 4"; Date = System.DateTime(2020, 9, 30, 0, 0, 0) }
        { ChapterName = "Frontier - Chapter 5"; Date = System.DateTime(2020, 9, 30, 0, 0, 0) }
        { ChapterName = "Frontier - Chapter 6"; Date = System.DateTime(2020, 9, 30, 0, 0, 0) }
        { ChapterName = "Frontier - Chapter 7"; Date = System.DateTime(2020, 9, 30, 0, 0, 0) }
        { ChapterName = "Frontier - Chapter 8"; Date = System.DateTime(2020, 9, 30, 0, 0, 0) }
        { ChapterName = "Frontier - Chapter 9"; Date = System.DateTime(2020, 9, 30, 0, 0, 0) }
        { ChapterName = "Frontier - Chapter 10"; Date = System.DateTime(2020, 9, 30, 0, 0, 0) }
        { ChapterName = "Frontier - Chapter 11"; Date = System.DateTime(2020, 9, 30, 0, 0, 0) }
        { ChapterName = "Frontier - Chapter 12"; Date = System.DateTime(2020, 9, 30, 0, 0, 0) }
    ]
    let private frontierBook = { BookName = "Frontier"; Chapters = frontierChapters }

    let private riseOfSolRepChaps = [
        { ChapterName = "Rise of the Sol Republic"; Date = System.DateTime(2021, 1, 17, 0, 0, 0) }
    ]
    let private riseOfSolRepBook = { BookName = "Rise of the Sol Republic"; Chapters = riseOfSolRepChaps }

    let private rookStories = { AuthorName = "Rook-385"; Books = [
        frontierBook
        riseOfSolRepBook
    ]}

    // Stories by SassyArtichoke
    let private riseOfReyloChapters = [
        { ChapterName = "The Rise of Reylo - Chapter 1"; Date = System.DateTime(2020, 12, 30, 0, 0, 0) }
        { ChapterName = "The Rise of Reylo - Chapter 2"; Date = System.DateTime(2020, 12, 30, 0, 0, 0) }
        { ChapterName = "The Rise of Reylo - Chapter 3"; Date = System.DateTime(2020, 12, 30, 0, 0, 0) }
        { ChapterName = "The Rise of Reylo - Chapter 4"; Date = System.DateTime(2020, 12, 30, 0, 0, 0) }
    ]
    let private riseOfReyloBook = { BookName = "The Rise of Reylo"; Chapters = riseOfReyloChapters }

    let private pushPullChapters = [
        { ChapterName = "The Push and the Pull"; Date = System.DateTime(2020, 4, 26, 0, 0, 0) }
    ]
    let private pushPullBook = { BookName = "The Push and the Pull"; Chapters = pushPullChapters }

    let private sassyArtichokeStories = { AuthorName = "Sassy Artichoke"; Books = [
        riseOfReyloBook
        pushPullBook
    ]}

    let authStories = [
        rookStories
        sassyArtichokeStories
    ]


    let stories = [
        { ChapterName = "abc"; Date = System.DateTime(2008,  3,  9,  1, 30, 0) };
        { ChapterName = "def"; Date = System.DateTime(2009,  4, 10, 11, 30, 0) };
        { ChapterName = "ghi"; Date = System.DateTime(2020, 12, 20, 14, 30, 0) }
    ]

