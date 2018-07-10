module IntegersAndNumbers =

    // 这是一个样本示例。
    let sampleInterger = 176

    // 这是一个浮点数示例。
    let sampleDouble = 4.1

    // 这通过某种算术计算出一个新数字。使用转换数字类型     
    // 函数'int'，'double'等等。
    let sampleInterger2 = (sampleInterger / 4 + 5 - 7) * 4 + int sampleDouble

    // 这是 0 到 99 之间的数字列表。
    let samplNumbers = [0 .. 99]

    // 这是包含0到99之间所有数字及其乘方的所有元组的列表。
    let sampleTableOfSquares = [for i in 0 .. 99 -> (i, i * i)]

    // 下一行打印包含元组的列表，使用'％A'进行通用打印。
    printfn "The table of squares from 0 to 99 is:\n%A" sampleTableOfSquares