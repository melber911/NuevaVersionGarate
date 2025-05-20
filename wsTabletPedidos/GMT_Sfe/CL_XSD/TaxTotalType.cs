using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[XmlRoot("TaxTotal", IsNullable = false, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[DesignerCategory("code")]
[GeneratedCode("xsd", "4.0.30319.33440")]
[XmlType(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[DebuggerStepThrough]
[Serializable]
public class TaxTotalType
{
    private TaxAmountType taxAmountField;
    private RoundingAmountType roundingAmountField;
    private TaxEvidenceIndicatorType taxEvidenceIndicatorField;
    private TaxIncludedIndicatorType taxIncludedIndicatorField;
    private TaxSubtotalType[] taxSubtotalField;

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public TaxAmountType TaxAmount
    {
        get
        {
            return this.taxAmountField;
        }
        set
        {
            this.taxAmountField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public RoundingAmountType RoundingAmount
    {
        get
        {
            return this.roundingAmountField;
        }
        set
        {
            this.roundingAmountField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public TaxEvidenceIndicatorType TaxEvidenceIndicator
    {
        get
        {
            return this.taxEvidenceIndicatorField;
        }
        set
        {
            this.taxEvidenceIndicatorField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public TaxIncludedIndicatorType TaxIncludedIndicator
    {
        get
        {
            return this.taxIncludedIndicatorField;
        }
        set
        {
            this.taxIncludedIndicatorField = value;
        }
    }

    [XmlElement("TaxSubtotal")]
    public TaxSubtotalType[] TaxSubtotal
    {
        get
        {
            return this.taxSubtotalField;
        }
        set
        {
            this.taxSubtotalField = value;
        }
    }
}
