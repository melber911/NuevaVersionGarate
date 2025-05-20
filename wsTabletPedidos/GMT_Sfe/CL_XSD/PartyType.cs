using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[XmlType(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[GeneratedCode("xsd", "4.0.30319.33440")]
[DebuggerStepThrough]
[DesignerCategory("code")]
[XmlRoot("AdditionalInformationParty", IsNullable = false, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[Serializable]
public class PartyType
{
    private MarkCareIndicatorType markCareIndicatorField;
    private MarkAttentionIndicatorType markAttentionIndicatorField;
    private WebsiteURIType websiteURIField;
    private LogoReferenceIDType logoReferenceIDField;
    private EndpointIDType endpointIDField;
    private IndustryClassificationCodeType industryClassificationCodeField;
    private PartyIdentificationType[] partyIdentificationField;
    private PartyNameType[] partyNameField;
    private LanguageType languageField;
    private AddressType postalAddressField;
    private LocationType1 physicalLocationField;
    private PartyTaxSchemeType[] partyTaxSchemeField;
    private PartyLegalEntityType[] partyLegalEntityField;
    private ContactType contactField;
    private PersonType[] personField;
    private PartyType agentPartyField;
    private ServiceProviderPartyType[] serviceProviderPartyField;
    private PowerOfAttorneyType[] powerOfAttorneyField;
    private FinancialAccountType financialAccountField;

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public MarkCareIndicatorType MarkCareIndicator
    {
        get
        {
            return this.markCareIndicatorField;
        }
        set
        {
            this.markCareIndicatorField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public MarkAttentionIndicatorType MarkAttentionIndicator
    {
        get
        {
            return this.markAttentionIndicatorField;
        }
        set
        {
            this.markAttentionIndicatorField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public WebsiteURIType WebsiteURI
    {
        get
        {
            return this.websiteURIField;
        }
        set
        {
            this.websiteURIField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public LogoReferenceIDType LogoReferenceID
    {
        get
        {
            return this.logoReferenceIDField;
        }
        set
        {
            this.logoReferenceIDField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public EndpointIDType EndpointID
    {
        get
        {
            return this.endpointIDField;
        }
        set
        {
            this.endpointIDField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public IndustryClassificationCodeType IndustryClassificationCode
    {
        get
        {
            return this.industryClassificationCodeField;
        }
        set
        {
            this.industryClassificationCodeField = value;
        }
    }

    [XmlElement("PartyIdentification")]
    public PartyIdentificationType[] PartyIdentification
    {
        get
        {
            return this.partyIdentificationField;
        }
        set
        {
            this.partyIdentificationField = value;
        }
    }

    [XmlElement("PartyName")]
    public PartyNameType[] PartyName
    {
        get
        {
            return this.partyNameField;
        }
        set
        {
            this.partyNameField = value;
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

    public AddressType PostalAddress
    {
        get
        {
            return this.postalAddressField;
        }
        set
        {
            this.postalAddressField = value;
        }
    }

    public LocationType1 PhysicalLocation
    {
        get
        {
            return this.physicalLocationField;
        }
        set
        {
            this.physicalLocationField = value;
        }
    }

    [XmlElement("PartyTaxScheme")]
    public PartyTaxSchemeType[] PartyTaxScheme
    {
        get
        {
            return this.partyTaxSchemeField;
        }
        set
        {
            this.partyTaxSchemeField = value;
        }
    }

    [XmlElement("PartyLegalEntity")]
    public PartyLegalEntityType[] PartyLegalEntity
    {
        get
        {
            return this.partyLegalEntityField;
        }
        set
        {
            this.partyLegalEntityField = value;
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

    [XmlElement("Person")]
    public PersonType[] Person
    {
        get
        {
            return this.personField;
        }
        set
        {
            this.personField = value;
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

    [XmlElement("ServiceProviderParty")]
    public ServiceProviderPartyType[] ServiceProviderParty
    {
        get
        {
            return this.serviceProviderPartyField;
        }
        set
        {
            this.serviceProviderPartyField = value;
        }
    }

    [XmlElement("PowerOfAttorney")]
    public PowerOfAttorneyType[] PowerOfAttorney
    {
        get
        {
            return this.powerOfAttorneyField;
        }
        set
        {
            this.powerOfAttorneyField = value;
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
}
