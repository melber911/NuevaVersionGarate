using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[XmlType(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[DesignerCategory("code")]
[GeneratedCode("xsd", "4.0.30319.33440")]
[DebuggerStepThrough]
[XmlRoot("FrameworkAgreement", IsNullable = false, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[Serializable]
public class FrameworkAgreementType
{
    private ExpectedOperatorQuantityType expectedOperatorQuantityField;
    private MaximumOperatorQuantityType maximumOperatorQuantityField;
    private JustificationType[] justificationField;
    private FrequencyType[] frequencyField;
    private PeriodType durationPeriodField;
    private TenderRequirementType[] subsequentProcessTenderRequirementField;

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public ExpectedOperatorQuantityType ExpectedOperatorQuantity
    {
        get
        {
            return this.expectedOperatorQuantityField;
        }
        set
        {
            this.expectedOperatorQuantityField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public MaximumOperatorQuantityType MaximumOperatorQuantity
    {
        get
        {
            return this.maximumOperatorQuantityField;
        }
        set
        {
            this.maximumOperatorQuantityField = value;
        }
    }

    [XmlElement("Justification", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public JustificationType[] Justification
    {
        get
        {
            return this.justificationField;
        }
        set
        {
            this.justificationField = value;
        }
    }

    [XmlElement("Frequency", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public FrequencyType[] Frequency
    {
        get
        {
            return this.frequencyField;
        }
        set
        {
            this.frequencyField = value;
        }
    }

    public PeriodType DurationPeriod
    {
        get
        {
            return this.durationPeriodField;
        }
        set
        {
            this.durationPeriodField = value;
        }
    }

    [XmlElement("SubsequentProcessTenderRequirement")]
    public TenderRequirementType[] SubsequentProcessTenderRequirement
    {
        get
        {
            return this.subsequentProcessTenderRequirementField;
        }
        set
        {
            this.subsequentProcessTenderRequirementField = value;
        }
    }
}
