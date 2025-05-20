using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[GeneratedCode("xsd", "4.0.30319.33440")]
[DesignerCategory("code")]
[XmlType(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
[DebuggerStepThrough]
[Serializable]
public class X509IssuerSerialType
{
    private string x509IssuerNameField;
    private string x509SerialNumberField;

    public string X509IssuerName
    {
        get
        {
            return this.x509IssuerNameField;
        }
        set
        {
            this.x509IssuerNameField = value;
        }
    }

    [XmlElement(DataType = "integer")]
    public string X509SerialNumber
    {
        get
        {
            return this.x509SerialNumberField;
        }
        set
        {
            this.x509SerialNumberField = value;
        }
    }
}
