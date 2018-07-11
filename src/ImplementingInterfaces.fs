// 对象类型和对象表达式可以实现接口。
// 
// 要了解更多信息，请参阅：https://docs.microsoft.com/dotnet/fsharp/language-reference/interfaces
module ImplementingInterfaces = 
    
    // 这是一种实现 IDisposable 的类型。
    type ReadFile() =

        let file = new System.IO.StreamReader("readme.txt")

        member this.ReadLine() = file.ReadLine()

        // 这是 IDisposable 成员的实现。
        interface System.IDisposable with
            member this.Dispose() = file.Close()
    
    // 这是一个通过对象表达式实现 IDisposable 的对象与其他语言（ 如 C＃ 或 Java ）不同，实现接口不需要新的类型定义。