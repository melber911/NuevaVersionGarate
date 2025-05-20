using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[DesignerCategory("code")]
[GeneratedCode("xsd", "4.0.30319.33440")]
[DebuggerStepThrough]
[XmlRoot("Item", IsNullable = false, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[XmlType(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[Serializable]
public class ItemType
{
    private DescriptionType[] descriptionField;
    private PackQuantityType packQuantityField;
    private PackSizeNumericType packSizeNumericField;
    private CatalogueIndicatorType catalogueIndicatorField;
    private NameType1 nameField;
    private HazardousRiskIndicatorType hazardousRiskIndicatorField;
    private AdditionalInformationType[] additionalInformationField;
    private KeywordType[] keywordField;
    private BrandNameType[] brandNameField;
    private ModelNameType[] modelNameField;
    private ItemIdentificationType buyersItemIdentificationField;
    private ItemIdentificationType sellersItemIdentificationField;
    private ItemIdentificationType[] manufacturersItemIdentificationField;
    private ItemIdentificationType standardItemIdentificationField;
    private ItemIdentificationType catalogueItemIdentificationField;
    private ItemIdentificationType[] additionalItemIdentificationField;
    private DocumentReferenceType catalogueDocumentReferenceField;
    private DocumentReferenceType[] itemSpecificationDocumentReferenceField;
    private CountryType originCountryField;
    private CommodityClassificationType[] commodityClassificationField;
    private TransactionConditionsType[] transactionConditionsField;
    private HazardousItemType[] hazardousItemField;
    private TaxCategoryType[] classifiedTaxCategoryField;
    private ItemPropertyType[] additionalItemPropertyField;
    private PartyType[] manufacturerPartyField;
    private PartyType informationContentProviderPartyField;
    private AddressType[] originAddressField;
    private ItemInstanceType[] itemInstanceField;
    private CertificateType[] certificateField;
    private DimensionType[] dimensionField;

    [XmlElement("Description", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public DescriptionType[] Description
    {
        get
        {
            return this.descriptionField;
        }
        set
        {
            this.descriptionField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public PackQuantityType PackQuantity
    {
        get
        {
            return this.packQuantityField;
        }
        set
        {
            this.packQuantityField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public PackSizeNumericType PackSizeNumeric
    {
        get
        {
            return this.packSizeNumericField;
        }
        set
        {
            this.packSizeNumericField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public CatalogueIndicatorType CatalogueIndicator
    {
        get
        {
            return this.catalogueIndicatorField;
        }
        set
        {
            this.catalogueIndicatorField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public NameType1 Name
    {
        get
        {
            return this.nameField;
        }
        set
        {
            this.nameField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public HazardousRiskIndicatorType HazardousRiskIndicator
    {
        get
        {
            return this.hazardousRiskIndicatorField;
        }
        set
        {
            this.hazardousRiskIndicatorField = value;
        }
    }

    [XmlElement("AdditionalInformation", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public AdditionalInformationType[] AdditionalInformation
    {
        get
        {
            return this.additionalInformationField;
        }
        set
        {
            this.additionalInformationField = value;
        }
    }

    [XmlElement("Keyword", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public KeywordType[] Keyword
    {
        get
        {
            return this.keywordField;
        }
        set
        {
            this.keywordField = value;
        }
    }

    [XmlElement("BrandName", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public BrandNameType[] BrandName
    {
        get
        {
            return this.brandNameField;
        }
        set
        {
            this.brandNameField = value;
        }
    }

    [XmlElement("ModelName", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public ModelNameType[] ModelName
    {
        get
        {
            return this.modelNameField;
        }
        set
        {
            this.modelNameField = value;
        }
    }

    public ItemIdentificationType BuyersItemIdentification
    {
        get
        {
            return this.buyersItemIdentificationField;
        }
        set
        {
            this.buyersItemIdentificationField = value;
        }
    }

    public ItemIdentificationType SellersItemIdentification
    {
        get
        {
            return this.sellersItemIdentificationField;
        }
        set
        {
            this.sellersItemIdentificationField = value;
        }
    }

    [XmlElement("ManufacturersItemIdentification")]
    public ItemIdentificationType[] ManufacturersItemIdentification
    {
        get
        {
            return this.manufacturersItemIdentificationField;
        }
        set
        {
            this.manufacturersItemIdentificationField = value;
        }
    }

    public ItemIdentificationType StandardItemIdentification
    {
        get
        {
            return this.standardItemIdentificationField;
        }
        set
        {
            this.standardItemIdentificationField = value;
        }
    }

    public ItemIdentificationType CatalogueItemIdentification
    {
        get
        {
            return this.catalogueItemIdentificationField;
        }
        set
        {
            this.catalogueItemIdentificationField = value;
        }
    }

    [XmlElement("AdditionalItemIdentification")]
    public ItemIdentificationType[] AdditionalItemIdentification
    {
        get
        {
            return this.additionalItemIdentificationField;
        }
        set
        {
            this.additionalItemIdentificationField = value;
        }
    }

    public DocumentReferenceType CatalogueDocumentReference
    {
        get
        {
            return this.catalogueDocumentReferenceField;
        }
        set
        {
            this.catalogueDocumentReferenceField = value;
        }
    }

    [XmlElement("ItemSpecificationDocumentReference")]
    public DocumentReferenceType[] ItemSpecificationDocumentReference
    {
        get
        {
            return this.itemSpecificationDocumentReferenceField;
        }
        set
        {
            this.itemSpecificationDocumentReferenceField = value;
        }
    }

    public CountryType OriginCountry
    {
        get
        {
            return this.originCountryField;
        }
        set
        {
            this.originCountryField = value;
        }
    }

    [XmlElement("CommodityClassification")]
    public CommodityClassificationType[] CommodityClassification
    {
        get
        {
            return this.commodityClassificationField;
        }
        set
        {
            this.commodityClassificationField = value;
        }
    }

    [XmlElement("TransactionConditions")]
    public TransactionConditionsType[] TransactionConditions
    {
        get
        {
            return this.transactionConditionsField;
        }
        set
        {
            this.transactionConditionsField = value;
        }
    }

    [XmlElement("HazardousItem")]
    public HazardousItemType[] HazardousItem
    {
        get
        {
            return this.hazardousItemField;
        }
        set
        {
            this.hazardousItemField = value;
        }
    }

    [XmlElement("ClassifiedTaxCategory")]
    public TaxCategoryType[] ClassifiedTaxCategory
    {
        get
        {
            return this.classifiedTaxCategoryField;
        }
        set
        {
            this.classifiedTaxCategoryField = value;
        }
    }

    [XmlElement("AdditionalItemProperty")]
    public ItemPropertyType[] AdditionalItemProperty
    {
        get
        {
            return this.additionalItemPropertyField;
        }
        set
        {
            this.additionalItemPropertyField = value;
        }
    }

    [XmlElement("ManufacturerParty")]
    public PartyType[] ManufacturerParty
    {
        get
        {
            return this.manufacturerPartyField;
        }
        set
        {
            this.manufacturerPartyField = value;
        }
    }

    public PartyType InformationContentProviderParty
    {
        get
        {
            return this.informationContentProviderPartyField;
        }
        set
        {
            this.informationContentProviderPartyField = value;
        }
    }

    [XmlElement("OriginAddress")]
    public AddressType[] OriginAddress
    {
        get
        {
            return this.originAddressField;
        }
        set
        {
            this.originAddressField = value;
        }
    }

    [XmlElement("ItemInstance")]
    public ItemInstanceType[] ItemInstance
    {
        get
        {
            return this.itemInstanceField;
        }
        set
        {
            this.itemInstanceField = value;
        }
    }

    [XmlElement("Certificate")]
    public CertificateType[] Certificate
    {
        get
        {
            return this.certificateField;
        }
        set
        {
            this.certificateField = value;
        }
    }

    [XmlElement("Dimension")]
    public DimensionType[] Dimension
    {
        get
        {
            return this.dimensionField;
        }
        set
        {
            this.dimensionField = value;
        }
    }
}
