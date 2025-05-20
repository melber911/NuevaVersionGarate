using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[XmlRoot("TendererPartyQualification", IsNullable = false, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[GeneratedCode("xsd", "4.0.30319.33440")]
[DesignerCategory("code")]
[XmlType(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[DebuggerStepThrough]
[Serializable]
public class TendererPartyQualificationType
{
    private ProcurementProjectLotType[] interestedProcurementProjectLotField;
    private QualifyingPartyType mainQualifyingPartyField;
    private QualifyingPartyType[] additionalQualifyingPartyField;

    [XmlElement("InterestedProcurementProjectLot")]
    public ProcurementProjectLotType[] InterestedProcurementProjectLot
    {
        get
        {
            return this.interestedProcurementProjectLotField;
        }
        set
        {
            this.interestedProcurementProjectLotField = value;
        }
    }

    public QualifyingPartyType MainQualifyingParty
    {
        get
        {
            return this.mainQualifyingPartyField;
        }
        set
        {
            this.mainQualifyingPartyField = value;
        }
    }

    [XmlElement("AdditionalQualifyingParty")]
    public QualifyingPartyType[] AdditionalQualifyingParty
    {
        get
        {
            return this.additionalQualifyingPartyField;
        }
        set
        {
            this.additionalQualifyingPartyField = value;
        }
    }
}
