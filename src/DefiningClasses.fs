// 要了解有关类的更多信息，请参阅：https://docs.microsoft.com/dotnet/fsharp/language-reference/classes
// 
// 要了解有关成员的更多信息，请访问：https://docs.microsoft.com/dotnet/fsharp/language-reference/members
module DefiningClasses =

    // 一个简单的二维Vector类。
    // 
    // 类的构造函数位于第一行，并带有两个参数：dx 和 dy，两者都是 'double' 类型。
    type Vector2D(dx: double, dy: double) =

        // 此内部字段存储在构造对象时计算的向量的长度
        let length = sqrt (dx * dx + dy * dy)

        // 'this' 指定对象的自标识符的名称。
        // 在实例方法中，它必须出现在成员名称之前。
        member this.DX = dx
        member this.DY = dy
        member this.Length = length

        // 这个成员是一种方法。前面的成员是属性。
        member this.Scale(k) = Vector2D(k * this.DX, k * this.DY)

    // 这是您实例化Vector2D类的方法。
    let vector1 = Vector2D(3.0, 4.0)

    // 获得一个新的缩放 vector 对象，不修改原始对象。