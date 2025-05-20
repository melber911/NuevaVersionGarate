using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[DebuggerStepThrough]
[XmlType(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[GeneratedCode("xsd", "4.0.30319.33440")]
[XmlRoot("PartyLegalEntity", IsNullable = false, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[DesignerCategory("code")]
[Serializable]
public class PartyLegalEntityType
{
    private RegistrationNameType registrationNameField;
    private CompanyIDType companyIDField;
    private RegistrationDateType registrationDateField;
    private RegistrationExpirationDateType registrationExpirationDateField;
    private CompanyLegalFormCodeType companyLegalFormCodeField;
    private CompanyLegalFormType companyLegalFormField;
    private SoleProprietorshipIndicatorType soleProprietorshipIndicatorField;
    private CompanyLiquidationStatusCodeType companyLiquidationStatusCodeField;
    private CorporateStockAmountType corporateStockAmountField;
    private FullyPaidSharesIndicatorType fullyPaidSharesIndicatorField;
    private AddressType registrationAddressField;
    private CorporateRegistrationSchemeType corporateRegistrationSchemeField;
    private PartyType headOfficePartyField;
    private ShareholderPartyType[] shareholderPartyField;

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public RegistrationNameType RegistrationName
    {
        get
        {
            return this.registrationNameField;
        }
        set
        {
            this.registrationNameField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public CompanyIDType CompanyID
    {
        get
        {
            return this.companyIDField;
        }
        set
        {
            this.companyIDField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public RegistrationDateType RegistrationDate
    {
        get
        {
            return this.registrationDateField;
        }
        set
        {
            this.registrationDateField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public RegistrationExpirationDateType RegistrationExpirationDate
    {
        get
        {
            return this.registrationExpirationDateField;
        }
        set
        {
            this.registrationExpirationDateField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public CompanyLegalFormCodeType CompanyLegalFormCode
    {
        get
        {
            return this.companyLegalFormCodeField;
        }
        set
        {
            this.companyLegalFormCodeField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public CompanyLegalFormType CompanyLegalForm
    {
        get
        {
            return this.companyLegalFormField;
        }
        set
        {
            this.companyLegalFormField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public SoleProprietorshipIndicatorType SoleProprietorshipIndicator
    {
        get
        {
            return this.soleProprietorshipIndicatorField;
        }
        set
        {
            this.soleProprietorshipIndicatorField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public CompanyLiquidationStatusCodeType CompanyLiquidationStatusCode
    {
        get
        {
            return this.companyLiquidationStatusCodeField;
        }
        set
        {
            this.companyLiquidationStatusCodeField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public CorporateStockAmountType CorporateStockAmount
    {
        get
        {
            return this.corporateStockAmountField;
        }
        set
        {
            this.corporateStockAmountField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public FullyPaidSharesIndicatorType FullyPaidSharesIndicator
    {
        get
        {
            return this.fullyPaidSharesIndicatorField;
        }
        set
        {
            this.fullyPaidSharesIndicatorField = value;
        }
    }

    public AddressType RegistrationAddress
    {
        get
        {
            return this.registrationAddressField;
        }
        set
        {
            this.registrationAddressField = value;
        }
    }

    public CorporateRegistrationSchemeType CorporateRegistrationScheme
    {
        get
        {
            return this.corporateRegistrationSchemeField;
        }
        set
        {
            this.corporateRegistrationSchemeField = value;
        }
    }

    public PartyType HeadOfficeParty
    {
        get
        {
            return this.headOfficePartyField;
        }
        set
        {
            this.headOfficePartyField = value;
        }
    }

    [XmlElement("ShareholderParty")]
    public ShareholderPartyType[] ShareholderParty
    {
        get
        {
            return this.shareholderPartyField;
        }
        set
        {
            this.shareholderPartyField = value;
        }
    }
}
