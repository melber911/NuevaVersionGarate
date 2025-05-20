using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[GeneratedCode("xsd", "4.0.30319.33440")]
[DebuggerStepThrough]
[XmlType(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[XmlRoot("Evidence", IsNullable = false, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[DesignerCategory("code")]
[Serializable]
public class EvidenceType
{
    private IDType idField;
    private EvidenceTypeCodeType evidenceTypeCodeField;
    private DescriptionType[] descriptionField;
    private CandidateStatementType[] candidateStatementField;
    private PartyType evidenceIssuingPartyField;
    private DocumentReferenceType documentReferenceField;
    private LanguageType languageField;

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
    public EvidenceTypeCodeType EvidenceTypeCode
    {
        get
        {
            return this.evidenceTypeCodeField;
        }
        set
        {
            this.evidenceTypeCodeField = value;
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

    [XmlElement("CandidateStatement", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public CandidateStatementType[] CandidateStatement
    {
        get
        {
            return this.candidateStatementField;
        }
        set
        {
            this.candidateStatementField = value;
        }
    }

    public PartyType EvidenceIssuingParty
    {
        get
        {
            return this.evidenceIssuingPartyField;
        }
        set
        {
            this.evidenceIssuingPartyField = value;
        }
    }

    public DocumentReferenceType DocumentReference
    {
        get
        {
            return this.documentReferenceField;
        }
        set
        {
            this.documentReferenceField = value;
        }
    }

    public LanguageType Language
    {
        get
        {
            return this.languageField;
        }
        set
        {
            this.languageField = value;
        }
    }
}
