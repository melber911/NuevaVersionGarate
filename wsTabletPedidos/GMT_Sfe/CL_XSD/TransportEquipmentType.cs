using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[DesignerCategory("code")]
[GeneratedCode("xsd", "4.0.30319.33440")]
[DebuggerStepThrough]
[XmlRoot("AttachedTransportEquipment", IsNullable = false, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[XmlType(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[Serializable]
public class TransportEquipmentType
{
    private IDType idField;
    private ReferencedConsignmentIDType[] referencedConsignmentIDField;
    private TransportEquipmentTypeCodeType transportEquipmentTypeCodeField;
    private ProviderTypeCodeType providerTypeCodeField;
    private OwnerTypeCodeType ownerTypeCodeField;
    private SizeTypeCodeType sizeTypeCodeField;
    private DispositionCodeType dispositionCodeField;
    private FullnessIndicationCodeType fullnessIndicationCodeField;
    private RefrigerationOnIndicatorType refrigerationOnIndicatorField;
    private InformationType[] informationField;
    private ReturnabilityIndicatorType returnabilityIndicatorField;
    private LegalStatusIndicatorType legalStatusIndicatorField;
    private AirFlowPercentType airFlowPercentField;
    private HumidityPercentType humidityPercentField;
    private AnimalFoodApprovedIndicatorType animalFoodApprovedIndicatorField;
    private HumanFoodApprovedIndicatorType humanFoodApprovedIndicatorField;
    private DangerousGoodsApprovedIndicatorType dangerousGoodsApprovedIndicatorField;
    private RefrigeratedIndicatorType refrigeratedIndicatorField;
    private CharacteristicsType characteristicsField;
    private DamageRemarksType[] damageRemarksField;
    private DescriptionType[] descriptionField;
    private SpecialTransportRequirementsType[] specialTransportRequirementsField;
    private GrossWeightMeasureType grossWeightMeasureField;
    private GrossVolumeMeasureType grossVolumeMeasureField;
    private TareWeightMeasureType tareWeightMeasureField;
    private TrackingDeviceCodeType trackingDeviceCodeField;
    private PowerIndicatorType powerIndicatorField;
    private TraceIDType traceIDField;
    private DimensionType[] measurementDimensionField;
    private TransportEquipmentSealType[] transportEquipmentSealField;
    private TemperatureType minimumTemperatureField;
    private TemperatureType maximumTemperatureField;
    private PartyType providerPartyField;
    private PartyType loadingProofPartyField;
    private SupplierPartyType supplierPartyField;
    private PartyType ownerPartyField;
    private PartyType operatingPartyField;
    private LocationType1 loadingLocationField;
    private LocationType1 unloadingLocationField;
    private LocationType1 storageLocationField;
    private TransportEventType[] positioningTransportEventField;
    private TransportEventType[] quarantineTransportEventField;
    private TransportEventType[] deliveryTransportEventField;
    private TransportEventType[] pickupTransportEventField;
    private TransportEventType[] handlingTransportEventField;
    private TransportEventType[] loadingTransportEventField;
    private TransportEventType[] transportEventField;
    private TransportMeansType applicableTransportMeansField;
    private TradingTermsType[] haulageTradingTermsField;
    private HazardousGoodsTransitType[] hazardousGoodsTransitField;
    private TransportHandlingUnitType[] packagedTransportHandlingUnitField;
    private AllowanceChargeType[] serviceAllowanceChargeField;
    private AllowanceChargeType[] freightAllowanceChargeField;
    private TransportEquipmentType[] attachedTransportEquipmentField;
    private DeliveryType deliveryField;
    private PickupType pickupField;
    private DespatchType despatchField;
    private DocumentReferenceType[] shipmentDocumentReferenceField;
    private TransportEquipmentType[] containedInTransportEquipmentField;
    private PackageType[] packageField;
    private GoodsItemType[] goodsItemField;

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

    [XmlElement("ReferencedConsignmentID", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public ReferencedConsignmentIDType[] ReferencedConsignmentID
    {
        get
        {
            return this.referencedConsignmentIDField;
        }
        set
        {
            this.referencedConsignmentIDField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public TransportEquipmentTypeCodeType TransportEquipmentTypeCode
    {
        get
        {
            return this.transportEquipmentTypeCodeField;
        }
        set
        {
            this.transportEquipmentTypeCodeField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public ProviderTypeCodeType ProviderTypeCode
    {
        get
        {
            return this.providerTypeCodeField;
        }
        set
        {
            this.providerTypeCodeField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public OwnerTypeCodeType OwnerTypeCode
    {
        get
        {
            return this.ownerTypeCodeField;
        }
        set
        {
            this.ownerTypeCodeField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public SizeTypeCodeType SizeTypeCode
    {
        get
        {
            return this.sizeTypeCodeField;
        }
        set
        {
            this.sizeTypeCodeField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public DispositionCodeType DispositionCode
    {
        get
        {
            return this.dispositionCodeField;
        }
        set
        {
            this.dispositionCodeField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public FullnessIndicationCodeType FullnessIndicationCode
    {
        get
        {
            return this.fullnessIndicationCodeField;
        }
        set
        {
            this.fullnessIndicationCodeField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public RefrigerationOnIndicatorType RefrigerationOnIndicator
    {
        get
        {
            return this.refrigerationOnIndicatorField;
        }
        set
        {
            this.refrigerationOnIndicatorField = value;
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
    public ReturnabilityIndicatorType ReturnabilityIndicator
    {
        get
        {
            return this.returnabilityIndicatorField;
        }
        set
        {
            this.returnabilityIndicatorField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public LegalStatusIndicatorType LegalStatusIndicator
    {
        get
        {
            return this.legalStatusIndicatorField;
        }
        set
        {
            this.legalStatusIndicatorField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public AirFlowPercentType AirFlowPercent
    {
        get
        {
            return this.airFlowPercentField;
        }
        set
        {
            this.airFlowPercentField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public HumidityPercentType HumidityPercent
    {
        get
        {
            return this.humidityPercentField;
        }
        set
        {
            this.humidityPercentField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public AnimalFoodApprovedIndicatorType AnimalFoodApprovedIndicator
    {
        get
        {
            return this.animalFoodApprovedIndicatorField;
        }
        set
        {
            this.animalFoodApprovedIndicatorField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public HumanFoodApprovedIndicatorType HumanFoodApprovedIndicator
    {
        get
        {
            return this.humanFoodApprovedIndicatorField;
        }
        set
        {
            this.humanFoodApprovedIndicatorField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public DangerousGoodsApprovedIndicatorType DangerousGoodsApprovedIndicator
    {
        get
        {
            return this.dangerousGoodsApprovedIndicatorField;
        }
        set
        {
            this.dangerousGoodsApprovedIndicatorField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public RefrigeratedIndicatorType RefrigeratedIndicator
    {
        get
        {
            return this.refrigeratedIndicatorField;
        }
        set
        {
            this.refrigeratedIndicatorField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public CharacteristicsType Characteristics
    {
        get
        {
            return this.characteristicsField;
        }
        set
        {
            this.characteristicsField = value;
        }
    }

    [XmlElement("DamageRemarks", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public DamageRemarksType[] DamageRemarks
    {
        get
        {
            return this.damageRemarksField;
        }
        set
        {
            this.damageRemarksField = value;
        }
    }

    [XmlElement("Description", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public DescriptionType[] Description
    {
        get
        {
            return this.descriptionField;
        }
        set
        {
            this.descriptionField = value;
        }
    }

    [XmlElement("SpecialTransportRequirements", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public SpecialTransportRequirementsType[] SpecialTransportRequirements
    {
        get
        {
            return this.specialTransportRequirementsField;
        }
        set
        {
            this.specialTransportRequirementsField = value;
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
    public TareWeightMeasureType TareWeightMeasure
    {
        get
        {
            return this.tareWeightMeasureField;
        }
        set
        {
            this.tareWeightMeasureField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public TrackingDeviceCodeType TrackingDeviceCode
    {
        get
        {
            return this.trackingDeviceCodeField;
        }
        set
        {
            this.trackingDeviceCodeField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public PowerIndicatorType PowerIndicator
    {
        get
        {
            return this.powerIndicatorField;
        }
        set
        {
            this.powerIndicatorField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public TraceIDType TraceID
    {
        get
        {
            return this.traceIDField;
        }
        set
        {
            this.traceIDField = value;
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

    [XmlElement("TransportEquipmentSeal")]
    public TransportEquipmentSealType[] TransportEquipmentSeal
    {
        get
        {
            return this.transportEquipmentSealField;
        }
        set
        {
            this.transportEquipmentSealField = value;
        }
    }

    public TemperatureType MinimumTemperature
    {
        get
        {
            return this.minimumTemperatureField;
        }
        set
        {
            this.minimumTemperatureField = value;
        }
    }

    public TemperatureType MaximumTemperature
    {
        get
        {
            return this.maximumTemperatureField;
        }
        set
        {
            this.maximumTemperatureField = value;
        }
    }

    public PartyType ProviderParty
    {
        get
        {
            return this.providerPartyField;
        }
        set
        {
            this.providerPartyField = value;
        }
    }

    public PartyType LoadingProofParty
    {
        get
        {
            return this.loadingProofPartyField;
        }
        set
        {
            this.loadingProofPartyField = value;
        }
    }

    public SupplierPartyType SupplierParty
    {
        get
        {
            return this.supplierPartyField;
        }
        set
        {
            this.supplierPartyField = value;
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

    public PartyType OperatingParty
    {
        get
        {
            return this.operatingPartyField;
        }
        set
        {
            this.operatingPartyField = value;
        }
    }

    public LocationType1 LoadingLocation
    {
        get
        {
            return this.loadingLocationField;
        }
        set
        {
            this.loadingLocationField = value;
        }
    }

    public LocationType1 UnloadingLocation
    {
        get
        {
            return this.unloadingLocationField;
        }
        set
        {
            this.unloadingLocationField = value;
        }
    }

    public LocationType1 StorageLocation
    {
        get
        {
            return this.storageLocationField;
        }
        set
        {
            this.storageLocationField = value;
        }
    }

    [XmlElement("PositioningTransportEvent")]
    public TransportEventType[] PositioningTransportEvent
    {
        get
        {
            return this.positioningTransportEventField;
        }
        set
        {
            this.positioningTransportEventField = value;
        }
    }

    [XmlElement("QuarantineTransportEvent")]
    public TransportEventType[] QuarantineTransportEvent
    {
        get
        {
            return this.quarantineTransportEventField;
        }
        set
        {
            this.quarantineTransportEventField = value;
        }
    }

    [XmlElement("DeliveryTransportEvent")]
    public TransportEventType[] DeliveryTransportEvent
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

    [XmlElement("PickupTransportEvent")]
    public TransportEventType[] PickupTransportEvent
    {
        get
        {
            return this.pickupTransportEventField;
        }
        set
        {
            this.pickupTransportEventField = value;
        }
    }

    [XmlElement("HandlingTransportEvent")]
    public TransportEventType[] HandlingTransportEvent
    {
        get
        {
            return this.handlingTransportEventField;
        }
        set
        {
            this.handlingTransportEventField = value;
        }
    }

    [XmlElement("LoadingTransportEvent")]
    public TransportEventType[] LoadingTransportEvent
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

    public TransportMeansType ApplicableTransportMeans
    {
        get
        {
            return this.applicableTransportMeansField;
        }
        set
        {
            this.applicableTransportMeansField = value;
        }
    }

    [XmlElement("HaulageTradingTerms")]
    public TradingTermsType[] HaulageTradingTerms
    {
        get
        {
            return this.haulageTradingTermsField;
        }
        set
        {
            this.haulageTradingTermsField = value;
        }
    }

    [XmlElement("HazardousGoodsTransit")]
    public HazardousGoodsTransitType[] HazardousGoodsTransit
    {
        get
        {
            return this.hazardousGoodsTransitField;
        }
        set
        {
            this.hazardousGoodsTransitField = value;
        }
    }

    [XmlElement("PackagedTransportHandlingUnit")]
    public TransportHandlingUnitType[] PackagedTransportHandlingUnit
    {
        get
        {
            return this.packagedTransportHandlingUnitField;
        }
        set
        {
            this.packagedTransportHandlingUnitField = value;
        }
    }

    [XmlElement("ServiceAllowanceCharge")]
    public AllowanceChargeType[] ServiceAllowanceCharge
    {
        get
        {
            return this.serviceAllowanceChargeField;
        }
        set
        {
            this.serviceAllowanceChargeField = value;
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

    [XmlElement("AttachedTransportEquipment")]
    public TransportEquipmentType[] AttachedTransportEquipment
    {
        get
        {
            return this.attachedTransportEquipmentField;
        }
        set
        {
            this.attachedTransportEquipmentField = value;
        }
    }

    public DeliveryType Delivery
    {
        get
        {
            return this.deliveryField;
        }
        set
        {
            this.deliveryField = value;
        }
    }

    public PickupType Pickup
    {
        get
        {
            return this.pickupField;
        }
        set
        {
            this.pickupField = value;
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

    [XmlElement("ShipmentDocumentReference")]
    public DocumentReferenceType[] ShipmentDocumentReference
    {
        get
        {
            return this.shipmentDocumentReferenceField;
        }
        set
        {
            this.shipmentDocumentReferenceField = value;
        }
    }

    [XmlElement("ContainedInTransportEquipment")]
    public TransportEquipmentType[] ContainedInTransportEquipment
    {
        get
        {
            return this.containedInTransportEquipmentField;
        }
        set
        {
            this.containedInTransportEquipmentField = value;
        }
    }

    [XmlElement("Package")]
    public PackageType[] Package
    {
        get
        {
            return this.packageField;
        }
        set
        {
            this.packageField = value;
        }
    }

    [XmlElement("GoodsItem")]
    public GoodsItemType[] GoodsItem
    {
        get
        {
            return this.goodsItemField;
        }
        set
        {
            this.goodsItemField = value;
        }
    }
}
