// 定义泛型类
// 在下文中，'T是类的类型参数。
// 
// 要了解更多信息，请访问：https://docs.microsoft.com/dotnet/fsharp/language-reference/generics/
module DefiningGenericClasses = 
    type StateTracker<'T>(initialElement: 'T) =

        // 此内部字段将状态存储在列表中。
        let mutable states = [ initialElement ]

        // 将新元素添加到状态列表中。
        member this.UpdateState newState =
            states <- newState :: states // 使用' <- '运算符来改变值。

        // 获取整个历史状态列表。
        member this.History = states

        // 获取最新状态。
        member this.Current = states.Head

    // 状态跟踪器类的 “int” 实例。请注意，推断出类型参数。
    let tracker = StateTracker 10