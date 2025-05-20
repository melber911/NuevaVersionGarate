using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[XmlRoot("ContractualDelivery", IsNullable = false, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[GeneratedCode("xsd", "4.0.30319.33440")]
[DebuggerStepThrough]
[DesignerCategory("code")]
[XmlType(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[Serializable]
public class DeliveryType
{
    private IDType idField;
    private QuantityType2 quantityField;
    private MinimumQuantityType minimumQuantityField;
    private MaximumQuantityType maximumQuantityField;
    private ActualDeliveryDateType actualDeliveryDateField;
    private ActualDeliveryTimeType actualDeliveryTimeField;
    private LatestDeliveryDateType latestDeliveryDateField;
    private LatestDeliveryTimeType latestDeliveryTimeField;
    private ReleaseIDType releaseIDField;
    private TrackingIDType trackingIDField;
    private AddressType deliveryAddressField;
    private LocationType1 deliveryLocationField;
    private LocationType1 alternativeDeliveryLocationField;
    private PeriodType requestedDeliveryPeriodField;
    private PeriodType promisedDeliveryPeriodField;
    private PeriodType estimatedDeliveryPeriodField;
    private PartyType carrierPartyField;
    private PartyType deliveryPartyField;
    private PartyType[] notifyPartyField;
    private DespatchType despatchField;
    private DeliveryTermsType[] deliveryTermsField;
    private DeliveryUnitType minimumDeliveryUnitField;
    private DeliveryUnitType maximumDeliveryUnitField;
    private ShipmentType shipmentField;

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
    public QuantityType2 Quantity
    {
        get
        {
            return this.quantityField;
        }
        set
        {
            this.quantityField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public MinimumQuantityType MinimumQuantity
    {
        get
        {
            return this.minimumQuantityField;
        }
        set
        {
            this.minimumQuantityField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public MaximumQuantityType MaximumQuantity
    {
        get
        {
            return this.maximumQuantityField;
        }
        set
        {
            this.maximumQuantityField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public ActualDeliveryDateType ActualDeliveryDate
    {
        get
        {
            return this.actualDeliveryDateField;
        }
        set
        {
            this.actualDeliveryDateField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public ActualDeliveryTimeType ActualDeliveryTime
    {
        get
        {
            return this.actualDeliveryTimeField;
        }
        set
        {
            this.actualDeliveryTimeField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public LatestDeliveryDateType LatestDeliveryDate
    {
        get
        {
            return this.latestDeliveryDateField;
        }
        set
        {
            this.latestDeliveryDateField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public LatestDeliveryTimeType LatestDeliveryTime
    {
        get
        {
            return this.latestDeliveryTimeField;
        }
        set
        {
            this.latestDeliveryTimeField = value;
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

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public TrackingIDType TrackingID
    {
        get
        {
            return this.trackingIDField;
        }
        set
        {
            this.trackingIDField = value;
        }
    }

    public AddressType DeliveryAddress
    {
        get
        {
            return this.deliveryAddressField;
        }
        set
        {
            this.deliveryAddressField = value;
        }
    }

    public LocationType1 DeliveryLocation
    {
        get
        {
            return this.deliveryLocationField;
        }
        set
        {
            this.deliveryLocationField = value;
        }
    }

    public LocationType1 AlternativeDeliveryLocation
    {
        get
        {
            return this.alternativeDeliveryLocationField;
        }
        set
        {
            this.alternativeDeliveryLocationField = value;
        }
    }

    public PeriodType RequestedDeliveryPeriod
    {
        get
        {
            return this.requestedDeliveryPeriodField;
        }
        set
        {
            this.requestedDeliveryPeriodField = value;
        }
    }

    public PeriodType PromisedDeliveryPeriod
    {
        get
        {
            return this.promisedDeliveryPeriodField;
        }
        set
        {
            this.promisedDeliveryPeriodField = value;
        }
    }

    public PeriodType EstimatedDeliveryPeriod
    {
        get
        {
            return this.estimatedDeliveryPeriodField;
        }
        set
        {
            this.estimatedDeliveryPeriodField = value;
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

    public PartyType DeliveryParty
    {
        get
        {
            return this.deliveryPartyField;
        }
        set
        {
            this.deliveryPartyField = value;
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

    public DespatchType Despatch
    {
        get
        {
            return this.despatchField;
        }
        set
        {
            this.despatchField = value;
        }
    }

    [XmlElement("DeliveryTerms")]
    public DeliveryTermsType[] DeliveryTerms
    {
        get
        {
            return this.deliveryTermsField;
        }
        set
        {
            this.deliveryTermsField = value;
        }
    }

    public DeliveryUnitType MinimumDeliveryUnit
    {
        get
        {
            return this.minimumDeliveryUnitField;
        }
        set
        {
            this.minimumDeliveryUnitField = value;
        }
    }

    public DeliveryUnitType MaximumDeliveryUnit
    {
        get
        {
            return this.maximumDeliveryUnitField;
        }
        set
        {
            this.maximumDeliveryUnitField = value;
        }
    }

    public ShipmentType Shipment
    {
        get
        {
            return this.shipmentField;
        }
        set
        {
            this.shipmentField = value;
        }
    }
}
