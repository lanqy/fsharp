module Sequences = 
    // 这是空序列。
    let seq1 = Seq.empty

    // 这是一个值序列。
    let seq2 = seq {yield "hello"; yield "world"; yield "and"; yield "hello"; yield "world"; yield "again"}

    // 这是从1到1000的按需序列。
    let numbersSeq = seq {1 .. 1000}

    // 这是一个产生 “hello” 和 “world” 字样的序列
    let seq3 = 
        seq {
            for word in seq2 do
                if word.Contains("l") then
                    yield word
        }

    // 这个序列产生的偶数高达 2000。
    let evenNumbers = Seq.init 1001 (fun n -> n * 2)

    let rnd = System.Random()

    // 这是一个随机生成的无限序列。
    // 这个例子使用 yield! 返回子序列的每个元素。
    let rec randomWalk x = 
        seq { yield x
              yield! randomWalk (x + rnd.NextDouble() - 0.5)
        }
    
    // 此示例显示随机生成的前 100 个元素。

    let first100ValuesOfRandomWalk = 
        randomWalk 5.0
        |> Seq.truncate 100
        |> Seq.toList
    
    printfn "First 100 elements of a random walk: %A" first100ValuesOfRandomWalk


