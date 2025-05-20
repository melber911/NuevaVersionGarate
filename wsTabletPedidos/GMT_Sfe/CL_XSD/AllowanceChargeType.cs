using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[GeneratedCode("xsd", "4.0.30319.33440")]
[DebuggerStepThrough]
[DesignerCategory("code")]
[XmlType(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[XmlRoot("AllowanceCharge", IsNullable = false, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[Serializable]
public class AllowanceChargeType
{
    private IDType idField;
    private ChargeIndicatorType chargeIndicatorField;
    private AllowanceChargeReasonCodeType allowanceChargeReasonCodeField;
    private AllowanceChargeReasonType[] allowanceChargeReasonField;
    private MultiplierFactorNumericType multiplierFactorNumericField;
    private PrepaidIndicatorType prepaidIndicatorField;
    private SequenceNumericType sequenceNumericField;
    private AmountType2 amountField;
    private BaseAmountType baseAmountField;
    private AccountingCostCodeType accountingCostCodeField;
    private AccountingCostType accountingCostField;
    private PerUnitAmountType perUnitAmountField;
    private TaxCategoryType[] taxCategoryField;
    private TaxTotalType taxTotalField;
    private PaymentMeansType[] paymentMeansField;

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
    public ChargeIndicatorType ChargeIndicator
    {
        get
        {
            return this.chargeIndicatorField;
        }
        set
        {
            this.chargeIndicatorField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public AllowanceChargeReasonCodeType AllowanceChargeReasonCode
    {
        get
        {
            return this.allowanceChargeReasonCodeField;
        }
        set
        {
            this.allowanceChargeReasonCodeField = value;
        }
    }

    [XmlElement("AllowanceChargeReason", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public AllowanceChargeReasonType[] AllowanceChargeReason
    {
        get
        {
            return this.allowanceChargeReasonField;
        }
        set
        {
            this.allowanceChargeReasonField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public MultiplierFactorNumericType MultiplierFactorNumeric
    {
        get
        {
            return this.multiplierFactorNumericField;
        }
        set
        {
            this.multiplierFactorNumericField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public PrepaidIndicatorType PrepaidIndicator
    {
        get
        {
            return this.prepaidIndicatorField;
        }
        set
        {
            this.prepaidIndicatorField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public SequenceNumericType SequenceNumeric
    {
        get
        {
            return this.sequenceNumericField;
        }
        set
        {
            this.sequenceNumericField = value;
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
    public BaseAmountType BaseAmount
    {
        get
        {
            return this.baseAmountField;
        }
        set
        {
            this.baseAmountField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public AccountingCostCodeType AccountingCostCode
    {
        get
        {
            return this.accountingCostCodeField;
        }
        set
        {
            this.accountingCostCodeField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public AccountingCostType AccountingCost
    {
        get
        {
            return this.accountingCostField;
        }
        set
        {
            this.accountingCostField = value;
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

    [XmlElement("TaxCategory")]
    public TaxCategoryType[] TaxCategory
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

    public TaxTotalType TaxTotal
    {
        get
        {
            return this.taxTotalField;
        }
        set
        {
            this.taxTotalField = value;
        }
    }

    [XmlElement("PaymentMeans")]
    public PaymentMeansType[] PaymentMeans
    {
        get
        {
            return this.paymentMeansField;
        }
        set
        {
            this.paymentMeansField = value;
        }
    }
}
