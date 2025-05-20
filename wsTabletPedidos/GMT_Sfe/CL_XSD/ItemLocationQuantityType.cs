using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[DesignerCategory("code")]
[XmlRoot("ItemLocationQuantity", IsNullable = false, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[GeneratedCode("xsd", "4.0.30319.33440")]
[XmlType(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[DebuggerStepThrough]
[Serializable]
public class ItemLocationQuantityType
{
    private LeadTimeMeasureType leadTimeMeasureField;
    private MinimumQuantityType minimumQuantityField;
    private MaximumQuantityType maximumQuantityField;
    private HazardousRiskIndicatorType hazardousRiskIndicatorField;
    private TradingRestrictionsType[] tradingRestrictionsField;
    private AddressType[] applicableTerritoryAddressField;
    private PriceType priceField;
    private DeliveryUnitType[] deliveryUnitField;
    private TaxCategoryType[] applicableTaxCategoryField;
    private PackageType packageField;
    private AllowanceChargeType[] allowanceChargeField;
    private DependentPriceReferenceType dependentPriceReferenceField;

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public LeadTimeMeasureType LeadTimeMeasure
    {
        get
        {
            return this.leadTimeMeasureField;
        }
        set
        {
            this.leadTimeMeasureField = value;
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

    [XmlElement("TradingRestrictions", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public TradingRestrictionsType[] TradingRestrictions
    {
        get
        {
            return this.tradingRestrictionsField;
        }
        set
        {
            this.tradingRestrictionsField = value;
        }
    }

    [XmlElement("ApplicableTerritoryAddress")]
    public AddressType[] ApplicableTerritoryAddress
    {
        get
        {
            return this.applicableTerritoryAddressField;
        }
        set
        {
            this.applicableTerritoryAddressField = value;
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

    [XmlElement("DeliveryUnit")]
    public DeliveryUnitType[] DeliveryUnit
    {
        get
        {
            return this.deliveryUnitField;
        }
        set
        {
            this.deliveryUnitField = value;
        }
    }

    [XmlElement("ApplicableTaxCategory")]
    public TaxCategoryType[] ApplicableTaxCategory
    {
        get
        {
            return this.applicableTaxCategoryField;
        }
        set
        {
            this.applicableTaxCategoryField = value;
        }
    }

    public PackageType Package
    {
        get
        {
            return this.packageField;
        }
        set
        {
            this.packageField = value;
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

    public DependentPriceReferenceType DependentPriceReference
    {
        get
        {
            return this.dependentPriceReferenceField;
        }
        set
        {
            this.dependentPriceReferenceField = value;
        }
    }
}
