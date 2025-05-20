using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[XmlRoot("TelecommunicationsService", IsNullable = false, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[GeneratedCode("xsd", "4.0.30319.33440")]
[DebuggerStepThrough]
[DesignerCategory("code")]
[XmlType(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[Serializable]
public class TelecommunicationsServiceType
{
    private IDType idField;
    private CallDateType callDateField;
    private CallTimeType callTimeField;
    private ServiceNumberCalledType serviceNumberCalledField;
    private TelecommunicationsServiceCategoryType telecommunicationsServiceCategoryField;
    private TelecommunicationsServiceCategoryCodeType telecommunicationsServiceCategoryCodeField;
    private MovieTitleType movieTitleField;
    private RoamingPartnerNameType roamingPartnerNameField;
    private PayPerViewType payPerViewField;
    private QuantityType2 quantityField;
    private TelecommunicationsServiceCallType telecommunicationsServiceCallField;
    private TelecommunicationsServiceCallCodeType telecommunicationsServiceCallCodeField;
    private CallBaseAmountType callBaseAmountField;
    private CallExtensionAmountType callExtensionAmountField;
    private PriceType priceField;
    private CountryType countryField;
    private ExchangeRateType[] exchangeRateField;
    private AllowanceChargeType[] allowanceChargeField;
    private TaxTotalType[] taxTotalField;
    private DutyType1[] callDutyField;
    private DutyType1[] timeDutyField;

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
    public CallDateType CallDate
    {
        get
        {
            return this.callDateField;
        }
        set
        {
            this.callDateField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public CallTimeType CallTime
    {
        get
        {
            return this.callTimeField;
        }
        set
        {
            this.callTimeField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public ServiceNumberCalledType ServiceNumberCalled
    {
        get
        {
            return this.serviceNumberCalledField;
        }
        set
        {
            this.serviceNumberCalledField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public TelecommunicationsServiceCategoryType TelecommunicationsServiceCategory
    {
        get
        {
            return this.telecommunicationsServiceCategoryField;
        }
        set
        {
            this.telecommunicationsServiceCategoryField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public TelecommunicationsServiceCategoryCodeType TelecommunicationsServiceCategoryCode
    {
        get
        {
            return this.telecommunicationsServiceCategoryCodeField;
        }
        set
        {
            this.telecommunicationsServiceCategoryCodeField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public MovieTitleType MovieTitle
    {
        get
        {
            return this.movieTitleField;
        }
        set
        {
            this.movieTitleField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public RoamingPartnerNameType RoamingPartnerName
    {
        get
        {
            return this.roamingPartnerNameField;
        }
        set
        {
            this.roamingPartnerNameField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public PayPerViewType PayPerView
    {
        get
        {
            return this.payPerViewField;
        }
        set
        {
            this.payPerViewField = value;
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
    public TelecommunicationsServiceCallType TelecommunicationsServiceCall
    {
        get
        {
            return this.telecommunicationsServiceCallField;
        }
        set
        {
            this.telecommunicationsServiceCallField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public TelecommunicationsServiceCallCodeType TelecommunicationsServiceCallCode
    {
        get
        {
            return this.telecommunicationsServiceCallCodeField;
        }
        set
        {
            this.telecommunicationsServiceCallCodeField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public CallBaseAmountType CallBaseAmount
    {
        get
        {
            return this.callBaseAmountField;
        }
        set
        {
            this.callBaseAmountField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public CallExtensionAmountType CallExtensionAmount
    {
        get
        {
            return this.callExtensionAmountField;
        }
        set
        {
            this.callExtensionAmountField = value;
        }
    }

    public PriceType Price
    {
        get
        {
            return this.priceField;
        }
        set
        {
            this.priceField = value;
        }
    }

    public CountryType Country
    {
        get
        {
            return this.countryField;
        }
        set
        {
            this.countryField = value;
        }
    }

    [XmlElement("ExchangeRate")]
    public ExchangeRateType[] ExchangeRate
    {
        get
        {
            return this.exchangeRateField;
        }
        set
        {
            this.exchangeRateField = value;
        }
    }

    [XmlElement("AllowanceCharge")]
    public AllowanceChargeType[] AllowanceCharge
    {
        get
        {
            return this.allowanceChargeField;
        }
        set
        {
            this.allowanceChargeField = value;
        }
    }

    [XmlElement("TaxTotal")]
    public TaxTotalType[] TaxTotal
    {
        get
        {
            return this.taxTotalField;
        }
        set
        {
            this.taxTotalField = value;
        }
    }

    [XmlElement("CallDuty")]
    public DutyType1[] CallDuty
    {
        get
        {
            return this.callDutyField;
        }
        set
        {
            this.callDutyField = value;
        }
    }

    [XmlElement("TimeDuty")]
    public DutyType1[] TimeDuty
    {
        get
        {
            return this.timeDutyField;
        }
        set
        {
            this.timeDutyField = value;
        }
    }
}
