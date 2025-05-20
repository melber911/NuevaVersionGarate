using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[XmlType(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[DesignerCategory("code")]
[DebuggerStepThrough]
[GeneratedCode("xsd", "4.0.30319.33440")]
[XmlRoot("EnvironmentalEmission", IsNullable = false, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[Serializable]
public class EnvironmentalEmissionType
{
    private EnvironmentalEmissionTypeCodeType environmentalEmissionTypeCodeField;
    private ValueMeasureType valueMeasureField;
    private DescriptionType[] descriptionField;
    private EmissionCalculationMethodType[] emissionCalculationMethodField;

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public EnvironmentalEmissionTypeCodeType EnvironmentalEmissionTypeCode
    {
        get
        {
            return this.environmentalEmissionTypeCodeField;
        }
        set
        {
            this.environmentalEmissionTypeCodeField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public ValueMeasureType ValueMeasure
    {
        get
        {
            return this.valueMeasureField;
        }
        set
        {
            this.valueMeasureField = value;
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

    [XmlElement("EmissionCalculationMethod")]
    public EmissionCalculationMethodType[] EmissionCalculationMethod
    {
        get
        {
            return this.emissionCalculationMethodField;
        }
        set
        {
            this.emissionCalculationMethodField = value;
        }
    }
}
