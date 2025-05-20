using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[GeneratedCode("xsd", "4.0.30319.33440")]
[DebuggerStepThrough]
[DesignerCategory("code")]
[XmlType(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[XmlRoot("PowerOfAttorney", IsNullable = false, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[Serializable]
public class PowerOfAttorneyType
{
    private IDType idField;
    private IssueDateType issueDateField;
    private IssueTimeType issueTimeField;
    private DescriptionType[] descriptionField;
    private PartyType notaryPartyField;
    private PartyType agentPartyField;
    private PartyType[] witnessPartyField;
    private DocumentReferenceType[] mandateDocumentReferenceField;

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
    public IssueDateType IssueDate
    {
        get
        {
            return this.issueDateField;
        }
        set
        {
            this.issueDateField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public IssueTimeType IssueTime
    {
        get
        {
            return this.issueTimeField;
        }
        set
        {
            this.issueTimeField = value;
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

    public PartyType NotaryParty
    {
        get
        {
            return this.notaryPartyField;
        }
        set
        {
            this.notaryPartyField = value;
        }
    }

    public PartyType AgentParty
    {
        get
        {
            return this.agentPartyField;
        }
        set
        {
            this.agentPartyField = value;
        }
    }

    [XmlElement("WitnessParty")]
    public PartyType[] WitnessParty
    {
        get
        {
            return this.witnessPartyField;
        }
        set
        {
            this.witnessPartyField = value;
        }
    }

    [XmlElement("MandateDocumentReference")]
    public DocumentReferenceType[] MandateDocumentReference
    {
        get
        {
            return this.mandateDocumentReferenceField;
        }
        set
        {
            this.mandateDocumentReferenceField = value;
        }
    }
}
