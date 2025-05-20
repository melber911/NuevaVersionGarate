using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[DesignerCategory("code")]
[XmlRoot("SignaturePolicyidentifierField", IsNullable = false, Namespace = "http://uri.etsi.org/01903/v1.3.2#")]
[GeneratedCode("xsd", "4.0.30319.33440")]
[DebuggerStepThrough]
[XmlType(Namespace = "http://uri.etsi.org/01903/v1.3.2#")]
[Serializable]
public class SignaturePolicyidentifierFieldType
{
    private object itemField;

    [XmlElement("SignaturePolicyImplied", typeof(object))]
    [XmlElement("SignaturePolicyId", typeof(SignaturePolicyIdType))]
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
}
