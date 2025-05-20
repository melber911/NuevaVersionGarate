using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[DesignerCategory("code")]
[XmlType(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[XmlRoot("AuctionTerms", IsNullable = false, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[GeneratedCode("xsd", "4.0.30319.33440")]
[DebuggerStepThrough]
[Serializable]
public class AuctionTermsType
{
    private AuctionConstraintIndicatorType auctionConstraintIndicatorField;
    private JustificationDescriptionType[] justificationDescriptionField;
    private DescriptionType[] descriptionField;
    private ProcessDescriptionType[] processDescriptionField;
    private ConditionsDescriptionType[] conditionsDescriptionField;
    private ElectronicDeviceDescriptionType[] electronicDeviceDescriptionField;
    private AuctionURIType auctionURIField;

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public AuctionConstraintIndicatorType AuctionConstraintIndicator
    {
        get
        {
            return this.auctionConstraintIndicatorField;
        }
        set
        {
            this.auctionConstraintIndicatorField = value;
        }
    }

    [XmlElement("JustificationDescription", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public JustificationDescriptionType[] JustificationDescription
    {
        get
        {
            return this.justificationDescriptionField;
        }
        set
        {
            this.justificationDescriptionField = value;
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

    [XmlElement("ProcessDescription", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public ProcessDescriptionType[] ProcessDescription
    {
        get
        {
            return this.processDescriptionField;
        }
        set
        {
            this.processDescriptionField = value;
        }
    }

    [XmlElement("ConditionsDescription", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public ConditionsDescriptionType[] ConditionsDescription
    {
        get
        {
            return this.conditionsDescriptionField;
        }
        set
        {
            this.conditionsDescriptionField = value;
        }
    }

    [XmlElement("ElectronicDeviceDescription", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public ElectronicDeviceDescriptionType[] ElectronicDeviceDescription
    {
        get
        {
            return this.electronicDeviceDescriptionField;
        }
        set
        {
            this.electronicDeviceDescriptionField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public AuctionURIType AuctionURI
    {
        get
        {
            return this.auctionURIField;
        }
        set
        {
            this.auctionURIField = value;
        }
    }
}
