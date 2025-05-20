using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[GeneratedCode("xsd", "4.0.30319.33440")]
[XmlRoot("ProcurementProject", IsNullable = false, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[XmlType(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[DebuggerStepThrough]
[DesignerCategory("code")]
[Serializable]
public class ProcurementProjectType
{
    private IDType idField;
    private NameType1[] nameField;
    private DescriptionType[] descriptionField;
    private ProcurementTypeCodeType procurementTypeCodeField;
    private ProcurementSubTypeCodeType procurementSubTypeCodeField;
    private QualityControlCodeType qualityControlCodeField;
    private RequiredFeeAmountType requiredFeeAmountField;
    private FeeDescriptionType[] feeDescriptionField;
    private RequestedDeliveryDateType requestedDeliveryDateField;
    private EstimatedOverallContractQuantityType estimatedOverallContractQuantityField;
    private NoteType[] noteField;
    private RequestedTenderTotalType requestedTenderTotalField;
    private CommodityClassificationType mainCommodityClassificationField;
    private CommodityClassificationType[] additionalCommodityClassificationField;
    private LocationType1[] realizedLocationField;
    private PeriodType plannedPeriodField;
    private ContractExtensionType contractExtensionField;
    private RequestForTenderLineType[] requestForTenderLineField;

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

    [XmlElement("Name", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public NameType1[] Name
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
    public ProcurementTypeCodeType ProcurementTypeCode
    {
        get
        {
            return this.procurementTypeCodeField;
        }
        set
        {
            this.procurementTypeCodeField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public ProcurementSubTypeCodeType ProcurementSubTypeCode
    {
        get
        {
            return this.procurementSubTypeCodeField;
        }
        set
        {
            this.procurementSubTypeCodeField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public QualityControlCodeType QualityControlCode
    {
        get
        {
            return this.qualityControlCodeField;
        }
        set
        {
            this.qualityControlCodeField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public RequiredFeeAmountType RequiredFeeAmount
    {
        get
        {
            return this.requiredFeeAmountField;
        }
        set
        {
            this.requiredFeeAmountField = value;
        }
    }

    [XmlElement("FeeDescription", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public FeeDescriptionType[] FeeDescription
    {
        get
        {
            return this.feeDescriptionField;
        }
        set
        {
            this.feeDescriptionField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public RequestedDeliveryDateType RequestedDeliveryDate
    {
        get
        {
            return this.requestedDeliveryDateField;
        }
        set
        {
            this.requestedDeliveryDateField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public EstimatedOverallContractQuantityType EstimatedOverallContractQuantity
    {
        get
        {
            return this.estimatedOverallContractQuantityField;
        }
        set
        {
            this.estimatedOverallContractQuantityField = value;
        }
    }

    [XmlElement("Note", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public NoteType[] Note
    {
        get
        {
            return this.noteField;
        }
        set
        {
            this.noteField = value;
        }
    }

    public RequestedTenderTotalType RequestedTenderTotal
    {
        get
        {
            return this.requestedTenderTotalField;
        }
        set
        {
            this.requestedTenderTotalField = value;
        }
    }

    public CommodityClassificationType MainCommodityClassification
    {
        get
        {
            return this.mainCommodityClassificationField;
        }
        set
        {
            this.mainCommodityClassificationField = value;
        }
    }

    [XmlElement("AdditionalCommodityClassification")]
    public CommodityClassificationType[] AdditionalCommodityClassification
    {
        get
        {
            return this.additionalCommodityClassificationField;
        }
        set
        {
            this.additionalCommodityClassificationField = value;
        }
    }

    [XmlElement("RealizedLocation")]
    public LocationType1[] RealizedLocation
    {
        get
        {
            return this.realizedLocationField;
        }
        set
        {
            this.realizedLocationField = value;
        }
    }

    public PeriodType PlannedPeriod
    {
        get
        {
            return this.plannedPeriodField;
        }
        set
        {
            this.plannedPeriodField = value;
        }
    }

    public ContractExtensionType ContractExtension
    {
        get
        {
            return this.contractExtensionField;
        }
        set
        {
            this.contractExtensionField = value;
        }
    }

    [XmlElement("RequestForTenderLine")]
    public RequestForTenderLineType[] RequestForTenderLine
    {
        get
        {
            return this.requestForTenderLineField;
        }
        set
        {
            this.requestForTenderLineField = value;
        }
    }
}
