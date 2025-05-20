using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[XmlRoot("SecondaryHazard", IsNullable = false, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[GeneratedCode("xsd", "4.0.30319.33440")]
[DebuggerStepThrough]
[DesignerCategory("code")]
[XmlType(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[Serializable]
public class SecondaryHazardType
{
    private IDType idField;
    private PlacardNotationType placardNotationField;
    private PlacardEndorsementType placardEndorsementField;
    private EmergencyProceduresCodeType emergencyProceduresCodeField;
    private ExtensionType[] extensionField;

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
    public PlacardNotationType PlacardNotation
    {
        get
        {
            return this.placardNotationField;
        }
        set
        {
            this.placardNotationField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public PlacardEndorsementType PlacardEndorsement
    {
        get
        {
            return this.placardEndorsementField;
        }
        set
        {
            this.placardEndorsementField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public EmergencyProceduresCodeType EmergencyProceduresCode
    {
        get
        {
            return this.emergencyProceduresCodeField;
        }
        set
        {
            this.emergencyProceduresCodeField = value;
        }
    }

    [XmlElement("Extension", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public ExtensionType[] Extension
    {
        get
        {
            return this.extensionField;
        }
        set
        {
            this.extensionField = value;
        }
    }
}
