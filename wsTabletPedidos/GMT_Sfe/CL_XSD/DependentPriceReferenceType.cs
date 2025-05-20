using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[GeneratedCode("xsd", "4.0.30319.33440")]
[XmlType(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[DesignerCategory("code")]
[XmlRoot("DependentPriceReference", IsNullable = false, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[DebuggerStepThrough]
[Serializable]
public class DependentPriceReferenceType
{
    private PercentType1 percentField;
    private AddressType locationAddressField;
    private LineReferenceType dependentLineReferenceField;

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public PercentType1 Percent
    {
        get
        {
            return this.percentField;
        }
        set
        {
            this.percentField = value;
        }
    }

    public AddressType LocationAddress
    {
        get
        {
            return this.locationAddressField;
        }
        set
        {
            this.locationAddressField = value;
        }
    }

    public LineReferenceType DependentLineReference
    {
        get
        {
            return this.dependentLineReferenceField;
        }
        set
        {
            this.dependentLineReferenceField = value;
        }
    }
}
