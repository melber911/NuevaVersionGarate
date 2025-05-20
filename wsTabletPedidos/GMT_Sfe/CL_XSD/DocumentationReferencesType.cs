using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[DesignerCategory("code")]
[XmlType(Namespace = "http://uri.etsi.org/01903/v1.3.2#")]
[GeneratedCode("xsd", "4.0.30319.33440")]
[DebuggerStepThrough]
[Serializable]
public class DocumentationReferencesType
{
    private string[] documentationReferenceField;

    [XmlElement("DocumentationReference", DataType = "anyURI")]
    public string[] DocumentationReference
    {
        get
        {
            return this.documentationReferenceField;
        }
        set
        {
            this.documentationReferenceField = value;
        }
    }
}
