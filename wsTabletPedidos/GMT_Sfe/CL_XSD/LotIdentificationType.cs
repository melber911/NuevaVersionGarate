using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[XmlRoot("LotIdentification", IsNullable = false, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[GeneratedCode("xsd", "4.0.30319.33440")]
[DebuggerStepThrough]
[DesignerCategory("code")]
[XmlType(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[Serializable]
public class LotIdentificationType
{
    private LotNumberIDType lotNumberIDField;
    private ExpiryDateType expiryDateField;
    private ItemPropertyType[] additionalItemPropertyField;

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public LotNumberIDType LotNumberID
    {
        get
        {
            return this.lotNumberIDField;
        }
        set
        {
            this.lotNumberIDField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public ExpiryDateType ExpiryDate
    {
        get
        {
            return this.expiryDateField;
        }
        set
        {
            this.expiryDateField = value;
        }
    }

    [XmlElement("AdditionalItemProperty")]
    public ItemPropertyType[] AdditionalItemProperty
    {
        get
        {
            return this.additionalItemPropertyField;
        }
        set
        {
            this.additionalItemPropertyField = value;
        }
    }
}
