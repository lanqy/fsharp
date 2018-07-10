module Tuples = 
    
    // 一个整数元组示例
    let tuple1 = (1, 2, 3)

    // 一个函数，用于交换元组中两个值的顺序
    /// F＃ 类型推断会自动将函数推广为泛型类型，    
    /// 意味着它适用于任何类型。
    let swapElems (a, b) = (b, a)
    
    printfn "The result of swapping (1, 2) is %A" (swapElems (1, 2))

    // 由整数，字符串组成的元组，和一个双精度浮点数。

    let tuple2 = (1, "fred", 3.1415)

    printfn "Tuple1: %A\ttuple2: %A" tuple1 tuple2