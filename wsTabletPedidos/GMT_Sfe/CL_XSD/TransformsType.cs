using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[XmlRoot("Transforms", IsNullable = false, Namespace = "http://www.w3.org/2000/09/xmldsig#")]
[DebuggerStepThrough]
[XmlType(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
[GeneratedCode("xsd", "4.0.30319.33440")]
[DesignerCategory("code")]
[Serializable]
public class TransformsType
{
    private TransformType[] transformField;

    [XmlElement("Transform")]
    public TransformType[] Transform
    {
        get
        {
            return this.transformField;
        }
        set
        {
            this.transformField = value;
        }
    }
}
