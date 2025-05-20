using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[XmlRoot("TenderResult", IsNullable = false, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[GeneratedCode("xsd", "4.0.30319.33440")]
[DebuggerStepThrough]
[XmlType(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[DesignerCategory("code")]
[Serializable]
public class TenderResultType
{
    private TenderResultCodeType tenderResultCodeField;
    private DescriptionType[] descriptionField;
    private AdvertisementAmountType advertisementAmountField;
    private AwardDateType awardDateField;
    private AwardTimeType awardTimeField;
    private ReceivedTenderQuantityType receivedTenderQuantityField;
    private LowerTenderAmountType lowerTenderAmountField;
    private HigherTenderAmountType higherTenderAmountField;
    private StartDateType startDateField;
    private ReceivedElectronicTenderQuantityType receivedElectronicTenderQuantityField;
    private ReceivedForeignTenderQuantityType receivedForeignTenderQuantityField;
    private ContractType contractField;
    private TenderedProjectType awardedTenderedProjectField;
    private PeriodType contractFormalizationPeriodField;
    private SubcontractTermsType[] subcontractTermsField;
    private WinningPartyType[] winningPartyField;

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public TenderResultCodeType TenderResultCode
    {
        get
        {
            return this.tenderResultCodeField;
        }
        set
        {
            this.tenderResultCodeField = value;
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
    public AdvertisementAmountType AdvertisementAmount
    {
        get
        {
            return this.advertisementAmountField;
        }
        set
        {
            this.advertisementAmountField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public AwardDateType AwardDate
    {
        get
        {
            return this.awardDateField;
        }
        set
        {
            this.awardDateField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public AwardTimeType AwardTime
    {
        get
        {
            return this.awardTimeField;
        }
        set
        {
            this.awardTimeField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public ReceivedTenderQuantityType ReceivedTenderQuantity
    {
        get
        {
            return this.receivedTenderQuantityField;
        }
        set
        {
            this.receivedTenderQuantityField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public LowerTenderAmountType LowerTenderAmount
    {
        get
        {
            return this.lowerTenderAmountField;
        }
        set
        {
            this.lowerTenderAmountField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public HigherTenderAmountType HigherTenderAmount
    {
        get
        {
            return this.higherTenderAmountField;
        }
        set
        {
            this.higherTenderAmountField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public StartDateType StartDate
    {
        get
        {
            return this.startDateField;
        }
        set
        {
            this.startDateField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public ReceivedElectronicTenderQuantityType ReceivedElectronicTenderQuantity
    {
        get
        {
            return this.receivedElectronicTenderQuantityField;
        }
        set
        {
            this.receivedElectronicTenderQuantityField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public ReceivedForeignTenderQuantityType ReceivedForeignTenderQuantity
    {
        get
        {
            return this.receivedForeignTenderQuantityField;
        }
        set
        {
            this.receivedForeignTenderQuantityField = value;
        }
    }

    public ContractType Contract
    {
        get
        {
            return this.contractField;
        }
        set
        {
            this.contractField = value;
        }
    }

    public TenderedProjectType AwardedTenderedProject
    {
        get
        {
            return this.awardedTenderedProjectField;
        }
        set
        {
            this.awardedTenderedProjectField = value;
        }
    }

    public PeriodType ContractFormalizationPeriod
    {
        get
        {
            return this.contractFormalizationPeriodField;
        }
        set
        {
            this.contractFormalizationPeriodField = value;
        }
    }

    [XmlElement("SubcontractTerms")]
    public SubcontractTermsType[] SubcontractTerms
    {
        get
        {
            return this.subcontractTermsField;
        }
        set
        {
            this.subcontractTermsField = value;
        }
    }

    [XmlElement("WinningParty")]
    public WinningPartyType[] WinningParty
    {
        get
        {
            return this.winningPartyField;
        }
        set
        {
            this.winningPartyField = value;
        }
    }
}
