using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[GeneratedCode("xsd", "4.0.30319.33440")]
[DebuggerStepThrough]
[XmlType(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[XmlRoot("AwardingCriterionResponse", IsNullable = false, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[DesignerCategory("code")]
[Serializable]
public class AwardingCriterionResponseType
{
    private IDType idField;
    private AwardingCriterionIDType awardingCriterionIDField;
    private AwardingCriterionDescriptionType[] awardingCriterionDescriptionField;
    private DescriptionType[] descriptionField;
    private QuantityType2 quantityField;
    private AmountType2 amountField;
    private AwardingCriterionResponseType[] subordinateAwardingCriterionResponseField;

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public IDType ID
    {
        get
        {
            return this.idField;
        }
        set
        {
            this.idField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public AwardingCriterionIDType AwardingCriterionID
    {
        get
        {
            return this.awardingCriterionIDField;
        }
        set
        {
            this.awardingCriterionIDField = value;
        }
    }

    [XmlElement("AwardingCriterionDescription", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public AwardingCriterionDescriptionType[] AwardingCriterionDescription
    {
        get
        {
            return this.awardingCriterionDescriptionField;
        }
        set
        {
            this.awardingCriterionDescriptionField = value;
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

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public QuantityType2 Quantity
    {
        get
        {
            return this.quantityField;
        }
        set
        {
            this.quantityField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public AmountType2 Amount
    {
        get
        {
            return this.amountField;
        }
        set
        {
            this.amountField = value;
        }
    }

    [XmlElement("SubordinateAwardingCriterionResponse")]
    public AwardingCriterionResponseType[] SubordinateAwardingCriterionResponse
    {
        get
        {
            return this.subordinateAwardingCriterionResponseField;
        }
        set
        {
            this.subordinateAwardingCriterionResponseField = value;
        }
    }
}
