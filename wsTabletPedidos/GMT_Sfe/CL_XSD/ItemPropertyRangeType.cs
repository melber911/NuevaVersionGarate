using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[XmlRoot("ItemPropertyRange", IsNullable = false, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[GeneratedCode("xsd", "4.0.30319.33440")]
[DebuggerStepThrough]
[DesignerCategory("code")]
[XmlType(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[Serializable]
public class ItemPropertyRangeType
{
    private MinimumValueType minimumValueField;
    private MaximumValueType maximumValueField;

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public MinimumValueType MinimumValue
    {
        get
        {
            return this.minimumValueField;
        }
        set
        {
            this.minimumValueField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public MaximumValueType MaximumValue
    {
        get
        {
            return this.maximumValueField;
        }
        set
        {
            this.maximumValueField = value;
        }
    }
}
