using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[XmlRoot("RequestForTenderLine", IsNullable = false, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[XmlType(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[GeneratedCode("xsd", "4.0.30319.33440")]
[DebuggerStepThrough]
[DesignerCategory("code")]
[Serializable]
public class RequestForTenderLineType
{
    private IDType idField;
    private UUIDType uUIDField;
    private NoteType[] noteField;
    private QuantityType2 quantityField;
    private MinimumQuantityType minimumQuantityField;
    private MaximumQuantityType maximumQuantityField;
    private TaxIncludedIndicatorType taxIncludedIndicatorField;
    private MinimumAmountType minimumAmountField;
    private MaximumAmountType maximumAmountField;
    private EstimatedAmountType estimatedAmountField;
    private DocumentReferenceType[] documentReferenceField;
    private PeriodType[] deliveryPeriodField;
    private ItemLocationQuantityType[] requiredItemLocationQuantityField;
    private PeriodType warrantyValidityPeriodField;
    private ItemType itemField;
    private RequestForTenderLineType[] subRequestForTenderLineField;

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
    public TaxIncludedIndicatorType TaxIncludedIndicator
    {
        get
        {
            return this.taxIncludedIndicatorField;
        }
        set
        {
            this.taxIncludedIndicatorField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public MinimumAmountType MinimumAmount
    {
        get
        {
            return this.minimumAmountField;
        }
        set
        {
            this.minimumAmountField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public MaximumAmountType MaximumAmount
    {
        get
        {
            return this.maximumAmountField;
        }
        set
        {
            this.maximumAmountField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public EstimatedAmountType EstimatedAmount
    {
        get
        {
            return this.estimatedAmountField;
        }
        set
        {
            this.estimatedAmountField = value;
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

    [XmlElement("DeliveryPeriod")]
    public PeriodType[] DeliveryPeriod
    {
        get
        {
            return this.deliveryPeriodField;
        }
        set
        {
            this.deliveryPeriodField = value;
        }
    }

    [XmlElement("RequiredItemLocationQuantity")]
    public ItemLocationQuantityType[] RequiredItemLocationQuantity
    {
        get
        {
            return this.requiredItemLocationQuantityField;
        }
        set
        {
            this.requiredItemLocationQuantityField = value;
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

    [XmlElement("SubRequestForTenderLine")]
    public RequestForTenderLineType[] SubRequestForTenderLine
    {
        get
        {
            return this.subRequestForTenderLineField;
        }
        set
        {
            this.subRequestForTenderLineField = value;
        }
    }
}
