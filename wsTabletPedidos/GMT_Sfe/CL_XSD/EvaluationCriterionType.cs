using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[GeneratedCode("xsd", "4.0.30319.33440")]
[DesignerCategory("code")]
[XmlType(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[XmlRoot("EvaluationCriterion", IsNullable = false, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[DebuggerStepThrough]
[Serializable]
public class EvaluationCriterionType
{
    private EvaluationCriterionTypeCodeType evaluationCriterionTypeCodeField;
    private DescriptionType[] descriptionField;
    private ThresholdAmountType thresholdAmountField;
    private ThresholdQuantityType thresholdQuantityField;
    private ExpressionCodeType expressionCodeField;
    private ExpressionType[] expressionField;
    private PeriodType durationPeriodField;
    private EvidenceType[] suggestedEvidenceField;

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public EvaluationCriterionTypeCodeType EvaluationCriterionTypeCode
    {
        get
        {
            return this.evaluationCriterionTypeCodeField;
        }
        set
        {
            this.evaluationCriterionTypeCodeField = value;
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
    public ThresholdAmountType ThresholdAmount
    {
        get
        {
            return this.thresholdAmountField;
        }
        set
        {
            this.thresholdAmountField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public ThresholdQuantityType ThresholdQuantity
    {
        get
        {
            return this.thresholdQuantityField;
        }
        set
        {
            this.thresholdQuantityField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public ExpressionCodeType ExpressionCode
    {
        get
        {
            return this.expressionCodeField;
        }
        set
        {
            this.expressionCodeField = value;
        }
    }

    [XmlElement("Expression", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public ExpressionType[] Expression
    {
        get
        {
            return this.expressionField;
        }
        set
        {
            this.expressionField = value;
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

    [XmlElement("SuggestedEvidence")]
    public EvidenceType[] SuggestedEvidence
    {
        get
        {
            return this.suggestedEvidenceField;
        }
        set
        {
            this.suggestedEvidenceField = value;
        }
    }
}
