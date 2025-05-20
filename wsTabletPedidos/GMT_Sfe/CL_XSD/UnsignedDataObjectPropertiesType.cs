using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[DebuggerStepThrough]
[XmlType(Namespace = "http://uri.etsi.org/01903/v1.3.2#")]
[XmlRoot("UnsignedDataObjectProperties", IsNullable = false, Namespace = "http://uri.etsi.org/01903/v1.3.2#")]
[GeneratedCode("xsd", "4.0.30319.33440")]
[DesignerCategory("code")]
[Serializable]
public class UnsignedDataObjectPropertiesType
{
    private AnyType[] unsignedDataObjectPropertyField;
    private string idField;

    [XmlElement("UnsignedDataObjectProperty")]
    public AnyType[] UnsignedDataObjectProperty
    {
        get
        {
            return this.unsignedDataObjectPropertyField;
        }
        set
        {
            this.unsignedDataObjectPropertyField = value;
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
