using System.Xml.Serialization;

[XmlRoot("CreditNote", IsNullable = false, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CreditNote-2")]
[XmlType(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CreditNote-2")]
public class CreditNoteType
{
    private UBLExtensionType[] uBLExtensionsField;
    private UBLVersionIDType uBLVersionIDField;
    private CustomizationIDType customizationIDField;
    private ProfileIDType profileIDField;
    private ProfileExecutionIDType profileExecutionIDField;
    private IDType idField;
    private CopyIndicatorType copyIndicatorField;
    private UUIDType uUIDField;
    private IssueDateType issueDateField;
    private IssueTimeType issueTimeField;
    private TaxPointDateType taxPointDateField;
    private CreditNoteTypeCodeType creditNoteTypeCodeField;
    private NoteType[] noteField;
    private DocumentCurrencyCodeType documentCurrencyCodeField;
    private TaxCurrencyCodeType taxCurrencyCodeField;
    private PricingCurrencyCodeType pricingCurrencyCodeField;
    private PaymentCurrencyCodeType paymentCurrencyCodeField;
    private PaymentAlternativeCurrencyCodeType paymentAlternativeCurrencyCodeField;
    private AccountingCostCodeType accountingCostCodeField;
    private AccountingCostType accountingCostField;
    private LineCountNumericType lineCountNumericField;
    private BuyerReferenceType buyerReferenceField;
    private PeriodType[] periodField;
    private ResponseType[] discrepancyResponseField;
    private OrderReferenceType orderReferenceField;
    private BillingReferenceType[] billingReferenceField;
    private DocumentReferenceType[] despatchDocumentReferenceField;
    private DocumentReferenceType[] receiptDocumentReferenceField;
    private DocumentReferenceType[] contractDocumentReferenceField;
    private DocumentReferenceType[] additionalDocumentReferenceField;
    private DocumentReferenceType[] statementDocumentReferenceField;
    private DocumentReferenceType[] originatorDocumentReferenceField;
    private SignatureType[] signatureField;
    private SupplierPartyType accountingSupplierPartyField;
    private CustomerPartyType accountingCustomerPartyField;
    private PartyType payeePartyField;
    private CustomerPartyType buyerCustomerPartyField;
    private SupplierPartyType sellerSupplierPartyField;
    private PartyType taxRepresentativePartyField;
    private DeliveryType[] deliveryField;
    private DeliveryTermsType[] deliveryTermsField;
    private PaymentMeansType[] paymentMeansField;
    private PaymentTermsType[] paymentTermsField;
    private ExchangeRateType taxExchangeRateField;
    private ExchangeRateType pricingExchangeRateField;
    private ExchangeRateType paymentExchangeRateField;
    private ExchangeRateType paymentAlternativeExchangeRateField;
    private AllowanceChargeType[] allowanceChargeField;
    private TaxTotalType[] taxTotalField;
    private MonetaryTotalType legalMonetaryTotalField;
    private CreditNoteLineType[] creditNoteLineField;

    [XmlArrayItem("UBLExtension", IsNullable = false)]
    [XmlArray(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonExtensionComponents-2")]
    public UBLExtensionType[] UBLExtensions
    {
        get
        {
            return this.uBLExtensionsField;
        }
        set
        {
            this.uBLExtensionsField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public UBLVersionIDType UBLVersionID
    {
        get
        {
            return this.uBLVersionIDField;
        }
        set
        {
            this.uBLVersionIDField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public CustomizationIDType CustomizationID
    {
        get
        {
            return this.customizationIDField;
        }
        set
        {
            this.customizationIDField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public ProfileIDType ProfileID
    {
        get
        {
            return this.profileIDField;
        }
        set
        {
            this.profileIDField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public ProfileExecutionIDType ProfileExecutionID
    {
        get
        {
            return this.profileExecutionIDField;
        }
        set
        {
            this.profileExecutionIDField = value;
        }
    }

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
    public CopyIndicatorType CopyIndicator
    {
        get
        {
            return this.copyIndicatorField;
        }
        set
        {
            this.copyIndicatorField = value;
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
    public IssueDateType IssueDate
    {
        get
        {
            return this.issueDateField;
        }
        set
        {
            this.issueDateField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public IssueTimeType IssueTime
    {
        get
        {
            return this.issueTimeField;
        }
        set
        {
            this.issueTimeField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public TaxPointDateType TaxPointDate
    {
        get
        {
            return this.taxPointDateField;
        }
        set
        {
            this.taxPointDateField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public CreditNoteTypeCodeType CreditNoteTypeCode
    {
        get
        {
            return this.creditNoteTypeCodeField;
        }
        set
        {
            this.creditNoteTypeCodeField = value;
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
    public DocumentCurrencyCodeType DocumentCurrencyCode
    {
        get
        {
            return this.documentCurrencyCodeField;
        }
        set
        {
            this.documentCurrencyCodeField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public TaxCurrencyCodeType TaxCurrencyCode
    {
        get
        {
            return this.taxCurrencyCodeField;
        }
        set
        {
            this.taxCurrencyCodeField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public PricingCurrencyCodeType PricingCurrencyCode
    {
        get
        {
            return this.pricingCurrencyCodeField;
        }
        set
        {
            this.pricingCurrencyCodeField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public PaymentCurrencyCodeType PaymentCurrencyCode
    {
        get
        {
            return this.paymentCurrencyCodeField;
        }
        set
        {
            this.paymentCurrencyCodeField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public PaymentAlternativeCurrencyCodeType PaymentAlternativeCurrencyCode
    {
        get
        {
            return this.paymentAlternativeCurrencyCodeField;
        }
        set
        {
            this.paymentAlternativeCurrencyCodeField = value;
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
    public LineCountNumericType LineCountNumeric
    {
        get
        {
            return this.lineCountNumericField;
        }
        set
        {
            this.lineCountNumericField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public BuyerReferenceType BuyerReference
    {
        get
        {
            return this.buyerReferenceField;
        }
        set
        {
            this.buyerReferenceField = value;
        }
    }

    [XmlElement("InvoicePeriod", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
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

    [XmlElement("DiscrepancyResponse", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
    public ResponseType[] DiscrepancyResponse
    {
        get
        {
            return this.discrepancyResponseField;
        }
        set
        {
            this.discrepancyResponseField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
    public OrderReferenceType OrderReference
    {
        get
        {
            return this.orderReferenceField;
        }
        set
        {
            this.orderReferenceField = value;
        }
    }

    [XmlElement("BillingReference", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
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

    [XmlElement("DespatchDocumentReference", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
    public DocumentReferenceType[] DespatchDocumentReference
    {
        get
        {
            return this.despatchDocumentReferenceField;
        }
        set
        {
            this.despatchDocumentReferenceField = value;
        }
    }

    [XmlElement("ReceiptDocumentReference", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
    public DocumentReferenceType[] ReceiptDocumentReference
    {
        get
        {
            return this.receiptDocumentReferenceField;
        }
        set
        {
            this.receiptDocumentReferenceField = value;
        }
    }

    [XmlElement("ContractDocumentReference", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
    public DocumentReferenceType[] ContractDocumentReference
    {
        get
        {
            return this.contractDocumentReferenceField;
        }
        set
        {
            this.contractDocumentReferenceField = value;
        }
    }

    [XmlElement("AdditionalDocumentReference", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
    public DocumentReferenceType[] AdditionalDocumentReference
    {
        get
        {
            return this.additionalDocumentReferenceField;
        }
        set
        {
            this.additionalDocumentReferenceField = value;
        }
    }

    [XmlElement("StatementDocumentReference", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
    public DocumentReferenceType[] StatementDocumentReference
    {
        get
        {
            return this.statementDocumentReferenceField;
        }
        set
        {
            this.statementDocumentReferenceField = value;
        }
    }

    [XmlElement("OriginatorDocumentReference", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
    public DocumentReferenceType[] OriginatorDocumentReference
    {
        get
        {
            return this.originatorDocumentReferenceField;
        }
        set
        {
            this.originatorDocumentReferenceField = value;
        }
    }

    [XmlElement("Signature", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
    public SignatureType[] Signature
    {
        get
        {
            return this.signatureField;
        }
        set
        {
            this.signatureField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
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

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
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

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
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

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
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

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
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

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
    public PartyType TaxRepresentativeParty
    {
        get
        {
            return this.taxRepresentativePartyField;
        }
        set
        {
            this.taxRepresentativePartyField = value;
        }
    }

    [XmlElement("Delivery", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
    public DeliveryType[] Delivery
    {
        get
        {
            return this.deliveryField;
        }
        set
        {
            this.deliveryField = value;
        }
    }

    [XmlElement("DeliveryTerms", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
    public DeliveryTermsType[] DeliveryTerms
    {
        get
        {
            return this.deliveryTermsField;
        }
        set
        {
            this.deliveryTermsField = value;
        }
    }

    [XmlElement("PaymentMeans", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
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

    [XmlElement("PaymentTerms", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
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

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
    public ExchangeRateType TaxExchangeRate
    {
        get
        {
            return this.taxExchangeRateField;
        }
        set
        {
            this.taxExchangeRateField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
    public ExchangeRateType PricingExchangeRate
    {
        get
        {
            return this.pricingExchangeRateField;
        }
        set
        {
            this.pricingExchangeRateField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
    public ExchangeRateType PaymentExchangeRate
    {
        get
        {
            return this.paymentExchangeRateField;
        }
        set
        {
            this.paymentExchangeRateField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
    public ExchangeRateType PaymentAlternativeExchangeRate
    {
        get
        {
            return this.paymentAlternativeExchangeRateField;
        }
        set
        {
            this.paymentAlternativeExchangeRateField = value;
        }
    }

    [XmlElement("AllowanceCharge", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
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

    [XmlElement("TaxTotal", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
    public TaxTotalType[] TaxTotal
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

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
    public MonetaryTotalType LegalMonetaryTotal
    {
        get
        {
            return this.legalMonetaryTotalField;
        }
        set
        {
            this.legalMonetaryTotalField = value;
        }
    }

    [XmlElement("CreditNoteLine", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
    public CreditNoteLineType[] CreditNoteLine
    {
        get
        {
            return this.creditNoteLineField;
        }
        set
        {
            this.creditNoteLineField = value;
        }
    }
}
