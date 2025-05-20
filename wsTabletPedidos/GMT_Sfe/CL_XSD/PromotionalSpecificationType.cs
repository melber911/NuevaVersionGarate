
// Type: PromotionalSpecificationType


using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[XmlRoot("PromotionalSpecification", IsNullable = false, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[GeneratedCode("xsd", "4.0.30319.33440")]
[DebuggerStepThrough]
[DesignerCategory("code")]
[XmlType(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[Serializable]
public class PromotionalSpecificationType
{
    private SpecificationIDType specificationIDField;
    private PromotionalEventLineItemType[] promotionalEventLineItemField;
    private EventTacticType[] eventTacticField;

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public SpecificationIDType SpecificationID
    {
        get
        {
            return this.specificationIDField;
        }
        set
        {
            this.specificationIDField = value;
        }
    }

    [XmlElement("PromotionalEventLineItem")]
    public PromotionalEventLineItemType[] PromotionalEventLineItem
    {
        get
        {
            return this.promotionalEventLineItemField;
        }
        set
        {
            this.promotionalEventLineItemField = value;
        }
    }

    [XmlElement("EventTactic")]
    public EventTacticType[] EventTactic
    {
        get
        {
            return this.eventTacticField;
        }
        set
        {
            this.eventTacticField = value;
        }
    }
}
