using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[XmlType(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[DesignerCategory("code")]
[GeneratedCode("xsd", "4.0.30319.33440")]
[DebuggerStepThrough]
[XmlRoot("CardAccount", IsNullable = false, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[Serializable]
public class CardAccountType
{
    private PrimaryAccountNumberIDType primaryAccountNumberIDField;
    private NetworkIDType networkIDField;
    private CardTypeCodeType cardTypeCodeField;
    private ValidityStartDateType validityStartDateField;
    private ExpiryDateType expiryDateField;
    private IssuerIDType issuerIDField;
    private IssueNumberIDType issueNumberIDField;
    private CV2IDType cV2IDField;
    private CardChipCodeType cardChipCodeField;
    private ChipApplicationIDType chipApplicationIDField;
    private HolderNameType holderNameField;

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public PrimaryAccountNumberIDType PrimaryAccountNumberID
    {
        get
        {
            return this.primaryAccountNumberIDField;
        }
        set
        {
            this.primaryAccountNumberIDField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public NetworkIDType NetworkID
    {
        get
        {
            return this.networkIDField;
        }
        set
        {
            this.networkIDField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public CardTypeCodeType CardTypeCode
    {
        get
        {
            return this.cardTypeCodeField;
        }
        set
        {
            this.cardTypeCodeField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public ValidityStartDateType ValidityStartDate
    {
        get
        {
            return this.validityStartDateField;
        }
        set
        {
            this.validityStartDateField = value;
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
    public IssuerIDType IssuerID
    {
        get
        {
            return this.issuerIDField;
        }
        set
        {
            this.issuerIDField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public IssueNumberIDType IssueNumberID
    {
        get
        {
            return this.issueNumberIDField;
        }
        set
        {
            this.issueNumberIDField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public CV2IDType CV2ID
    {
        get
        {
            return this.cV2IDField;
        }
        set
        {
            this.cV2IDField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public CardChipCodeType CardChipCode
    {
        get
        {
            return this.cardChipCodeField;
        }
        set
        {
            this.cardChipCodeField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public ChipApplicationIDType ChipApplicationID
    {
        get
        {
            return this.chipApplicationIDField;
        }
        set
        {
            this.chipApplicationIDField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public HolderNameType HolderName
    {
        get
        {
            return this.holderNameField;
        }
        set
        {
            this.holderNameField = value;
        }
    }
}
