using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[DebuggerStepThrough]
[GeneratedCode("xsd", "4.0.30319.33440")]
[XmlRoot("EmbassyEndorsement", IsNullable = false, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[DesignerCategory("code")]
[XmlType(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[Serializable]
public class EndorsementType
{
    private DocumentIDType documentIDField;
    private ApprovalStatusType approvalStatusField;
    private RemarksType[] remarksField;
    private EndorserPartyType endorserPartyField;
    private SignatureType[] signatureField;

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public DocumentIDType DocumentID
    {
        get
        {
            return this.documentIDField;
        }
        set
        {
            this.documentIDField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public ApprovalStatusType ApprovalStatus
    {
        get
        {
            return this.approvalStatusField;
        }
        set
        {
            this.approvalStatusField = value;
        }
    }

    [XmlElement("Remarks", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public RemarksType[] Remarks
    {
        get
        {
            return this.remarksField;
        }
        set
        {
            this.remarksField = value;
        }
    }

    public EndorserPartyType EndorserParty
    {
        get
        {
            return this.endorserPartyField;
        }
        set
        {
            this.endorserPartyField = value;
        }
    }

    [XmlElement("Signature")]
    public SignatureType[] Signature
    {
        get
        {
            return this.signatureField;
        }
        set
        {
            this.signatureField = value;
        }
    }
}
