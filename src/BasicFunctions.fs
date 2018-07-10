namespace BasicFunctions
module BasicFunctions = 
    let sampleFunctions x = x * x + 3

    let result1 = sampleFunctions 4573

    printfn "The result of squaring the integer 4573 and adding 3 is %d" result1

    let sampleFunctions2 (x:int) = 2 * x * x - x / 5 + 3

    let result2 = sampleFunctions2 (7 + 4)
    printfn "The result of applying the 2nd sample function to (7 + 4) is %d" result2

    let sampleFunctions3 x =
        if x < 100.0 then
            2.0 * x * x - x / 5.0 + 3.0
        else
            2.0 * x * x + x / 5.0 - 37.0
    let result3 = sampleFunctions3 (6.5 + 4.5)