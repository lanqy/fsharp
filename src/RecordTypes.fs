module RecordTypes = 
    // 此示例显示如何定义新记录类型。
    type ContactCard = 
        {
            Name: string
            Phone: string
            Verified: bool
        }
       
    // 此示例显示如何实例化记录类型。
    let contact1 =
        {
            Name = "Alf"
            Phone = "(206) 555-0157"
            Verified = false
        }
    
    // 您也可以使用';'在同一行上执行此操作分隔符。
    let contactOnSameLine = { Name = "Alf"; Phone = "(201) 555-0157"; Verified = false }

    // 此示例显示如何对记录值使用“复制和更新”。 它创建一个新记录值，它是contact1的副本，但对“Phone”和“Verified”字段具有不同的值。
    // 要了解更多信息，请参阅：https：//docs.microsoft.com/dotnet/fsharp/language-reference/copy-and-update-record-expressions

    let contact2 = 
        {
            contact1 with
                Phone = "(206) 555-0112"
                Verified = true
        }

    // 此示例显示如何编写处理记录值的函数。
    // 它将 'ContactCard' 对象转换为字符串。

    let showContactCard (c: ContactCard) = 
        c.Name + " Phone: " + c.Phone + (if not c.Verified then " (unverified)" else "")
    
    printfn "Alf's Contact Card: %s" (showContactCard contact1)

    // 这是带有成员的记录示例
    type ContactCardAlternate = 
        {
            Name: string
            Phone: string
            Address: string
            Verified:bool
        }

        // 成员可以实现面向对象的成员。
        member this.PrintedContactCard = 
            this.Name + " Phone: " + this.Phone + (if not this.Verified then " (unverified) " else "") + this.Address

    let contactAlternate = 
        {
            Name =  "Alf"
            Phone = "(206) 555-0157"
            Verified = false
            Address = "111 Alf Street"
        }
    
    // 成员可通过 '.' 访问。实例化类型的运算符

    printfn "Alf's alternate contact card is %s" contactAlternate.PrintedContactCard


    // 记录也可以通过'Struct'属性表示为结构。
    // 这在结构的性能超过引用类型的灵活性的情况下很有用。
    [<Struct>]
    type ContactCardStruct = 
        { Name: string
          Phone: string
          Verified: bool
        }