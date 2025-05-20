using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[XmlRoot("MaritimeTransport", IsNullable = false, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[DebuggerStepThrough]
[GeneratedCode("xsd", "4.0.30319.33440")]
[DesignerCategory("code")]
[XmlType(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[Serializable]
public class MaritimeTransportType
{
    private VesselIDType vesselIDField;
    private VesselNameType vesselNameField;
    private RadioCallSignIDType radioCallSignIDField;
    private ShipsRequirementsType[] shipsRequirementsField;
    private GrossTonnageMeasureType grossTonnageMeasureField;
    private NetTonnageMeasureType netTonnageMeasureField;
    private DocumentReferenceType registryCertificateDocumentReferenceField;
    private LocationType1 registryPortLocationField;

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public VesselIDType VesselID
    {
        get
        {
            return this.vesselIDField;
        }
        set
        {
            this.vesselIDField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public VesselNameType VesselName
    {
        get
        {
            return this.vesselNameField;
        }
        set
        {
            this.vesselNameField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public RadioCallSignIDType RadioCallSignID
    {
        get
        {
            return this.radioCallSignIDField;
        }
        set
        {
            this.radioCallSignIDField = value;
        }
    }

    [XmlElement("ShipsRequirements", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public ShipsRequirementsType[] ShipsRequirements
    {
        get
        {
            return this.shipsRequirementsField;
        }
        set
        {
            this.shipsRequirementsField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public GrossTonnageMeasureType GrossTonnageMeasure
    {
        get
        {
            return this.grossTonnageMeasureField;
        }
        set
        {
            this.grossTonnageMeasureField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public NetTonnageMeasureType NetTonnageMeasure
    {
        get
        {
            return this.netTonnageMeasureField;
        }
        set
        {
            this.netTonnageMeasureField = value;
        }
    }

    public DocumentReferenceType RegistryCertificateDocumentReference
    {
        get
        {
            return this.registryCertificateDocumentReferenceField;
        }
        set
        {
            this.registryCertificateDocumentReferenceField = value;
        }
    }

    public LocationType1 RegistryPortLocation
    {
        get
        {
            return this.registryPortLocationField;
        }
        set
        {
            this.registryPortLocationField = value;
        }
    }
}
