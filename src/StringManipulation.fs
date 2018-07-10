module StringManipulation = 
    
    // 字符串使用双引号。
    let string1 = "Hello"
    let string2 = "world"

    // 字符串也可以使用@来创建逐字字符串文字。     
    // 这将忽略转义字符，例如'\'，'\ n'，'\ t'等。
    let string3 = @"C:\Program Files\"

    // 字符串文字也可以使用三引号。
    let string4 = """The computer said "hello world" when I told it to!"""

    // 字符串连接通常使用'+'运算符完成。
    let helloWorld = string1 + " " + string2

    // 此行使用'％s'来打印字符串值。这是类型安全的。
    printfn "%s" helloWorld

    // 子字符串使用索引器表示法。此行将前7个字符提取为子字符串。
    // 请注意，与许多语言一样，字符串在F＃中为零索引。
    let substring = helloWorld.[0 .. 6]
    
    printfn "%s" substring