using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[DesignerCategory("code")]
[XmlType(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[GeneratedCode("xsd", "4.0.30319.33440")]
[DebuggerStepThrough]
[XmlRoot("ConsumptionCorrection", IsNullable = false, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[Serializable]
public class ConsumptionCorrectionType
{
    private CorrectionTypeType correctionTypeField;
    private CorrectionTypeCodeType correctionTypeCodeField;
    private MeterNumberType meterNumberField;
    private GasPressureQuantityType gasPressureQuantityField;
    private ActualTemperatureReductionQuantityType actualTemperatureReductionQuantityField;
    private NormalTemperatureReductionQuantityType normalTemperatureReductionQuantityField;
    private DifferenceTemperatureReductionQuantityType differenceTemperatureReductionQuantityField;
    private DescriptionType[] descriptionField;
    private CorrectionUnitAmountType correctionUnitAmountField;
    private ConsumptionEnergyQuantityType consumptionEnergyQuantityField;
    private ConsumptionWaterQuantityType consumptionWaterQuantityField;
    private CorrectionAmountType correctionAmountField;

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public CorrectionTypeType CorrectionType
    {
        get
        {
            return this.correctionTypeField;
        }
        set
        {
            this.correctionTypeField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public CorrectionTypeCodeType CorrectionTypeCode
    {
        get
        {
            return this.correctionTypeCodeField;
        }
        set
        {
            this.correctionTypeCodeField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public MeterNumberType MeterNumber
    {
        get
        {
            return this.meterNumberField;
        }
        set
        {
            this.meterNumberField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public GasPressureQuantityType GasPressureQuantity
    {
        get
        {
            return this.gasPressureQuantityField;
        }
        set
        {
            this.gasPressureQuantityField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public ActualTemperatureReductionQuantityType ActualTemperatureReductionQuantity
    {
        get
        {
            return this.actualTemperatureReductionQuantityField;
        }
        set
        {
            this.actualTemperatureReductionQuantityField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public NormalTemperatureReductionQuantityType NormalTemperatureReductionQuantity
    {
        get
        {
            return this.normalTemperatureReductionQuantityField;
        }
        set
        {
            this.normalTemperatureReductionQuantityField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public DifferenceTemperatureReductionQuantityType DifferenceTemperatureReductionQuantity
    {
        get
        {
            return this.differenceTemperatureReductionQuantityField;
        }
        set
        {
            this.differenceTemperatureReductionQuantityField = value;
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
    public CorrectionUnitAmountType CorrectionUnitAmount
    {
        get
        {
            return this.correctionUnitAmountField;
        }
        set
        {
            this.correctionUnitAmountField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public ConsumptionEnergyQuantityType ConsumptionEnergyQuantity
    {
        get
        {
            return this.consumptionEnergyQuantityField;
        }
        set
        {
            this.consumptionEnergyQuantityField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public ConsumptionWaterQuantityType ConsumptionWaterQuantity
    {
        get
        {
            return this.consumptionWaterQuantityField;
        }
        set
        {
            this.consumptionWaterQuantityField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public CorrectionAmountType CorrectionAmount
    {
        get
        {
            return this.correctionAmountField;
        }
        set
        {
            this.correctionAmountField = value;
        }
    }
}
