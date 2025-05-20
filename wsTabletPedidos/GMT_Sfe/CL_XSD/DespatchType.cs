using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[DebuggerStepThrough]
[XmlType(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[GeneratedCode("xsd", "4.0.30319.33440")]
[XmlRoot("Despatch", IsNullable = false, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[DesignerCategory("code")]
[Serializable]
public class DespatchType
{
    private IDType idField;
    private RequestedDespatchDateType requestedDespatchDateField;
    private RequestedDespatchTimeType requestedDespatchTimeField;
    private EstimatedDespatchDateType estimatedDespatchDateField;
    private EstimatedDespatchTimeType estimatedDespatchTimeField;
    private ActualDespatchDateType actualDespatchDateField;
    private ActualDespatchTimeType actualDespatchTimeField;
    private GuaranteedDespatchDateType guaranteedDespatchDateField;
    private GuaranteedDespatchTimeType guaranteedDespatchTimeField;
    private ReleaseIDType releaseIDField;
    private InstructionsType[] instructionsField;
    private AddressType despatchAddressField;
    private LocationType1 despatchLocationField;
    private PartyType despatchPartyField;
    private PartyType carrierPartyField;
    private PartyType[] notifyPartyField;
    private ContactType contactField;
    private PeriodType estimatedDespatchPeriodField;
    private PeriodType requestedDespatchPeriodField;

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
    public RequestedDespatchDateType RequestedDespatchDate
    {
        get
        {
            return this.requestedDespatchDateField;
        }
        set
        {
            this.requestedDespatchDateField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public RequestedDespatchTimeType RequestedDespatchTime
    {
        get
        {
            return this.requestedDespatchTimeField;
        }
        set
        {
            this.requestedDespatchTimeField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public EstimatedDespatchDateType EstimatedDespatchDate
    {
        get
        {
            return this.estimatedDespatchDateField;
        }
        set
        {
            this.estimatedDespatchDateField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public EstimatedDespatchTimeType EstimatedDespatchTime
    {
        get
        {
            return this.estimatedDespatchTimeField;
        }
        set
        {
            this.estimatedDespatchTimeField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public ActualDespatchDateType ActualDespatchDate
    {
        get
        {
            return this.actualDespatchDateField;
        }
        set
        {
            this.actualDespatchDateField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public ActualDespatchTimeType ActualDespatchTime
    {
        get
        {
            return this.actualDespatchTimeField;
        }
        set
        {
            this.actualDespatchTimeField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public GuaranteedDespatchDateType GuaranteedDespatchDate
    {
        get
        {
            return this.guaranteedDespatchDateField;
        }
        set
        {
            this.guaranteedDespatchDateField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public GuaranteedDespatchTimeType GuaranteedDespatchTime
    {
        get
        {
            return this.guaranteedDespatchTimeField;
        }
        set
        {
            this.guaranteedDespatchTimeField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public ReleaseIDType ReleaseID
    {
        get
        {
            return this.releaseIDField;
        }
        set
        {
            this.releaseIDField = value;
        }
    }

    [XmlElement("Instructions", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public InstructionsType[] Instructions
    {
        get
        {
            return this.instructionsField;
        }
        set
        {
            this.instructionsField = value;
        }
    }

    public AddressType DespatchAddress
    {
        get
        {
            return this.despatchAddressField;
        }
        set
        {
            this.despatchAddressField = value;
        }
    }

    public LocationType1 DespatchLocation
    {
        get
        {
            return this.despatchLocationField;
        }
        set
        {
            this.despatchLocationField = value;
        }
    }

    public PartyType DespatchParty
    {
        get
        {
            return this.despatchPartyField;
        }
        set
        {
            this.despatchPartyField = value;
        }
    }

    public PartyType CarrierParty
    {
        get
        {
            return this.carrierPartyField;
        }
        set
        {
            this.carrierPartyField = value;
        }
    }

    [XmlElement("NotifyParty")]
    public PartyType[] NotifyParty
    {
        get
        {
            return this.notifyPartyField;
        }
        set
        {
            this.notifyPartyField = value;
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

    public PeriodType EstimatedDespatchPeriod
    {
        get
        {
            return this.estimatedDespatchPeriodField;
        }
        set
        {
            this.estimatedDespatchPeriodField = value;
        }
    }

    public PeriodType RequestedDespatchPeriod
    {
        get
        {
            return this.requestedDespatchPeriodField;
        }
        set
        {
            this.requestedDespatchPeriodField = value;
        }
    }
}
