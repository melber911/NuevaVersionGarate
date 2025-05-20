using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[GeneratedCode("xsd", "4.0.30319.33440")]
[DesignerCategory("code")]
[DebuggerStepThrough]
[XmlType(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[XmlRoot("CatalogueLine", IsNullable = false, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[Serializable]
public class CatalogueLineType
{
    private IDType idField;
    private ActionCodeType actionCodeField;
    private LifeCycleStatusCodeType lifeCycleStatusCodeField;
    private ContractSubdivisionType contractSubdivisionField;
    private NoteType[] noteField;
    private OrderableIndicatorType orderableIndicatorField;
    private OrderableUnitType orderableUnitField;
    private ContentUnitQuantityType contentUnitQuantityField;
    private OrderQuantityIncrementNumericType orderQuantityIncrementNumericField;
    private MinimumOrderQuantityType minimumOrderQuantityField;
    private MaximumOrderQuantityType maximumOrderQuantityField;
    private WarrantyInformationType[] warrantyInformationField;
    private PackLevelCodeType packLevelCodeField;
    private CustomerPartyType contractorCustomerPartyField;
    private SupplierPartyType sellerSupplierPartyField;
    private PartyType warrantyPartyField;
    private PeriodType warrantyValidityPeriodField;
    private PeriodType lineValidityPeriodField;
    private ItemComparisonType[] itemComparisonField;
    private RelatedItemType[] componentRelatedItemField;
    private RelatedItemType[] accessoryRelatedItemField;
    private RelatedItemType[] requiredRelatedItemField;
    private RelatedItemType[] replacementRelatedItemField;
    private RelatedItemType[] complementaryRelatedItemField;
    private RelatedItemType[] replacedRelatedItemField;
    private ItemLocationQuantityType[] requiredItemLocationQuantityField;
    private DocumentReferenceType[] documentReferenceField;
    private ItemType itemField;
    private ItemPropertyType[] keywordItemPropertyField;
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

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public ActionCodeType ActionCode
    {
        get
        {
            return this.actionCodeField;
        }
        set
        {
            this.actionCodeField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public LifeCycleStatusCodeType LifeCycleStatusCode
    {
        get
        {
            return this.lifeCycleStatusCodeField;
        }
        set
        {
            this.lifeCycleStatusCodeField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public ContractSubdivisionType ContractSubdivision
    {
        get
        {
            return this.contractSubdivisionField;
        }
        set
        {
            this.contractSubdivisionField = value;
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
    public OrderableIndicatorType OrderableIndicator
    {
        get
        {
            return this.orderableIndicatorField;
        }
        set
        {
            this.orderableIndicatorField = value;
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

    public CustomerPartyType ContractorCustomerParty
    {
        get
        {
            return this.contractorCustomerPartyField;
        }
        set
        {
            this.contractorCustomerPartyField = value;
        }
    }

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

    public PeriodType LineValidityPeriod
    {
        get
        {
            return this.lineValidityPeriodField;
        }
        set
        {
            this.lineValidityPeriodField = value;
        }
    }

    [XmlElement("ItemComparison")]
    public ItemComparisonType[] ItemComparison
    {
        get
        {
            return this.itemComparisonField;
        }
        set
        {
            this.itemComparisonField = value;
        }
    }

    [XmlElement("ComponentRelatedItem")]
    public RelatedItemType[] ComponentRelatedItem
    {
        get
        {
            return this.componentRelatedItemField;
        }
        set
        {
            this.componentRelatedItemField = value;
        }
    }

    [XmlElement("AccessoryRelatedItem")]
    public RelatedItemType[] AccessoryRelatedItem
    {
        get
        {
            return this.accessoryRelatedItemField;
        }
        set
        {
            this.accessoryRelatedItemField = value;
        }
    }

    [XmlElement("RequiredRelatedItem")]
    public RelatedItemType[] RequiredRelatedItem
    {
        get
        {
            return this.requiredRelatedItemField;
        }
        set
        {
            this.requiredRelatedItemField = value;
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

    [XmlElement("ComplementaryRelatedItem")]
    public RelatedItemType[] ComplementaryRelatedItem
    {
        get
        {
            return this.complementaryRelatedItemField;
        }
        set
        {
            this.complementaryRelatedItemField = value;
        }
    }

    [XmlElement("ReplacedRelatedItem")]
    public RelatedItemType[] ReplacedRelatedItem
    {
        get
        {
            return this.replacedRelatedItemField;
        }
        set
        {
            this.replacedRelatedItemField = value;
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

    [XmlElement("KeywordItemProperty")]
    public ItemPropertyType[] KeywordItemProperty
    {
        get
        {
            return this.keywordItemPropertyField;
        }
        set
        {
            this.keywordItemPropertyField = value;
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
