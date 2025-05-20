using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[DesignerCategory("code")]
[XmlType(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[XmlRoot("BusinessClassificationScheme", IsNullable = false, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[GeneratedCode("xsd", "4.0.30319.33440")]
[DebuggerStepThrough]
[Serializable]
public class ClassificationSchemeType
{
    private IDType idField;
    private UUIDType uUIDField;
    private LastRevisionDateType lastRevisionDateField;
    private LastRevisionTimeType lastRevisionTimeField;
    private NoteType[] noteField;
    private NameType1 nameField;
    private DescriptionType[] descriptionField;
    private AgencyIDType agencyIDField;
    private AgencyNameType agencyNameField;
    private VersionIDType versionIDField;
    private URIType uRIField;
    private SchemeURIType schemeURIField;
    private LanguageIDType languageIDField;
    private ClassificationCategoryType[] classificationCategoryField;

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
    public LastRevisionDateType LastRevisionDate
    {
        get
        {
            return this.lastRevisionDateField;
        }
        set
        {
            this.lastRevisionDateField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public LastRevisionTimeType LastRevisionTime
    {
        get
        {
            return this.lastRevisionTimeField;
        }
        set
        {
            this.lastRevisionTimeField = value;
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
    public NameType1 Name
    {
        get
        {
            return this.nameField;
        }
        set
        {
            this.nameField = value;
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

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public AgencyIDType AgencyID
    {
        get
        {
            return this.agencyIDField;
        }
        set
        {
            this.agencyIDField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public AgencyNameType AgencyName
    {
        get
        {
            return this.agencyNameField;
        }
        set
        {
            this.agencyNameField = value;
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
    public SchemeURIType SchemeURI
    {
        get
        {
            return this.schemeURIField;
        }
        set
        {
            this.schemeURIField = value;
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

    [XmlElement("ClassificationCategory")]
    public ClassificationCategoryType[] ClassificationCategory
    {
        get
        {
            return this.classificationCategoryField;
        }
        set
        {
            this.classificationCategoryField = value;
        }
    }
}
