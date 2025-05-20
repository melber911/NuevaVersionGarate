using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[DesignerCategory("code")]
[GeneratedCode("xsd", "4.0.30319.33440")]
[DebuggerStepThrough]
[XmlType(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[XmlRoot("ScheduledServiceFrequency", IsNullable = false, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[Serializable]
public class ServiceFrequencyType
{
    private WeekDayCodeType weekDayCodeField;

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public WeekDayCodeType WeekDayCode
    {
        get
        {
            return this.weekDayCodeField;
        }
        set
        {
            this.weekDayCodeField = value;
        }
    }
}
