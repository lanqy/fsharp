// 然后，您可以对这些值执行类型安全算术。
// 
// 要了解更多信息，请参阅：https://docs.microsoft.com/dotnet/fsharp/language-reference/units-of-measure
module UnitsOfMeasure = 

    // 首先，打开一组常用的单位名称
    open Microsoft.FSharp.Data.UnitSystems.SI.UnitNames

    // 定义一个单位常数
    let sampleValue1 = 1600.0<meter>

    // 接下来，定义新的单元类型
    [<Measure>]
    type mile = 
        // 换算系数英里到米。
        static member asMeter = 1609.34<meter/mile>
    
    // 定义一个单位常数
    let sampleValue2 = 500.0<mile>

    // 计算度量系统常量
    let sampleValue3 = sampleValue2 * mile.asMeter
