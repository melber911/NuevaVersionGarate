using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[XmlRoot("FinancialAccount", IsNullable = false, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[DesignerCategory("code")]
[XmlType(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[DebuggerStepThrough]
[GeneratedCode("xsd", "4.0.30319.33440")]
[Serializable]
public class FinancialAccountType
{
    private IDType idField;
    private NameType1 nameField;
    private AliasNameType aliasNameField;
    private AccountTypeCodeType accountTypeCodeField;
    private AccountFormatCodeType accountFormatCodeField;
    private CurrencyCodeType currencyCodeField;
    private PaymentNoteType[] paymentNoteField;
    private BranchType financialInstitutionBranchField;
    private CountryType countryField;

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

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public AliasNameType AliasName
    {
        get
        {
            return this.aliasNameField;
        }
        set
        {
            this.aliasNameField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public AccountTypeCodeType AccountTypeCode
    {
        get
        {
            return this.accountTypeCodeField;
        }
        set
        {
            this.accountTypeCodeField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public AccountFormatCodeType AccountFormatCode
    {
        get
        {
            return this.accountFormatCodeField;
        }
        set
        {
            this.accountFormatCodeField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public CurrencyCodeType CurrencyCode
    {
        get
        {
            return this.currencyCodeField;
        }
        set
        {
            this.currencyCodeField = value;
        }
    }

    [XmlElement("PaymentNote", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public PaymentNoteType[] PaymentNote
    {
        get
        {
            return this.paymentNoteField;
        }
        set
        {
            this.paymentNoteField = value;
        }
    }

    public BranchType FinancialInstitutionBranch
    {
        get
        {
            return this.financialInstitutionBranchField;
        }
        set
        {
            this.financialInstitutionBranchField = value;
        }
    }

    public CountryType Country
    {
        get
        {
            return this.countryField;
        }
        set
        {
            this.countryField = value;
        }
    }
}
