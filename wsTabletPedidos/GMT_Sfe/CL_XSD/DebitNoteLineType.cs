using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[XmlType(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[DesignerCategory("code")]
[DebuggerStepThrough]
[GeneratedCode("xsd", "4.0.30319.33440")]
[XmlRoot("DebitNoteLine", IsNullable = false, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[Serializable]
public class DebitNoteLineType
{
    private IDType idField;
    private UUIDType uUIDField;
    private NoteType[] noteField;
    private DebitedQuantityType debitedQuantityField;
    private LineExtensionAmountType lineExtensionAmountField;
    private TaxPointDateType taxPointDateField;
    private AccountingCostCodeType accountingCostCodeField;
    private AccountingCostType accountingCostField;
    private PaymentPurposeCodeType paymentPurposeCodeField;
    private ResponseType[] discrepancyResponseField;
    private LineReferenceType[] despatchLineReferenceField;
    private LineReferenceType[] receiptLineReferenceField;
    private BillingReferenceType[] billingReferenceField;
    private DocumentReferenceType[] documentReferenceField;
    private PricingReferenceType pricingReferenceField;
    private DeliveryType[] deliveryField;
    private TaxTotalType[] taxTotalField;
    private AllowanceChargeType[] allowanceChargeField;
    private ItemType itemField;
    private PriceType priceField;
    private DebitNoteLineType[] subDebitNoteLineField;

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
    public DebitedQuantityType DebitedQuantity
    {
        get
        {
            return this.debitedQuantityField;
        }
        set
        {
            this.debitedQuantityField = value;
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

    [XmlElement("DiscrepancyResponse")]
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

    [XmlElement("SubDebitNoteLine")]
    public DebitNoteLineType[] SubDebitNoteLine
    {
        get
        {
            return this.subDebitNoteLineField;
        }
        set
        {
            this.subDebitNoteLineField = value;
        }
    }
}
