module Immutability =

    // 通过 'let' 将值绑定到名称使其不可变
    // 第二行代码无法编译，因为 'number' 是不可变的并且是绑定的。
    // 在 F＃ 中不允许将'number'重新定义为不同的值。
    let number = 2
    // let number = 3

    // 可变的绑定。这需要能够改变 'otherNumber' 的值。
    let mutable otherNumber = 2

    printfn "'otherNumber' is %d" otherNumber

    // 变异值时，使用“<-”指定新值。
    // 请注意，'='与此不同。 '='用于测试相等性。
    otherNumber <- otherNumber + 1

    printfn "'otherNumber' changed to be %d" otherNumber
