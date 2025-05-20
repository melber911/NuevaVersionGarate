using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[DebuggerStepThrough]
[XmlType(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[DesignerCategory("code")]
[GeneratedCode("xsd", "4.0.30319.33440")]
[XmlRoot("Stowage", IsNullable = false, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[Serializable]
public class StowageType
{
    private LocationIDType locationIDField;
    private LocationType[] locationField;
    private DimensionType[] measurementDimensionField;

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public LocationIDType LocationID
    {
        get
        {
            return this.locationIDField;
        }
        set
        {
            this.locationIDField = value;
        }
    }

    [XmlElement("Location", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public LocationType[] Location
    {
        get
        {
            return this.locationField;
        }
        set
        {
            this.locationField = value;
        }
    }

    [XmlElement("MeasurementDimension")]
    public DimensionType[] MeasurementDimension
    {
        get
        {
            return this.measurementDimensionField;
        }
        set
        {
            this.measurementDimensionField = value;
        }
    }
}
