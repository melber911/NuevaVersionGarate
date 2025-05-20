using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[XmlRoot("RequestedTenderTotal", IsNullable = false, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[GeneratedCode("xsd", "4.0.30319.33440")]
[DebuggerStepThrough]
[DesignerCategory("code")]
[XmlType(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[Serializable]
public class RequestedTenderTotalType
{
    private EstimatedOverallContractAmountType estimatedOverallContractAmountField;
    private TotalAmountType totalAmountField;
    private TaxIncludedIndicatorType taxIncludedIndicatorField;
    private MinimumAmountType minimumAmountField;
    private MaximumAmountType maximumAmountField;
    private MonetaryScopeType[] monetaryScopeField;
    private AverageSubsequentContractAmountType averageSubsequentContractAmountField;
    private TaxCategoryType[] applicableTaxCategoryField;

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public EstimatedOverallContractAmountType EstimatedOverallContractAmount
    {
        get
        {
            return this.estimatedOverallContractAmountField;
        }
        set
        {
            this.estimatedOverallContractAmountField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public TotalAmountType TotalAmount
    {
        get
        {
            return this.totalAmountField;
        }
        set
        {
            this.totalAmountField = value;
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

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public MinimumAmountType MinimumAmount
    {
        get
        {
            return this.minimumAmountField;
        }
        set
        {
            this.minimumAmountField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public MaximumAmountType MaximumAmount
    {
        get
        {
            return this.maximumAmountField;
        }
        set
        {
            this.maximumAmountField = value;
        }
    }

    [XmlElement("MonetaryScope", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public MonetaryScopeType[] MonetaryScope
    {
        get
        {
            return this.monetaryScopeField;
        }
        set
        {
            this.monetaryScopeField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public AverageSubsequentContractAmountType AverageSubsequentContractAmount
    {
        get
        {
            return this.averageSubsequentContractAmountField;
        }
        set
        {
            this.averageSubsequentContractAmountField = value;
        }
    }

    [XmlElement("ApplicableTaxCategory")]
    public TaxCategoryType[] ApplicableTaxCategory
    {
        get
        {
            return this.applicableTaxCategoryField;
        }
        set
        {
            this.applicableTaxCategoryField = value;
        }
    }
}
