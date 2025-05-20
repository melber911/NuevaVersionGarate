
// Type: UnstructuredPriceType




using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[GeneratedCode("xsd", "4.0.30319.33440")]
[XmlType(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[DebuggerStepThrough]
[DesignerCategory("code")]
[XmlRoot("UnstructuredPrice", IsNullable = false, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[Serializable]
public class UnstructuredPriceType
{
    private PriceAmountType priceAmountField;
    private TimeAmountType timeAmountField;

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public PriceAmountType PriceAmount
    {
        get
        {
            return this.priceAmountField;
        }
        set
        {
            this.priceAmountField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public TimeAmountType TimeAmount
    {
        get
        {
            return this.timeAmountField;
        }
        set
        {
            this.timeAmountField = value;
        }
    }
}
