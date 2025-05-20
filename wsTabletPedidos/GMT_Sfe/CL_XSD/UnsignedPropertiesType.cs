using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[GeneratedCode("xsd", "4.0.30319.33440")]
[XmlType(Namespace = "http://uri.etsi.org/01903/v1.3.2#")]
[XmlRoot("UnsignedProperties", IsNullable = false, Namespace = "http://uri.etsi.org/01903/v1.3.2#")]
[DebuggerStepThrough]
[DesignerCategory("code")]
[Serializable]
public class UnsignedPropertiesType
{
    private UnsignedSignaturePropertiesType unsignedSignaturePropertiesField;
    private UnsignedDataObjectPropertiesType unsignedDataObjectPropertiesField;
    private string idField;

    public UnsignedSignaturePropertiesType UnsignedSignatureProperties
    {
        get
        {
            return this.unsignedSignaturePropertiesField;
        }
        set
        {
            this.unsignedSignaturePropertiesField = value;
        }
    }

    public UnsignedDataObjectPropertiesType UnsignedDataObjectProperties
    {
        get
        {
            return this.unsignedDataObjectPropertiesField;
        }
        set
        {
            this.unsignedDataObjectPropertiesField = value;
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
