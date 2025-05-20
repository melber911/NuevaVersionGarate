using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[DesignerCategory("code")]
[GeneratedCode("xsd", "4.0.30319.33440")]
[XmlRoot("ExceptionCriteriaLine", IsNullable = false, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[XmlType(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[DebuggerStepThrough]
[Serializable]
public class ExceptionCriteriaLineType
{
    private IDType idField;
    private NoteType[] noteField;
    private ThresholdValueComparisonCodeType thresholdValueComparisonCodeField;
    private ThresholdQuantityType thresholdQuantityField;
    private ExceptionStatusCodeType exceptionStatusCodeField;
    private CollaborationPriorityCodeType collaborationPriorityCodeField;
    private ExceptionResolutionCodeType exceptionResolutionCodeField;
    private SupplyChainActivityTypeCodeType supplyChainActivityTypeCodeField;
    private PerformanceMetricTypeCodeType performanceMetricTypeCodeField;
    private PeriodType effectivePeriodField;
    private ItemType[] supplyItemField;
    private ForecastExceptionCriterionLineType forecastExceptionCriterionLineField;

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

    [XmlElement("Note", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public NoteType[] Note
    {
        get
        {
            return this.noteField;
        }
        set
        {
            this.noteField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public ThresholdValueComparisonCodeType ThresholdValueComparisonCode
    {
        get
        {
            return this.thresholdValueComparisonCodeField;
        }
        set
        {
            this.thresholdValueComparisonCodeField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public ThresholdQuantityType ThresholdQuantity
    {
        get
        {
            return this.thresholdQuantityField;
        }
        set
        {
            this.thresholdQuantityField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public ExceptionStatusCodeType ExceptionStatusCode
    {
        get
        {
            return this.exceptionStatusCodeField;
        }
        set
        {
            this.exceptionStatusCodeField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public CollaborationPriorityCodeType CollaborationPriorityCode
    {
        get
        {
            return this.collaborationPriorityCodeField;
        }
        set
        {
            this.collaborationPriorityCodeField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public ExceptionResolutionCodeType ExceptionResolutionCode
    {
        get
        {
            return this.exceptionResolutionCodeField;
        }
        set
        {
            this.exceptionResolutionCodeField = value;
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

    [XmlElement("SupplyItem")]
    public ItemType[] SupplyItem
    {
        get
        {
            return this.supplyItemField;
        }
        set
        {
            this.supplyItemField = value;
        }
    }

    public ForecastExceptionCriterionLineType ForecastExceptionCriterionLine
    {
        get
        {
            return this.forecastExceptionCriterionLineField;
        }
        set
        {
            this.forecastExceptionCriterionLineField = value;
        }
    }
}
