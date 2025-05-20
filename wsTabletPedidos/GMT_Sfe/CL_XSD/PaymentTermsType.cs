using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[XmlType(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[XmlRoot("BonusPaymentTerms", IsNullable = false, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[GeneratedCode("xsd", "4.0.30319.33440")]
[DebuggerStepThrough]
[DesignerCategory("code")]
[Serializable]
public class PaymentTermsType
{
    private IDType idField;
    private PaymentMeansIDType paymentMeansIDField;
    private PrepaidPaymentReferenceIDType prepaidPaymentReferenceIDField;
    private NoteType[] noteField;
    private ReferenceEventCodeType referenceEventCodeField;
    private SettlementDiscountPercentType settlementDiscountPercentField;
    private PenaltySurchargePercentType penaltySurchargePercentField;
    private PaymentPercentType paymentPercentField;
    private AmountType2 amountField;
    private SettlementDiscountAmountType settlementDiscountAmountField;
    private PenaltyAmountType penaltyAmountField;
    private PaymentTermsDetailsURIType paymentTermsDetailsURIField;
    private PaymentDueDateType paymentDueDateField;
    private InstallmentDueDateType installmentDueDateField;
    private InvoicingPartyReferenceType invoicingPartyReferenceField;
    private PeriodType settlementPeriodField;
    private PeriodType penaltyPeriodField;
    private ExchangeRateType exchangeRateField;
    private PeriodType validityPeriodField;

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

    [XmlElement("PaymentMeansID", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public PaymentMeansIDType PaymentMeansID
    {
        get
        {
            return this.paymentMeansIDField;
        }
        set
        {
            this.paymentMeansIDField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public PrepaidPaymentReferenceIDType PrepaidPaymentReferenceID
    {
        get
        {
            return this.prepaidPaymentReferenceIDField;
        }
        set
        {
            this.prepaidPaymentReferenceIDField = value;
        }
    }

    [XmlElement("Note", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public NoteType[] Note
    {
        get
        {
            return this.noteField;
        }
        set
        {
            this.noteField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public ReferenceEventCodeType ReferenceEventCode
    {
        get
        {
            return this.referenceEventCodeField;
        }
        set
        {
            this.referenceEventCodeField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public SettlementDiscountPercentType SettlementDiscountPercent
    {
        get
        {
            return this.settlementDiscountPercentField;
        }
        set
        {
            this.settlementDiscountPercentField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public PenaltySurchargePercentType PenaltySurchargePercent
    {
        get
        {
            return this.penaltySurchargePercentField;
        }
        set
        {
            this.penaltySurchargePercentField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public PaymentPercentType PaymentPercent
    {
        get
        {
            return this.paymentPercentField;
        }
        set
        {
            this.paymentPercentField = value;
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
    public SettlementDiscountAmountType SettlementDiscountAmount
    {
        get
        {
            return this.settlementDiscountAmountField;
        }
        set
        {
            this.settlementDiscountAmountField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public PenaltyAmountType PenaltyAmount
    {
        get
        {
            return this.penaltyAmountField;
        }
        set
        {
            this.penaltyAmountField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public PaymentTermsDetailsURIType PaymentTermsDetailsURI
    {
        get
        {
            return this.paymentTermsDetailsURIField;
        }
        set
        {
            this.paymentTermsDetailsURIField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public PaymentDueDateType PaymentDueDate
    {
        get
        {
            return this.paymentDueDateField;
        }
        set
        {
            this.paymentDueDateField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public InstallmentDueDateType InstallmentDueDate
    {
        get
        {
            return this.installmentDueDateField;
        }
        set
        {
            this.installmentDueDateField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public InvoicingPartyReferenceType InvoicingPartyReference
    {
        get
        {
            return this.invoicingPartyReferenceField;
        }
        set
        {
            this.invoicingPartyReferenceField = value;
        }
    }

    public PeriodType SettlementPeriod
    {
        get
        {
            return this.settlementPeriodField;
        }
        set
        {
            this.settlementPeriodField = value;
        }
    }

    public PeriodType PenaltyPeriod
    {
        get
        {
            return this.penaltyPeriodField;
        }
        set
        {
            this.penaltyPeriodField = value;
        }
    }

    public ExchangeRateType ExchangeRate
    {
        get
        {
            return this.exchangeRateField;
        }
        set
        {
            this.exchangeRateField = value;
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
