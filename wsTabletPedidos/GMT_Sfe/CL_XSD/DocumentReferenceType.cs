using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[XmlType(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[DesignerCategory("code")]
[DebuggerStepThrough]
[GeneratedCode("xsd", "4.0.30319.33440")]
[XmlRoot("AdditionalDocumentReference", IsNullable = false, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[Serializable]
public class DocumentReferenceType
{
    private IDType idField;
    private CopyIndicatorType copyIndicatorField;
    private UUIDType uUIDField;
    private IssueDateType issueDateField;
    private IssueTimeType issueTimeField;
    private DocumentTypeCodeType documentTypeCodeField;
    private DocumentTypeType documentTypeField;
    private XPathType[] xPathField;
    private LanguageIDType languageIDField;
    private LocaleCodeType localeCodeField;
    private VersionIDType versionIDField;
    private DocumentStatusCodeType documentStatusCodeField;
    private DocumentDescriptionType[] documentDescriptionField;
    private AttachmentType attachmentField;
    private PeriodType validityPeriodField;
    private PartyType issuerPartyField;
    private ResultOfVerificationType resultOfVerificationField;

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
    public CopyIndicatorType CopyIndicator
    {
        get
        {
            return this.copyIndicatorField;
        }
        set
        {
            this.copyIndicatorField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public UUIDType UUID
    {
        get
        {
            return this.uUIDField;
        }
        set
        {
            this.uUIDField = value;
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

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public DocumentTypeCodeType DocumentTypeCode
    {
        get
        {
            return this.documentTypeCodeField;
        }
        set
        {
            this.documentTypeCodeField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public DocumentTypeType DocumentType
    {
        get
        {
            return this.documentTypeField;
        }
        set
        {
            this.documentTypeField = value;
        }
    }

    [XmlElement("XPath", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public XPathType[] XPath
    {
        get
        {
            return this.xPathField;
        }
        set
        {
            this.xPathField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public LanguageIDType LanguageID
    {
        get
        {
            return this.languageIDField;
        }
        set
        {
            this.languageIDField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public LocaleCodeType LocaleCode
    {
        get
        {
            return this.localeCodeField;
        }
        set
        {
            this.localeCodeField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public VersionIDType VersionID
    {
        get
        {
            return this.versionIDField;
        }
        set
        {
            this.versionIDField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public DocumentStatusCodeType DocumentStatusCode
    {
        get
        {
            return this.documentStatusCodeField;
        }
        set
        {
            this.documentStatusCodeField = value;
        }
    }

    [XmlElement("DocumentDescription", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public DocumentDescriptionType[] DocumentDescription
    {
        get
        {
            return this.documentDescriptionField;
        }
        set
        {
            this.documentDescriptionField = value;
        }
    }

    public AttachmentType Attachment
    {
        get
        {
            return this.attachmentField;
        }
        set
        {
            this.attachmentField = value;
        }
    }

    public PeriodType ValidityPeriod
    {
        get
        {
            return this.validityPeriodField;
        }
        set
        {
            this.validityPeriodField = value;
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

    public ResultOfVerificationType ResultOfVerification
    {
        get
        {
            return this.resultOfVerificationField;
        }
        set
        {
            this.resultOfVerificationField = value;
        }
    }
}
