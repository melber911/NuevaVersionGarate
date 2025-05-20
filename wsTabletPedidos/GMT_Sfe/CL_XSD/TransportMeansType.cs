using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[DebuggerStepThrough]
[XmlRoot("ApplicableTransportMeans", IsNullable = false, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[DesignerCategory("code")]
[XmlType(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[GeneratedCode("xsd", "4.0.30319.33440")]
[Serializable]
public class TransportMeansType
{
    private JourneyIDType journeyIDField;
    private RegistrationNationalityIDType registrationNationalityIDField;
    private RegistrationNationalityType[] registrationNationalityField;
    private DirectionCodeType directionCodeField;
    private TransportMeansTypeCodeType transportMeansTypeCodeField;
    private TradeServiceCodeType tradeServiceCodeField;
    private StowageType stowageField;
    private AirTransportType airTransportField;
    private RoadTransportType roadTransportField;
    private RailTransportType railTransportField;
    private MaritimeTransportType maritimeTransportField;
    private PartyType ownerPartyField;
    private DimensionType[] measurementDimensionField;

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public JourneyIDType JourneyID
    {
        get
        {
            return this.journeyIDField;
        }
        set
        {
            this.journeyIDField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public RegistrationNationalityIDType RegistrationNationalityID
    {
        get
        {
            return this.registrationNationalityIDField;
        }
        set
        {
            this.registrationNationalityIDField = value;
        }
    }

    [XmlElement("RegistrationNationality", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public RegistrationNationalityType[] RegistrationNationality
    {
        get
        {
            return this.registrationNationalityField;
        }
        set
        {
            this.registrationNationalityField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public DirectionCodeType DirectionCode
    {
        get
        {
            return this.directionCodeField;
        }
        set
        {
            this.directionCodeField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public TransportMeansTypeCodeType TransportMeansTypeCode
    {
        get
        {
            return this.transportMeansTypeCodeField;
        }
        set
        {
            this.transportMeansTypeCodeField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public TradeServiceCodeType TradeServiceCode
    {
        get
        {
            return this.tradeServiceCodeField;
        }
        set
        {
            this.tradeServiceCodeField = value;
        }
    }

    public StowageType Stowage
    {
        get
        {
            return this.stowageField;
        }
        set
        {
            this.stowageField = value;
        }
    }

    public AirTransportType AirTransport
    {
        get
        {
            return this.airTransportField;
        }
        set
        {
            this.airTransportField = value;
        }
    }

    public RoadTransportType RoadTransport
    {
        get
        {
            return this.roadTransportField;
        }
        set
        {
            this.roadTransportField = value;
        }
    }

    public RailTransportType RailTransport
    {
        get
        {
            return this.railTransportField;
        }
        set
        {
            this.railTransportField = value;
        }
    }

    public MaritimeTransportType MaritimeTransport
    {
        get
        {
            return this.maritimeTransportField;
        }
        set
        {
            this.maritimeTransportField = value;
        }
    }

    public PartyType OwnerParty
    {
        get
        {
            return this.ownerPartyField;
        }
        set
        {
            this.ownerPartyField = value;
        }
    }

    [XmlElement("MeasurementDimension")]
    public DimensionType[] MeasurementDimension
    {
        get
        {
            return this.measurementDimensionField;
        }
        set
        {
            this.measurementDimensionField = value;
        }
    }
}
