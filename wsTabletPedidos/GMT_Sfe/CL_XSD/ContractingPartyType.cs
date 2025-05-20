using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[GeneratedCode("xsd", "4.0.30319.33440")]
[DebuggerStepThrough]
[DesignerCategory("code")]
[XmlType(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[XmlRoot("ContractingParty", IsNullable = false, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[Serializable]
public class ContractingPartyType
{
    private BuyerProfileURIType buyerProfileURIField;
    private ContractingPartyTypeType[] contractingPartyType1Field;
    private ContractingActivityType[] contractingActivityField;
    private PartyType partyField;

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public BuyerProfileURIType BuyerProfileURI
    {
        get
        {
            return this.buyerProfileURIField;
        }
        set
        {
            this.buyerProfileURIField = value;
        }
    }

    [XmlElement("ContractingPartyType")]
    public ContractingPartyTypeType[] ContractingPartyType1
    {
        get
        {
            return this.contractingPartyType1Field;
        }
        set
        {
            this.contractingPartyType1Field = value;
        }
    }

    [XmlElement("ContractingActivity")]
    public ContractingActivityType[] ContractingActivity
    {
        get
        {
            return this.contractingActivityField;
        }
        set
        {
            this.contractingActivityField = value;
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
}
