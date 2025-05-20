using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[GeneratedCode("xsd", "4.0.30319.33440")]
[XmlType(Namespace = "http://uri.etsi.org/01903/v1.3.2#")]
[DebuggerStepThrough]
[DesignerCategory("code")]
[Serializable]
public class CertIDType
{
    private DigestAlgAndValueType certDigestField;
    private X509IssuerSerialType issuerSerialField;
    private string uRIField;

    public DigestAlgAndValueType CertDigest
    {
        get
        {
            return this.certDigestField;
        }
        set
        {
            this.certDigestField = value;
        }
    }

    public X509IssuerSerialType IssuerSerial
    {
        get
        {
            return this.issuerSerialField;
        }
        set
        {
            this.issuerSerialField = value;
        }
    }

    [XmlAttribute(DataType = "anyURI")]
    public string URI
    {
        get
        {
            return this.uRIField;
        }
        set
        {
            this.uRIField = value;
        }
    }
}
