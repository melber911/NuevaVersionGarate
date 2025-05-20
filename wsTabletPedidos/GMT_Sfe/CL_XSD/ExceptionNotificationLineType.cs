using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[DesignerCategory("code")]
[XmlType(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[XmlRoot("ExceptionNotificationLine", IsNullable = false, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[DebuggerStepThrough]
[GeneratedCode("xsd", "4.0.30319.33440")]
[Serializable]
public class ExceptionNotificationLineType
{
    private IDType idField;
    private NoteType[] noteField;
    private DescriptionType[] descriptionField;
    private ExceptionStatusCodeType exceptionStatusCodeField;
    private CollaborationPriorityCodeType collaborationPriorityCodeField;
    private ResolutionCodeType resolutionCodeField;
    private ComparedValueMeasureType comparedValueMeasureField;
    private SourceValueMeasureType sourceValueMeasureField;
    private VarianceQuantityType varianceQuantityField;
    private SupplyChainActivityTypeCodeType supplyChainActivityTypeCodeField;
    private PerformanceMetricTypeCodeType performanceMetricTypeCodeField;
    private PeriodType exceptionObservationPeriodField;
    private DocumentReferenceType[] documentReferenceField;
    private ForecastExceptionType forecastExceptionField;
    private ItemType supplyItemField;

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
    public ResolutionCodeType ResolutionCode
    {
        get
        {
            return this.resolutionCodeField;
        }
        set
        {
            this.resolutionCodeField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public ComparedValueMeasureType ComparedValueMeasure
    {
        get
        {
            return this.comparedValueMeasureField;
        }
        set
        {
            this.comparedValueMeasureField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public SourceValueMeasureType SourceValueMeasure
    {
        get
        {
            return this.sourceValueMeasureField;
        }
        set
        {
            this.sourceValueMeasureField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public VarianceQuantityType VarianceQuantity
    {
        get
        {
            return this.varianceQuantityField;
        }
        set
        {
            this.varianceQuantityField = value;
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

    public PeriodType ExceptionObservationPeriod
    {
        get
        {
            return this.exceptionObservationPeriodField;
        }
        set
        {
            this.exceptionObservationPeriodField = value;
        }
    }

    [XmlElement("DocumentReference")]
    public DocumentReferenceType[] DocumentReference
    {
        get
        {
            return this.documentReferenceField;
        }
        set
        {
            this.documentReferenceField = value;
        }
    }

    public ForecastExceptionType ForecastException
    {
        get
        {
            return this.forecastExceptionField;
        }
        set
        {
            this.forecastExceptionField = value;
        }
    }

    public ItemType SupplyItem
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
}
