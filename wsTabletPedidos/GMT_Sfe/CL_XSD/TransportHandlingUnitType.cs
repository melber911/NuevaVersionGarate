using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[XmlType(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[XmlRoot("PackagedTransportHandlingUnit", IsNullable = false, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[GeneratedCode("xsd", "4.0.30319.33440")]
[DebuggerStepThrough]
[DesignerCategory("code")]
[Serializable]
public class TransportHandlingUnitType
{
    private IDType idField;
    private TransportHandlingUnitTypeCodeType transportHandlingUnitTypeCodeField;
    private HandlingCodeType handlingCodeField;
    private HandlingInstructionsType[] handlingInstructionsField;
    private HazardousRiskIndicatorType hazardousRiskIndicatorField;
    private TotalGoodsItemQuantityType totalGoodsItemQuantityField;
    private TotalPackageQuantityType totalPackageQuantityField;
    private DamageRemarksType[] damageRemarksField;
    private ShippingMarksType[] shippingMarksField;
    private TraceIDType traceIDField;
    private DespatchLineType[] handlingUnitDespatchLineField;
    private PackageType[] actualPackageField;
    private ReceiptLineType[] receivedHandlingUnitReceiptLineField;
    private TransportEquipmentType[] transportEquipmentField;
    private TransportMeansType[] transportMeansField;
    private HazardousGoodsTransitType[] hazardousGoodsTransitField;
    private DimensionType[] measurementDimensionField;
    private TemperatureType minimumTemperatureField;
    private TemperatureType maximumTemperatureField;
    private GoodsItemType[] goodsItemField;
    private DimensionType floorSpaceMeasurementDimensionField;
    private DimensionType palletSpaceMeasurementDimensionField;
    private DocumentReferenceType[] shipmentDocumentReferenceField;
    private StatusType[] statusField;
    private CustomsDeclarationType[] customsDeclarationFieldF;
    private ShipmentType[] referencedShipmentField;
    private PackageType[] packageField;

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
    public TransportHandlingUnitTypeCodeType TransportHandlingUnitTypeCode
    {
        get
        {
            return this.transportHandlingUnitTypeCodeField;
        }
        set
        {
            this.transportHandlingUnitTypeCodeField = value;
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
    public TotalPackageQuantityType TotalPackageQuantity
    {
        get
        {
            return this.totalPackageQuantityField;
        }
        set
        {
            this.totalPackageQuantityField = value;
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

    [XmlElement("ShippingMarks", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public ShippingMarksType[] ShippingMarks
    {
        get
        {
            return this.shippingMarksField;
        }
        set
        {
            this.shippingMarksField = value;
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

    [XmlElement("HandlingUnitDespatchLine")]
    public DespatchLineType[] HandlingUnitDespatchLine
    {
        get
        {
            return this.handlingUnitDespatchLineField;
        }
        set
        {
            this.handlingUnitDespatchLineField = value;
        }
    }

    [XmlElement("ActualPackage")]
    public PackageType[] ActualPackage
    {
        get
        {
            return this.actualPackageField;
        }
        set
        {
            this.actualPackageField = value;
        }
    }

    [XmlElement("ReceivedHandlingUnitReceiptLine")]
    public ReceiptLineType[] ReceivedHandlingUnitReceiptLine
    {
        get
        {
            return this.receivedHandlingUnitReceiptLineField;
        }
        set
        {
            this.receivedHandlingUnitReceiptLineField = value;
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

    [XmlElement("TransportMeans")]
    public TransportMeansType[] TransportMeans
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

    public DimensionType FloorSpaceMeasurementDimension
    {
        get
        {
            return this.floorSpaceMeasurementDimensionField;
        }
        set
        {
            this.floorSpaceMeasurementDimensionField = value;
        }
    }

    public DimensionType PalletSpaceMeasurementDimension
    {
        get
        {
            return this.palletSpaceMeasurementDimensionField;
        }
        set
        {
            this.palletSpaceMeasurementDimensionField = value;
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

    [XmlElement("CustomsDeclaration")]
    public CustomsDeclarationType[] CustomsDeclaration
    {
        get
        {
            return this.customsDeclarationFieldF;
        }
        set
        {
            this.customsDeclarationFieldF = value;
        }
    }

    [XmlElement("ReferencedShipment")]
    public ShipmentType[] ReferencedShipment
    {
        get
        {
            return this.referencedShipmentField;
        }
        set
        {
            this.referencedShipmentField = value;
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
}
