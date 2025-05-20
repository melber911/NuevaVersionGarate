using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[GeneratedCode("xsd", "4.0.30319.33440")]
[DesignerCategory("code")]
[XmlType(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
[DebuggerStepThrough]
[XmlRoot("KeyValue", IsNullable = false, Namespace = "http://www.w3.org/2000/09/xmldsig#")]
[Serializable]
public class KeyValueType
{
    private object itemField;
    private string[] textField;

    [XmlElement("DSAKeyValue", typeof(DSAKeyValueType))]
    [XmlElement("RSAKeyValue", typeof(RSAKeyValueType))]
    [XmlAnyElement]
    public object Item
    {
        get
        {
            return this.itemField;
        }
        set
        {
            this.itemField = value;
        }
    }

    [XmlText]
    public string[] Text
    {
        get
        {
            return this.textField;
        }
        set
        {
            this.textField = value;
        }
    }
}
