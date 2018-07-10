module Arrays = 

    // 这是空数组。请注意，语法类似于Lists，但使用`[| ... |]` 代替。
    let array1 = [| |]

    // 使用与列表相同的构造范围指定数组。
    let array2 = [| "hello"; "world"; "and"; "hello"; "world"; "again"|]

    // 这是一个从 1 到 1000 的数字数组。
    let array3 = [| 1 .. 1000 |]

    // 这是一个只包含单词 “hello” 和 “world” 的数组。
    let array4 = 
        [|
            for word in array2 do
                if word.Contains("l") then
                    yield word
        |]
    
    // 这是一个由索引初始化的数组，包含从 0 到 2000 的偶数。
    let evenNumbers = Array.init 1001 (fun n -> n * 2)

    // 使用切片表示法提取子数组。
    let evenNumbersSlice = evenNumbers.[0..500]

    // 您可以使用 “for” 循环遍历数组和列表。
    for word in array4 do
        printfn "word: %s" word

    // 您可以使用左箭头分配运算符修改数组元素的内容。
    // 要了解有关此运算符的更多信息，请参阅：https：//docs.microsoft.com/dotnet/fsharp/language-reference/values/index#mutable-variables
    array2.[1] <- "WORLD!"

    // 您可以使用 “Array.map” 和其他函数编程操作来转换数组。
    // 以下计算以 'h' 开头的单词长度之和。

    let sumOfLengthsOfWords = 
        array2
        |> Array.filter (fun x -> x.StartsWith "h")
        |> Array.sumBy (fun x -> x.Length)
    
    printfn "The sum of the lengths of the words in Array 2 is: %d" sumOfLengthsOfWords