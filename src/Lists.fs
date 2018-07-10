module Lists = 

    // 列表使用[...]定义。这是一个空列表。
    let list1 = []

    // 这是一个包含3个元素的列表。 ';'用于分隔同一行上的元素。
    let list2 = [1; 2; 3]

    // 您还可以通过将元素放在各自的行上来分隔元素。
    let list3 = [
        1
        2
        3
    ]

    // 这是 1 到 1000 之间的整数列表
    let numberList = [1 .. 1000]

    // 列表也可以通过计算生成。 这是一个包含一年中所有日期的列表。

    let daysList = 
        [for month in 1 .. 12 do
            for day in 1 .. System.DateTime.DaysInMonth(2017, month) do
                yield System.DateTime(2017, month, day)]
    
    // 使用 'List.take' 打印 'daysList' 的前 5 个元素。

    printfn "The first 5 days of 2017 are: %A" (daysList |> List.take 5)

    // 计算可以包括条件。 这是一个包含元组的列表，这些元组是棋盘上黑色方块的坐标。
    let blackSquares = 
        [ for i in 0 .. 7 do
                for j in 0 .. 7 do
                    if (i + j) / 2 = 1 then
                        yield (i, j) ]
    
    // 可以使用“List.map”和其他函数式编程组合器转换列表。
    // 此定义通过对 numberList 中的数字进行平方来生成新列表，使用管道运算符将参数传递给 List.map。

    let squares =
        numberList
        |> List.map (fun x -> x * x)

    // 还有许多其他列表组合。 以下计算可被3整除的数字的平方和。

    let sumOfSquares = 
        numberList
        |> List.filter (fun x -> x % 3 = 0)
        |> List.sumBy (fun x -> x * x)
        
    printfn "The sum of the squares of numbers up to 1000 that are divisible by 3 is: %d" sumOfSquares