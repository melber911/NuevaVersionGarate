using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[DesignerCategory("code")]
[XmlRoot("ChildConsignment", IsNullable = false, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[XmlType(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[GeneratedCode("xsd", "4.0.30319.33440")]
[DebuggerStepThrough]
[Serializable]
public class ConsignmentType
{
    private IDType idField;
    private CarrierAssignedIDType carrierAssignedIDField;
    private ConsigneeAssignedIDType consigneeAssignedIDField;
    private ConsignorAssignedIDType consignorAssignedIDField;
    private FreightForwarderAssignedIDType freightForwarderAssignedIDField;
    private BrokerAssignedIDType brokerAssignedIDField;
    private ContractedCarrierAssignedIDType contractedCarrierAssignedIDField;
    private PerformingCarrierAssignedIDType performingCarrierAssignedIDField;
    private SummaryDescriptionType[] summaryDescriptionField;
    private TotalInvoiceAmountType totalInvoiceAmountField;
    private DeclaredCustomsValueAmountType declaredCustomsValueAmountField;
    private TariffDescriptionType[] tariffDescriptionField;
    private TariffCodeType tariffCodeField;
    private InsurancePremiumAmountType insurancePremiumAmountField;
    private GrossWeightMeasureType grossWeightMeasureField;
    private NetWeightMeasureType netWeightMeasureField;
    private NetNetWeightMeasureType netNetWeightMeasureField;
    private ChargeableWeightMeasureType chargeableWeightMeasureField;
    private GrossVolumeMeasureType grossVolumeMeasureField;
    private NetVolumeMeasureType netVolumeMeasureField;
    private LoadingLengthMeasureType loadingLengthMeasureField;
    private RemarksType[] remarksField;
    private HazardousRiskIndicatorType hazardousRiskIndicatorField;
    private AnimalFoodIndicatorType animalFoodIndicatorField;
    private HumanFoodIndicatorType humanFoodIndicatorField;
    private LivestockIndicatorType livestockIndicatorField;
    private BulkCargoIndicatorType bulkCargoIndicatorField;
    private ContainerizedIndicatorType containerizedIndicatorField;
    private GeneralCargoIndicatorType generalCargoIndicatorField;
    private SpecialSecurityIndicatorType specialSecurityIndicatorField;
    private ThirdPartyPayerIndicatorType thirdPartyPayerIndicatorField;
    private CarrierServiceInstructionsType[] carrierServiceInstructionsField;
    private CustomsClearanceServiceInstructionsType[] customsClearanceServiceInstructionsField;
    private ForwarderServiceInstructionsType[] forwarderServiceInstructionsField;
    private SpecialServiceInstructionsType[] specialServiceInstructionsField;
    private SequenceIDType sequenceIDField;
    private ShippingPriorityLevelCodeType shippingPriorityLevelCodeField;
    private HandlingCodeType handlingCodeField;
    private HandlingInstructionsType[] handlingInstructionsField;
    private InformationType[] informationField;
    private TotalGoodsItemQuantityType totalGoodsItemQuantityField;
    private TotalTransportHandlingUnitQuantityType totalTransportHandlingUnitQuantityField;
    private InsuranceValueAmountType insuranceValueAmountField;
    private DeclaredForCarriageValueAmountType declaredForCarriageValueAmountField;
    private DeclaredStatisticsValueAmountType declaredStatisticsValueAmountField;
    private FreeOnBoardValueAmountType freeOnBoardValueAmountField;
    private SpecialInstructionsType[] specialInstructionsField;
    private SplitConsignmentIndicatorType splitConsignmentIndicatorField;
    private DeliveryInstructionsType[] deliveryInstructionsField;
    private ConsignmentQuantityType consignmentQuantityField;
    private ConsolidatableIndicatorType consolidatableIndicatorField;
    private HaulageInstructionsType[] haulageInstructionsField;
    private LoadingSequenceIDType loadingSequenceIDField;
    private ChildConsignmentQuantityType childConsignmentQuantityField;
    private TotalPackagesQuantityType totalPackagesQuantityField;
    private ShipmentType[] consolidatedShipmentField;
    private CustomsDeclarationType[] customsDeclarationField;
    private TransportEventType requestedPickupTransportEventField;
    private TransportEventType requestedDeliveryTransportEventField;
    private TransportEventType plannedPickupTransportEventField;
    private TransportEventType plannedDeliveryTransportEventField;
    private StatusType[] statusField;
    private ConsignmentType[] childConsignmentField;
    private PartyType consigneePartyField;
    private PartyType exporterPartyField;
    private PartyType ConsignorPartyField;
    private PartyType importerPartyField;
    private PartyType carrierPartyField;
    private PartyType freightForwarderPartyField;
    private PartyType notifyPartyField;
    private PartyType originalDespatchPartyField;
    private PartyType finalDeliveryPartyField;
    private PartyType performingCarrierPartyField;
    private PartyType substituteCarrierPartyField;
    private PartyType logisticsOperatorPartyField;
    private PartyType transportAdvisorPartyField;
    private PartyType hazardousItemNotificationPartyField;
    private PartyType insurancePartyField;
    private PartyType mortgageHolderPartyField;
    private PartyType billOfLadingHolderPartyField;
    private CountryType originalDepartureCountryField;
    private CountryType finalDestinationCountryField;
    private CountryType[] transitCountryField;
    private ContractType transportContractField;
    private TransportEventType[] transportEventField;
    private TransportationServiceType originalDespatchTransportationServiceField;
    private TransportationServiceType finalDeliveryTransportationServiceField;
    private DeliveryTermsType deliveryTermsField;
    private PaymentTermsType paymentTermsField;
    private PaymentTermsType collectPaymentTermsField;
    private PaymentTermsType disbursementPaymentTermsField;
    private PaymentTermsType prepaidPaymentTermsField;
    private AllowanceChargeType[] freightAllowanceChargeField;
    private AllowanceChargeType[] extraAllowanceChargeField;
    private ShipmentStageType[] mainCarriageShipmentStageField;
    private ShipmentStageType[] preCarriageShipmentStageField;
    private ShipmentStageType[] onCarriageShipmentStageField;
    private TransportHandlingUnitType[] transportHandlingUnitField;
    private LocationType1 firstArrivalPortLocationField;
    private LocationType1 lastExitPortLocationField;

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
    public CarrierAssignedIDType CarrierAssignedID
    {
        get
        {
            return this.carrierAssignedIDField;
        }
        set
        {
            this.carrierAssignedIDField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public ConsigneeAssignedIDType ConsigneeAssignedID
    {
        get
        {
            return this.consigneeAssignedIDField;
        }
        set
        {
            this.consigneeAssignedIDField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public ConsignorAssignedIDType ConsignorAssignedID
    {
        get
        {
            return this.consignorAssignedIDField;
        }
        set
        {
            this.consignorAssignedIDField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public FreightForwarderAssignedIDType FreightForwarderAssignedID
    {
        get
        {
            return this.freightForwarderAssignedIDField;
        }
        set
        {
            this.freightForwarderAssignedIDField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public BrokerAssignedIDType BrokerAssignedID
    {
        get
        {
            return this.brokerAssignedIDField;
        }
        set
        {
            this.brokerAssignedIDField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public ContractedCarrierAssignedIDType ContractedCarrierAssignedID
    {
        get
        {
            return this.contractedCarrierAssignedIDField;
        }
        set
        {
            this.contractedCarrierAssignedIDField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public PerformingCarrierAssignedIDType PerformingCarrierAssignedID
    {
        get
        {
            return this.performingCarrierAssignedIDField;
        }
        set
        {
            this.performingCarrierAssignedIDField = value;
        }
    }

    [XmlElement("SummaryDescription", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public SummaryDescriptionType[] SummaryDescription
    {
        get
        {
            return this.summaryDescriptionField;
        }
        set
        {
            this.summaryDescriptionField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public TotalInvoiceAmountType TotalInvoiceAmount
    {
        get
        {
            return this.totalInvoiceAmountField;
        }
        set
        {
            this.totalInvoiceAmountField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public DeclaredCustomsValueAmountType DeclaredCustomsValueAmount
    {
        get
        {
            return this.declaredCustomsValueAmountField;
        }
        set
        {
            this.declaredCustomsValueAmountField = value;
        }
    }

    [XmlElement("TariffDescription", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public TariffDescriptionType[] TariffDescription
    {
        get
        {
            return this.tariffDescriptionField;
        }
        set
        {
            this.tariffDescriptionField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public TariffCodeType TariffCode
    {
        get
        {
            return this.tariffCodeField;
        }
        set
        {
            this.tariffCodeField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public InsurancePremiumAmountType InsurancePremiumAmount
    {
        get
        {
            return this.insurancePremiumAmountField;
        }
        set
        {
            this.insurancePremiumAmountField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public GrossWeightMeasureType GrossWeightMeasure
    {
        get
        {
            return this.grossWeightMeasureField;
        }
        set
        {
            this.grossWeightMeasureField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public NetWeightMeasureType NetWeightMeasure
    {
        get
        {
            return this.netWeightMeasureField;
        }
        set
        {
            this.netWeightMeasureField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public NetNetWeightMeasureType NetNetWeightMeasure
    {
        get
        {
            return this.netNetWeightMeasureField;
        }
        set
        {
            this.netNetWeightMeasureField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public ChargeableWeightMeasureType ChargeableWeightMeasure
    {
        get
        {
            return this.chargeableWeightMeasureField;
        }
        set
        {
            this.chargeableWeightMeasureField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public GrossVolumeMeasureType GrossVolumeMeasure
    {
        get
        {
            return this.grossVolumeMeasureField;
        }
        set
        {
            this.grossVolumeMeasureField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public NetVolumeMeasureType NetVolumeMeasure
    {
        get
        {
            return this.netVolumeMeasureField;
        }
        set
        {
            this.netVolumeMeasureField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public LoadingLengthMeasureType LoadingLengthMeasure
    {
        get
        {
            return this.loadingLengthMeasureField;
        }
        set
        {
            this.loadingLengthMeasureField = value;
        }
    }

    [XmlElement("Remarks", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public RemarksType[] Remarks
    {
        get
        {
            return this.remarksField;
        }
        set
        {
            this.remarksField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public HazardousRiskIndicatorType HazardousRiskIndicator
    {
        get
        {
            return this.hazardousRiskIndicatorField;
        }
        set
        {
            this.hazardousRiskIndicatorField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public AnimalFoodIndicatorType AnimalFoodIndicator
    {
        get
        {
            return this.animalFoodIndicatorField;
        }
        set
        {
            this.animalFoodIndicatorField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public HumanFoodIndicatorType HumanFoodIndicator
    {
        get
        {
            return this.humanFoodIndicatorField;
        }
        set
        {
            this.humanFoodIndicatorField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public LivestockIndicatorType LivestockIndicator
    {
        get
        {
            return this.livestockIndicatorField;
        }
        set
        {
            this.livestockIndicatorField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public BulkCargoIndicatorType BulkCargoIndicator
    {
        get
        {
            return this.bulkCargoIndicatorField;
        }
        set
        {
            this.bulkCargoIndicatorField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public ContainerizedIndicatorType ContainerizedIndicator
    {
        get
        {
            return this.containerizedIndicatorField;
        }
        set
        {
            this.containerizedIndicatorField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public GeneralCargoIndicatorType GeneralCargoIndicator
    {
        get
        {
            return this.generalCargoIndicatorField;
        }
        set
        {
            this.generalCargoIndicatorField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public SpecialSecurityIndicatorType SpecialSecurityIndicator
    {
        get
        {
            return this.specialSecurityIndicatorField;
        }
        set
        {
            this.specialSecurityIndicatorField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public ThirdPartyPayerIndicatorType ThirdPartyPayerIndicator
    {
        get
        {
            return this.thirdPartyPayerIndicatorField;
        }
        set
        {
            this.thirdPartyPayerIndicatorField = value;
        }
    }

    [XmlElement("CarrierServiceInstructions", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public CarrierServiceInstructionsType[] CarrierServiceInstructions
    {
        get
        {
            return this.carrierServiceInstructionsField;
        }
        set
        {
            this.carrierServiceInstructionsField = value;
        }
    }

    [XmlElement("CustomsClearanceServiceInstructions", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public CustomsClearanceServiceInstructionsType[] CustomsClearanceServiceInstructions
    {
        get
        {
            return this.customsClearanceServiceInstructionsField;
        }
        set
        {
            this.customsClearanceServiceInstructionsField = value;
        }
    }

    [XmlElement("ForwarderServiceInstructions", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public ForwarderServiceInstructionsType[] ForwarderServiceInstructions
    {
        get
        {
            return this.forwarderServiceInstructionsField;
        }
        set
        {
            this.forwarderServiceInstructionsField = value;
        }
    }

    [XmlElement("SpecialServiceInstructions", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public SpecialServiceInstructionsType[] SpecialServiceInstructions
    {
        get
        {
            return this.specialServiceInstructionsField;
        }
        set
        {
            this.specialServiceInstructionsField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public SequenceIDType SequenceID
    {
        get
        {
            return this.sequenceIDField;
        }
        set
        {
            this.sequenceIDField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public ShippingPriorityLevelCodeType ShippingPriorityLevelCode
    {
        get
        {
            return this.shippingPriorityLevelCodeField;
        }
        set
        {
            this.shippingPriorityLevelCodeField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public HandlingCodeType HandlingCode
    {
        get
        {
            return this.handlingCodeField;
        }
        set
        {
            this.handlingCodeField = value;
        }
    }

    [XmlElement("HandlingInstructions", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public HandlingInstructionsType[] HandlingInstructions
    {
        get
        {
            return this.handlingInstructionsField;
        }
        set
        {
            this.handlingInstructionsField = value;
        }
    }

    [XmlElement("Information", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public InformationType[] Information
    {
        get
        {
            return this.informationField;
        }
        set
        {
            this.informationField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public TotalGoodsItemQuantityType TotalGoodsItemQuantity
    {
        get
        {
            return this.totalGoodsItemQuantityField;
        }
        set
        {
            this.totalGoodsItemQuantityField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public TotalTransportHandlingUnitQuantityType TotalTransportHandlingUnitQuantity
    {
        get
        {
            return this.totalTransportHandlingUnitQuantityField;
        }
        set
        {
            this.totalTransportHandlingUnitQuantityField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public InsuranceValueAmountType InsuranceValueAmount
    {
        get
        {
            return this.insuranceValueAmountField;
        }
        set
        {
            this.insuranceValueAmountField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public DeclaredForCarriageValueAmountType DeclaredForCarriageValueAmount
    {
        get
        {
            return this.declaredForCarriageValueAmountField;
        }
        set
        {
            this.declaredForCarriageValueAmountField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public DeclaredStatisticsValueAmountType DeclaredStatisticsValueAmount
    {
        get
        {
            return this.declaredStatisticsValueAmountField;
        }
        set
        {
            this.declaredStatisticsValueAmountField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public FreeOnBoardValueAmountType FreeOnBoardValueAmount
    {
        get
        {
            return this.freeOnBoardValueAmountField;
        }
        set
        {
            this.freeOnBoardValueAmountField = value;
        }
    }

    [XmlElement("SpecialInstructions", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public SpecialInstructionsType[] SpecialInstructions
    {
        get
        {
            return this.specialInstructionsField;
        }
        set
        {
            this.specialInstructionsField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public SplitConsignmentIndicatorType SplitConsignmentIndicator
    {
        get
        {
            return this.splitConsignmentIndicatorField;
        }
        set
        {
            this.splitConsignmentIndicatorField = value;
        }
    }

    [XmlElement("DeliveryInstructions", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public DeliveryInstructionsType[] DeliveryInstructions
    {
        get
        {
            return this.deliveryInstructionsField;
        }
        set
        {
            this.deliveryInstructionsField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public ConsignmentQuantityType ConsignmentQuantity
    {
        get
        {
            return this.consignmentQuantityField;
        }
        set
        {
            this.consignmentQuantityField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public ConsolidatableIndicatorType ConsolidatableIndicator
    {
        get
        {
            return this.consolidatableIndicatorField;
        }
        set
        {
            this.consolidatableIndicatorField = value;
        }
    }

    [XmlElement("HaulageInstructions", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public HaulageInstructionsType[] HaulageInstructions
    {
        get
        {
            return this.haulageInstructionsField;
        }
        set
        {
            this.haulageInstructionsField = value;
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
    public ChildConsignmentQuantityType ChildConsignmentQuantity
    {
        get
        {
            return this.childConsignmentQuantityField;
        }
        set
        {
            this.childConsignmentQuantityField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public TotalPackagesQuantityType TotalPackagesQuantity
    {
        get
        {
            return this.totalPackagesQuantityField;
        }
        set
        {
            this.totalPackagesQuantityField = value;
        }
    }

    [XmlElement("ConsolidatedShipment")]
    public ShipmentType[] ConsolidatedShipment
    {
        get
        {
            return this.consolidatedShipmentField;
        }
        set
        {
            this.consolidatedShipmentField = value;
        }
    }

    [XmlElement("CustomsDeclaration")]
    public CustomsDeclarationType[] CustomsDeclaration
    {
        get
        {
            return this.customsDeclarationField;
        }
        set
        {
            this.customsDeclarationField = value;
        }
    }

    public TransportEventType RequestedPickupTransportEvent
    {
        get
        {
            return this.requestedPickupTransportEventField;
        }
        set
        {
            this.requestedPickupTransportEventField = value;
        }
    }

    public TransportEventType RequestedDeliveryTransportEvent
    {
        get
        {
            return this.requestedDeliveryTransportEventField;
        }
        set
        {
            this.requestedDeliveryTransportEventField = value;
        }
    }

    public TransportEventType PlannedPickupTransportEvent
    {
        get
        {
            return this.plannedPickupTransportEventField;
        }
        set
        {
            this.plannedPickupTransportEventField = value;
        }
    }

    public TransportEventType PlannedDeliveryTransportEvent
    {
        get
        {
            return this.plannedDeliveryTransportEventField;
        }
        set
        {
            this.plannedDeliveryTransportEventField = value;
        }
    }

    [XmlElement("Status")]
    public StatusType[] Status
    {
        get
        {
            return this.statusField;
        }
        set
        {
            this.statusField = value;
        }
    }

    [XmlElement("ChildConsignment")]
    public ConsignmentType[] ChildConsignment
    {
        get
        {
            return this.childConsignmentField;
        }
        set
        {
            this.childConsignmentField = value;
        }
    }

    public PartyType ConsigneeParty
    {
        get
        {
            return this.consigneePartyField;
        }
        set
        {
            this.consigneePartyField = value;
        }
    }

    public PartyType ExporterParty
    {
        get
        {
            return this.exporterPartyField;
        }
        set
        {
            this.exporterPartyField = value;
        }
    }

    public PartyType ConsignorParty
    {
        get
        {
            return this.ConsignorPartyField;
        }
        set
        {
            this.ConsignorPartyField = value;
        }
    }

    public PartyType ImporterParty
    {
        get
        {
            return this.importerPartyField;
        }
        set
        {
            this.importerPartyField = value;
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

    public PartyType FreightForwarderParty
    {
        get
        {
            return this.freightForwarderPartyField;
        }
        set
        {
            this.freightForwarderPartyField = value;
        }
    }

    public PartyType NotifyParty
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

    public PartyType OriginalDespatchParty
    {
        get
        {
            return this.originalDespatchPartyField;
        }
        set
        {
            this.originalDespatchPartyField = value;
        }
    }

    public PartyType FinalDeliveryParty
    {
        get
        {
            return this.finalDeliveryPartyField;
        }
        set
        {
            this.finalDeliveryPartyField = value;
        }
    }

    public PartyType PerformingCarrierParty
    {
        get
        {
            return this.performingCarrierPartyField;
        }
        set
        {
            this.performingCarrierPartyField = value;
        }
    }

    public PartyType SubstituteCarrierParty
    {
        get
        {
            return this.substituteCarrierPartyField;
        }
        set
        {
            this.substituteCarrierPartyField = value;
        }
    }

    public PartyType LogisticsOperatorParty
    {
        get
        {
            return this.logisticsOperatorPartyField;
        }
        set
        {
            this.logisticsOperatorPartyField = value;
        }
    }

    public PartyType TransportAdvisorParty
    {
        get
        {
            return this.transportAdvisorPartyField;
        }
        set
        {
            this.transportAdvisorPartyField = value;
        }
    }

    public PartyType HazardousItemNotificationParty
    {
        get
        {
            return this.hazardousItemNotificationPartyField;
        }
        set
        {
            this.hazardousItemNotificationPartyField = value;
        }
    }

    public PartyType InsuranceParty
    {
        get
        {
            return this.insurancePartyField;
        }
        set
        {
            this.insurancePartyField = value;
        }
    }

    public PartyType MortgageHolderParty
    {
        get
        {
            return this.mortgageHolderPartyField;
        }
        set
        {
            this.mortgageHolderPartyField = value;
        }
    }

    public PartyType BillOfLadingHolderParty
    {
        get
        {
            return this.billOfLadingHolderPartyField;
        }
        set
        {
            this.billOfLadingHolderPartyField = value;
        }
    }

    public CountryType OriginalDepartureCountry
    {
        get
        {
            return this.originalDepartureCountryField;
        }
        set
        {
            this.originalDepartureCountryField = value;
        }
    }

    public CountryType FinalDestinationCountry
    {
        get
        {
            return this.finalDestinationCountryField;
        }
        set
        {
            this.finalDestinationCountryField = value;
        }
    }

    [XmlElement("TransitCountry")]
    public CountryType[] TransitCountry
    {
        get
        {
            return this.transitCountryField;
        }
        set
        {
            this.transitCountryField = value;
        }
    }

    public ContractType TransportContract
    {
        get
        {
            return this.transportContractField;
        }
        set
        {
            this.transportContractField = value;
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

    public TransportationServiceType OriginalDespatchTransportationService
    {
        get
        {
            return this.originalDespatchTransportationServiceField;
        }
        set
        {
            this.originalDespatchTransportationServiceField = value;
        }
    }

    public TransportationServiceType FinalDeliveryTransportationService
    {
        get
        {
            return this.finalDeliveryTransportationServiceField;
        }
        set
        {
            this.finalDeliveryTransportationServiceField = value;
        }
    }

    public DeliveryTermsType DeliveryTerms
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

    public PaymentTermsType PaymentTerms
    {
        get
        {
            return this.paymentTermsField;
        }
        set
        {
            this.paymentTermsField = value;
        }
    }

    public PaymentTermsType CollectPaymentTerms
    {
        get
        {
            return this.collectPaymentTermsField;
        }
        set
        {
            this.collectPaymentTermsField = value;
        }
    }

    public PaymentTermsType DisbursementPaymentTerms
    {
        get
        {
            return this.disbursementPaymentTermsField;
        }
        set
        {
            this.disbursementPaymentTermsField = value;
        }
    }

    public PaymentTermsType PrepaidPaymentTerms
    {
        get
        {
            return this.prepaidPaymentTermsField;
        }
        set
        {
            this.prepaidPaymentTermsField = value;
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

    [XmlElement("ExtraAllowanceCharge")]
    public AllowanceChargeType[] ExtraAllowanceCharge
    {
        get
        {
            return this.extraAllowanceChargeField;
        }
        set
        {
            this.extraAllowanceChargeField = value;
        }
    }

    [XmlElement("MainCarriageShipmentStage")]
    public ShipmentStageType[] MainCarriageShipmentStage
    {
        get
        {
            return this.mainCarriageShipmentStageField;
        }
        set
        {
            this.mainCarriageShipmentStageField = value;
        }
    }

    [XmlElement("PreCarriageShipmentStage")]
    public ShipmentStageType[] PreCarriageShipmentStage
    {
        get
        {
            return this.preCarriageShipmentStageField;
        }
        set
        {
            this.preCarriageShipmentStageField = value;
        }
    }

    [XmlElement("OnCarriageShipmentStage")]
    public ShipmentStageType[] OnCarriageShipmentStage
    {
        get
        {
            return this.onCarriageShipmentStageField;
        }
        set
        {
            this.onCarriageShipmentStageField = value;
        }
    }

    [XmlElement("TransportHandlingUnit")]
    public TransportHandlingUnitType[] TransportHandlingUnit
    {
        get
        {
            return this.transportHandlingUnitField;
        }
        set
        {
            this.transportHandlingUnitField = value;
        }
    }

    public LocationType1 FirstArrivalPortLocation
    {
        get
        {
            return this.firstArrivalPortLocationField;
        }
        set
        {
            this.firstArrivalPortLocationField = value;
        }
    }

    public LocationType1 LastExitPortLocation
    {
        get
        {
            return this.lastExitPortLocationField;
        }
        set
        {
            this.lastExitPortLocationField = value;
        }
    }
}
