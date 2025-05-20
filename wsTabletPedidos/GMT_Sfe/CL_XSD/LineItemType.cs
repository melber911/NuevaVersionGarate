using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[XmlType(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[GeneratedCode("xsd", "4.0.30319.33440")]
[DesignerCategory("code")]
[XmlRoot("AlternativeLineItem", IsNullable = false, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[DebuggerStepThrough]
[Serializable]
public class LineItemType
{
    private IDType idField;
    private SalesOrderIDType salesOrderIDField;
    private UUIDType uUIDField;
    private NoteType[] noteField;
    private LineStatusCodeType lineStatusCodeField;
    private QuantityType2 quantityField;
    private LineExtensionAmountType lineExtensionAmountField;
    private TotalTaxAmountType totalTaxAmountField;
    private MinimumQuantityType minimumQuantityField;
    private MaximumQuantityType maximumQuantityField;
    private MinimumBackorderQuantityType minimumBackorderQuantityField;
    private MaximumBackorderQuantityType maximumBackorderQuantityField;
    private InspectionMethodCodeType inspectionMethodCodeField;
    private PartialDeliveryIndicatorType partialDeliveryIndicatorField;
    private BackOrderAllowedIndicatorType backOrderAllowedIndicatorField;
    private AccountingCostCodeType accountingCostCodeField;
    private AccountingCostType accountingCostField;
    private WarrantyInformationType[] warrantyInformationField;
    private DeliveryType[] deliveryField;
    private DeliveryTermsType deliveryTermsField;
    private PartyType originatorPartyField;
    private OrderedShipmentType[] orderedShipmentField;
    private PricingReferenceType pricingReferenceField;
    private AllowanceChargeType[] allowanceChargeField;
    private PriceType priceField;
    private ItemType itemField;
    private LineItemType[] subLineItemField;
    private PeriodType warrantyValidityPeriodField;
    private PartyType warrantyPartyField;
    private TaxTotalType[] taxTotalField;
    private PriceExtensionType itemPriceExtensionField;
    private LineReferenceType[] lineReferenceField;

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
    public SalesOrderIDType SalesOrderID
    {
        get
        {
            return this.salesOrderIDField;
        }
        set
        {
            this.salesOrderIDField = value;
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
    public LineStatusCodeType LineStatusCode
    {
        get
        {
            return this.lineStatusCodeField;
        }
        set
        {
            this.lineStatusCodeField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public QuantityType2 Quantity
    {
        get
        {
            return this.quantityField;
        }
        set
        {
            this.quantityField = value;
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
    public TotalTaxAmountType TotalTaxAmount
    {
        get
        {
            return this.totalTaxAmountField;
        }
        set
        {
            this.totalTaxAmountField = value;
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
    public MinimumBackorderQuantityType MinimumBackorderQuantity
    {
        get
        {
            return this.minimumBackorderQuantityField;
        }
        set
        {
            this.minimumBackorderQuantityField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public MaximumBackorderQuantityType MaximumBackorderQuantity
    {
        get
        {
            return this.maximumBackorderQuantityField;
        }
        set
        {
            this.maximumBackorderQuantityField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public InspectionMethodCodeType InspectionMethodCode
    {
        get
        {
            return this.inspectionMethodCodeField;
        }
        set
        {
            this.inspectionMethodCodeField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public PartialDeliveryIndicatorType PartialDeliveryIndicator
    {
        get
        {
            return this.partialDeliveryIndicatorField;
        }
        set
        {
            this.partialDeliveryIndicatorField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public BackOrderAllowedIndicatorType BackOrderAllowedIndicator
    {
        get
        {
            return this.backOrderAllowedIndicatorField;
        }
        set
        {
            this.backOrderAllowedIndicatorField = value;
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

    [XmlElement("WarrantyInformation", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public WarrantyInformationType[] WarrantyInformation
    {
        get
        {
            return this.warrantyInformationField;
        }
        set
        {
            this.warrantyInformationField = value;
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

    [XmlElement("OrderedShipment")]
    public OrderedShipmentType[] OrderedShipment
    {
        get
        {
            return this.orderedShipmentField;
        }
        set
        {
            this.orderedShipmentField = value;
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

    [XmlElement("SubLineItem")]
    public LineItemType[] SubLineItem
    {
        get
        {
            return this.subLineItemField;
        }
        set
        {
            this.subLineItemField = value;
        }
    }

    public PeriodType WarrantyValidityPeriod
    {
        get
        {
            return this.warrantyValidityPeriodField;
        }
        set
        {
            this.warrantyValidityPeriodField = value;
        }
    }

    public PartyType WarrantyParty
    {
        get
        {
            return this.warrantyPartyField;
        }
        set
        {
            this.warrantyPartyField = value;
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

    [XmlElement("LineReference")]
    public LineReferenceType[] LineReference
    {
        get
        {
            return this.lineReferenceField;
        }
        set
        {
            this.lineReferenceField = value;
        }
    }
}
