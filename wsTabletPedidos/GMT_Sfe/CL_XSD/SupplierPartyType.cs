using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[XmlType(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[DesignerCategory("code")]
[DebuggerStepThrough]
[XmlRoot("AccountingSupplierParty", IsNullable = false, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[GeneratedCode("xsd", "4.0.30319.33440")]
[Serializable]
public class SupplierPartyType
{
    private CustomerAssignedAccountIDType customerAssignedAccountIDField;
    private AdditionalAccountIDType[] additionalAccountIDField;
    private DataSendingCapabilityType dataSendingCapabilityField;
    private PartyType partyField;
    private ContactType despatchContactField;
    private ContactType accountingContactField;
    private ContactType sellerContactField;

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public CustomerAssignedAccountIDType CustomerAssignedAccountID
    {
        get
        {
            return this.customerAssignedAccountIDField;
        }
        set
        {
            this.customerAssignedAccountIDField = value;
        }
    }

    [XmlElement("AdditionalAccountID", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public AdditionalAccountIDType[] AdditionalAccountID
    {
        get
        {
            return this.additionalAccountIDField;
        }
        set
        {
            this.additionalAccountIDField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public DataSendingCapabilityType DataSendingCapability
    {
        get
        {
            return this.dataSendingCapabilityField;
        }
        set
        {
            this.dataSendingCapabilityField = value;
        }
    }

    public PartyType Party
    {
        get
        {
            return this.partyField;
        }
        set
        {
            this.partyField = value;
        }
    }

    public ContactType DespatchContact
    {
        get
        {
            return this.despatchContactField;
        }
        set
        {
            this.despatchContactField = value;
        }
    }

    public ContactType AccountingContact
    {
        get
        {
            return this.accountingContactField;
        }
        set
        {
            this.accountingContactField = value;
        }
    }

    public ContactType SellerContact
    {
        get
        {
            return this.sellerContactField;
        }
        set
        {
            this.sellerContactField = value;
        }
    }
}
