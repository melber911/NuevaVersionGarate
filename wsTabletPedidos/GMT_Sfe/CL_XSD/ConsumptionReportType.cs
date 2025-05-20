using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[XmlRoot("ConsumptionReport", IsNullable = false, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[DesignerCategory("code")]
[GeneratedCode("xsd", "4.0.30319.33440")]
[XmlType(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[DebuggerStepThrough]
[Serializable]
public class ConsumptionReportType
{
    private IDType idField;
    private ConsumptionTypeType consumptionTypeField;
    private ConsumptionTypeCodeType consumptionTypeCodeField;
    private DescriptionType[] descriptionField;
    private TotalConsumedQuantityType totalConsumedQuantityField;
    private BasicConsumedQuantityType basicConsumedQuantityField;
    private ResidentOccupantsNumericType residentOccupantsNumericField;
    private ConsumersEnergyLevelCodeType consumersEnergyLevelCodeField;
    private ConsumersEnergyLevelType consumersEnergyLevelField;
    private ResidenceTypeType residenceTypeField;
    private ResidenceTypeCodeType residenceTypeCodeField;
    private HeatingTypeType heatingTypeField;
    private HeatingTypeCodeType heatingTypeCodeField;
    private PeriodType periodField;
    private DocumentReferenceType guidanceDocumentReferenceField;
    private DocumentReferenceType documentReferenceField;
    private ConsumptionReportReferenceType[] consumptionReportReferenceField;
    private ConsumptionHistoryType[] consumptionHistoryField;

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
    public ConsumptionTypeType ConsumptionType
    {
        get
        {
            return this.consumptionTypeField;
        }
        set
        {
            this.consumptionTypeField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public ConsumptionTypeCodeType ConsumptionTypeCode
    {
        get
        {
            return this.consumptionTypeCodeField;
        }
        set
        {
            this.consumptionTypeCodeField = value;
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
    public TotalConsumedQuantityType TotalConsumedQuantity
    {
        get
        {
            return this.totalConsumedQuantityField;
        }
        set
        {
            this.totalConsumedQuantityField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public BasicConsumedQuantityType BasicConsumedQuantity
    {
        get
        {
            return this.basicConsumedQuantityField;
        }
        set
        {
            this.basicConsumedQuantityField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public ResidentOccupantsNumericType ResidentOccupantsNumeric
    {
        get
        {
            return this.residentOccupantsNumericField;
        }
        set
        {
            this.residentOccupantsNumericField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public ConsumersEnergyLevelCodeType ConsumersEnergyLevelCode
    {
        get
        {
            return this.consumersEnergyLevelCodeField;
        }
        set
        {
            this.consumersEnergyLevelCodeField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public ConsumersEnergyLevelType ConsumersEnergyLevel
    {
        get
        {
            return this.consumersEnergyLevelField;
        }
        set
        {
            this.consumersEnergyLevelField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public ResidenceTypeType ResidenceType
    {
        get
        {
            return this.residenceTypeField;
        }
        set
        {
            this.residenceTypeField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public ResidenceTypeCodeType ResidenceTypeCode
    {
        get
        {
            return this.residenceTypeCodeField;
        }
        set
        {
            this.residenceTypeCodeField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public HeatingTypeType HeatingType
    {
        get
        {
            return this.heatingTypeField;
        }
        set
        {
            this.heatingTypeField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public HeatingTypeCodeType HeatingTypeCode
    {
        get
        {
            return this.heatingTypeCodeField;
        }
        set
        {
            this.heatingTypeCodeField = value;
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

    public DocumentReferenceType GuidanceDocumentReference
    {
        get
        {
            return this.guidanceDocumentReferenceField;
        }
        set
        {
            this.guidanceDocumentReferenceField = value;
        }
    }

    public DocumentReferenceType DocumentReference
    {
        get
        {
            return this.documentReferenceField;
        }
        set
        {
            this.documentReferenceField = value;
        }
    }

    [XmlElement("ConsumptionReportReference")]
    public ConsumptionReportReferenceType[] ConsumptionReportReference
    {
        get
        {
            return this.consumptionReportReferenceField;
        }
        set
        {
            this.consumptionReportReferenceField = value;
        }
    }

    [XmlElement("ConsumptionHistory")]
    public ConsumptionHistoryType[] ConsumptionHistory
    {
        get
        {
            return this.consumptionHistoryField;
        }
        set
        {
            this.consumptionHistoryField = value;
        }
    }
}
