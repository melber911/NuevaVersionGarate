using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[GeneratedCode("xsd", "4.0.30319.33440")]
[XmlType(Namespace = "urn:sunat:names:specification:ubl:peru:schema:xsd:SunatAggregateComponents-1")]
[DesignerCategory("code")]
[XmlRoot("SUNATPerceptionSummaryDocumentReference", IsNullable = false, Namespace = "urn:sunat:names:specification:ubl:peru:schema:xsd:SunatAggregateComponents-1")]
[DebuggerStepThrough]
[Serializable]
public class SUNATPerceptionSummaryDocumentReferenceType
{
    private IDType sUNATPerceptionSystemCodeField;
    private PercentType sUNATPerceptionPercentField;
    private TotalInvoiceAmountType totalInvoiceAmountField;
    private AmountType1 sUNATTotalCashedField;
    private TaxableAmountType taxableAmountField;

    public IDType SUNATPerceptionSystemCode
    {
        get
        {
            return this.sUNATPerceptionSystemCodeField;
        }
        set
        {
            this.sUNATPerceptionSystemCodeField = value;
        }
    }

    public PercentType SUNATPerceptionPercent
    {
        get
        {
            return this.sUNATPerceptionPercentField;
        }
        set
        {
            this.sUNATPerceptionPercentField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public TotalInvoiceAmountType TotalInvoiceAmount
    {
        get
        {
            return this.totalInvoiceAmountField;
        }
        set
        {
            this.totalInvoiceAmountField = value;
        }
    }

    public AmountType1 SUNATTotalCashed
    {
        get
        {
            return this.sUNATTotalCashedField;
        }
        set
        {
            this.sUNATTotalCashedField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public TaxableAmountType TaxableAmount
    {
        get
        {
            return this.taxableAmountField;
        }
        set
        {
            this.taxableAmountField = value;
        }
    }
}
