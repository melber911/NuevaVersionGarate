using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[GeneratedCode("xsd", "4.0.30319.33440")]
[DesignerCategory("code")]
[XmlType(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[XmlRoot("ServiceProviderParty", IsNullable = false, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[DebuggerStepThrough]
[Serializable]
public class ServiceProviderPartyType
{
    private IDType idField;
    private ServiceTypeCodeType serviceTypeCodeField;
    private ServiceTypeType[] serviceTypeField;
    private PartyType partyField;
    private ContactType sellerContactField;

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
    public ServiceTypeCodeType ServiceTypeCode
    {
        get
        {
            return this.serviceTypeCodeField;
        }
        set
        {
            this.serviceTypeCodeField = value;
        }
    }

    [XmlElement("ServiceType", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public ServiceTypeType[] ServiceType
    {
        get
        {
            return this.serviceTypeField;
        }
        set
        {
            this.serviceTypeField = value;
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
