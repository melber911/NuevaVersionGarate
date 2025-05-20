using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[XmlType(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[DebuggerStepThrough]
[XmlRoot("QualificationResolution", IsNullable = false, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[DesignerCategory("code")]
[GeneratedCode("xsd", "4.0.30319.33440")]
[Serializable]
public class QualificationResolutionType
{
    private AdmissionCodeType admissionCodeField;
    private ExclusionReasonType[] exclusionReasonField;
    private ResolutionType[] resolutionField;
    private ResolutionDateType resolutionDateField;
    private ResolutionTimeType resolutionTimeField;
    private ProcurementProjectLotType procurementProjectLotField;

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public AdmissionCodeType AdmissionCode
    {
        get
        {
            return this.admissionCodeField;
        }
        set
        {
            this.admissionCodeField = value;
        }
    }

    [XmlElement("ExclusionReason", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public ExclusionReasonType[] ExclusionReason
    {
        get
        {
            return this.exclusionReasonField;
        }
        set
        {
            this.exclusionReasonField = value;
        }
    }

    [XmlElement("Resolution", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public ResolutionType[] Resolution
    {
        get
        {
            return this.resolutionField;
        }
        set
        {
            this.resolutionField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public ResolutionDateType ResolutionDate
    {
        get
        {
            return this.resolutionDateField;
        }
        set
        {
            this.resolutionDateField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public ResolutionTimeType ResolutionTime
    {
        get
        {
            return this.resolutionTimeField;
        }
        set
        {
            this.resolutionTimeField = value;
        }
    }

    public ProcurementProjectLotType ProcurementProjectLot
    {
        get
        {
            return this.procurementProjectLotField;
        }
        set
        {
            this.procurementProjectLotField = value;
        }
    }
}
