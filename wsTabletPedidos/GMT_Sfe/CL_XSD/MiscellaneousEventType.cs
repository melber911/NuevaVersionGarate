using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[DesignerCategory("code")]
[XmlType(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[XmlRoot("MiscellaneousEvent", IsNullable = false, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[GeneratedCode("xsd", "4.0.30319.33440")]
[DebuggerStepThrough]
[Serializable]
public class MiscellaneousEventType
{
    private MiscellaneousEventTypeCodeType miscellaneousEventTypeCodeField;
    private EventLineItemType[] eventLineItemField;

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public MiscellaneousEventTypeCodeType MiscellaneousEventTypeCode
    {
        get
        {
            return this.miscellaneousEventTypeCodeField;
        }
        set
        {
            this.miscellaneousEventTypeCodeField = value;
        }
    }

    [XmlElement("EventLineItem")]
    public EventLineItemType[] EventLineItem
    {
        get
        {
            return this.eventLineItemField;
        }
        set
        {
            this.eventLineItemField = value;
        }
    }
}
