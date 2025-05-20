using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[DesignerCategory("code")]
[XmlRoot("KeyInfo", IsNullable = false, Namespace = "http://www.w3.org/2000/09/xmldsig#")]
[GeneratedCode("xsd", "4.0.30319.33440")]
[DebuggerStepThrough]
[XmlType(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
[Serializable]
public class KeyInfoType
{
    private object[] itemsField;
    private ItemsChoiceType2[] itemsElementNameField;
    private string[] textField;
    private string idField;

    [XmlAnyElement]
    [XmlElement("SPKIData", typeof(SPKIDataType))]
    [XmlElement("KeyValue", typeof(KeyValueType))]
    [XmlElement("KeyName", typeof(string))]
    [XmlElement("X509Data", typeof(X509DataType))]
    [XmlChoiceIdentifier("ItemsElementName")]
    [XmlElement("PGPData", typeof(PGPDataType))]
    [XmlElement("MgmtData", typeof(string))]
    [XmlElement("RetrievalMethod", typeof(RetrievalMethodType))]
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

    [XmlIgnore]
    [XmlElement("ItemsElementName")]
    public ItemsChoiceType2[] ItemsElementName
    {
        get
        {
            return this.itemsElementNameField;
        }
        set
        {
            this.itemsElementNameField = value;
        }
    }

    [XmlText]
    public string[] Text
    {
        get
        {
            return this.textField;
        }
        set
        {
            this.textField = value;
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
