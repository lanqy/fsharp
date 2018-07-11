// 语言将使用空引用。
// 要了解更多信息，请访问：https://docs.microsoft.com/dotnet/fsharp/language-reference/options

module OptionValues = 
    // 首先，定义通过单一区分的联合定义的邮政编码。
    type ZipCode = ZipCode of string

    // 接下来，定义 ZipCode 是可选的类型。
    type Customer = { ZipCode: ZipCode option }

    // 接下来，在给定 'getState' 和 'getShippingZone' 抽象方法的实现的情况下，定义一个接口类型，代表一个对象来计算客户邮政编码的运送区域。
    type IShippingCalculator = 
        abstract GetState: ZipCode -> string option
        abstract GetShippingZone: string -> int

    // 接下来，使用计算器实例计算客户的运输区域。
    // 这使用 Option 模块中的组合器来允许使用 Optionals 转换数据的功能管道。
    // let CustomerShippingZone (calculator: IShippingCalculator, customer: Customer) =