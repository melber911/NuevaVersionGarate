using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[DesignerCategory("code")]
[XmlRoot("CommitmentTypeIndication", IsNullable = false, Namespace = "http://uri.etsi.org/01903/v1.3.2#")]
[GeneratedCode("xsd", "4.0.30319.33440")]
[DebuggerStepThrough]
[XmlType(Namespace = "http://uri.etsi.org/01903/v1.3.2#")]
[Serializable]
public class CommitmentTypeIndicationType
{
    private ObjectIdentifierType commitmentTypeIdField;
    private object[] itemsField;
    private AnyType[] commitmentTypeQualifiersField;

    public ObjectIdentifierType CommitmentTypeId
    {
        get
        {
            return this.commitmentTypeIdField;
        }
        set
        {
            this.commitmentTypeIdField = value;
        }
    }

    [XmlElement("AllSignedDataObjects", typeof(object))]
    [XmlElement("ObjectReference", typeof(string), DataType = "anyURI")]
    public object[] Items
    {
        get
        {
            return this.itemsField;
        }
        set
        {
            this.itemsField = value;
        }
    }

    [XmlArrayItem("CommitmentTypeQualifier", IsNullable = false)]
    public AnyType[] CommitmentTypeQualifiers
    {
        get
        {
            return this.commitmentTypeQualifiersField;
        }
        set
        {
            this.commitmentTypeQualifiersField = value;
        }
    }
}
