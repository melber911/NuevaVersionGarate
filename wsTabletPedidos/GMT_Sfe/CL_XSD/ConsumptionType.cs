using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[XmlType(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[XmlRoot("Consumption", IsNullable = false, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[DebuggerStepThrough]
[DesignerCategory("code")]
[GeneratedCode("xsd", "4.0.30319.33440")]
[Serializable]
public class ConsumptionType
{
    private UtilityStatementTypeCodeType utilityStatementTypeCodeField;
    private PeriodType mainPeriodField;
    private AllowanceChargeType[] allowanceChargeField;
    private TaxTotalType[] taxTotalField;
    private EnergyWaterSupplyType energyWaterSupplyField;
    private TelecommunicationsSupplyType telecommunicationsSupplyField;
    private MonetaryTotalType legalMonetaryTotalField;

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public UtilityStatementTypeCodeType UtilityStatementTypeCode
    {
        get
        {
            return this.utilityStatementTypeCodeField;
        }
        set
        {
            this.utilityStatementTypeCodeField = value;
        }
    }

    public PeriodType MainPeriod
    {
        get
        {
            return this.mainPeriodField;
        }
        set
        {
            this.mainPeriodField = value;
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

    [XmlElement("TaxTotal")]
    public TaxTotalType[] TaxTotal
    {
        get
        {
            return this.taxTotalField;
        }
        set
        {
            this.taxTotalField = value;
        }
    }

    public EnergyWaterSupplyType EnergyWaterSupply
    {
        get
        {
            return this.energyWaterSupplyField;
        }
        set
        {
            this.energyWaterSupplyField = value;
        }
    }

    public TelecommunicationsSupplyType TelecommunicationsSupply
    {
        get
        {
            return this.telecommunicationsSupplyField;
        }
        set
        {
            this.telecommunicationsSupplyField = value;
        }
    }

    public MonetaryTotalType LegalMonetaryTotal
    {
        get
        {
            return this.legalMonetaryTotalField;
        }
        set
        {
            this.legalMonetaryTotalField = value;
        }
    }
}
