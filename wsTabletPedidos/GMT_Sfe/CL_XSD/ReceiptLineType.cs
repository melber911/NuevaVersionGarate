using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[DesignerCategory("code")]
[DebuggerStepThrough]
[XmlRoot("ReceiptLine", IsNullable = false, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[GeneratedCode("xsd", "4.0.30319.33440")]
[XmlType(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[Serializable]
public class ReceiptLineType
{
    private IDType idField;
    private UUIDType uUIDField;
    private NoteType[] noteField;
    private ReceivedQuantityType receivedQuantityField;
    private ShortQuantityType shortQuantityField;
    private ShortageActionCodeType shortageActionCodeField;
    private RejectedQuantityType rejectedQuantityField;
    private RejectReasonCodeType rejectReasonCodeField;
    private RejectReasonType[] rejectReasonField;
    private RejectActionCodeType rejectActionCodeField;
    private QuantityDiscrepancyCodeType quantityDiscrepancyCodeField;
    private OversupplyQuantityType oversupplyQuantityField;
    private ReceivedDateType receivedDateField;
    private TimingComplaintCodeType timingComplaintCodeField;
    private TimingComplaintType timingComplaintField;
    private OrderLineReferenceType orderLineReferenceField;
    private LineReferenceType[] despatchLineReferenceField;
    private DocumentReferenceType[] documentReferenceField;
    private ItemType[] itemField;
    private ShipmentType[] shipmentField;

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
    public ReceivedQuantityType ReceivedQuantity
    {
        get
        {
            return this.receivedQuantityField;
        }
        set
        {
            this.receivedQuantityField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public ShortQuantityType ShortQuantity
    {
        get
        {
            return this.shortQuantityField;
        }
        set
        {
            this.shortQuantityField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public ShortageActionCodeType ShortageActionCode
    {
        get
        {
            return this.shortageActionCodeField;
        }
        set
        {
            this.shortageActionCodeField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public RejectedQuantityType RejectedQuantity
    {
        get
        {
            return this.rejectedQuantityField;
        }
        set
        {
            this.rejectedQuantityField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public RejectReasonCodeType RejectReasonCode
    {
        get
        {
            return this.rejectReasonCodeField;
        }
        set
        {
            this.rejectReasonCodeField = value;
        }
    }

    [XmlElement("RejectReason", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public RejectReasonType[] RejectReason
    {
        get
        {
            return this.rejectReasonField;
        }
        set
        {
            this.rejectReasonField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public RejectActionCodeType RejectActionCode
    {
        get
        {
            return this.rejectActionCodeField;
        }
        set
        {
            this.rejectActionCodeField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public QuantityDiscrepancyCodeType QuantityDiscrepancyCode
    {
        get
        {
            return this.quantityDiscrepancyCodeField;
        }
        set
        {
            this.quantityDiscrepancyCodeField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public OversupplyQuantityType OversupplyQuantity
    {
        get
        {
            return this.oversupplyQuantityField;
        }
        set
        {
            this.oversupplyQuantityField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public ReceivedDateType ReceivedDate
    {
        get
        {
            return this.receivedDateField;
        }
        set
        {
            this.receivedDateField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public TimingComplaintCodeType TimingComplaintCode
    {
        get
        {
            return this.timingComplaintCodeField;
        }
        set
        {
            this.timingComplaintCodeField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public TimingComplaintType TimingComplaint
    {
        get
        {
            return this.timingComplaintField;
        }
        set
        {
            this.timingComplaintField = value;
        }
    }

    public OrderLineReferenceType OrderLineReference
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

    [XmlElement("Item")]
    public ItemType[] Item
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

    [XmlElement("Shipment")]
    public ShipmentType[] Shipment
    {
        get
        {
            return this.shipmentField;
        }
        set
        {
            this.shipmentField = value;
        }
    }
}
