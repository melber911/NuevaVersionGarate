using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[XmlType(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[DesignerCategory("code")]
[XmlRoot("ImmobilizedSecurity", IsNullable = false, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[GeneratedCode("xsd", "4.0.30319.33440")]
[DebuggerStepThrough]
[Serializable]
public class ImmobilizedSecurityType
{
    private ImmobilizationCertificateIDType immobilizationCertificateIDField;
    private SecurityIDType securityIDField;
    private IssueDateType issueDateField;
    private FaceValueAmountType faceValueAmountField;
    private MarketValueAmountType marketValueAmountField;
    private SharesNumberQuantityType sharesNumberQuantityField;
    private PartyType issuerPartyField;

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public ImmobilizationCertificateIDType ImmobilizationCertificateID
    {
        get
        {
            return this.immobilizationCertificateIDField;
        }
        set
        {
            this.immobilizationCertificateIDField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public SecurityIDType SecurityID
    {
        get
        {
            return this.securityIDField;
        }
        set
        {
            this.securityIDField = value;
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
    public FaceValueAmountType FaceValueAmount
    {
        get
        {
            return this.faceValueAmountField;
        }
        set
        {
            this.faceValueAmountField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public MarketValueAmountType MarketValueAmount
    {
        get
        {
            return this.marketValueAmountField;
        }
        set
        {
            this.marketValueAmountField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public SharesNumberQuantityType SharesNumberQuantity
    {
        get
        {
            return this.sharesNumberQuantityField;
        }
        set
        {
            this.sharesNumberQuantityField = value;
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
}
