using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[XmlType(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[XmlRoot("LocationCoordinate", IsNullable = false, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[DebuggerStepThrough]
[GeneratedCode("xsd", "4.0.30319.33440")]
[DesignerCategory("code")]
[Serializable]
public class LocationCoordinateType
{
    private CoordinateSystemCodeType coordinateSystemCodeField;
    private LatitudeDegreesMeasureType latitudeDegreesMeasureField;
    private LatitudeMinutesMeasureType latitudeMinutesMeasureField;
    private LatitudeDirectionCodeType latitudeDirectionCodeField;
    private LongitudeDegreesMeasureType longitudeDegreesMeasureField;
    private LongitudeMinutesMeasureType longitudeMinutesMeasureField;
    private LongitudeDirectionCodeType longitudeDirectionCodeField;
    private AltitudeMeasureType altitudeMeasureCodeField;

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public CoordinateSystemCodeType CoordinateSystemCode
    {
        get
        {
            return this.coordinateSystemCodeField;
        }
        set
        {
            this.coordinateSystemCodeField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public LatitudeDegreesMeasureType LatitudeDegreesMeasure
    {
        get
        {
            return this.latitudeDegreesMeasureField;
        }
        set
        {
            this.latitudeDegreesMeasureField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public LatitudeMinutesMeasureType LatitudeMinutesMeasure
    {
        get
        {
            return this.latitudeMinutesMeasureField;
        }
        set
        {
            this.latitudeMinutesMeasureField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public LatitudeDirectionCodeType LatitudeDirectionCode
    {
        get
        {
            return this.latitudeDirectionCodeField;
        }
        set
        {
            this.latitudeDirectionCodeField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public LongitudeDegreesMeasureType LongitudeDegreesMeasure
    {
        get
        {
            return this.longitudeDegreesMeasureField;
        }
        set
        {
            this.longitudeDegreesMeasureField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public LongitudeMinutesMeasureType LongitudeMinutesMeasure
    {
        get
        {
            return this.longitudeMinutesMeasureField;
        }
        set
        {
            this.longitudeMinutesMeasureField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public LongitudeDirectionCodeType LongitudeDirectionCode
    {
        get
        {
            return this.longitudeDirectionCodeField;
        }
        set
        {
            this.longitudeDirectionCodeField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public AltitudeMeasureType AltitudeMeasure
    {
        get
        {
            return this.altitudeMeasureCodeField;
        }
        set
        {
            this.altitudeMeasureCodeField = value;
        }
    }
}
