using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[GeneratedCode("xsd", "4.0.30319.33440")]
[XmlRoot("ExchangeRate", IsNullable = false, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[DebuggerStepThrough]
[DesignerCategory("code")]
[XmlType(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[Serializable]
public class ExchangeRateType
{
    private SourceCurrencyCodeType sourceCurrencyCodeField;
    private SourceCurrencyBaseRateType sourceCurrencyBaseRateField;
    private TargetCurrencyCodeType targetCurrencyCodeField;
    private TargetCurrencyBaseRateType targetCurrencyBaseRateField;
    private ExchangeMarketIDType exchangeMarketIDField;
    private CalculationRateType calculationRateField;
    private MathematicOperatorCodeType mathematicOperatorCodeField;
    private DateType1 dateField;
    private ContractType foreignExchangeContractField;

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public SourceCurrencyCodeType SourceCurrencyCode
    {
        get
        {
            return this.sourceCurrencyCodeField;
        }
        set
        {
            this.sourceCurrencyCodeField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public SourceCurrencyBaseRateType SourceCurrencyBaseRate
    {
        get
        {
            return this.sourceCurrencyBaseRateField;
        }
        set
        {
            this.sourceCurrencyBaseRateField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public TargetCurrencyCodeType TargetCurrencyCode
    {
        get
        {
            return this.targetCurrencyCodeField;
        }
        set
        {
            this.targetCurrencyCodeField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public TargetCurrencyBaseRateType TargetCurrencyBaseRate
    {
        get
        {
            return this.targetCurrencyBaseRateField;
        }
        set
        {
            this.targetCurrencyBaseRateField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public ExchangeMarketIDType ExchangeMarketID
    {
        get
        {
            return this.exchangeMarketIDField;
        }
        set
        {
            this.exchangeMarketIDField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public CalculationRateType CalculationRate
    {
        get
        {
            return this.calculationRateField;
        }
        set
        {
            this.calculationRateField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public MathematicOperatorCodeType MathematicOperatorCode
    {
        get
        {
            return this.mathematicOperatorCodeField;
        }
        set
        {
            this.mathematicOperatorCodeField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public DateType1 Date
    {
        get
        {
            return this.dateField;
        }
        set
        {
            this.dateField = value;
        }
    }

    public ContractType ForeignExchangeContract
    {
        get
        {
            return this.foreignExchangeContractField;
        }
        set
        {
            this.foreignExchangeContractField = value;
        }
    }
}
