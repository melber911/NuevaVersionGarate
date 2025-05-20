
// Type: ShipmentStageType




using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[XmlType(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[XmlRoot("MainCarriageShipmentStage", IsNullable = false, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[DesignerCategory("code")]
[GeneratedCode("xsd", "4.0.30319.33440")]
[DebuggerStepThrough]
[Serializable]
public class ShipmentStageType
{
    private IDType idField;
    private TransportModeCodeType transportModeCodeField;
    private TransportMeansTypeCodeType transportMeansTypeCodeField;
    private TransitDirectionCodeType transitDirectionCodeField;
    private PreCarriageIndicatorType preCarriageIndicatorField;
    private OnCarriageIndicatorType onCarriageIndicatorField;
    private EstimatedDeliveryDateType estimatedDeliveryDateField;
    private EstimatedDeliveryTimeType estimatedDeliveryTimeField;
    private RequiredDeliveryDateType requiredDeliveryDateField;
    private RequiredDeliveryTimeType requiredDeliveryTimeField;
    private LoadingSequenceIDType loadingSequenceIDField;
    private SuccessiveSequenceIDType successiveSequenceIDField;
    private InstructionsType[] instructionsField;
    private DemurrageInstructionsType[] demurrageInstructionsField;
    private CrewQuantityType crewQuantityField;
    private PassengerQuantityType passengerQuantityField;
    private PeriodType transitPeriodField;
    private PartyType[] carrierPartyField;
    private TransportMeansType transportMeansField;
    private LocationType1 loadingPortLocationField;
    private LocationType1 unloadingPortLocationField;
    private LocationType1 transshipPortLocationField;
    private TransportEventType loadingTransportEventField;
    private TransportEventType examinationTransportEventField;
    private TransportEventType availabilityTransportEventField;
    private TransportEventType exportationTransportEventField;
    private TransportEventType dischargeTransportEventField;
    private TransportEventType warehousingTransportEventField;
    private TransportEventType takeoverTransportEventField;
    private TransportEventType optionalTakeoverTransportEventField;
    private TransportEventType dropoffTransportEventField;
    private TransportEventType actualPickupTransportEventField;
    private TransportEventType deliveryTransportEventField;
    private TransportEventType receiptTransportEventField;
    private TransportEventType storageTransportEventField;
    private TransportEventType acceptanceTransportEventField;
    private PartyType terminalOperatorPartyField;
    private PartyType customsAgentPartyField;
    private PeriodType estimatedTransitPeriodField;
    private AllowanceChargeType[] freightAllowanceChargeField;
    private LocationType1 freightChargeLocationField;
    private TransportEventType[] detentionTransportEventField;
    private TransportEventType requestedDepartureTransportEventField;
    private TransportEventType requestedArrivalTransportEventField;
    private TransportEventType[] requestedWaypointTransportEventField;
    private TransportEventType plannedDepartureTransportEventField;
    private TransportEventType plannedArrivalTransportEventField;
    private TransportEventType[] plannedWaypointTransportEventField;
    private TransportEventType actualDepartureTransportEventField;
    private TransportEventType actualWaypointTransportEventField;
    private TransportEventType actualArrivalTransportEventField;
    private TransportEventType[] transportEventField;
    private TransportEventType estimatedDepartureTransportEventField;
    private TransportEventType estimatedArrivalTransportEventField;
    private PersonType[] passengerPersonField;
    private PersonType[] driverPersonField;
    private PersonType reportingPersonField;
    private PersonType[] crewMemberPersonField;
    private PersonType securityOfficerPersonField;
    private PersonType masterPersonField;
    private PersonType shipsSurgeonPersonField;

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
    public TransportModeCodeType TransportModeCode
    {
        get
        {
            return this.transportModeCodeField;
        }
        set
        {
            this.transportModeCodeField = value;
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
    public TransitDirectionCodeType TransitDirectionCode
    {
        get
        {
            return this.transitDirectionCodeField;
        }
        set
        {
            this.transitDirectionCodeField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public PreCarriageIndicatorType PreCarriageIndicator
    {
        get
        {
            return this.preCarriageIndicatorField;
        }
        set
        {
            this.preCarriageIndicatorField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public OnCarriageIndicatorType OnCarriageIndicator
    {
        get
        {
            return this.onCarriageIndicatorField;
        }
        set
        {
            this.onCarriageIndicatorField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public EstimatedDeliveryDateType EstimatedDeliveryDate
    {
        get
        {
            return this.estimatedDeliveryDateField;
        }
        set
        {
            this.estimatedDeliveryDateField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public EstimatedDeliveryTimeType EstimatedDeliveryTime
    {
        get
        {
            return this.estimatedDeliveryTimeField;
        }
        set
        {
            this.estimatedDeliveryTimeField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public RequiredDeliveryDateType RequiredDeliveryDate
    {
        get
        {
            return this.requiredDeliveryDateField;
        }
        set
        {
            this.requiredDeliveryDateField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public RequiredDeliveryTimeType RequiredDeliveryTime
    {
        get
        {
            return this.requiredDeliveryTimeField;
        }
        set
        {
            this.requiredDeliveryTimeField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public LoadingSequenceIDType LoadingSequenceID
    {
        get
        {
            return this.loadingSequenceIDField;
        }
        set
        {
            this.loadingSequenceIDField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public SuccessiveSequenceIDType SuccessiveSequenceID
    {
        get
        {
            return this.successiveSequenceIDField;
        }
        set
        {
            this.successiveSequenceIDField = value;
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

    [XmlElement("DemurrageInstructions", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public DemurrageInstructionsType[] DemurrageInstructions
    {
        get
        {
            return this.demurrageInstructionsField;
        }
        set
        {
            this.demurrageInstructionsField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public CrewQuantityType CrewQuantity
    {
        get
        {
            return this.crewQuantityField;
        }
        set
        {
            this.crewQuantityField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public PassengerQuantityType PassengerQuantity
    {
        get
        {
            return this.passengerQuantityField;
        }
        set
        {
            this.passengerQuantityField = value;
        }
    }

    public PeriodType TransitPeriod
    {
        get
        {
            return this.transitPeriodField;
        }
        set
        {
            this.transitPeriodField = value;
        }
    }

    [XmlElement("CarrierParty")]
    public PartyType[] CarrierParty
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

    public TransportMeansType TransportMeans
    {
        get
        {
            return this.transportMeansField;
        }
        set
        {
            this.transportMeansField = value;
        }
    }

    public LocationType1 LoadingPortLocation
    {
        get
        {
            return this.loadingPortLocationField;
        }
        set
        {
            this.loadingPortLocationField = value;
        }
    }

    public LocationType1 UnloadingPortLocation
    {
        get
        {
            return this.unloadingPortLocationField;
        }
        set
        {
            this.unloadingPortLocationField = value;
        }
    }

    public LocationType1 TransshipPortLocation
    {
        get
        {
            return this.transshipPortLocationField;
        }
        set
        {
            this.transshipPortLocationField = value;
        }
    }

    public TransportEventType LoadingTransportEvent
    {
        get
        {
            return this.loadingTransportEventField;
        }
        set
        {
            this.loadingTransportEventField = value;
        }
    }

    public TransportEventType ExaminationTransportEvent
    {
        get
        {
            return this.examinationTransportEventField;
        }
        set
        {
            this.examinationTransportEventField = value;
        }
    }

    public TransportEventType AvailabilityTransportEvent
    {
        get
        {
            return this.availabilityTransportEventField;
        }
        set
        {
            this.availabilityTransportEventField = value;
        }
    }

    public TransportEventType ExportationTransportEvent
    {
        get
        {
            return this.exportationTransportEventField;
        }
        set
        {
            this.exportationTransportEventField = value;
        }
    }

    public TransportEventType DischargeTransportEvent
    {
        get
        {
            return this.dischargeTransportEventField;
        }
        set
        {
            this.dischargeTransportEventField = value;
        }
    }

    public TransportEventType WarehousingTransportEvent
    {
        get
        {
            return this.warehousingTransportEventField;
        }
        set
        {
            this.warehousingTransportEventField = value;
        }
    }

    public TransportEventType TakeoverTransportEvent
    {
        get
        {
            return this.takeoverTransportEventField;
        }
        set
        {
            this.takeoverTransportEventField = value;
        }
    }

    public TransportEventType OptionalTakeoverTransportEvent
    {
        get
        {
            return this.optionalTakeoverTransportEventField;
        }
        set
        {
            this.optionalTakeoverTransportEventField = value;
        }
    }

    public TransportEventType DropoffTransportEvent
    {
        get
        {
            return this.dropoffTransportEventField;
        }
        set
        {
            this.dropoffTransportEventField = value;
        }
    }

    public TransportEventType ActualPickupTransportEvent
    {
        get
        {
            return this.actualPickupTransportEventField;
        }
        set
        {
            this.actualPickupTransportEventField = value;
        }
    }

    public TransportEventType DeliveryTransportEvent
    {
        get
        {
            return this.deliveryTransportEventField;
        }
        set
        {
            this.deliveryTransportEventField = value;
        }
    }

    public TransportEventType ReceiptTransportEvent
    {
        get
        {
            return this.receiptTransportEventField;
        }
        set
        {
            this.receiptTransportEventField = value;
        }
    }

    public TransportEventType StorageTransportEvent
    {
        get
        {
            return this.storageTransportEventField;
        }
        set
        {
            this.storageTransportEventField = value;
        }
    }

    public TransportEventType AcceptanceTransportEvent
    {
        get
        {
            return this.acceptanceTransportEventField;
        }
        set
        {
            this.acceptanceTransportEventField = value;
        }
    }

    public PartyType TerminalOperatorParty
    {
        get
        {
            return this.terminalOperatorPartyField;
        }
        set
        {
            this.terminalOperatorPartyField = value;
        }
    }

    public PartyType CustomsAgentParty
    {
        get
        {
            return this.customsAgentPartyField;
        }
        set
        {
            this.customsAgentPartyField = value;
        }
    }

    public PeriodType EstimatedTransitPeriod
    {
        get
        {
            return this.estimatedTransitPeriodField;
        }
        set
        {
            this.estimatedTransitPeriodField = value;
        }
    }

    [XmlElement("FreightAllowanceCharge")]
    public AllowanceChargeType[] FreightAllowanceCharge
    {
        get
        {
            return this.freightAllowanceChargeField;
        }
        set
        {
            this.freightAllowanceChargeField = value;
        }
    }

    public LocationType1 FreightChargeLocation
    {
        get
        {
            return this.freightChargeLocationField;
        }
        set
        {
            this.freightChargeLocationField = value;
        }
    }

    [XmlElement("DetentionTransportEvent")]
    public TransportEventType[] DetentionTransportEvent
    {
        get
        {
            return this.detentionTransportEventField;
        }
        set
        {
            this.detentionTransportEventField = value;
        }
    }

    public TransportEventType RequestedDepartureTransportEvent
    {
        get
        {
            return this.requestedDepartureTransportEventField;
        }
        set
        {
            this.requestedDepartureTransportEventField = value;
        }
    }

    public TransportEventType RequestedArrivalTransportEvent
    {
        get
        {
            return this.requestedArrivalTransportEventField;
        }
        set
        {
            this.requestedArrivalTransportEventField = value;
        }
    }

    [XmlElement("RequestedWaypointTransportEvent")]
    public TransportEventType[] RequestedWaypointTransportEvent
    {
        get
        {
            return this.requestedWaypointTransportEventField;
        }
        set
        {
            this.requestedWaypointTransportEventField = value;
        }
    }

    public TransportEventType PlannedDepartureTransportEvent
    {
        get
        {
            return this.plannedDepartureTransportEventField;
        }
        set
        {
            this.plannedDepartureTransportEventField = value;
        }
    }

    public TransportEventType PlannedArrivalTransportEvent
    {
        get
        {
            return this.plannedArrivalTransportEventField;
        }
        set
        {
            this.plannedArrivalTransportEventField = value;
        }
    }

    [XmlElement("PlannedWaypointTransportEvent")]
    public TransportEventType[] PlannedWaypointTransportEvent
    {
        get
        {
            return this.plannedWaypointTransportEventField;
        }
        set
        {
            this.plannedWaypointTransportEventField = value;
        }
    }

    public TransportEventType ActualDepartureTransportEvent
    {
        get
        {
            return this.actualDepartureTransportEventField;
        }
        set
        {
            this.actualDepartureTransportEventField = value;
        }
    }

    public TransportEventType ActualWaypointTransportEvent
    {
        get
        {
            return this.actualWaypointTransportEventField;
        }
        set
        {
            this.actualWaypointTransportEventField = value;
        }
    }

    public TransportEventType ActualArrivalTransportEvent
    {
        get
        {
            return this.actualArrivalTransportEventField;
        }
        set
        {
            this.actualArrivalTransportEventField = value;
        }
    }

    [XmlElement("TransportEvent")]
    public TransportEventType[] TransportEvent
    {
        get
        {
            return this.transportEventField;
        }
        set
        {
            this.transportEventField = value;
        }
    }

    public TransportEventType EstimatedDepartureTransportEvent
    {
        get
        {
            return this.estimatedDepartureTransportEventField;
        }
        set
        {
            this.estimatedDepartureTransportEventField = value;
        }
    }

    public TransportEventType EstimatedArrivalTransportEvent
    {
        get
        {
            return this.estimatedArrivalTransportEventField;
        }
        set
        {
            this.estimatedArrivalTransportEventField = value;
        }
    }

    [XmlElement("PassengerPerson")]
    public PersonType[] PassengerPerson
    {
        get
        {
            return this.passengerPersonField;
        }
        set
        {
            this.passengerPersonField = value;
        }
    }

    [XmlElement("DriverPerson")]
    public PersonType[] DriverPerson
    {
        get
        {
            return this.driverPersonField;
        }
        set
        {
            this.driverPersonField = value;
        }
    }

    public PersonType ReportingPerson
    {
        get
        {
            return this.reportingPersonField;
        }
        set
        {
            this.reportingPersonField = value;
        }
    }

    [XmlElement("CrewMemberPerson")]
    public PersonType[] CrewMemberPerson
    {
        get
        {
            return this.crewMemberPersonField;
        }
        set
        {
            this.crewMemberPersonField = value;
        }
    }

    public PersonType SecurityOfficerPerson
    {
        get
        {
            return this.securityOfficerPersonField;
        }
        set
        {
            this.securityOfficerPersonField = value;
        }
    }

    public PersonType MasterPerson
    {
        get
        {
            return this.masterPersonField;
        }
        set
        {
            this.masterPersonField = value;
        }
    }

    public PersonType ShipsSurgeonPerson
    {
        get
        {
            return this.shipsSurgeonPersonField;
        }
        set
        {
            this.shipsSurgeonPersonField = value;
        }
    }
}
