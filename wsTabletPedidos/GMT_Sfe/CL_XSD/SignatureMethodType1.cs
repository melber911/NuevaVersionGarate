using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml;
using System.Xml.Serialization;

[GeneratedCode("xsd", "4.0.30319.33440")]
[XmlType(Namespace = "http://www.w3.org/2000/09/xmldsig#", TypeName = "SignatureMethodType")]
[XmlRoot("SignatureMethod", IsNullable = false, Namespace = "http://www.w3.org/2000/09/xmldsig#")]
[DebuggerStepThrough]
[DesignerCategory("code")]
[Serializable]
public class SignatureMethodType1
{
    private string hMACOutputLengthField;
    private XmlNode[] anyField;
    private string algorithmField;

    [XmlElement(DataType = "integer")]
    public string HMACOutputLength
    {
        get
        {
            return this.hMACOutputLengthField;
        }
        set
        {
            this.hMACOutputLengthField = value;
        }
    }

    [XmlAnyElement]
    [XmlText]
    public XmlNode[] Any
    {
        get
        {
            return this.anyField;
        }
        set
        {
            this.anyField = value;
        }
    }

    [XmlAttribute(DataType = "anyURI")]
    public string Algorithm
    {
        get
        {
            return this.algorithmField;
        }
        set
        {
            this.algorithmField = value;
        }
    }
}
