using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[XmlInclude(typeof(OtherTimeStampType))]
[DebuggerStepThrough]
[XmlType(Namespace = "http://uri.etsi.org/01903/v1.3.2#")]
[XmlInclude(typeof(XAdESTimeStampType))]
[GeneratedCode("xsd", "4.0.30319.33440")]
[DesignerCategory("code")]
[Serializable]
public abstract class GenericTimeStampType
{
    private object[] itemsField;
    private CanonicalizationMethodType1 canonicalizationMethodField;
    private object[] items1Field;
    private string idField;

    [XmlElement("Include", typeof(IncludeType))]
    [XmlElement("ReferenceInfo", typeof(ReferenceInfoType))]
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

    [XmlElement(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    public CanonicalizationMethodType1 CanonicalizationMethod
    {
        get
        {
            return this.canonicalizationMethodField;
        }
        set
        {
            this.canonicalizationMethodField = value;
        }
    }

    [XmlElement("XMLTimeStamp", typeof(AnyType))]
    [XmlElement("EncapsulatedTimeStamp", typeof(EncapsulatedPKIDataType))]
    public object[] Items1
    {
        get
        {
            return this.items1Field;
        }
        set
        {
            this.items1Field = value;
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
