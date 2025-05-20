using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[DebuggerStepThrough]
[XmlRoot("CurrentStatus", IsNullable = false, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[GeneratedCode("xsd", "4.0.30319.33440")]
[DesignerCategory("code")]
[XmlType(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[Serializable]
public class StatusType
{
    private ConditionCodeType conditionCodeField;
    private ReferenceDateType referenceDateField;
    private ReferenceTimeType referenceTimeField;
    private DescriptionType[] descriptionField;
    private StatusReasonCodeType statusReasonCodeField;
    private StatusReasonType[] statusReasonField;
    private SequenceIDType sequenceIDField;
    private TextType2[] textField;
    private IndicationIndicatorType indicationIndicatorField;
    private PercentType1 percentField;
    private ReliabilityPercentType reliabilityPercentField;
    private ConditionType1[] conditionField;

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public ConditionCodeType ConditionCode
    {
        get
        {
            return this.conditionCodeField;
        }
        set
        {
            this.conditionCodeField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public ReferenceDateType ReferenceDate
    {
        get
        {
            return this.referenceDateField;
        }
        set
        {
            this.referenceDateField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public ReferenceTimeType ReferenceTime
    {
        get
        {
            return this.referenceTimeField;
        }
        set
        {
            this.referenceTimeField = value;
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
    public StatusReasonCodeType StatusReasonCode
    {
        get
        {
            return this.statusReasonCodeField;
        }
        set
        {
            this.statusReasonCodeField = value;
        }
    }

    [XmlElement("StatusReason", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public StatusReasonType[] StatusReason
    {
        get
        {
            return this.statusReasonField;
        }
        set
        {
            this.statusReasonField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public SequenceIDType SequenceID
    {
        get
        {
            return this.sequenceIDField;
        }
        set
        {
            this.sequenceIDField = value;
        }
    }

    [XmlElement("Text", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public TextType2[] Text
    {
        get
        {
            return this.textField;
        }
        set
        {
            this.textField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public IndicationIndicatorType IndicationIndicator
    {
        get
        {
            return this.indicationIndicatorField;
        }
        set
        {
            this.indicationIndicatorField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public PercentType1 Percent
    {
        get
        {
            return this.percentField;
        }
        set
        {
            this.percentField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public ReliabilityPercentType ReliabilityPercent
    {
        get
        {
            return this.reliabilityPercentField;
        }
        set
        {
            this.reliabilityPercentField = value;
        }
    }

    [XmlElement("Condition")]
    public ConditionType1[] Condition
    {
        get
        {
            return this.conditionField;
        }
        set
        {
            this.conditionField = value;
        }
    }
}
