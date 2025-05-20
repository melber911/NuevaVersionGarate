using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[DesignerCategory("code")]
[XmlRoot("AwardingTerms", IsNullable = false, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[DebuggerStepThrough]
[XmlType(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[GeneratedCode("xsd", "4.0.30319.33440")]
[Serializable]
public class AwardingTermsType
{
    private WeightingAlgorithmCodeType weightingAlgorithmCodeField;
    private DescriptionType[] descriptionField;
    private TechnicalCommitteeDescriptionType[] technicalCommitteeDescriptionField;
    private LowTendersDescriptionType[] lowTendersDescriptionField;
    private PrizeIndicatorType prizeIndicatorField;
    private PrizeDescriptionType[] prizeDescriptionField;
    private PaymentDescriptionType[] paymentDescriptionField;
    private FollowupContractIndicatorType followupContractIndicatorField;
    private BindingOnBuyerIndicatorType bindingOnBuyerIndicatorField;
    private AwardingCriterionType[] awardingCriterionField;
    private PersonType[] technicalCommitteePersonField;

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public WeightingAlgorithmCodeType WeightingAlgorithmCode
    {
        get
        {
            return this.weightingAlgorithmCodeField;
        }
        set
        {
            this.weightingAlgorithmCodeField = value;
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

    [XmlElement("TechnicalCommitteeDescription", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public TechnicalCommitteeDescriptionType[] TechnicalCommitteeDescription
    {
        get
        {
            return this.technicalCommitteeDescriptionField;
        }
        set
        {
            this.technicalCommitteeDescriptionField = value;
        }
    }

    [XmlElement("LowTendersDescription", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public LowTendersDescriptionType[] LowTendersDescription
    {
        get
        {
            return this.lowTendersDescriptionField;
        }
        set
        {
            this.lowTendersDescriptionField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public PrizeIndicatorType PrizeIndicator
    {
        get
        {
            return this.prizeIndicatorField;
        }
        set
        {
            this.prizeIndicatorField = value;
        }
    }

    [XmlElement("PrizeDescription", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public PrizeDescriptionType[] PrizeDescription
    {
        get
        {
            return this.prizeDescriptionField;
        }
        set
        {
            this.prizeDescriptionField = value;
        }
    }

    [XmlElement("PaymentDescription", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public PaymentDescriptionType[] PaymentDescription
    {
        get
        {
            return this.paymentDescriptionField;
        }
        set
        {
            this.paymentDescriptionField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public FollowupContractIndicatorType FollowupContractIndicator
    {
        get
        {
            return this.followupContractIndicatorField;
        }
        set
        {
            this.followupContractIndicatorField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public BindingOnBuyerIndicatorType BindingOnBuyerIndicator
    {
        get
        {
            return this.bindingOnBuyerIndicatorField;
        }
        set
        {
            this.bindingOnBuyerIndicatorField = value;
        }
    }

    [XmlElement("AwardingCriterion")]
    public AwardingCriterionType[] AwardingCriterion
    {
        get
        {
            return this.awardingCriterionField;
        }
        set
        {
            this.awardingCriterionField = value;
        }
    }

    [XmlElement("TechnicalCommitteePerson")]
    public PersonType[] TechnicalCommitteePerson
    {
        get
        {
            return this.technicalCommitteePersonField;
        }
        set
        {
            this.technicalCommitteePersonField = value;
        }
    }
}
