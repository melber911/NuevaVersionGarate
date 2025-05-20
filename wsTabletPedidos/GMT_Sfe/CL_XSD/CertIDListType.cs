using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[DebuggerStepThrough]
[XmlRoot("SigningCertificate", IsNullable = false, Namespace = "http://uri.etsi.org/01903/v1.3.2#")]
[GeneratedCode("xsd", "4.0.30319.33440")]
[DesignerCategory("code")]
[XmlType(Namespace = "http://uri.etsi.org/01903/v1.3.2#")]
[Serializable]
public class CertIDListType
{
    private CertIDType[] certField;

    [XmlElement("Cert")]
    public CertIDType[] Cert
    {
        get
        {
            return this.certField;
        }
        set
        {
            this.certField = value;
        }
    }
}
