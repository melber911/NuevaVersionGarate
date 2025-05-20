using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[XmlRoot("ForecastLine", IsNullable = false, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[DebuggerStepThrough]
[DesignerCategory("code")]
[XmlType(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[GeneratedCode("xsd", "4.0.30319.33440")]
[Serializable]
public class ForecastLineType
{
    private IDType idField;
    private NoteType[] noteField;
    private FrozenDocumentIndicatorType frozenDocumentIndicatorField;
    private ForecastTypeCodeType forecastTypeCodeField;
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

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public FrozenDocumentIndicatorType FrozenDocumentIndicator
    {
        get
        {
            return this.frozenDocumentIndicatorField;
        }
        set
        {
            this.frozenDocumentIndicatorField = value;
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
