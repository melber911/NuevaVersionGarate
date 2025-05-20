using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[XmlRoot("AdditionalCommodityClassification", IsNullable = false, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[GeneratedCode("xsd", "4.0.30319.33440")]
[DebuggerStepThrough]
[DesignerCategory("code")]
[XmlType(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[Serializable]
public class CommodityClassificationType
{
    private NatureCodeType natureCodeField;
    private CargoTypeCodeType cargoTypeCodeField;
    private CommodityCodeType commodityCodeField;
    private ItemClassificationCodeType itemClassificationCodeField;

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public NatureCodeType NatureCode
    {
        get
        {
            return this.natureCodeField;
        }
        set
        {
            this.natureCodeField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public CargoTypeCodeType CargoTypeCode
    {
        get
        {
            return this.cargoTypeCodeField;
        }
        set
        {
            this.cargoTypeCodeField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public CommodityCodeType CommodityCode
    {
        get
        {
            return this.commodityCodeField;
        }
        set
        {
            this.commodityCodeField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public ItemClassificationCodeType ItemClassificationCode
    {
        get
        {
            return this.itemClassificationCodeField;
        }
        set
        {
            this.itemClassificationCodeField = value;
        }
    }
}
