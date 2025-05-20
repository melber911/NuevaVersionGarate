using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[XmlRoot("StatementLine", IsNullable = false, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[GeneratedCode("xsd", "4.0.30319.33440")]
[DesignerCategory("code")]
[DebuggerStepThrough]
[XmlType(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[Serializable]
public class StatementLineType
{
    private IDType idField;
    private NoteType[] noteField;
    private UUIDType uUIDField;
    private BalanceBroughtForwardIndicatorType balanceBroughtForwardIndicatorField;
    private DebitLineAmountType debitLineAmountField;
    private CreditLineAmountType creditLineAmountField;
    private BalanceAmountType balanceAmountField;
    private PaymentPurposeCodeType paymentPurposeCodeField;
    private PaymentMeansType paymentMeansField;
    private PaymentTermsType[] paymentTermsField;
    private CustomerPartyType buyerCustomerPartyField;
    private SupplierPartyType sellerSupplierPartyField;
    private CustomerPartyType originatorCustomerPartyField;
    private CustomerPartyType accountingCustomerPartyField;
    private SupplierPartyType accountingSupplierPartyField;
    private PartyType payeePartyField;
    private PeriodType[] periodField;
    private BillingReferenceType[] billingReferenceField;
    private DocumentReferenceType[] documentReferenceField;
    private ExchangeRateType exchangeRateField;
    private AllowanceChargeType[] allowanceChargeField;
    private PaymentType[] collectedPaymentField;

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
    public UUIDType UUID
    {
        get
        {
            return this.uUIDField;
        }
        set
        {
            this.uUIDField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public BalanceBroughtForwardIndicatorType BalanceBroughtForwardIndicator
    {
        get
        {
            return this.balanceBroughtForwardIndicatorField;
        }
        set
        {
            this.balanceBroughtForwardIndicatorField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public DebitLineAmountType DebitLineAmount
    {
        get
        {
            return this.debitLineAmountField;
        }
        set
        {
            this.debitLineAmountField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public CreditLineAmountType CreditLineAmount
    {
        get
        {
            return this.creditLineAmountField;
        }
        set
        {
            this.creditLineAmountField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public BalanceAmountType BalanceAmount
    {
        get
        {
            return this.balanceAmountField;
        }
        set
        {
            this.balanceAmountField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public PaymentPurposeCodeType PaymentPurposeCode
    {
        get
        {
            return this.paymentPurposeCodeField;
        }
        set
        {
            this.paymentPurposeCodeField = value;
        }
    }

    public PaymentMeansType PaymentMeans
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

    [XmlElement("PaymentTerms")]
    public PaymentTermsType[] PaymentTerms
    {
        get
        {
            return this.paymentTermsField;
        }
        set
        {
            this.paymentTermsField = value;
        }
    }

    public CustomerPartyType BuyerCustomerParty
    {
        get
        {
            return this.buyerCustomerPartyField;
        }
        set
        {
            this.buyerCustomerPartyField = value;
        }
    }

    public SupplierPartyType SellerSupplierParty
    {
        get
        {
            return this.sellerSupplierPartyField;
        }
        set
        {
            this.sellerSupplierPartyField = value;
        }
    }

    public CustomerPartyType OriginatorCustomerParty
    {
        get
        {
            return this.originatorCustomerPartyField;
        }
        set
        {
            this.originatorCustomerPartyField = value;
        }
    }

    public CustomerPartyType AccountingCustomerParty
    {
        get
        {
            return this.accountingCustomerPartyField;
        }
        set
        {
            this.accountingCustomerPartyField = value;
        }
    }

    public SupplierPartyType AccountingSupplierParty
    {
        get
        {
            return this.accountingSupplierPartyField;
        }
        set
        {
            this.accountingSupplierPartyField = value;
        }
    }

    public PartyType PayeeParty
    {
        get
        {
            return this.payeePartyField;
        }
        set
        {
            this.payeePartyField = value;
        }
    }

    [XmlElement("InvoicePeriod")]
    public PeriodType[] InvoicePeriod
    {
        get
        {
            return this.periodField;
        }
        set
        {
            this.periodField = value;
        }
    }

    [XmlElement("BillingReference")]
    public BillingReferenceType[] BillingReference
    {
        get
        {
            return this.billingReferenceField;
        }
        set
        {
            this.billingReferenceField = value;
        }
    }

    [XmlElement("DocumentReference")]
    public DocumentReferenceType[] DocumentReference
    {
        get
        {
            return this.documentReferenceField;
        }
        set
        {
            this.documentReferenceField = value;
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

    [XmlElement("AllowanceCharge")]
    public AllowanceChargeType[] AllowanceCharge
    {
        get
        {
            return this.allowanceChargeField;
        }
        set
        {
            this.allowanceChargeField = value;
        }
    }

    [XmlElement("CollectedPayment")]
    public PaymentType[] CollectedPayment
    {
        get
        {
            return this.collectedPaymentField;
        }
        set
        {
            this.collectedPaymentField = value;
        }
    }
}
