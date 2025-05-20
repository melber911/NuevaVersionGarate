using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[GeneratedCode("xsd", "4.0.30319.33440")]
[DesignerCategory("code")]
[XmlType(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[XmlRoot("ForecastRevisionLine", IsNullable = false, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[DebuggerStepThrough]
[Serializable]
public class ForecastRevisionLineType
{
    private IDType idField;
    private NoteType[] noteField;
    private DescriptionType[] descriptionField;
    private RevisedForecastLineIDType revisedForecastLineIDField;
    private SourceForecastIssueDateType sourceForecastIssueDateField;
    private SourceForecastIssueTimeType sourceForecastIssueTimeField;
    private AdjustmentReasonCodeType adjustmentReasonCodeField;
    private PeriodType forecastPeriodField;
    private SalesItemType salesItemField;

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
    public RevisedForecastLineIDType RevisedForecastLineID
    {
        get
        {
            return this.revisedForecastLineIDField;
        }
        set
        {
            this.revisedForecastLineIDField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public SourceForecastIssueDateType SourceForecastIssueDate
    {
        get
        {
            return this.sourceForecastIssueDateField;
        }
        set
        {
            this.sourceForecastIssueDateField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public SourceForecastIssueTimeType SourceForecastIssueTime
    {
        get
        {
            return this.sourceForecastIssueTimeField;
        }
        set
        {
            this.sourceForecastIssueTimeField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public AdjustmentReasonCodeType AdjustmentReasonCode
    {
        get
        {
            return this.adjustmentReasonCodeField;
        }
        set
        {
            this.adjustmentReasonCodeField = value;
        }
    }

    public PeriodType ForecastPeriod
    {
        get
        {
            return this.forecastPeriodField;
        }
        set
        {
            this.forecastPeriodField = value;
        }
    }

    public SalesItemType SalesItem
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
