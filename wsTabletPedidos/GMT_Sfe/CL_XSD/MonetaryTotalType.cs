using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[GeneratedCode("xsd", "4.0.30319.33440")]
[XmlRoot("AnticipatedMonetaryTotal", IsNullable = false, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[DebuggerStepThrough]
[DesignerCategory("code")]
[XmlType(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[Serializable]
public class MonetaryTotalType
{
    private LineExtensionAmountType lineExtensionAmountField;
    private TaxExclusiveAmountType taxExclusiveAmountField;
    private TaxInclusiveAmountType taxInclusiveAmountField;
    private AllowanceTotalAmountType allowanceTotalAmountField;
    private ChargeTotalAmountType chargeTotalAmountField;
    private PrepaidAmountType prepaidAmountField;
    private PayableRoundingAmountType payableRoundingAmountField;
    private PayableAmountType payableAmountField;
    private PayableAlternativeAmountType payableAlternativeAmountField;

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public LineExtensionAmountType LineExtensionAmount
    {
        get
        {
            return this.lineExtensionAmountField;
        }
        set
        {
            this.lineExtensionAmountField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public TaxExclusiveAmountType TaxExclusiveAmount
    {
        get
        {
            return this.taxExclusiveAmountField;
        }
        set
        {
            this.taxExclusiveAmountField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public TaxInclusiveAmountType TaxInclusiveAmount
    {
        get
        {
            return this.taxInclusiveAmountField;
        }
        set
        {
            this.taxInclusiveAmountField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public AllowanceTotalAmountType AllowanceTotalAmount
    {
        get
        {
            return this.allowanceTotalAmountField;
        }
        set
        {
            this.allowanceTotalAmountField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public ChargeTotalAmountType ChargeTotalAmount
    {
        get
        {
            return this.chargeTotalAmountField;
        }
        set
        {
            this.chargeTotalAmountField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public PrepaidAmountType PrepaidAmount
    {
        get
        {
            return this.prepaidAmountField;
        }
        set
        {
            this.prepaidAmountField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public PayableRoundingAmountType PayableRoundingAmount
    {
        get
        {
            return this.payableRoundingAmountField;
        }
        set
        {
            this.payableRoundingAmountField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public PayableAmountType PayableAmount
    {
        get
        {
            return this.payableAmountField;
        }
        set
        {
            this.payableAmountField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public PayableAlternativeAmountType PayableAlternativeAmount
    {
        get
        {
            return this.payableAlternativeAmountField;
        }
        set
        {
            this.payableAlternativeAmountField = value;
        }
    }
}
