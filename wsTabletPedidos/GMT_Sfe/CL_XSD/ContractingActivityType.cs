using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[DebuggerStepThrough]
[XmlRoot("ContractingActivity", IsNullable = false, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[GeneratedCode("xsd", "4.0.30319.33440")]
[DesignerCategory("code")]
[XmlType(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[Serializable]
public class ContractingActivityType
{
    private ActivityTypeCodeType activityTypeCodeField;
    private ActivityTypeType activityTypeField;

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public ActivityTypeCodeType ActivityTypeCode
    {
        get
        {
            return this.activityTypeCodeField;
        }
        set
        {
            this.activityTypeCodeField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public ActivityTypeType ActivityType
    {
        get
        {
            return this.activityTypeField;
        }
        set
        {
            this.activityTypeField = value;
        }
    }
}
