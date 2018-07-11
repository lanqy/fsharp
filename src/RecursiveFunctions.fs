module RecursiveFunctions = 
    // 此示例显示了一个递归函数，用于计算整数的阶乘。 它使用 'let rec' 来定义递归函数。
    let rec factorial n = 
        if n = 0 then 1 else n * factorial (n - 1)
    
    printfn "Factorial of 6 is: %d" (factorial 6)

    // 计算两个整数的最大公因子。
    // 由于所有递归调用都是尾调用，因此编译器会将函数转换为循环，从而提高性能并减少内存消耗。
    let rec greatestCommonFactor a b = 
        if a = 0 then b
        elif a < b then greatestCommonFactor a (b - a)
        else greatestCommonFactor (a - b) b
    printfn "The Greatest Common Factor of 300 and 620 is %d" (greatestCommonFactor 300 620)

    // 此示例使用递归计算整数列表的总和。
    let rec private sumListTailRecHelper accumulator xs =
        match xs with
        | [] -> accumulator
        | y :: ys -> sumListTailRecHelper (accumulator + y) ys

    // 这将调用尾递归辅助函数，提供 '0' 作为种子累加器。
    // 像这样的方法在 F＃ 中很常见。
    let sumListTailRecursive xs = sumListTailRecHelper 0 xs

    let oneThroughTen = [1; 2; 3; 4; 5; 6; 7; 8; 9; 10]

    printfn "The sum 1-10 is %d" (sumListTailRecursive oneThroughTen)

