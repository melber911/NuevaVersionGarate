using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[DesignerCategory("code")]
[DebuggerStepThrough]
[GeneratedCode("xsd", "4.0.30319.33440")]
[XmlType(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[XmlRoot("CompletedTask", IsNullable = false, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[Serializable]
public class CompletedTaskType
{
    private AnnualAverageAmountType annualAverageAmountField;
    private TotalTaskAmountType totalTaskAmountField;
    private PartyCapacityAmountType partyCapacityAmountField;
    private DescriptionType[] descriptionField;
    private EvidenceSuppliedType[] evidenceSuppliedField;
    private PeriodType periodField;
    private CustomerPartyType recipientCustomerPartyField;

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public AnnualAverageAmountType AnnualAverageAmount
    {
        get
        {
            return this.annualAverageAmountField;
        }
        set
        {
            this.annualAverageAmountField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public TotalTaskAmountType TotalTaskAmount
    {
        get
        {
            return this.totalTaskAmountField;
        }
        set
        {
            this.totalTaskAmountField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public PartyCapacityAmountType PartyCapacityAmount
    {
        get
        {
            return this.partyCapacityAmountField;
        }
        set
        {
            this.partyCapacityAmountField = value;
        }
    }

    [XmlElement("Description", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public DescriptionType[] Description
    {
        get
        {
            return this.descriptionField;
        }
        set
        {
            this.descriptionField = value;
        }
    }

    [XmlElement("EvidenceSupplied")]
    public EvidenceSuppliedType[] EvidenceSupplied
    {
        get
        {
            return this.evidenceSuppliedField;
        }
        set
        {
            this.evidenceSuppliedField = value;
        }
    }

    public PeriodType Period
    {
        get
        {
            return this.periodField;
        }
        set
        {
            this.periodField = value;
        }
    }

    public CustomerPartyType RecipientCustomerParty
    {
        get
        {
            return this.recipientCustomerPartyField;
        }
        set
        {
            this.recipientCustomerPartyField = value;
        }
    }
}
