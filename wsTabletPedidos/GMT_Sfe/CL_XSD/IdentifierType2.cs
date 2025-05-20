using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[DesignerCategory("code")]
[GeneratedCode("xsd", "4.0.30319.33440")]
[DebuggerStepThrough]
[XmlType(Namespace = "http://uri.etsi.org/01903/v1.3.2#", TypeName = "identifierFieldType")]
[Serializable]
public class IdentifierType2
{
    private QualifierType qualifierField;
    private bool qualifierSpecifiedField;
    private string valueField;

    [XmlAttribute]
    public QualifierType Qualifier
    {
        get
        {
            return this.qualifierField;
        }
        set
        {
            this.qualifierField = value;
        }
    }

    [XmlIgnore]
    public bool QualifierSpecified
    {
        get
        {
            return this.qualifierSpecifiedField;
        }
        set
        {
            this.qualifierSpecifiedField = value;
        }
    }

    [XmlText(DataType = "anyURI")]
    public string Value
    {
        get
        {
            return this.valueField;
        }
        set
        {
            this.valueField = value;
        }
    }
}
