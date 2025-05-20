using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[XmlRoot("PricingReference", IsNullable = false, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[DebuggerStepThrough]
[XmlType(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[GeneratedCode("xsd", "4.0.30319.33440")]
[DesignerCategory("code")]
[Serializable]
public class PricingReferenceType
{
    private ItemLocationQuantityType originalItemLocationQuantityField;
    private PriceType[] alternativeConditionPriceField;

    public ItemLocationQuantityType OriginalItemLocationQuantity
    {
        get
        {
            return this.originalItemLocationQuantityField;
        }
        set
        {
            this.originalItemLocationQuantityField = value;
        }
    }

    [XmlElement("AlternativeConditionPrice")]
    public PriceType[] AlternativeConditionPrice
    {
        get
        {
            return this.alternativeConditionPriceField;
        }
        set
        {
            this.alternativeConditionPriceField = value;
        }
    }
}
