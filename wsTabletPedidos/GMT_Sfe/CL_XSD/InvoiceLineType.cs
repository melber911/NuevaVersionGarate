using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[GeneratedCode("xsd", "4.0.30319.33440")]
[DebuggerStepThrough]
[DesignerCategory("code")]
[XmlType(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[XmlRoot("InvoiceLine", IsNullable = false, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[Serializable]
public class InvoiceLineType
{
    private IDType idField;
    private UUIDType uUIDField;
    private NoteType[] noteField;
    private InvoicedQuantityType invoicedQuantityField;
    private LineExtensionAmountType lineExtensionAmountField;
    private TaxPointDateType taxPointDateField;
    private AccountingCostCodeType accountingCostCodeField;
    private AccountingCostType accountingCostField;
    private PaymentPurposeCodeType paymentPurposeCodeField;
    private FreeOfChargeIndicatorType freeOfChargeIndicatorField;
    private PeriodType[] periodField;
    private OrderLineReferenceType[] orderLineReferenceField;
    private LineReferenceType[] despatchLineReferenceField;
    private LineReferenceType[] receiptLineReferenceField;
    private BillingReferenceType[] billingReferenceField;
    private DocumentReferenceType[] documentReferenceField;
    private PricingReferenceType pricingReferenceField;
    private PartyType originatorPartyField;
    private DeliveryType[] deliveryField;
    private PaymentTermsType[] paymentTermsField;
    private AllowanceChargeType[] allowanceChargeField;
    private TaxTotalType[] taxTotalField;
    private TaxTotalType[] withholdingTaxTotalField;
    private ItemType itemField;
    private PriceType priceField;
    private DeliveryTermsType deliveryTermsField;
    private InvoiceLineType[] subInvoiceLineField;
    private PriceExtensionType itemPriceExtensionField;

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
    public InvoicedQuantityType InvoicedQuantity
    {
        get
        {
            return this.invoicedQuantityField;
        }
        set
        {
            this.invoicedQuantityField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public LineExtensionAmountType LineExtensionAmount
    {
        get
        {
            return this.lineExtensionAmountField;
        }
        set
        {
            this.lineExtensionAmountField = value;
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

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public FreeOfChargeIndicatorType FreeOfChargeIndicator
    {
        get
        {
            return this.freeOfChargeIndicatorField;
        }
        set
        {
            this.freeOfChargeIndicatorField = value;
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

    [XmlElement("OrderLineReference")]
    public OrderLineReferenceType[] OrderLineReference
    {
        get
        {
            return this.orderLineReferenceField;
        }
        set
        {
            this.orderLineReferenceField = value;
        }
    }

    [XmlElement("DespatchLineReference")]
    public LineReferenceType[] DespatchLineReference
    {
        get
        {
            return this.despatchLineReferenceField;
        }
        set
        {
            this.despatchLineReferenceField = value;
        }
    }

    [XmlElement("ReceiptLineReference")]
    public LineReferenceType[] ReceiptLineReference
    {
        get
        {
            return this.receiptLineReferenceField;
        }
        set
        {
            this.receiptLineReferenceField = value;
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

    public PricingReferenceType PricingReference
    {
        get
        {
            return this.pricingReferenceField;
        }
        set
        {
            this.pricingReferenceField = value;
        }
    }

    public PartyType OriginatorParty
    {
        get
        {
            return this.originatorPartyField;
        }
        set
        {
            this.originatorPartyField = value;
        }
    }

    [XmlElement("Delivery")]
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

    [XmlElement("TaxTotal")]
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

    [XmlElement("WithholdingTaxTotal")]
    public TaxTotalType[] WithholdingTaxTotal
    {
        get
        {
            return this.withholdingTaxTotalField;
        }
        set
        {
            this.withholdingTaxTotalField = value;
        }
    }

    public ItemType Item
    {
        get
        {
            return this.itemField;
        }
        set
        {
            this.itemField = value;
        }
    }

    public PriceType Price
    {
        get
        {
            return this.priceField;
        }
        set
        {
            this.priceField = value;
        }
    }

    public DeliveryTermsType DeliveryTerms
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

    [XmlElement("SubInvoiceLine")]
    public InvoiceLineType[] SubInvoiceLine
    {
        get
        {
            return this.subInvoiceLineField;
        }
        set
        {
            this.subInvoiceLineField = value;
        }
    }

    public PriceExtensionType ItemPriceExtension
    {
        get
        {
            return this.itemPriceExtensionField;
        }
        set
        {
            this.itemPriceExtensionField = value;
        }
    }
}
