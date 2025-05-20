using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[GeneratedCode("xsd", "4.0.30319.33440")]
[XmlRoot("Pickup", IsNullable = false, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[DebuggerStepThrough]
[DesignerCategory("code")]
[XmlType(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[Serializable]
public class PickupType
{
    private IDType idField;
    private ActualPickupDateType actualPickupDateField;
    private ActualPickupTimeType actualPickupTimeField;
    private EarliestPickupDateType earliestPickupDateField;
    private EarliestPickupTimeType earliestPickupTimeField;
    private LatestPickupDateType latestPickupDateField;
    private LatestPickupTimeType latestPickupTimeField;
    private LocationType1 pickupLocationField;
    private PartyType pickupPartyField;

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
    public ActualPickupDateType ActualPickupDate
    {
        get
        {
            return this.actualPickupDateField;
        }
        set
        {
            this.actualPickupDateField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public ActualPickupTimeType ActualPickupTime
    {
        get
        {
            return this.actualPickupTimeField;
        }
        set
        {
            this.actualPickupTimeField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public EarliestPickupDateType EarliestPickupDate
    {
        get
        {
            return this.earliestPickupDateField;
        }
        set
        {
            this.earliestPickupDateField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public EarliestPickupTimeType EarliestPickupTime
    {
        get
        {
            return this.earliestPickupTimeField;
        }
        set
        {
            this.earliestPickupTimeField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public LatestPickupDateType LatestPickupDate
    {
        get
        {
            return this.latestPickupDateField;
        }
        set
        {
            this.latestPickupDateField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public LatestPickupTimeType LatestPickupTime
    {
        get
        {
            return this.latestPickupTimeField;
        }
        set
        {
            this.latestPickupTimeField = value;
        }
    }

    public LocationType1 PickupLocation
    {
        get
        {
            return this.pickupLocationField;
        }
        set
        {
            this.pickupLocationField = value;
        }
    }

    public PartyType PickupParty
    {
        get
        {
            return this.pickupPartyField;
        }
        set
        {
            this.pickupPartyField = value;
        }
    }
}
