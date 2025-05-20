using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml;
using System.Xml.Serialization;

[DebuggerStepThrough]
[XmlRoot("CanonicalizationMethod", IsNullable = false, Namespace = "http://www.w3.org/2000/09/xmldsig#")]
[GeneratedCode("xsd", "4.0.30319.33440")]
[DesignerCategory("code")]
[XmlType(Namespace = "http://www.w3.org/2000/09/xmldsig#", TypeName = "CanonicalizationMethodType")]
[Serializable]
public class CanonicalizationMethodType1
{
    private XmlNode[] anyField;
    private string algorithmField;

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
