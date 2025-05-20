using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[DebuggerStepThrough]
[GeneratedCode("xsd", "4.0.30319.33440")]
[DesignerCategory("code")]
[XmlType(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[XmlRoot("UtilityItem", IsNullable = false, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[Serializable]
public class UtilityItemType
{
    private IDType idField;
    private SubscriberIDType subscriberIDField;
    private SubscriberTypeType subscriberTypeField;
    private SubscriberTypeCodeType subscriberTypeCodeField;
    private DescriptionType[] descriptionField;
    private PackQuantityType packQuantityField;
    private PackSizeNumericType packSizeNumericField;
    private ConsumptionTypeType consumptionTypeField;
    private ConsumptionTypeCodeType consumptionTypeCodeField;
    private CurrentChargeTypeType currentChargeTypeField;
    private CurrentChargeTypeCodeType currentChargeTypeCodeField;
    private OneTimeChargeTypeType oneTimeChargeTypeField;
    private OneTimeChargeTypeCodeType oneTimeChargeTypeCodeField;
    private TaxCategoryType taxCategoryField;
    private ContractType contractField;

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
    public SubscriberIDType SubscriberID
    {
        get
        {
            return this.subscriberIDField;
        }
        set
        {
            this.subscriberIDField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public SubscriberTypeType SubscriberType
    {
        get
        {
            return this.subscriberTypeField;
        }
        set
        {
            this.subscriberTypeField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public SubscriberTypeCodeType SubscriberTypeCode
    {
        get
        {
            return this.subscriberTypeCodeField;
        }
        set
        {
            this.subscriberTypeCodeField = value;
        }
    }

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
    public ConsumptionTypeType ConsumptionType
    {
        get
        {
            return this.consumptionTypeField;
        }
        set
        {
            this.consumptionTypeField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public ConsumptionTypeCodeType ConsumptionTypeCode
    {
        get
        {
            return this.consumptionTypeCodeField;
        }
        set
        {
            this.consumptionTypeCodeField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public CurrentChargeTypeType CurrentChargeType
    {
        get
        {
            return this.currentChargeTypeField;
        }
        set
        {
            this.currentChargeTypeField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public CurrentChargeTypeCodeType CurrentChargeTypeCode
    {
        get
        {
            return this.currentChargeTypeCodeField;
        }
        set
        {
            this.currentChargeTypeCodeField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public OneTimeChargeTypeType OneTimeChargeType
    {
        get
        {
            return this.oneTimeChargeTypeField;
        }
        set
        {
            this.oneTimeChargeTypeField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public OneTimeChargeTypeCodeType OneTimeChargeTypeCode
    {
        get
        {
            return this.oneTimeChargeTypeCodeField;
        }
        set
        {
            this.oneTimeChargeTypeCodeField = value;
        }
    }

    public TaxCategoryType TaxCategory
    {
        get
        {
            return this.taxCategoryField;
        }
        set
        {
            this.taxCategoryField = value;
        }
    }

    public ContractType Contract
    {
        get
        {
            return this.contractField;
        }
        set
        {
            this.contractField = value;
        }
    }
}
