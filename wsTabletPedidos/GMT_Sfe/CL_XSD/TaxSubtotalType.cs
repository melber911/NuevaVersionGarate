﻿using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[DesignerCategory("code")]
[XmlType(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[XmlRoot("TaxSubtotal", IsNullable = false, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[GeneratedCode("xsd", "4.0.30319.33440")]
[DebuggerStepThrough]
[Serializable]
public class TaxSubtotalType
{
    private TaxableAmountType taxableAmountField;
    private TaxAmountType taxAmountField;
    private CalculationSequenceNumericType calculationSequenceNumericField;
    private TransactionCurrencyTaxAmountType transactionCurrencyTaxAmountField;
    private PercentType1 percentField;
    private BaseUnitMeasureType baseUnitMeasureField;
    private PerUnitAmountType perUnitAmountField;
    private TierRangeType tierRangeField;
    private TierRatePercentType tierRatePercentField;
    private TaxCategoryType taxCategoryField;

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public TaxableAmountType TaxableAmount
    {
        get
        {
            return this.taxableAmountField;
        }
        set
        {
            this.taxableAmountField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public TaxAmountType TaxAmount
    {
        get
        {
            return this.taxAmountField;
        }
        set
        {
            this.taxAmountField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public CalculationSequenceNumericType CalculationSequenceNumeric
    {
        get
        {
            return this.calculationSequenceNumericField;
        }
        set
        {
            this.calculationSequenceNumericField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public TransactionCurrencyTaxAmountType TransactionCurrencyTaxAmount
    {
        get
        {
            return this.transactionCurrencyTaxAmountField;
        }
        set
        {
            this.transactionCurrencyTaxAmountField = value;
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

    public TaxCategoryType TaxCategory
    {
        get
        {
            return this.taxCategoryField;
        }
        set
        {
            this.taxCategoryField = value;
        }
    }
}
