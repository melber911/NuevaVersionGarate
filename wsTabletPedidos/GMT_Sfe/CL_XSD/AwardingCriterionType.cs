using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[GeneratedCode("xsd", "4.0.30319.33440")]
[XmlRoot("AwardingCriterion", IsNullable = false, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[XmlType(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[DebuggerStepThrough]
[DesignerCategory("code")]
[Serializable]
public class AwardingCriterionType
{
    private IDType idField;
    private AwardingCriterionTypeCodeType awardingCriterionTypeCodeField;
    private DescriptionType[] descriptionField;
    private WeightNumericType weightNumericField;
    private WeightType[] weightField;
    private CalculationExpressionType[] calculationExpressionField;
    private CalculationExpressionCodeType calculationExpressionCodeField;
    private MinimumQuantityType minimumQuantityField;
    private MaximumQuantityType maximumQuantityField;
    private MinimumAmountType minimumAmountField;
    private MaximumAmountType maximumAmountField;
    private MinimumImprovementBidType[] minimumImprovementBidField;
    private AwardingCriterionType[] subordinateAwardingCriterionField;

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public IDType ID
    {
        get
        {
            return this.idField;
        }
        set
        {
            this.idField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public AwardingCriterionTypeCodeType AwardingCriterionTypeCode
    {
        get
        {
            return this.awardingCriterionTypeCodeField;
        }
        set
        {
            this.awardingCriterionTypeCodeField = value;
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
    public WeightNumericType WeightNumeric
    {
        get
        {
            return this.weightNumericField;
        }
        set
        {
            this.weightNumericField = value;
        }
    }

    [XmlElement("Weight", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public WeightType[] Weight
    {
        get
        {
            return this.weightField;
        }
        set
        {
            this.weightField = value;
        }
    }

    [XmlElement("CalculationExpression", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public CalculationExpressionType[] CalculationExpression
    {
        get
        {
            return this.calculationExpressionField;
        }
        set
        {
            this.calculationExpressionField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public CalculationExpressionCodeType CalculationExpressionCode
    {
        get
        {
            return this.calculationExpressionCodeField;
        }
        set
        {
            this.calculationExpressionCodeField = value;
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
    public MinimumAmountType MinimumAmount
    {
        get
        {
            return this.minimumAmountField;
        }
        set
        {
            this.minimumAmountField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public MaximumAmountType MaximumAmount
    {
        get
        {
            return this.maximumAmountField;
        }
        set
        {
            this.maximumAmountField = value;
        }
    }

    [XmlElement("MinimumImprovementBid", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public MinimumImprovementBidType[] MinimumImprovementBid
    {
        get
        {
            return this.minimumImprovementBidField;
        }
        set
        {
            this.minimumImprovementBidField = value;
        }
    }

    [XmlElement("SubordinateAwardingCriterion")]
    public AwardingCriterionType[] SubordinateAwardingCriterion
    {
        get
        {
            return this.subordinateAwardingCriterionField;
        }
        set
        {
            this.subordinateAwardingCriterionField = value;
        }
    }
}
