using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[DebuggerStepThrough]
[XmlRoot("ProcessJustification", IsNullable = false, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[GeneratedCode("xsd", "4.0.30319.33440")]
[XmlType(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[DesignerCategory("code")]
[Serializable]
public class ProcessJustificationType
{
    private PreviousCancellationReasonCodeType previousCancellationReasonCodeField;
    private ProcessReasonCodeType processReasonCodeField;
    private ProcessReasonType[] processReasonField;
    private DescriptionType[] descriptionField;

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public PreviousCancellationReasonCodeType PreviousCancellationReasonCode
    {
        get
        {
            return this.previousCancellationReasonCodeField;
        }
        set
        {
            this.previousCancellationReasonCodeField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public ProcessReasonCodeType ProcessReasonCode
    {
        get
        {
            return this.processReasonCodeField;
        }
        set
        {
            this.processReasonCodeField = value;
        }
    }

    [XmlElement("ProcessReason", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public ProcessReasonType[] ProcessReason
    {
        get
        {
            return this.processReasonField;
        }
        set
        {
            this.processReasonField = value;
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
}
