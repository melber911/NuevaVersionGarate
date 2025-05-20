using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[XmlRoot("ConsumptionLine", IsNullable = false, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[XmlType(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[GeneratedCode("xsd", "4.0.30319.33440")]
[DebuggerStepThrough]
[DesignerCategory("code")]
[Serializable]
public class ConsumptionLineType
{
    private IDType idField;
    private ParentDocumentLineReferenceIDType parentDocumentLineReferenceIDField;
    private InvoicedQuantityType invoicedQuantityField;
    private LineExtensionAmountType lineExtensionAmountField;
    private PeriodType periodField;
    private DeliveryType[] deliveryField;
    private AllowanceChargeType[] allowanceChargeField;
    private TaxTotalType[] taxTotalField;
    private UtilityItemType utilityItemField;
    private PriceType priceField;
    private UnstructuredPriceType unstructuredPriceField;

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
    public ParentDocumentLineReferenceIDType ParentDocumentLineReferenceID
    {
        get
        {
            return this.parentDocumentLineReferenceIDField;
        }
        set
        {
            this.parentDocumentLineReferenceIDField = value;
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

    public PeriodType Period
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

    public UtilityItemType UtilityItem
    {
        get
        {
            return this.utilityItemField;
        }
        set
        {
            this.utilityItemField = value;
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

    public UnstructuredPriceType UnstructuredPrice
    {
        get
        {
            return this.unstructuredPriceField;
        }
        set
        {
            this.unstructuredPriceField = value;
        }
    }
}
