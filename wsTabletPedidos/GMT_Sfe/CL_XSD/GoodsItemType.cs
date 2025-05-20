using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[GeneratedCode("xsd", "4.0.30319.33440")]
[XmlType(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[DesignerCategory("code")]
[XmlRoot("ContainedGoodsItem", IsNullable = false, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[DebuggerStepThrough]
[Serializable]
public class GoodsItemType
{
    private IDType idField;
    private SequenceNumberIDType sequenceNumberIDField;
    private DescriptionType[] descriptionField;
    private HazardousRiskIndicatorType hazardousRiskIndicatorField;
    private DeclaredCustomsValueAmountType declaredCustomsValueAmountField;
    private DeclaredForCarriageValueAmountType declaredForCarriageValueAmountField;
    private DeclaredStatisticsValueAmountType declaredStatisticsValueAmountField;
    private FreeOnBoardValueAmountType freeOnBoardValueAmountField;
    private InsuranceValueAmountType insuranceValueAmountField;
    private ValueAmountType valueAmountField;
    private GrossWeightMeasureType grossWeightMeasureField;
    private NetWeightMeasureType netWeightMeasureField;
    private NetNetWeightMeasureType netNetWeightMeasureField;
    private ChargeableWeightMeasureType chargeableWeightMeasureField;
    private GrossVolumeMeasureType grossVolumeMeasureField;
    private NetVolumeMeasureType netVolumeMeasureField;
    private QuantityType2 quantityField;
    private PreferenceCriterionCodeType preferenceCriterionCodeField;
    private RequiredCustomsIDType requiredCustomsIDField;
    private CustomsStatusCodeType customsStatusCodeField;
    private CustomsTariffQuantityType customsTariffQuantityField;
    private CustomsImportClassifiedIndicatorType customsImportClassifiedIndicatorField;
    private ChargeableQuantityType chargeableQuantityField;
    private ReturnableQuantityType returnableQuantityField;
    private TraceIDType traceIDField;
    private ItemType[] itemField;
    private GoodsItemContainerType[] goodsItemContainerField;
    private AllowanceChargeType[] freightAllowanceChargeField;
    private InvoiceLineType[] invoiceLineField;
    private TemperatureType[] temperatureField;
    private GoodsItemType[] containedGoodsItemField;
    private AddressType originAddressField;
    private DeliveryType deliveryField;
    private PickupType pickupField;
    private DespatchType despatchField;
    private DimensionType[] measurementDimensionField;
    private PackageType[] containingPackageField;
    private DocumentReferenceType shipmentDocumentReferenceField;
    private TemperatureType minimumTemperatureField;
    private TemperatureType maximumTemperatureField;

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
    public SequenceNumberIDType SequenceNumberID
    {
        get
        {
            return this.sequenceNumberIDField;
        }
        set
        {
            this.sequenceNumberIDField = value;
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
    public ValueAmountType ValueAmount
    {
        get
        {
            return this.valueAmountField;
        }
        set
        {
            this.valueAmountField = value;
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
    public PreferenceCriterionCodeType PreferenceCriterionCode
    {
        get
        {
            return this.preferenceCriterionCodeField;
        }
        set
        {
            this.preferenceCriterionCodeField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public RequiredCustomsIDType RequiredCustomsID
    {
        get
        {
            return this.requiredCustomsIDField;
        }
        set
        {
            this.requiredCustomsIDField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public CustomsStatusCodeType CustomsStatusCode
    {
        get
        {
            return this.customsStatusCodeField;
        }
        set
        {
            this.customsStatusCodeField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public CustomsTariffQuantityType CustomsTariffQuantity
    {
        get
        {
            return this.customsTariffQuantityField;
        }
        set
        {
            this.customsTariffQuantityField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public CustomsImportClassifiedIndicatorType CustomsImportClassifiedIndicator
    {
        get
        {
            return this.customsImportClassifiedIndicatorField;
        }
        set
        {
            this.customsImportClassifiedIndicatorField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public ChargeableQuantityType ChargeableQuantity
    {
        get
        {
            return this.chargeableQuantityField;
        }
        set
        {
            this.chargeableQuantityField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public ReturnableQuantityType ReturnableQuantity
    {
        get
        {
            return this.returnableQuantityField;
        }
        set
        {
            this.returnableQuantityField = value;
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

    [XmlElement("Item")]
    public ItemType[] Item
    {
        get
        {
            return this.itemField;
        }
        set
        {
            this.itemField = value;
        }
    }

    [XmlElement("GoodsItemContainer")]
    public GoodsItemContainerType[] GoodsItemContainer
    {
        get
        {
            return this.goodsItemContainerField;
        }
        set
        {
            this.goodsItemContainerField = value;
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

    [XmlElement("InvoiceLine")]
    public InvoiceLineType[] InvoiceLine
    {
        get
        {
            return this.invoiceLineField;
        }
        set
        {
            this.invoiceLineField = value;
        }
    }

    [XmlElement("Temperature")]
    public TemperatureType[] Temperature
    {
        get
        {
            return this.temperatureField;
        }
        set
        {
            this.temperatureField = value;
        }
    }

    [XmlElement("ContainedGoodsItem")]
    public GoodsItemType[] ContainedGoodsItem
    {
        get
        {
            return this.containedGoodsItemField;
        }
        set
        {
            this.containedGoodsItemField = value;
        }
    }

    public AddressType OriginAddress
    {
        get
        {
            return this.originAddressField;
        }
        set
        {
            this.originAddressField = value;
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

    [XmlElement("ContainingPackage")]
    public PackageType[] ContainingPackage
    {
        get
        {
            return this.containingPackageField;
        }
        set
        {
            this.containingPackageField = value;
        }
    }

    public DocumentReferenceType ShipmentDocumentReference
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
}
