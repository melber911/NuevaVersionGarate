using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[GeneratedCode("xsd", "4.0.30319.33440")]
[XmlRoot("QualifyingProperties", IsNullable = false, Namespace = "http://uri.etsi.org/01903/v1.3.2#")]
[DesignerCategory("code")]
[XmlType(Namespace = "http://uri.etsi.org/01903/v1.3.2#")]
[DebuggerStepThrough]
[Serializable]
public class QualifyingPropertiesType
{
    private SignedPropertiesType signedPropertiesField;
    private UnsignedPropertiesType unsignedPropertiesField;
    private string targetField;
    private string idField;

    public SignedPropertiesType SignedProperties
    {
        get
        {
            return this.signedPropertiesField;
        }
        set
        {
            this.signedPropertiesField = value;
        }
    }

    public UnsignedPropertiesType UnsignedProperties
    {
        get
        {
            return this.unsignedPropertiesField;
        }
        set
        {
            this.unsignedPropertiesField = value;
        }
    }

    [XmlAttribute(DataType = "anyURI")]
    public string Target
    {
        get
        {
            return this.targetField;
        }
        set
        {
            this.targetField = value;
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
