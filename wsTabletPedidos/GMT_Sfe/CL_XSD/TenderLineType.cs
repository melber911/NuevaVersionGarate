
// Type: TenderLineType




using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[DesignerCategory("code")]
[DebuggerStepThrough]
[GeneratedCode("xsd", "4.0.30319.33440")]
[XmlType(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[XmlRoot("SubTenderLine", IsNullable = false, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[Serializable]
public class TenderLineType
{
    private IDType idField;
    private NoteType[] noteField;
    private QuantityType2 quantityField;
    private LineExtensionAmountType lineExtensionAmountField;
    private TotalTaxAmountType totalTaxAmountField;
    private OrderableUnitType orderableUnitField;
    private ContentUnitQuantityType contentUnitQuantityField;
    private OrderQuantityIncrementNumericType orderQuantityIncrementNumericField;
    private MinimumOrderQuantityType minimumOrderQuantityField;
    private MaximumOrderQuantityType maximumOrderQuantityField;
    private WarrantyInformationType[] warrantyInformationField;
    private PackLevelCodeType packLevelCodeField;
    private DocumentReferenceType[] documentReferenceField;
    private ItemType itemField;
    private ItemLocationQuantityType[] offeredItemLocationQuantityField;
    private RelatedItemType[] replacementRelatedItemField;
    private PartyType warrantyPartyField;
    private PeriodType warrantyValidityPeriodField;
    private TenderLineType[] subTenderLineField;
    private LineReferenceType callForTendersLineReferenceField;
    private DocumentReferenceType callForTendersDocumentReferenceField;

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
    public OrderableUnitType OrderableUnit
    {
        get
        {
            return this.orderableUnitField;
        }
        set
        {
            this.orderableUnitField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public ContentUnitQuantityType ContentUnitQuantity
    {
        get
        {
            return this.contentUnitQuantityField;
        }
        set
        {
            this.contentUnitQuantityField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public OrderQuantityIncrementNumericType OrderQuantityIncrementNumeric
    {
        get
        {
            return this.orderQuantityIncrementNumericField;
        }
        set
        {
            this.orderQuantityIncrementNumericField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public MinimumOrderQuantityType MinimumOrderQuantity
    {
        get
        {
            return this.minimumOrderQuantityField;
        }
        set
        {
            this.minimumOrderQuantityField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public MaximumOrderQuantityType MaximumOrderQuantity
    {
        get
        {
            return this.maximumOrderQuantityField;
        }
        set
        {
            this.maximumOrderQuantityField = value;
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

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public PackLevelCodeType PackLevelCode
    {
        get
        {
            return this.packLevelCodeField;
        }
        set
        {
            this.packLevelCodeField = value;
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

    [XmlElement("OfferedItemLocationQuantity")]
    public ItemLocationQuantityType[] OfferedItemLocationQuantity
    {
        get
        {
            return this.offeredItemLocationQuantityField;
        }
        set
        {
            this.offeredItemLocationQuantityField = value;
        }
    }

    [XmlElement("ReplacementRelatedItem")]
    public RelatedItemType[] ReplacementRelatedItem
    {
        get
        {
            return this.replacementRelatedItemField;
        }
        set
        {
            this.replacementRelatedItemField = value;
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

    [XmlElement("SubTenderLine")]
    public TenderLineType[] SubTenderLine
    {
        get
        {
            return this.subTenderLineField;
        }
        set
        {
            this.subTenderLineField = value;
        }
    }

    public LineReferenceType CallForTendersLineReference
    {
        get
        {
            return this.callForTendersLineReferenceField;
        }
        set
        {
            this.callForTendersLineReferenceField = value;
        }
    }

    public DocumentReferenceType CallForTendersDocumentReference
    {
        get
        {
            return this.callForTendersDocumentReferenceField;
        }
        set
        {
            this.callForTendersDocumentReferenceField = value;
        }
    }
}
