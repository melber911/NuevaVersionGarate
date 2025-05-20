using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[GeneratedCode("xsd", "4.0.30319.33440")]
[DebuggerStepThrough]
[XmlType(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[XmlRoot("AdditionalDocumentResponse", IsNullable = false, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[DesignerCategory("code")]
[Serializable]
public class DocumentResponseType
{
    private ResponseType responseField;
    private DocumentReferenceType[] documentReferenceField;
    private PartyType issuerPartyField;
    private PartyType recipientPartyField;
    private LineResponseType[] lineResponseField;

    public ResponseType Response
    {
        get
        {
            return this.responseField;
        }
        set
        {
            this.responseField = value;
        }
    }

    [XmlElement("DocumentReference")]
    public DocumentReferenceType[] DocumentReference
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

    public PartyType IssuerParty
    {
        get
        {
            return this.issuerPartyField;
        }
        set
        {
            this.issuerPartyField = value;
        }
    }

    public PartyType RecipientParty
    {
        get
        {
            return this.recipientPartyField;
        }
        set
        {
            this.recipientPartyField = value;
        }
    }

    [XmlElement("LineResponse")]
    public LineResponseType[] LineResponse
    {
        get
        {
            return this.lineResponseField;
        }
        set
        {
            this.lineResponseField = value;
        }
    }
}
