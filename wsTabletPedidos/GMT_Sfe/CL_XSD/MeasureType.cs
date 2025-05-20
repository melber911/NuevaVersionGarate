using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[XmlInclude(typeof(LongitudeMinutesMeasureType))]
[XmlInclude(typeof(GrossVolumeMeasureType))]
[XmlInclude(typeof(DurationMeasureType))]
[XmlInclude(typeof(ComparedValueMeasureType))]
[XmlInclude(typeof(ChargeableWeightMeasureType))]
[XmlInclude(typeof(BaseUnitMeasureType))]
[XmlInclude(typeof(AltitudeMeasureType))]
[GeneratedCode("xsd", "4.0.30319.33440")]
[DebuggerStepThrough]
[DesignerCategory("code")]
[XmlType(Namespace = "urn:un:unece:uncefact:data:specification:CoreComponentTypeSchemaModule:2")]
[XmlInclude(typeof(MeasureType1))]
[XmlInclude(typeof(ValueMeasureType))]
[XmlInclude(typeof(TareWeightMeasureType))]
[XmlInclude(typeof(SourceValueMeasureType))]
[XmlInclude(typeof(PreEventNotificationDurationMeasureType))]
[XmlInclude(typeof(PostEventNotificationDurationMeasureType))]
[XmlInclude(typeof(GrossTonnageMeasureType))]
[XmlInclude(typeof(NetWeightMeasureType))]
[XmlInclude(typeof(GrossWeightMeasureType))]
[XmlInclude(typeof(NetTonnageMeasureType))]
[XmlInclude(typeof(NetNetWeightMeasureType))]
[XmlInclude(typeof(MinimumMeasureType))]
[XmlInclude(typeof(MeasureType2))]
[XmlInclude(typeof(MaximumMeasureType))]
[XmlInclude(typeof(NetVolumeMeasureType))]
[XmlInclude(typeof(LongitudeDegreesMeasureType))]
[XmlInclude(typeof(LoadingLengthMeasureType))]
[XmlInclude(typeof(LeadTimeMeasureType))]
[XmlInclude(typeof(LatitudeMinutesMeasureType))]
[XmlInclude(typeof(LatitudeDegreesMeasureType))]
[Serializable]
public class MeasureType
{
    private string unitCodeField;
    private string unitCodeListVersionIDField;
    private Decimal valueField;

    [XmlAttribute(DataType = "normalizedString")]
    public string unitCode
    {
        get
        {
            return this.unitCodeField;
        }
        set
        {
            this.unitCodeField = value;
        }
    }

    [XmlAttribute(DataType = "normalizedString")]
    public string unitCodeListVersionID
    {
        get
        {
            return this.unitCodeListVersionIDField;
        }
        set
        {
            this.unitCodeListVersionIDField = value;
        }
    }

    [XmlText]
    public Decimal Value
    {
        get
        {
            return this.valueField;
        }
        set
        {
            this.valueField = value;
        }
    }
}
