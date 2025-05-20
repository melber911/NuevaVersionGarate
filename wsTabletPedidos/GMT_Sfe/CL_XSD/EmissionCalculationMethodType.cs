using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[XmlRoot("EmissionCalculationMethod", IsNullable = false, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[DebuggerStepThrough]
[XmlType(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[GeneratedCode("xsd", "4.0.30319.33440")]
[DesignerCategory("code")]
[Serializable]
public class EmissionCalculationMethodType
{
    private CalculationMethodCodeType calculationMethodCodeField;
    private FullnessIndicationCodeType fullnessIndicationCodeField;
    private LocationType1 measurementFromLocationField;
    private LocationType1 measurementToLocationField;

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public CalculationMethodCodeType CalculationMethodCode
    {
        get
        {
            return this.calculationMethodCodeField;
        }
        set
        {
            this.calculationMethodCodeField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public FullnessIndicationCodeType FullnessIndicationCode
    {
        get
        {
            return this.fullnessIndicationCodeField;
        }
        set
        {
            this.fullnessIndicationCodeField = value;
        }
    }

    public LocationType1 MeasurementFromLocation
    {
        get
        {
            return this.measurementFromLocationField;
        }
        set
        {
            this.measurementFromLocationField = value;
        }
    }

    public LocationType1 MeasurementToLocation
    {
        get
        {
            return this.measurementToLocationField;
        }
        set
        {
            this.measurementToLocationField = value;
        }
    }
}
