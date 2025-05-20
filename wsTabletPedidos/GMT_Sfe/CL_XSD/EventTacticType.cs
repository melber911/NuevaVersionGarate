using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[GeneratedCode("xsd", "4.0.30319.33440")]
[DebuggerStepThrough]
[DesignerCategory("code")]
[XmlType(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[XmlRoot("EventTactic", IsNullable = false, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[Serializable]
public class EventTacticType
{
    private CommentType commentField;
    private QuantityType2 quantityField;
    private EventTacticEnumerationType eventTacticEnumerationField;
    private PeriodType periodField;

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public CommentType Comment
    {
        get
        {
            return this.commentField;
        }
        set
        {
            this.commentField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public QuantityType2 Quantity
    {
        get
        {
            return this.quantityField;
        }
        set
        {
            this.quantityField = value;
        }
    }

    public EventTacticEnumerationType EventTacticEnumeration
    {
        get
        {
            return this.eventTacticEnumerationField;
        }
        set
        {
            this.eventTacticEnumerationField = value;
        }
    }

    public PeriodType Period
    {
        get
        {
            return this.periodField;
        }
        set
        {
            this.periodField = value;
        }
    }
}
