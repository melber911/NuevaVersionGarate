using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[DebuggerStepThrough]
[DesignerCategory("code")]
[XmlType(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[XmlRoot("HazardousGoodsTransit", IsNullable = false, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[GeneratedCode("xsd", "4.0.30319.33440")]
[Serializable]
public class HazardousGoodsTransitType
{
    private TransportEmergencyCardCodeType transportEmergencyCardCodeField;
    private PackingCriteriaCodeType packingCriteriaCodeField;
    private HazardousRegulationCodeType hazardousRegulationCodeField;
    private InhalationToxicityZoneCodeType inhalationToxicityZoneCodeField;
    private TransportAuthorizationCodeType transportAuthorizationCodeField;
    private TemperatureType maximumTemperatureField;
    private TemperatureType minimumTemperatureField;

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public TransportEmergencyCardCodeType TransportEmergencyCardCode
    {
        get
        {
            return this.transportEmergencyCardCodeField;
        }
        set
        {
            this.transportEmergencyCardCodeField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public PackingCriteriaCodeType PackingCriteriaCode
    {
        get
        {
            return this.packingCriteriaCodeField;
        }
        set
        {
            this.packingCriteriaCodeField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public HazardousRegulationCodeType HazardousRegulationCode
    {
        get
        {
            return this.hazardousRegulationCodeField;
        }
        set
        {
            this.hazardousRegulationCodeField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public InhalationToxicityZoneCodeType InhalationToxicityZoneCode
    {
        get
        {
            return this.inhalationToxicityZoneCodeField;
        }
        set
        {
            this.inhalationToxicityZoneCodeField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public TransportAuthorizationCodeType TransportAuthorizationCode
    {
        get
        {
            return this.transportAuthorizationCodeField;
        }
        set
        {
            this.transportAuthorizationCodeField = value;
        }
    }

    public TemperatureType MaximumTemperature
    {
        get
        {
            return this.maximumTemperatureField;
        }
        set
        {
            this.maximumTemperatureField = value;
        }
    }

    public TemperatureType MinimumTemperature
    {
        get
        {
            return this.minimumTemperatureField;
        }
        set
        {
            this.minimumTemperatureField = value;
        }
    }
}
