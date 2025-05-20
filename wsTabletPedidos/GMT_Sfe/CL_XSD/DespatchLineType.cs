using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[GeneratedCode("xsd", "4.0.30319.33440")]
[DebuggerStepThrough]
[DesignerCategory("code")]
[XmlType(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[XmlRoot("DespatchLine", IsNullable = false, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[Serializable]
public class DespatchLineType
{
    private IDType idField;
    private UUIDType uUIDField;
    private NoteType[] noteField;
    private LineStatusCodeType lineStatusCodeField;
    private DeliveredQuantityType deliveredQuantityField;
    private BackorderQuantityType backorderQuantityField;
    private BackorderReasonType[] backorderReasonField;
    private OutstandingQuantityType outstandingQuantityField;
    private OutstandingReasonType[] outstandingReasonField;
    private OversupplyQuantityType oversupplyQuantityField;
    private OrderLineReferenceType[] orderLineReferenceField;
    private DocumentReferenceType[] documentReferenceField;
    private ItemType itemField;
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
    public DeliveredQuantityType DeliveredQuantity
    {
        get
        {
            return this.deliveredQuantityField;
        }
        set
        {
            this.deliveredQuantityField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public BackorderQuantityType BackorderQuantity
    {
        get
        {
            return this.backorderQuantityField;
        }
        set
        {
            this.backorderQuantityField = value;
        }
    }

    [XmlElement("BackorderReason", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public BackorderReasonType[] BackorderReason
    {
        get
        {
            return this.backorderReasonField;
        }
        set
        {
            this.backorderReasonField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public OutstandingQuantityType OutstandingQuantity
    {
        get
        {
            return this.outstandingQuantityField;
        }
        set
        {
            this.outstandingQuantityField = value;
        }
    }

    [XmlElement("OutstandingReason", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public OutstandingReasonType[] OutstandingReason
    {
        get
        {
            return this.outstandingReasonField;
        }
        set
        {
            this.outstandingReasonField = value;
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
