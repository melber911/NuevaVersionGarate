using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[XmlInclude(typeof(StartTimeType))]
[XmlInclude(typeof(IssueTimeType))]
[XmlType(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:UnqualifiedDataTypes-2")]
[XmlInclude(typeof(SourceForecastIssueTimeType))]
[XmlInclude(typeof(RevisionTimeType))]
[XmlInclude(typeof(ResponseTimeType))]
[XmlInclude(typeof(ResolutionTimeType))]
[XmlInclude(typeof(RequiredDeliveryTimeType))]
[XmlInclude(typeof(RequestedDespatchTimeType))]
[XmlInclude(typeof(RegisteredTimeType))]
[XmlInclude(typeof(ReferenceTimeType))]
[XmlInclude(typeof(PaidTimeType))]
[XmlInclude(typeof(OccurrenceTimeType))]
[XmlInclude(typeof(NominationTimeType))]
[XmlInclude(typeof(ManufactureTimeType))]
[XmlInclude(typeof(LatestPickupTimeType))]
[XmlInclude(typeof(LatestDeliveryTimeType))]
[XmlInclude(typeof(LastRevisionTimeType))]
[XmlInclude(typeof(ValidationTimeType))]
[XmlInclude(typeof(GuaranteedDespatchTimeType))]
[XmlInclude(typeof(ExpiryTimeType))]
[XmlInclude(typeof(EstimatedDespatchTimeType))]
[XmlInclude(typeof(EstimatedDeliveryTimeType))]
[XmlInclude(typeof(EndTimeType))]
[XmlInclude(typeof(EffectiveTimeType))]
[XmlInclude(typeof(EarliestPickupTimeType))]
[XmlInclude(typeof(ComparisonForecastIssueTimeType))]
[XmlInclude(typeof(CallTimeType))]
[XmlInclude(typeof(AwardTimeType))]
[XmlInclude(typeof(ActualPickupTimeType))]
[XmlInclude(typeof(ActualDespatchTimeType))]
[XmlInclude(typeof(ActualDeliveryTimeType))]
[GeneratedCode("xsd", "4.0.30319.33440")]
[DebuggerStepThrough]
[DesignerCategory("code")]
[Serializable]
public class TimeType
{
    private DateTime valueField;

    [XmlIgnore]
    [XmlText(DataType = "time")]
    public DateTime Value
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

    [XmlText(DataType = "string")]
    public String TimeString
    {
        get { return this.valueField.ToString("hh:mm:ss"); }
        set { this.valueField = DateTime.ParseExact(value, "hh:mm:ss", System.Globalization.CultureInfo.InvariantCulture); }
    }
}
