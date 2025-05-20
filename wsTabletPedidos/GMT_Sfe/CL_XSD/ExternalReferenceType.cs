using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[DesignerCategory("code")]
[DebuggerStepThrough]
[XmlRoot("ExternalReference", IsNullable = false, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[GeneratedCode("xsd", "4.0.30319.33440")]
[XmlType(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[Serializable]
public class ExternalReferenceType
{
    private URIType uRIField;
    private DocumentHashType documentHashField;
    private HashAlgorithmMethodType hashAlgorithmMethodField;
    private ExpiryDateType expiryDateField;
    private ExpiryTimeType expiryTimeField;
    private MimeCodeType mimeCodeField;
    private FormatCodeType formatCodeField;
    private EncodingCodeType encodingCodeField;
    private CharacterSetCodeType characterSetCodeField;
    private FileNameType fileNameField;
    private DescriptionType[] descriptionField;

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public URIType URI
    {
        get
        {
            return this.uRIField;
        }
        set
        {
            this.uRIField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public DocumentHashType DocumentHash
    {
        get
        {
            return this.documentHashField;
        }
        set
        {
            this.documentHashField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public HashAlgorithmMethodType HashAlgorithmMethod
    {
        get
        {
            return this.hashAlgorithmMethodField;
        }
        set
        {
            this.hashAlgorithmMethodField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public ExpiryDateType ExpiryDate
    {
        get
        {
            return this.expiryDateField;
        }
        set
        {
            this.expiryDateField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public ExpiryTimeType ExpiryTime
    {
        get
        {
            return this.expiryTimeField;
        }
        set
        {
            this.expiryTimeField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public MimeCodeType MimeCode
    {
        get
        {
            return this.mimeCodeField;
        }
        set
        {
            this.mimeCodeField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public FormatCodeType FormatCode
    {
        get
        {
            return this.formatCodeField;
        }
        set
        {
            this.formatCodeField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public EncodingCodeType EncodingCode
    {
        get
        {
            return this.encodingCodeField;
        }
        set
        {
            this.encodingCodeField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public CharacterSetCodeType CharacterSetCode
    {
        get
        {
            return this.characterSetCodeField;
        }
        set
        {
            this.characterSetCodeField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public FileNameType FileName
    {
        get
        {
            return this.fileNameField;
        }
        set
        {
            this.fileNameField = value;
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
