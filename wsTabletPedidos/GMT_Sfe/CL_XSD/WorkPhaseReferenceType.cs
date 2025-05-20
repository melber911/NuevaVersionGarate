using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[XmlType(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[GeneratedCode("xsd", "4.0.30319.33440")]
[DesignerCategory("code")]
[XmlRoot("WorkPhaseReference", IsNullable = false, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[DebuggerStepThrough]
[Serializable]
public class WorkPhaseReferenceType
{
    private IDType idField;
    private WorkPhaseCodeType workPhaseCodeField;
    private WorkPhaseType[] workPhaseField;
    private ProgressPercentType progressPercentField;
    private StartDateType startDateField;
    private EndDateType endDateField;
    private DocumentReferenceType[] workOrderDocumentReferenceField;

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

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public WorkPhaseCodeType WorkPhaseCode
    {
        get
        {
            return this.workPhaseCodeField;
        }
        set
        {
            this.workPhaseCodeField = value;
        }
    }

    [XmlElement("WorkPhase", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public WorkPhaseType[] WorkPhase
    {
        get
        {
            return this.workPhaseField;
        }
        set
        {
            this.workPhaseField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public ProgressPercentType ProgressPercent
    {
        get
        {
            return this.progressPercentField;
        }
        set
        {
            this.progressPercentField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public StartDateType StartDate
    {
        get
        {
            return this.startDateField;
        }
        set
        {
            this.startDateField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public EndDateType EndDate
    {
        get
        {
            return this.endDateField;
        }
        set
        {
            this.endDateField = value;
        }
    }

    [XmlElement("WorkOrderDocumentReference")]
    public DocumentReferenceType[] WorkOrderDocumentReference
    {
        get
        {
            return this.workOrderDocumentReferenceField;
        }
        set
        {
            this.workOrderDocumentReferenceField = value;
        }
    }
}
