using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[DebuggerStepThrough]
[XmlRoot("EconomicOperatorShortList", IsNullable = false, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[GeneratedCode("xsd", "4.0.30319.33440")]
[XmlType(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[DesignerCategory("code")]
[Serializable]
public class EconomicOperatorShortListType
{
    private LimitationDescriptionType[] limitationDescriptionField;
    private ExpectedQuantityType expectedQuantityField;
    private MaximumQuantityType maximumQuantityField;
    private MinimumQuantityType minimumQuantityField;
    private PartyType[] preSelectedPartyField;

    [XmlElement("LimitationDescription", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public LimitationDescriptionType[] LimitationDescription
    {
        get
        {
            return this.limitationDescriptionField;
        }
        set
        {
            this.limitationDescriptionField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public ExpectedQuantityType ExpectedQuantity
    {
        get
        {
            return this.expectedQuantityField;
        }
        set
        {
            this.expectedQuantityField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public MaximumQuantityType MaximumQuantity
    {
        get
        {
            return this.maximumQuantityField;
        }
        set
        {
            this.maximumQuantityField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public MinimumQuantityType MinimumQuantity
    {
        get
        {
            return this.minimumQuantityField;
        }
        set
        {
            this.minimumQuantityField = value;
        }
    }

    [XmlElement("PreSelectedParty")]
    public PartyType[] PreSelectedParty
    {
        get
        {
            return this.preSelectedPartyField;
        }
        set
        {
            this.preSelectedPartyField = value;
        }
    }
}
