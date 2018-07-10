module Booleans = 
    // 布尔值是 'true' and 'false'.
    let boolean1 = true
    let boolean2 = false

    // 布尔值上的运算符是 'not'，'&&' 和 '||'。
    let boolean3 = not boolean1 && (boolean2 || false)

    // 该行使用'％b'来打印布尔值。这是类型安全的
    printfn "The expression 'not boolean1 && (boolean2 || false)' is %b" boolean3