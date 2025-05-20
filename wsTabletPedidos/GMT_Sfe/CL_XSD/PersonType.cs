using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[GeneratedCode("xsd", "4.0.30319.33440")]
[DesignerCategory("code")]
[XmlType(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[XmlRoot("CrewMemberPerson", IsNullable = false, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[DebuggerStepThrough]
[Serializable]
public class PersonType
{
    private IDType idField;
    private FirstNameType firstNameField;
    private FamilyNameType familyNameField;
    private TitleType titleField;
    private MiddleNameType middleNameField;
    private OtherNameType otherNameField;
    private NameSuffixType nameSuffixField;
    private JobTitleType jobTitleField;
    private NationalityIDType nationalityIDField;
    private GenderCodeType genderCodeField;
    private BirthDateType birthDateField;
    private BirthplaceNameType birthplaceNameField;
    private OrganizationDepartmentType organizationDepartmentField;
    private ContactType contactField;
    private FinancialAccountType financialAccountField;
    private DocumentReferenceType[] identityDocumentReferenceField;
    private AddressType residenceAddressField;

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
    public FirstNameType FirstName
    {
        get
        {
            return this.firstNameField;
        }
        set
        {
            this.firstNameField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public FamilyNameType FamilyName
    {
        get
        {
            return this.familyNameField;
        }
        set
        {
            this.familyNameField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public TitleType Title
    {
        get
        {
            return this.titleField;
        }
        set
        {
            this.titleField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public MiddleNameType MiddleName
    {
        get
        {
            return this.middleNameField;
        }
        set
        {
            this.middleNameField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public OtherNameType OtherName
    {
        get
        {
            return this.otherNameField;
        }
        set
        {
            this.otherNameField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public NameSuffixType NameSuffix
    {
        get
        {
            return this.nameSuffixField;
        }
        set
        {
            this.nameSuffixField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public JobTitleType JobTitle
    {
        get
        {
            return this.jobTitleField;
        }
        set
        {
            this.jobTitleField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public NationalityIDType NationalityID
    {
        get
        {
            return this.nationalityIDField;
        }
        set
        {
            this.nationalityIDField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public GenderCodeType GenderCode
    {
        get
        {
            return this.genderCodeField;
        }
        set
        {
            this.genderCodeField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public BirthDateType BirthDate
    {
        get
        {
            return this.birthDateField;
        }
        set
        {
            this.birthDateField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public BirthplaceNameType BirthplaceName
    {
        get
        {
            return this.birthplaceNameField;
        }
        set
        {
            this.birthplaceNameField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public OrganizationDepartmentType OrganizationDepartment
    {
        get
        {
            return this.organizationDepartmentField;
        }
        set
        {
            this.organizationDepartmentField = value;
        }
    }

    public ContactType Contact
    {
        get
        {
            return this.contactField;
        }
        set
        {
            this.contactField = value;
        }
    }

    public FinancialAccountType FinancialAccount
    {
        get
        {
            return this.financialAccountField;
        }
        set
        {
            this.financialAccountField = value;
        }
    }

    [XmlElement("IdentityDocumentReference")]
    public DocumentReferenceType[] IdentityDocumentReference
    {
        get
        {
            return this.identityDocumentReferenceField;
        }
        set
        {
            this.identityDocumentReferenceField = value;
        }
    }

    public AddressType ResidenceAddress
    {
        get
        {
            return this.residenceAddressField;
        }
        set
        {
            this.residenceAddressField = value;
        }
    }
}
