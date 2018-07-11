module DiscriminatedUnions =
    // 以下代表扑克牌的套装。
    type Suit =
        | Hearts
        | Clubs
        | Diamonds
        | Spades

    // 一个有区别的结合也可以用来表示纸牌的等级。
    type Rank = 
        // 代表卡的等级2 .. 10
        | Value of int
        | Ace
        | King
        | Queen
        | Jack

        // 识别联合也可以实现面向对象的成员。
        static member GetAllRanks() = 
            [
                yield Ace
                for i in 2 .. 10 do yield Value i
                yield Jack
                yield Queen
                yield King
            ]
    // 这是一种结合了 Suit 和 Rank s的记录类型。
    // 在表示数据时，通常使用记录和区别联合。
    type Card = { Suit: Suit; Rank: Rank }

    // 这会计算一个代表牌组中所有牌的列表。
    let fullDeck = 
        [ for suit in [Hearts; Diamonds; Clubs; Spades] do 
              for rank in Rank.GetAllRanks() do 
                    yield {Suit = suit; Rank = rank} ]

    // 此示例将 “Card” 对象转换为字符串。
    let showPlayingCard (c: Card) =
        let rankString = 
            match c.Rank with
            | Ace -> "Ace"
            | King -> "King"
            | Queen -> "Queen"
            | Jack -> "Jack"
            | Value n -> string n
        let suitString = 
            match c.Suit with
            | Clubs -> "clubs"
            | Diamonds -> "diamonds"
            | Spades -> "spades"
            | Hearts -> "hearts"
        rankString + " of " + suitString

    // 此示例打印一个游戏牌中的所有牌。
    let printAllCards() = 
        for card in fullDeck do
            printfn "%s" (showPlayingCard card)


// 单箱 DU 通常用于域建模。 这可以为您提供额外的类型安全性，而不是原始类型，如字符串和整数。
// 单个案例的 DU 不能隐式转换为它们包装的类型。
// 例如，接收地址的函数不能接受字符串作为该输入，反之亦然。
type Address = Address of string
type Name = Name of string
type SSN  = SSN of int

// 您可以按如下方式轻松实例化单案例DU。
let address = Address "111 Alf Way"
let name = Name "Alf"
let ssn = SSN 123456789

// 当您需要该值时，可以使用简单函数解包基础值
let unwrapAddress (Address a) = a
let unwrapName (Name n) = n
let unwrapSSN (SSN s) = s

// 打印单箱 DU 很简单，具有展开功能。
printfn "Address: %s, Name: %s, and SSN: %d" (address |> unwrapAddress) (name |> unwrapName) (ssn |> unwrapSSN)

// 识别联合也支持递归定义。
// 这表示二进制搜索树，其中一个是空树，另一个是具有值和两个子树的节点。
type BST<'T> =
    | Empty
    | Node of value:'T * left: BST<'T> * right: BST<'T>

// 检查二叉搜索树中是否存在项目。
// 使用模式匹配递归搜索。如果存在则返回 true;否则，false。
let rec exists item bst =
    match bst with
    | Empty -> false
    | Node (x, left, right) ->
        if item = x then true
        elif item < x then (exists item left) // 检查左子树。
        else (exists item right) // 检查右子树。

// 在二进制搜索树中插入一个项目。
// 找到使用 Pattern Matching 递归插入的位置，然后插入一个新节点。
// 如果该项目已存在，则不会插入任何内容。
let rec insert item bst =
    match bst with
    | Empty -> Node(item, Empty, Empty)
    | Node(x, left, right) as node ->
        if item = x then node // 它不需要插入，它已经存在;返回节点。
        elif item < x then Node(x, insert item left, right) // 调用左子树
        else Node(x, left, insert item right) // 调用右子树

// 区分联合也可以通过 'Struct' 属性表示为结构。这在结构的性能超过引用类型的灵活性的情况下很有用。
// 
// 但是，执行此操作时需要了解两件重要事项：
// 1.结构 DU 不能递归定义。
// 2.结构 DU 必须具有每个案例的唯一名称。
[<Struct>]
type Shape = 
    | Circle of radius: float
    | Square of side: float
    | Triangle of height: float * width: float


















// DU 指的是可区分联合

