using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[DesignerCategory("code")]
[XmlRoot("Condition", IsNullable = false, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[DebuggerStepThrough]
[GeneratedCode("xsd", "4.0.30319.33440")]
[XmlType(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2", TypeName = "ConditionType")]
[Serializable]
public class ConditionType1
{
    private AttributeIDType attributeIDField;
    private MeasureType2 measureField;
    private DescriptionType[] descriptionField;
    private MinimumMeasureType minimumMeasureField;
    private MaximumMeasureType maximumMeasureField;

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
    public MeasureType2 Measure
    {
        get
        {
            return this.measureField;
        }
        set
        {
            this.measureField = value;
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

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public MinimumMeasureType MinimumMeasure
    {
        get
        {
            return this.minimumMeasureField;
        }
        set
        {
            this.minimumMeasureField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public MaximumMeasureType MaximumMeasure
    {
        get
        {
            return this.maximumMeasureField;
        }
        set
        {
            this.maximumMeasureField = value;
        }
    }
}
