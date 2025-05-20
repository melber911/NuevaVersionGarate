using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[XmlType(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[DebuggerStepThrough]
[XmlRoot("EnergyTaxReport", IsNullable = false, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[GeneratedCode("xsd", "4.0.30319.33440")]
[DesignerCategory("code")]
[Serializable]
public class EnergyTaxReportType
{
    private TaxEnergyAmountType taxEnergyAmountField;
    private TaxEnergyOnAccountAmountType taxEnergyOnAccountAmountField;
    private TaxEnergyBalanceAmountType taxEnergyBalanceAmountField;
    private TaxSchemeType taxSchemeField;

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public TaxEnergyAmountType TaxEnergyAmount
    {
        get
        {
            return this.taxEnergyAmountField;
        }
        set
        {
            this.taxEnergyAmountField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public TaxEnergyOnAccountAmountType TaxEnergyOnAccountAmount
    {
        get
        {
            return this.taxEnergyOnAccountAmountField;
        }
        set
        {
            this.taxEnergyOnAccountAmountField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public TaxEnergyBalanceAmountType TaxEnergyBalanceAmount
    {
        get
        {
            return this.taxEnergyBalanceAmountField;
        }
        set
        {
            this.taxEnergyBalanceAmountField = value;
        }
    }

    public TaxSchemeType TaxScheme
    {
        get
        {
            return this.taxSchemeField;
        }
        set
        {
            this.taxSchemeField = value;
        }
    }
}
