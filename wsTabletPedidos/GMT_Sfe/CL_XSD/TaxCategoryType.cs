using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[GeneratedCode("xsd", "4.0.30319.33440")]
[DebuggerStepThrough]
[XmlType(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[XmlRoot("ApplicableTaxCategory", IsNullable = false, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[DesignerCategory("code")]
[Serializable]
public class TaxCategoryType
{
    private IDType idField;
    private NameType1 nameField;
    private PercentType1 percentField;
    private BaseUnitMeasureType baseUnitMeasureField;
    private PerUnitAmountType perUnitAmountField;
    private TaxExemptionReasonCodeType taxExemptionReasonCodeField;
    private TaxExemptionReasonType[] taxExemptionReasonField;
    private TierRangeType tierRangeField;
    private TierRatePercentType tierRatePercentField;
    private TaxSchemeType taxSchemeField;

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
    public NameType1 Name
    {
        get
        {
            return this.nameField;
        }
        set
        {
            this.nameField = value;
        }
    }

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

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public BaseUnitMeasureType BaseUnitMeasure
    {
        get
        {
            return this.baseUnitMeasureField;
        }
        set
        {
            this.baseUnitMeasureField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public PerUnitAmountType PerUnitAmount
    {
        get
        {
            return this.perUnitAmountField;
        }
        set
        {
            this.perUnitAmountField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public TaxExemptionReasonCodeType TaxExemptionReasonCode
    {
        get
        {
            return this.taxExemptionReasonCodeField;
        }
        set
        {
            this.taxExemptionReasonCodeField = value;
        }
    }

    [XmlElement("TaxExemptionReason", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public TaxExemptionReasonType[] TaxExemptionReason
    {
        get
        {
            return this.taxExemptionReasonField;
        }
        set
        {
            this.taxExemptionReasonField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public TierRangeType TierRange
    {
        get
        {
            return this.tierRangeField;
        }
        set
        {
            this.tierRangeField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public TierRatePercentType TierRatePercent
    {
        get
        {
            return this.tierRatePercentField;
        }
        set
        {
            this.tierRatePercentField = value;
        }
    }

    public TaxSchemeType TaxScheme
    {
        get
        {
            return this.taxSchemeField;
        }
        set
        {
            this.taxSchemeField = value;
        }
    }
}
