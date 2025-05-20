using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[GeneratedCode("xsd", "4.0.30319.33440")]
[DebuggerStepThrough]
[DesignerCategory("code")]
[XmlType(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[XmlRoot("AccountingCustomerParty", IsNullable = false, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[Serializable]
public class CustomerPartyType
{
    private CustomerAssignedAccountIDType customerAssignedAccountIDField;
    private SupplierAssignedAccountIDType supplierAssignedAccountIDField;
    private AdditionalAccountIDType[] additionalAccountIDField;
    private PartyType partyField;
    private ContactType deliveryContactField;
    private ContactType accountingContactField;
    private ContactType buyerContactField;

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

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public SupplierAssignedAccountIDType SupplierAssignedAccountID
    {
        get
        {
            return this.supplierAssignedAccountIDField;
        }
        set
        {
            this.supplierAssignedAccountIDField = value;
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

    public ContactType DeliveryContact
    {
        get
        {
            return this.deliveryContactField;
        }
        set
        {
            this.deliveryContactField = value;
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

    public ContactType BuyerContact
    {
        get
        {
            return this.buyerContactField;
        }
        set
        {
            this.buyerContactField = value;
        }
    }
}
