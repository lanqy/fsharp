module PatternMatching =

    // 一个人的名字和姓氏的记录
    type Person = {
        First: string
        Last: string
    }

    // 由三种不同类型的员工组成的区分联合
    type Employee =
        | Engineer of engineer: Person
        | Manager of manager: Person * reports: List<Employee>
        | Executive of executive: Person * reports: List<Employee> * assistant: Employee


    // 计算管理层次结构中员工下方的所有人员，包括员工。 匹配将名称绑定到案例的属性，以便可以在匹配分支中使用这些名称。
    // 请注意，用于绑定的名称不必与上面DU定义中给出的名称相同。
    let rec countReports(emp: Employee) =
        1 + match emp with
            | Engineer(person) ->
                0
            | Manager(person, reports) ->
                reports |> List.sumBy countReports
            | Executive(person, reports, assistant) ->
                (reports |> List.sumBy countReports) + countReports assistant


    // 找到所有没有任何报告的经理/主管。
    // 这使用 'function' 简写作为 lambda 表达式。
    let rec findDaveWithOpenPosition(emps: List<Employee>) =
        emps
        |> List.filter(function
                        | Manager({First = "Dave"}, []) -> true // [] 匹配一个空列表。
                        | _ -> false)  // '_'是一个匹配任何东西的通配符模式。这处理“或”的情况。

open System

// 您还可以使用简写函数构造进行模式匹配，这在您编写使用部分应用程序的函数时非常有用。
let private parseHelper f = f >> function
    | (true, item) -> Some item
    | (false, _) -> None

let parseDateTimeOffset = parseHelper DateTimeOffset.TryParse

let result = parseDateTimeOffset "1970-01-01"
match result with
| Some dto -> printfn "It parsed!"
| None -> printfn "It did't parse!"

// 定义一些使用辅助函数解析的函数。

let parseInt = parseHelper Int16.TryParse
let parseDouble = parseHelper Double.TryParse
let parseTimeSpan = parseHelper TimeSpan.TryParse

// Active Patterns ( 活动模式 )是另一种用于模式匹配的强大构造。
// 它们允许您将输入数据分区为自定义表单，并在模式匹配调用站点中对其进行分解。
// 要了解更多信息，请参阅：https://docs.microsoft.com/dotnet/fsharp/language-reference/active-patterns
let (|Int|_|) = parseInt
let (|Double|_|) = parseDouble
let (|Date|_|) = parseDateTimeOffset
let (|TimeSpan|_|) = parseTimeSpan

// 通过 'function' 关键字和 Active Patterns 进行模式匹配通常看起来像这样。
let printParseResult = function
    | Int x -> printfn "%d" x
    | Double x -> printfn "%f" x
    | Date d -> printfn "%s" (d.ToString())
    | TimeSpan t -> printfn "%s" (t.ToString())
    | _ -> printfn "Nothing was parse-able!"

// 使用一些不同的值调用打印机进行解析

printParseResult "12"
printParseResult "12.045"