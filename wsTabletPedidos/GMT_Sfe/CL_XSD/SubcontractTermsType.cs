using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[XmlRoot("AllowedSubcontractTerms", IsNullable = false, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[GeneratedCode("xsd", "4.0.30319.33440")]
[DebuggerStepThrough]
[DesignerCategory("code")]
[XmlType(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[Serializable]
public class SubcontractTermsType
{
    private RateType1 rateField;
    private UnknownPriceIndicatorType unknownPriceIndicatorField;
    private DescriptionType[] descriptionField;
    private AmountType2 amountField;
    private SubcontractingConditionsCodeType subcontractingConditionsCodeField;
    private MaximumPercentType maximumPercentField;
    private MinimumPercentType minimumPercentField;

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public RateType1 Rate
    {
        get
        {
            return this.rateField;
        }
        set
        {
            this.rateField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public UnknownPriceIndicatorType UnknownPriceIndicator
    {
        get
        {
            return this.unknownPriceIndicatorField;
        }
        set
        {
            this.unknownPriceIndicatorField = value;
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
    public AmountType2 Amount
    {
        get
        {
            return this.amountField;
        }
        set
        {
            this.amountField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public SubcontractingConditionsCodeType SubcontractingConditionsCode
    {
        get
        {
            return this.subcontractingConditionsCodeField;
        }
        set
        {
            this.subcontractingConditionsCodeField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public MaximumPercentType MaximumPercent
    {
        get
        {
            return this.maximumPercentField;
        }
        set
        {
            this.maximumPercentField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public MinimumPercentType MinimumPercent
    {
        get
        {
            return this.minimumPercentField;
        }
        set
        {
            this.minimumPercentField = value;
        }
    }
}
