using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[DebuggerStepThrough]
[XmlRoot("DeliveryTerms", IsNullable = false, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[XmlType(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[GeneratedCode("xsd", "4.0.30319.33440")]
[DesignerCategory("code")]
[Serializable]
public class DeliveryTermsType
{
    private IDType idField;
    private SpecialTermsType[] specialTermsField;
    private LossRiskResponsibilityCodeType lossRiskResponsibilityCodeField;
    private LossRiskType[] lossRiskField;
    private AmountType2 amountField;
    private LocationType1 deliveryLocationField;
    private AllowanceChargeType allowanceChargeField;

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

    [XmlElement("SpecialTerms", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public SpecialTermsType[] SpecialTerms
    {
        get
        {
            return this.specialTermsField;
        }
        set
        {
            this.specialTermsField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public LossRiskResponsibilityCodeType LossRiskResponsibilityCode
    {
        get
        {
            return this.lossRiskResponsibilityCodeField;
        }
        set
        {
            this.lossRiskResponsibilityCodeField = value;
        }
    }

    [XmlElement("LossRisk", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public LossRiskType[] LossRisk
    {
        get
        {
            return this.lossRiskField;
        }
        set
        {
            this.lossRiskField = value;
        }
    }

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

    public LocationType1 DeliveryLocation
    {
        get
        {
            return this.deliveryLocationField;
        }
        set
        {
            this.deliveryLocationField = value;
        }
    }

    public AllowanceChargeType AllowanceCharge
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
}
