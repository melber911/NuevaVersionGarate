using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[DebuggerStepThrough]
[GeneratedCode("xsd", "4.0.30319.33440")]
[DesignerCategory("code")]
[XmlRoot("PartyTaxScheme", IsNullable = false, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[XmlType(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[Serializable]
public class PartyTaxSchemeType
{
    private RegistrationNameType registrationNameField;
    private CompanyIDType companyIDField;
    private TaxLevelCodeType taxLevelCodeField;
    private ExemptionReasonCodeType exemptionReasonCodeField;
    private ExemptionReasonType[] exemptionReasonField;
    private AddressType registrationAddressField;
    private TaxSchemeType taxSchemeField;

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
    public TaxLevelCodeType TaxLevelCode
    {
        get
        {
            return this.taxLevelCodeField;
        }
        set
        {
            this.taxLevelCodeField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public ExemptionReasonCodeType ExemptionReasonCode
    {
        get
        {
            return this.exemptionReasonCodeField;
        }
        set
        {
            this.exemptionReasonCodeField = value;
        }
    }

    [XmlElement("ExemptionReason", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public ExemptionReasonType[] ExemptionReason
    {
        get
        {
            return this.exemptionReasonField;
        }
        set
        {
            this.exemptionReasonField = value;
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

    public TaxSchemeType TaxScheme
    {
        get
        {
            return this.taxSchemeField;
        }
        set
        {
            this.taxSchemeField = value;
        }
    }
}
