using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[XmlType(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[XmlRoot("AdditionalTransportationService", IsNullable = false, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[GeneratedCode("xsd", "4.0.30319.33440")]
[DebuggerStepThrough]
[DesignerCategory("code")]
[Serializable]
public class TransportationServiceType
{
    private TransportServiceCodeType transportServiceCodeField;
    private TariffClassCodeType tariffClassCodeField;
    private PriorityType priorityField;
    private FreightRateClassCodeType freightRateClassCodeField;
    private TransportationServiceDescriptionType[] transportationServiceDescriptionField;
    private TransportationServiceDetailsURIType transportationServiceDetailsURIField;
    private NominationDateType nominationDateField;
    private NominationTimeType nominationTimeField;
    private NameType1 nameField;
    private SequenceNumericType sequenceNumericField;
    private TransportEquipmentType[] transportEquipmentField;
    private TransportEquipmentType[] supportedTransportEquipmentField;
    private TransportEquipmentType[] unsupportedTransportEquipmentField;
    private CommodityClassificationType[] commodityClassificationField;
    private CommodityClassificationType[] supportedCommodityClassificationField;
    private CommodityClassificationType[] unsupportedCommodityClassificationField;
    private DimensionType totalCapacityDimensionField;
    private ShipmentStageType[] shipmentStageField;
    private TransportEventType[] transportEventField;
    private PartyType responsibleTransportServiceProviderPartyField;
    private EnvironmentalEmissionType[] environmentalEmissionField;
    private PeriodType estimatedDurationPeriodField;
    private ServiceFrequencyType[] scheduledServiceFrequencyField;

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public TransportServiceCodeType TransportServiceCode
    {
        get
        {
            return this.transportServiceCodeField;
        }
        set
        {
            this.transportServiceCodeField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public TariffClassCodeType TariffClassCode
    {
        get
        {
            return this.tariffClassCodeField;
        }
        set
        {
            this.tariffClassCodeField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public PriorityType Priority
    {
        get
        {
            return this.priorityField;
        }
        set
        {
            this.priorityField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public FreightRateClassCodeType FreightRateClassCode
    {
        get
        {
            return this.freightRateClassCodeField;
        }
        set
        {
            this.freightRateClassCodeField = value;
        }
    }

    [XmlElement("TransportationServiceDescription", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public TransportationServiceDescriptionType[] TransportationServiceDescription
    {
        get
        {
            return this.transportationServiceDescriptionField;
        }
        set
        {
            this.transportationServiceDescriptionField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public TransportationServiceDetailsURIType TransportationServiceDetailsURI
    {
        get
        {
            return this.transportationServiceDetailsURIField;
        }
        set
        {
            this.transportationServiceDetailsURIField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public NominationDateType NominationDate
    {
        get
        {
            return this.nominationDateField;
        }
        set
        {
            this.nominationDateField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public NominationTimeType NominationTime
    {
        get
        {
            return this.nominationTimeField;
        }
        set
        {
            this.nominationTimeField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public NameType1 Name
    {
        get
        {
            return this.nameField;
        }
        set
        {
            this.nameField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public SequenceNumericType SequenceNumeric
    {
        get
        {
            return this.sequenceNumericField;
        }
        set
        {
            this.sequenceNumericField = value;
        }
    }

    [XmlElement("TransportEquipment")]
    public TransportEquipmentType[] TransportEquipment
    {
        get
        {
            return this.transportEquipmentField;
        }
        set
        {
            this.transportEquipmentField = value;
        }
    }

    [XmlElement("SupportedTransportEquipment")]
    public TransportEquipmentType[] SupportedTransportEquipment
    {
        get
        {
            return this.supportedTransportEquipmentField;
        }
        set
        {
            this.supportedTransportEquipmentField = value;
        }
    }

    [XmlElement("UnsupportedTransportEquipment")]
    public TransportEquipmentType[] UnsupportedTransportEquipment
    {
        get
        {
            return this.unsupportedTransportEquipmentField;
        }
        set
        {
            this.unsupportedTransportEquipmentField = value;
        }
    }

    [XmlElement("CommodityClassification")]
    public CommodityClassificationType[] CommodityClassification
    {
        get
        {
            return this.commodityClassificationField;
        }
        set
        {
            this.commodityClassificationField = value;
        }
    }

    [XmlElement("SupportedCommodityClassification")]
    public CommodityClassificationType[] SupportedCommodityClassification
    {
        get
        {
            return this.supportedCommodityClassificationField;
        }
        set
        {
            this.supportedCommodityClassificationField = value;
        }
    }

    [XmlElement("UnsupportedCommodityClassification")]
    public CommodityClassificationType[] UnsupportedCommodityClassification
    {
        get
        {
            return this.unsupportedCommodityClassificationField;
        }
        set
        {
            this.unsupportedCommodityClassificationField = value;
        }
    }

    public DimensionType TotalCapacityDimension
    {
        get
        {
            return this.totalCapacityDimensionField;
        }
        set
        {
            this.totalCapacityDimensionField = value;
        }
    }

    [XmlElement("ShipmentStage")]
    public ShipmentStageType[] ShipmentStage
    {
        get
        {
            return this.shipmentStageField;
        }
        set
        {
            this.shipmentStageField = value;
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

    public PartyType ResponsibleTransportServiceProviderParty
    {
        get
        {
            return this.responsibleTransportServiceProviderPartyField;
        }
        set
        {
            this.responsibleTransportServiceProviderPartyField = value;
        }
    }

    [XmlElement("EnvironmentalEmission")]
    public EnvironmentalEmissionType[] EnvironmentalEmission
    {
        get
        {
            return this.environmentalEmissionField;
        }
        set
        {
            this.environmentalEmissionField = value;
        }
    }

    public PeriodType EstimatedDurationPeriod
    {
        get
        {
            return this.estimatedDurationPeriodField;
        }
        set
        {
            this.estimatedDurationPeriodField = value;
        }
    }

    [XmlElement("ScheduledServiceFrequency")]
    public ServiceFrequencyType[] ScheduledServiceFrequency
    {
        get
        {
            return this.scheduledServiceFrequencyField;
        }
        set
        {
            this.scheduledServiceFrequencyField = value;
        }
    }
}
