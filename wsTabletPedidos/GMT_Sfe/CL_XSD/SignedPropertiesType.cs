using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[GeneratedCode("xsd", "4.0.30319.33440")]
[XmlType(Namespace = "http://uri.etsi.org/01903/v1.3.2#")]
[DebuggerStepThrough]
[DesignerCategory("code")]
[XmlRoot("SignedProperties", IsNullable = false, Namespace = "http://uri.etsi.org/01903/v1.3.2#")]
[Serializable]
public class SignedPropertiesType
{
    private SignedSignaturePropertiesType signedSignaturePropertiesField;
    private SignedDataObjectPropertiesType signedDataObjectPropertiesField;
    private string idField;

    public SignedSignaturePropertiesType SignedSignatureProperties
    {
        get
        {
            return this.signedSignaturePropertiesField;
        }
        set
        {
            this.signedSignaturePropertiesField = value;
        }
    }

    public SignedDataObjectPropertiesType SignedDataObjectProperties
    {
        get
        {
            return this.signedDataObjectPropertiesField;
        }
        set
        {
            this.signedDataObjectPropertiesField = value;
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
