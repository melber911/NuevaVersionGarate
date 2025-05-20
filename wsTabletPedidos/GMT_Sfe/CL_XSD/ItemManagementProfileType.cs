using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[DebuggerStepThrough]
[GeneratedCode("xsd", "4.0.30319.33440")]
[XmlRoot("ItemManagementProfile", IsNullable = false, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[DesignerCategory("code")]
[XmlType(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[Serializable]
public class ItemManagementProfileType
{
    private FrozenPeriodDaysNumericType frozenPeriodDaysNumericField;
    private MinimumInventoryQuantityType minimumInventoryQuantityField;
    private MultipleOrderQuantityType multipleOrderQuantityField;
    private OrderIntervalDaysNumericType orderIntervalDaysNumericField;
    private ReplenishmentOwnerDescriptionType[] replenishmentOwnerDescriptionField;
    private TargetServicePercentType targetServicePercentField;
    private TargetInventoryQuantityType targetInventoryQuantityField;
    private PeriodType effectivePeriodField;
    private ItemType itemField;
    private ItemLocationQuantityType itemLocationQuantityField;

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public FrozenPeriodDaysNumericType FrozenPeriodDaysNumeric
    {
        get
        {
            return this.frozenPeriodDaysNumericField;
        }
        set
        {
            this.frozenPeriodDaysNumericField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public MinimumInventoryQuantityType MinimumInventoryQuantity
    {
        get
        {
            return this.minimumInventoryQuantityField;
        }
        set
        {
            this.minimumInventoryQuantityField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public MultipleOrderQuantityType MultipleOrderQuantity
    {
        get
        {
            return this.multipleOrderQuantityField;
        }
        set
        {
            this.multipleOrderQuantityField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public OrderIntervalDaysNumericType OrderIntervalDaysNumeric
    {
        get
        {
            return this.orderIntervalDaysNumericField;
        }
        set
        {
            this.orderIntervalDaysNumericField = value;
        }
    }

    [XmlElement("ReplenishmentOwnerDescription", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public ReplenishmentOwnerDescriptionType[] ReplenishmentOwnerDescription
    {
        get
        {
            return this.replenishmentOwnerDescriptionField;
        }
        set
        {
            this.replenishmentOwnerDescriptionField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public TargetServicePercentType TargetServicePercent
    {
        get
        {
            return this.targetServicePercentField;
        }
        set
        {
            this.targetServicePercentField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public TargetInventoryQuantityType TargetInventoryQuantity
    {
        get
        {
            return this.targetInventoryQuantityField;
        }
        set
        {
            this.targetInventoryQuantityField = value;
        }
    }

    public PeriodType EffectivePeriod
    {
        get
        {
            return this.effectivePeriodField;
        }
        set
        {
            this.effectivePeriodField = value;
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

    public ItemLocationQuantityType ItemLocationQuantity
    {
        get
        {
            return this.itemLocationQuantityField;
        }
        set
        {
            this.itemLocationQuantityField = value;
        }
    }
}
