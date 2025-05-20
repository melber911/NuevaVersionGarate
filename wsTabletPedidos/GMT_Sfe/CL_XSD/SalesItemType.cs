using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[XmlRoot("SalesItem", IsNullable = false, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[XmlType(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[GeneratedCode("xsd", "4.0.30319.33440")]
[DebuggerStepThrough]
[DesignerCategory("code")]
[Serializable]
public class SalesItemType
{
    private QuantityType2 quantityField;
    private ActivityPropertyType[] activityPropertyField;
    private PriceType[] taxExclusivePriceField;
    private PriceType[] taxInclusivePriceField;
    private ItemType itemField;

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public QuantityType2 Quantity
    {
        get
        {
            return this.quantityField;
        }
        set
        {
            this.quantityField = value;
        }
    }

    [XmlElement("ActivityProperty")]
    public ActivityPropertyType[] ActivityProperty
    {
        get
        {
            return this.activityPropertyField;
        }
        set
        {
            this.activityPropertyField = value;
        }
    }

    [XmlElement("TaxExclusivePrice")]
    public PriceType[] TaxExclusivePrice
    {
        get
        {
            return this.taxExclusivePriceField;
        }
        set
        {
            this.taxExclusivePriceField = value;
        }
    }

    [XmlElement("TaxInclusivePrice")]
    public PriceType[] TaxInclusivePrice
    {
        get
        {
            return this.taxInclusivePriceField;
        }
        set
        {
            this.taxInclusivePriceField = value;
        }
    }

    public ItemType Item
    {
        get
        {
            return this.itemField;
        }
        set
        {
            this.itemField = value;
        }
    }
}
