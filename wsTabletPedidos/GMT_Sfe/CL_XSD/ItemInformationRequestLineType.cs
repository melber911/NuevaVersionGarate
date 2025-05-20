using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[XmlRoot("ItemInformationRequestLine", IsNullable = false, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[GeneratedCode("xsd", "4.0.30319.33440")]
[DebuggerStepThrough]
[XmlType(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[DesignerCategory("code")]
[Serializable]
public class ItemInformationRequestLineType
{
    private TimeFrequencyCodeType timeFrequencyCodeField;
    private SupplyChainActivityTypeCodeType supplyChainActivityTypeCodeField;
    private ForecastTypeCodeType forecastTypeCodeField;
    private PerformanceMetricTypeCodeType performanceMetricTypeCodeField;
    private PeriodType[] periodField;
    private SalesItemType[] salesItemField;

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public TimeFrequencyCodeType TimeFrequencyCode
    {
        get
        {
            return this.timeFrequencyCodeField;
        }
        set
        {
            this.timeFrequencyCodeField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public SupplyChainActivityTypeCodeType SupplyChainActivityTypeCode
    {
        get
        {
            return this.supplyChainActivityTypeCodeField;
        }
        set
        {
            this.supplyChainActivityTypeCodeField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public ForecastTypeCodeType ForecastTypeCode
    {
        get
        {
            return this.forecastTypeCodeField;
        }
        set
        {
            this.forecastTypeCodeField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public PerformanceMetricTypeCodeType PerformanceMetricTypeCode
    {
        get
        {
            return this.performanceMetricTypeCodeField;
        }
        set
        {
            this.performanceMetricTypeCodeField = value;
        }
    }

    [XmlElement("Period")]
    public PeriodType[] Period
    {
        get
        {
            return this.periodField;
        }
        set
        {
            this.periodField = value;
        }
    }

    [XmlElement("SalesItem")]
    public SalesItemType[] SalesItem
    {
        get
        {
            return this.salesItemField;
        }
        set
        {
            this.salesItemField = value;
        }
    }
}
