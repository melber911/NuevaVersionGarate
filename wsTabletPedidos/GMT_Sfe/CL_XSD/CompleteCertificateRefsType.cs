using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[DebuggerStepThrough]
[XmlRoot("CompleteCertificateRefs", IsNullable = false, Namespace = "http://uri.etsi.org/01903/v1.3.2#")]
[GeneratedCode("xsd", "4.0.30319.33440")]
[DesignerCategory("code")]
[XmlType(Namespace = "http://uri.etsi.org/01903/v1.3.2#")]
[Serializable]
public class CompleteCertificateRefsType
{
    private CertIDType[] certRefsField;
    private string idField;

    [XmlArrayItem("Cert", IsNullable = false)]
    public CertIDType[] CertRefs
    {
        get
        {
            return this.certRefsField;
        }
        set
        {
            this.certRefsField = value;
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
}
