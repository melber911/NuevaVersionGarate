using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml;
using System.Xml.Serialization;

[XmlRoot("SPKIData", IsNullable = false, Namespace = "http://www.w3.org/2000/09/xmldsig#")]
[GeneratedCode("xsd", "4.0.30319.33440")]
[DebuggerStepThrough]
[DesignerCategory("code")]
[XmlType(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
[Serializable]
public class SPKIDataType
{
    private byte[][] sPKISexpField;
    private XmlElement anyField;

    [XmlElement("SPKISexp", DataType = "base64Binary")]
    public byte[][] SPKISexp
    {
        get
        {
            return this.sPKISexpField;
        }
        set
        {
            this.sPKISexpField = value;
        }
    }

    [XmlAnyElement]
    public XmlElement Any
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
}
