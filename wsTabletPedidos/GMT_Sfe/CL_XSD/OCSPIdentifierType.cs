using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[XmlType(Namespace = "http://uri.etsi.org/01903/v1.3.2#")]
[GeneratedCode("xsd", "4.0.30319.33440")]
[DebuggerStepThrough]
[DesignerCategory("code")]
[Serializable]
public class OCSPidentifierFieldType
{
    private ResponderIDType ResponderIDField;
    private DateTime producedAtField;
    private string uRIField;

    public ResponderIDType ResponderID
    {
        get
        {
            return this.ResponderIDField;
        }
        set
        {
            this.ResponderIDField = value;
        }
    }

    public DateTime ProducedAt
    {
        get
        {
            return this.producedAtField;
        }
        set
        {
            this.producedAtField = value;
        }
    }

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
}
