using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[GeneratedCode("xsd", "4.0.30319.1")]
[XmlRoot("SUNATRetentionInformation", IsNullable = false, Namespace = "urn:sunat:names:specification:ubl:peru:schema:xsd:SunatAggregateComponents-1")]
[DebuggerStepThrough]
[DesignerCategory("code")]
[XmlType(Namespace = "urn:sunat:names:specification:ubl:peru:schema:xsd:SunatAggregateComponents-1")]
[Serializable]
public class SUNATRetentionInformationType
{
    private SUNATRetentionAmountType sUNATRetentionAmountField;
    private SUNATRetentionDateType sUNATRetentionDateField;
    private SUNATNetTotalPaidType sUNATNetTotalPaidField;
    private ExchangeRateType exchangeRateField;

    [XmlElement(Namespace = "urn:sunat:names:specification:ubl:peru:schema:xsd:SunatAggregateComponents-1")]
    public SUNATRetentionAmountType SUNATRetentionAmount
    {
        get
        {
            return this.sUNATRetentionAmountField;
        }
        set
        {
            this.sUNATRetentionAmountField = value;
        }
    }

    [XmlElement(Namespace = "urn:sunat:names:specification:ubl:peru:schema:xsd:SunatAggregateComponents-1")]
    public SUNATRetentionDateType SUNATRetentionDate
    {
        get
        {
            return this.sUNATRetentionDateField;
        }
        set
        {
            this.sUNATRetentionDateField = value;
        }
    }

    [XmlElement(Namespace = "urn:sunat:names:specification:ubl:peru:schema:xsd:SunatAggregateComponents-1")]
    public SUNATNetTotalPaidType SUNATNetTotalPaid
    {
        get
        {
            return this.sUNATNetTotalPaidField;
        }
        set
        {
            this.sUNATNetTotalPaidField = value;
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
