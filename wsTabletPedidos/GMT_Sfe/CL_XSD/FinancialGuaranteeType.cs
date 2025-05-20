using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[DebuggerStepThrough]
[XmlRoot("FinalFinancialGuarantee", IsNullable = false, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[GeneratedCode("xsd", "4.0.30319.33440")]
[DesignerCategory("code")]
[XmlType(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[Serializable]
public class FinancialGuaranteeType
{
    private GuaranteeTypeCodeType guaranteeTypeCodeField;
    private DescriptionType[] descriptionField;
    private LiabilityAmountType liabilityAmountField;
    private AmountRateType amountRateField;
    private PeriodType constitutionPeriodField;

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public GuaranteeTypeCodeType GuaranteeTypeCode
    {
        get
        {
            return this.guaranteeTypeCodeField;
        }
        set
        {
            this.guaranteeTypeCodeField = value;
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
    public LiabilityAmountType LiabilityAmount
    {
        get
        {
            return this.liabilityAmountField;
        }
        set
        {
            this.liabilityAmountField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public AmountRateType AmountRate
    {
        get
        {
            return this.amountRateField;
        }
        set
        {
            this.amountRateField = value;
        }
    }

    public PeriodType ConstitutionPeriod
    {
        get
        {
            return this.constitutionPeriodField;
        }
        set
        {
            this.constitutionPeriodField = value;
        }
    }
}
