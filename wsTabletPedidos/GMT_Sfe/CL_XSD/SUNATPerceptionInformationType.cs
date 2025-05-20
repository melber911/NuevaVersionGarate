using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[DebuggerStepThrough]
[XmlRoot("SUNATPerceptionInformation", IsNullable = false, Namespace = "urn:sunat:names:specification:ubl:peru:schema:xsd:SunatAggregateComponents-1")]
[GeneratedCode("xsd", "4.0.30319.1")]
[DesignerCategory("code")]
[XmlType(Namespace = "urn:sunat:names:specification:ubl:peru:schema:xsd:SunatAggregateComponents-1")]
[Serializable]
public class SUNATPerceptionInformationType
{
    private SUNATPerceptionAmountType sUNATPerceptionAmountField;
    private SUNATPerceptionDateType sUNATPerceptionDateField;
    private SUNATNetTotalCashedType sUNATNetTotalCashedField;
    private ExchangeRateType exchangeRateField;

    [XmlElement(Namespace = "urn:sunat:names:specification:ubl:peru:schema:xsd:SunatAggregateComponents-1")]
    public SUNATPerceptionAmountType SUNATPerceptionAmount
    {
        get
        {
            return this.sUNATPerceptionAmountField;
        }
        set
        {
            this.sUNATPerceptionAmountField = value;
        }
    }

    [XmlElement(Namespace = "urn:sunat:names:specification:ubl:peru:schema:xsd:SunatAggregateComponents-1")]
    public SUNATPerceptionDateType SUNATPerceptionDate
    {
        get
        {
            return this.sUNATPerceptionDateField;
        }
        set
        {
            this.sUNATPerceptionDateField = value;
        }
    }

    [XmlElement(Namespace = "urn:sunat:names:specification:ubl:peru:schema:xsd:SunatAggregateComponents-1")]
    public SUNATNetTotalCashedType SUNATNetTotalCashed
    {
        get
        {
            return this.sUNATNetTotalCashedField;
        }
        set
        {
            this.sUNATNetTotalCashedField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
    public ExchangeRateType ExchangeRate
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
}
