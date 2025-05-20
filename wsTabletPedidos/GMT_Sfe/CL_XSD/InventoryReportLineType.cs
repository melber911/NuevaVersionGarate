using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[XmlRoot("InventoryReportLine", IsNullable = false, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[DebuggerStepThrough]
[DesignerCategory("code")]
[GeneratedCode("xsd", "4.0.30319.33440")]
[XmlType(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[Serializable]
public class InventoryReportLineType
{
    private IDType idField;
    private NoteType[] noteField;
    private QuantityType2 quantityField;
    private InventoryValueAmountType inventoryValueAmountField;
    private AvailabilityDateType availabilityDateField;
    private AvailabilityStatusCodeType availabilityStatusCodeField;
    private ItemType itemField;
    private LocationType1 inventoryLocationField;

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
    public InventoryValueAmountType InventoryValueAmount
    {
        get
        {
            return this.inventoryValueAmountField;
        }
        set
        {
            this.inventoryValueAmountField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public AvailabilityDateType AvailabilityDate
    {
        get
        {
            return this.availabilityDateField;
        }
        set
        {
            this.availabilityDateField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public AvailabilityStatusCodeType AvailabilityStatusCode
    {
        get
        {
            return this.availabilityStatusCodeField;
        }
        set
        {
            this.availabilityStatusCodeField = value;
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

    public LocationType1 InventoryLocation
    {
        get
        {
            return this.inventoryLocationField;
        }
        set
        {
            this.inventoryLocationField = value;
        }
    }
}
