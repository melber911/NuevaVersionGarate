using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[DesignerCategory("code")]
[XmlRoot("SignatureProperties", IsNullable = false, Namespace = "http://www.w3.org/2000/09/xmldsig#")]
[GeneratedCode("xsd", "4.0.30319.33440")]
[DebuggerStepThrough]
[XmlType(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
[Serializable]
public class SignaturePropertiesType
{
    private SignaturePropertyType[] signaturePropertyField;
    private string idField;

    [XmlElement("SignatureProperty")]
    public SignaturePropertyType[] SignatureProperty
    {
        get
        {
            return this.signaturePropertyField;
        }
        set
        {
            this.signaturePropertyField = value;
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
