using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[GeneratedCode("xsd", "4.0.30319.33440")]
[XmlType(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[XmlRoot("AlternativeConditionPrice", IsNullable = false, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[DebuggerStepThrough]
[DesignerCategory("code")]
[Serializable]
public class PriceType
{
    private PriceAmountType priceAmountField;
    private BaseQuantityType baseQuantityField;
    private PriceChangeReasonType[] priceChangeReasonField;
    private PriceTypeCodeType priceTypeCodeField;
    private PriceTypeType PriceType1Field;
    private OrderableUnitFactorRateType orderableUnitFactorRateField;
    private PeriodType[] validityPeriodField;
    private PriceListType priceListField;
    private AllowanceChargeType[] allowanceChargeField;
    private ExchangeRateType pricingExchangeRateField;

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public PriceAmountType PriceAmount
    {
        get
        {
            return this.priceAmountField;
        }
        set
        {
            this.priceAmountField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public BaseQuantityType BaseQuantity
    {
        get
        {
            return this.baseQuantityField;
        }
        set
        {
            this.baseQuantityField = value;
        }
    }

    [XmlElement("PriceChangeReason", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public PriceChangeReasonType[] PriceChangeReason
    {
        get
        {
            return this.priceChangeReasonField;
        }
        set
        {
            this.priceChangeReasonField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public PriceTypeCodeType PriceTypeCode
    {
        get
        {
            return this.priceTypeCodeField;
        }
        set
        {
            this.priceTypeCodeField = value;
        }
    }

    [XmlElement("PriceType", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public PriceTypeType PriceType1
    {
        get
        {
            return this.PriceType1Field;
        }
        set
        {
            this.PriceType1Field = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public OrderableUnitFactorRateType OrderableUnitFactorRate
    {
        get
        {
            return this.orderableUnitFactorRateField;
        }
        set
        {
            this.orderableUnitFactorRateField = value;
        }
    }

    [XmlElement("ValidityPeriod")]
    public PeriodType[] ValidityPeriod
    {
        get
        {
            return this.validityPeriodField;
        }
        set
        {
            this.validityPeriodField = value;
        }
    }

    public PriceListType PriceList
    {
        get
        {
            return this.priceListField;
        }
        set
        {
            this.priceListField = value;
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

    public ExchangeRateType PricingExchangeRate
    {
        get
        {
            return this.pricingExchangeRateField;
        }
        set
        {
            this.pricingExchangeRateField = value;
        }
    }
}
