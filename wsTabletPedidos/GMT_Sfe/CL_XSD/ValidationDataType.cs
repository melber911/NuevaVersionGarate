using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[XmlType(Namespace = "http://uri.etsi.org/01903/v1.4.1#")]
[DesignerCategory("code")]
[XmlRoot("TimeStampValidationData", IsNullable = false, Namespace = "http://uri.etsi.org/01903/v1.4.1#")]
[GeneratedCode("xsd", "4.0.30319.33440")]
[DebuggerStepThrough]
[Serializable]
public class ValidationDataType
{
    private CertificateValuesType certificateValuesField;
    private RevocationValuesType revocationValuesField;
    private string idField;
    private string uRField;

    [XmlElement(Namespace = "http://uri.etsi.org/01903/v1.3.2#")]
    public CertificateValuesType CertificateValues
    {
        get
        {
            return this.certificateValuesField;
        }
        set
        {
            this.certificateValuesField = value;
        }
    }

    [XmlElement(Namespace = "http://uri.etsi.org/01903/v1.3.2#")]
    public RevocationValuesType RevocationValues
    {
        get
        {
            return this.revocationValuesField;
        }
        set
        {
            this.revocationValuesField = value;
        }
    }

    [XmlAttribute(DataType = "ID")]
    public string Id
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

    [XmlAttribute(DataType = "anyURI")]
    public string UR
    {
        get
        {
            return this.uRField;
        }
        set
        {
            this.uRField = value;
        }
    }
}
