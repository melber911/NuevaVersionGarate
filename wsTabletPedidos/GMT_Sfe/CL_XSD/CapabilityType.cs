using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[DesignerCategory("code")]
[GeneratedCode("xsd", "4.0.30319.33440")]
[DebuggerStepThrough]
[XmlType(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[XmlRoot("Capability", IsNullable = false, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[Serializable]
public class CapabilityType
{
    private CapabilityTypeCodeType capabilityTypeCodeField;
    private DescriptionType[] descriptionField;
    private ValueAmountType valueAmountField;
    private ValueQuantityType valueQuantityField;
    private EvidenceSuppliedType[] evidenceSuppliedField;
    private PeriodType validityPeriodField;

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public CapabilityTypeCodeType CapabilityTypeCode
    {
        get
        {
            return this.capabilityTypeCodeField;
        }
        set
        {
            this.capabilityTypeCodeField = value;
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
    public ValueAmountType ValueAmount
    {
        get
        {
            return this.valueAmountField;
        }
        set
        {
            this.valueAmountField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public ValueQuantityType ValueQuantity
    {
        get
        {
            return this.valueQuantityField;
        }
        set
        {
            this.valueQuantityField = value;
        }
    }

    [XmlElement("EvidenceSupplied")]
    public EvidenceSuppliedType[] EvidenceSupplied
    {
        get
        {
            return this.evidenceSuppliedField;
        }
        set
        {
            this.evidenceSuppliedField = value;
        }
    }

    public PeriodType ValidityPeriod
    {
        get
        {
            return this.validityPeriodField;
        }
        set
        {
            this.validityPeriodField = value;
        }
    }
}