using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[DebuggerStepThrough]
[DesignerCategory("code")]
[XmlRoot("ActualPackage", IsNullable = false, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[GeneratedCode("xsd", "4.0.30319.33440")]
[XmlType(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[Serializable]
public class PackageType
{
    private IDType idField;
    private QuantityType2 quantityField;
    private ReturnableMaterialIndicatorType returnableMaterialIndicatorField;
    private PackageLevelCodeType packageLevelCodeField;
    private PackagingTypeCodeType packagingTypeCodeField;
    private PackingMaterialType[] packingMaterialField;
    private TraceIDType traceIDField;
    private PackageType[] containedPackageField;
    private TransportEquipmentType containingTransportEquipmentField;
    private GoodsItemType[] goodsItemField;
    private DimensionType[] measurementDimensionField;
    private DeliveryUnitType[] deliveryUnitField;
    private DeliveryType deliveryField;
    private PickupType pickupField;
    private DespatchType despatchField;

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
    public ReturnableMaterialIndicatorType ReturnableMaterialIndicator
    {
        get
        {
            return this.returnableMaterialIndicatorField;
        }
        set
        {
            this.returnableMaterialIndicatorField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public PackageLevelCodeType PackageLevelCode
    {
        get
        {
            return this.packageLevelCodeField;
        }
        set
        {
            this.packageLevelCodeField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public PackagingTypeCodeType PackagingTypeCode
    {
        get
        {
            return this.packagingTypeCodeField;
        }
        set
        {
            this.packagingTypeCodeField = value;
        }
    }

    [XmlElement("PackingMaterial", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public PackingMaterialType[] PackingMaterial
    {
        get
        {
            return this.packingMaterialField;
        }
        set
        {
            this.packingMaterialField = value;
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

    [XmlElement("ContainedPackage")]
    public PackageType[] ContainedPackage
    {
        get
        {
            return this.containedPackageField;
        }
        set
        {
            this.containedPackageField = value;
        }
    }

    public TransportEquipmentType ContainingTransportEquipment
    {
        get
        {
            return this.containingTransportEquipmentField;
        }
        set
        {
            this.containingTransportEquipmentField = value;
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

    [XmlElement("DeliveryUnit")]
    public DeliveryUnitType[] DeliveryUnit
    {
        get
        {
            return this.deliveryUnitField;
        }
        set
        {
            this.deliveryUnitField = value;
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
}
