using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[DebuggerStepThrough]
[DesignerCategory("code")]
[XmlType(Namespace = "http://uri.etsi.org/01903/v1.3.2#")]
[GeneratedCode("xsd", "4.0.30319.33440")]
[Serializable]
public class DigestAlgAndValueType
{
    private DigestMethodType digestMethodField;
    private byte[] digestValueField;

    [XmlElement(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    public DigestMethodType DigestMethod
    {
        get
        {
            return this.digestMethodField;
        }
        set
        {
            this.digestMethodField = value;
        }
    }

    [XmlElement(DataType = "base64Binary", Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    public byte[] DigestValue
    {
        get
        {
            return this.digestValueField;
        }
        set
        {
            this.digestValueField = value;
        }
    }
}
