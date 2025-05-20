using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[GeneratedCode("xsd", "4.0.30319.33440")]
[XmlType(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[XmlRoot("PhysicalAttribute", IsNullable = false, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[DesignerCategory("code")]
[DebuggerStepThrough]
[Serializable]
public class PhysicalAttributeType
{
    private AttributeIDType attributeIDField;
    private PositionCodeType positionCodeField;
    private DescriptionCodeType descriptionCodeField;
    private DescriptionType[] descriptionField;

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public AttributeIDType AttributeID
    {
        get
        {
            return this.attributeIDField;
        }
        set
        {
            this.attributeIDField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public PositionCodeType PositionCode
    {
        get
        {
            return this.positionCodeField;
        }
        set
        {
            this.positionCodeField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public DescriptionCodeType DescriptionCode
    {
        get
        {
            return this.descriptionCodeField;
        }
        set
        {
            this.descriptionCodeField = value;
        }
    }

    [XmlElement("Description", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public DescriptionType[] Description
    {
        get
        {
            return this.descriptionField;
        }
        set
        {
            this.descriptionField = value;
        }
    }
}
