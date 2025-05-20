using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[XmlType(Namespace = "http://uri.etsi.org/01903/v1.3.2#")]
[GeneratedCode("xsd", "4.0.30319.33440")]
[DebuggerStepThrough]
[XmlRoot("Include", IsNullable = false, Namespace = "http://uri.etsi.org/01903/v1.3.2#")]
[DesignerCategory("code")]
[Serializable]
public class IncludeType
{
    private string uRIField;
    private bool referencedDataField;
    private bool referencedDataSpecifiedField;

    [XmlAttribute(DataType = "anyURI")]
    public string URI
    {
        get
        {
            return this.uRIField;
        }
        set
        {
            this.uRIField = value;
        }
    }

    [XmlAttribute]
    public bool referencedData
    {
        get
        {
            return this.referencedDataField;
        }
        set
        {
            this.referencedDataField = value;
        }
    }

    [XmlIgnore]
    public bool referencedDataSpecified
    {
        get
        {
            return this.referencedDataSpecifiedField;
        }
        set
        {
            this.referencedDataSpecifiedField = value;
        }
    }
}
