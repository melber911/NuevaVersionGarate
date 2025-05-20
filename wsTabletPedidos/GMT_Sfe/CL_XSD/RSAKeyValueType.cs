using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[DebuggerStepThrough]
[XmlRoot("RSAKeyValue", IsNullable = false, Namespace = "http://www.w3.org/2000/09/xmldsig#")]
[XmlType(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
[GeneratedCode("xsd", "4.0.30319.33440")]
[DesignerCategory("code")]
[Serializable]
public class RSAKeyValueType
{
    private byte[] modulusField;
    private byte[] exponentField;

    [XmlElement(DataType = "base64Binary")]
    public byte[] Modulus
    {
        get
        {
            return this.modulusField;
        }
        set
        {
            this.modulusField = value;
        }
    }

    [XmlElement(DataType = "base64Binary")]
    public byte[] Exponent
    {
        get
        {
            return this.exponentField;
        }
        set
        {
            this.exponentField = value;
        }
    }
}
