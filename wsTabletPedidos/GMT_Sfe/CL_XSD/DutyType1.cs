using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[DesignerCategory("code")]
[GeneratedCode("xsd", "4.0.30319.33440")]
[XmlRoot("CallDuty", IsNullable = false, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[XmlType(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2", TypeName = "DutyType")]
[DebuggerStepThrough]
[Serializable]
public class DutyType1
{
    private AmountType2 amountField;
    private DutyType dutyField;
    private DutyCodeType dutyCodeField;
    private TaxCategoryType taxCategoryField;

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public AmountType2 Amount
    {
        get
        {
            return this.amountField;
        }
        set
        {
            this.amountField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public DutyType Duty
    {
        get
        {
            return this.dutyField;
        }
        set
        {
            this.dutyField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public DutyCodeType DutyCode
    {
        get
        {
            return this.dutyCodeField;
        }
        set
        {
            this.dutyCodeField = value;
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
}
