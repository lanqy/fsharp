module PipelinesAndComposition = 

    // 平方值。
    let square x = x * x

    // 将 1 添加到值
    let addOne x = x + 1

    // 通过取模测试整数值是否为奇数。
    let isOdd x = x % 2 <> 0

    // 5个数字的列表。稍后列出更多内容。
    let numbers = [1; 2; 3; 4; 5]

    // 给定一个整数列表，它会过滤掉偶数，对得到的赔率进行平方，并将平均赔率加1。
    let squareOddValuesAndAddOne values = 
        let odds = List.filter isOdd values
        let squares = List.map square odds
        let result = List.map addOne squares
        result
        
    printfn "processing %A through 'squareOddValuesAndAddOne' produces: %A" numbers (squareOddValuesAndAddOne numbers)

    
    /// 编写'squareOddValuesAndAddOne'的更简单方法是将每个子结果嵌套到函数调用本身中。     

    /// 这使得功能更短，但很难看到处理数据的顺序。
    
    let squareOddValuesAndAddOneNested values = 
        List.map addOne (List.map square (List.filter isOdd values))
    
    printfn "processing %A through 'squareOddValuesAndAddOneNested' produces: %A" numbers (squareOddValuesAndAddOneNested numbers)

    // 编写 'squareOddValuesAndAddOne' 的首选方法是使用 F＃ 管道运算符。
    // 这允许您避免创建中间结果，但比嵌套函数调用（如'squareOddValuesAndAddOneNested'）更具可读性
    let squareOddValuesAndAddOnePipeline values =
        values
        |> List.filter isOdd
        |> List.map square
        |> List.map addOne

    printfn "processing %A through 'squareOddValuesAndAddOneNested' produces: %A" numbers (squareOddValuesAndAddOnePipeline numbers)
    
    // 您可以使用 Lambda 函数将第二个 `List.map` 调用移动到第一个调用中来缩短 'squareOddValuesAndAddOnePipeline'。
    // 请注意，管道也在 lambda 函数中使用。 F＃ 管道运算符也可用于单个值。 这使它们对处理数据非常有用。

    let squareOddValuesAndAddOneShorterPipeline values =
        values
        |> List.filter isOdd
        |> List.map(fun x -> x |> square |> addOne)
    
    printfn "processing %A through 'squareOddValuesAndAddOneShorterPipeline' produces: %A" numbers (squareOddValuesAndAddOneShorterPipeline numbers)