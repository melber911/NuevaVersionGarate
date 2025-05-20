using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[XmlRoot("AdditionalItemProperty", IsNullable = false, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[GeneratedCode("xsd", "4.0.30319.33440")]
[DebuggerStepThrough]
[DesignerCategory("code")]
[XmlType(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[Serializable]
public class ItemPropertyType
{
    private IDType idField;
    private NameType1 nameField;
    private NameCodeType nameCodeField;
    private TestMethodType testMethodField;
    private ValueType valueField;
    private ValueQuantityType valueQuantityField;
    private ValueQualifierType[] valueQualifierField;
    private ImportanceCodeType importanceCodeField;
    private ListValueType[] listValueField;
    private PeriodType usabilityPeriodField;
    private ItemPropertyGroupType[] itemPropertyGroupField;
    private DimensionType rangeDimensionField;
    private ItemPropertyRangeType itemPropertyRangeField;

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
    public NameCodeType NameCode
    {
        get
        {
            return this.nameCodeField;
        }
        set
        {
            this.nameCodeField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public TestMethodType TestMethod
    {
        get
        {
            return this.testMethodField;
        }
        set
        {
            this.testMethodField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public ValueType Value
    {
        get
        {
            return this.valueField;
        }
        set
        {
            this.valueField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public ValueQuantityType ValueQuantity
    {
        get
        {
            return this.valueQuantityField;
        }
        set
        {
            this.valueQuantityField = value;
        }
    }

    [XmlElement("ValueQualifier", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public ValueQualifierType[] ValueQualifier
    {
        get
        {
            return this.valueQualifierField;
        }
        set
        {
            this.valueQualifierField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public ImportanceCodeType ImportanceCode
    {
        get
        {
            return this.importanceCodeField;
        }
        set
        {
            this.importanceCodeField = value;
        }
    }

    [XmlElement("ListValue", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public ListValueType[] ListValue
    {
        get
        {
            return this.listValueField;
        }
        set
        {
            this.listValueField = value;
        }
    }

    public PeriodType UsabilityPeriod
    {
        get
        {
            return this.usabilityPeriodField;
        }
        set
        {
            this.usabilityPeriodField = value;
        }
    }

    [XmlElement("ItemPropertyGroup")]
    public ItemPropertyGroupType[] ItemPropertyGroup
    {
        get
        {
            return this.itemPropertyGroupField;
        }
        set
        {
            this.itemPropertyGroupField = value;
        }
    }

    public DimensionType RangeDimension
    {
        get
        {
            return this.rangeDimensionField;
        }
        set
        {
            this.rangeDimensionField = value;
        }
    }

    public ItemPropertyRangeType ItemPropertyRange
    {
        get
        {
            return this.itemPropertyRangeField;
        }
        set
        {
            this.itemPropertyRangeField = value;
        }
    }
}
