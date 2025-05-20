using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[XmlType(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[GeneratedCode("xsd", "4.0.30319.33440")]
[DebuggerStepThrough]
[DesignerCategory("code")]
[XmlRoot("Signature", IsNullable = false, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[Serializable]
public class SignatureType
{
    private IDType idField;
    private NoteType[] noteField;
    private ValidationDateType validationDateField;
    private ValidationTimeType validationTimeField;
    private ValidatorIDType validatorIDField;
    private CanonicalizationMethodType canonicalizationMethodField;
    private SignatureMethodType signatureMethodField;
    private PartyType signatoryPartyField;
    private AttachmentType digitalSignatureAttachmentField;
    private DocumentReferenceType originalDocumentReferenceField;

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

    [XmlElement("Note", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public NoteType[] Note
    {
        get
        {
            return this.noteField;
        }
        set
        {
            this.noteField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public ValidationDateType ValidationDate
    {
        get
        {
            return this.validationDateField;
        }
        set
        {
            this.validationDateField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public ValidationTimeType ValidationTime
    {
        get
        {
            return this.validationTimeField;
        }
        set
        {
            this.validationTimeField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public ValidatorIDType ValidatorID
    {
        get
        {
            return this.validatorIDField;
        }
        set
        {
            this.validatorIDField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public CanonicalizationMethodType CanonicalizationMethod
    {
        get
        {
            return this.canonicalizationMethodField;
        }
        set
        {
            this.canonicalizationMethodField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public SignatureMethodType SignatureMethod
    {
        get
        {
            return this.signatureMethodField;
        }
        set
        {
            this.signatureMethodField = value;
        }
    }

    public PartyType SignatoryParty
    {
        get
        {
            return this.signatoryPartyField;
        }
        set
        {
            this.signatoryPartyField = value;
        }
    }

    public AttachmentType DigitalSignatureAttachment
    {
        get
        {
            return this.digitalSignatureAttachmentField;
        }
        set
        {
            this.digitalSignatureAttachmentField = value;
        }
    }

    public DocumentReferenceType OriginalDocumentReference
    {
        get
        {
            return this.originalDocumentReferenceField;
        }
        set
        {
            this.originalDocumentReferenceField = value;
        }
    }
}
