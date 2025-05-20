using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[XmlType(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[DesignerCategory("code")]
[GeneratedCode("xsd", "4.0.30319.33440")]
[XmlRoot("EnergyWaterSupply", IsNullable = false, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[DebuggerStepThrough]
[Serializable]
public class EnergyWaterSupplyType
{
    private ConsumptionReportType[] consumptionReportField;
    private EnergyTaxReportType[] energyTaxReportField;
    private ConsumptionAverageType[] consumptionAverageField;
    private ConsumptionCorrectionType[] energyWaterConsumptionCorrectionField;

    [XmlElement("ConsumptionReport")]
    public ConsumptionReportType[] ConsumptionReport
    {
        get
        {
            return this.consumptionReportField;
        }
        set
        {
            this.consumptionReportField = value;
        }
    }

    [XmlElement("EnergyTaxReport")]
    public EnergyTaxReportType[] EnergyTaxReport
    {
        get
        {
            return this.energyTaxReportField;
        }
        set
        {
            this.energyTaxReportField = value;
        }
    }

    [XmlElement("ConsumptionAverage")]
    public ConsumptionAverageType[] ConsumptionAverage
    {
        get
        {
            return this.consumptionAverageField;
        }
        set
        {
            this.consumptionAverageField = value;
        }
    }

    [XmlElement("EnergyWaterConsumptionCorrection")]
    public ConsumptionCorrectionType[] EnergyWaterConsumptionCorrection
    {
        get
        {
            return this.energyWaterConsumptionCorrectionField;
        }
        set
        {
            this.energyWaterConsumptionCorrectionField = value;
        }
    }
}
