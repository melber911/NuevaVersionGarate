
// Type: PGPDataType




using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[XmlRoot("PGPData", IsNullable = false, Namespace = "http://www.w3.org/2000/09/xmldsig#")]
[DebuggerStepThrough]
[XmlType(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
[GeneratedCode("xsd", "4.0.30319.33440")]
[DesignerCategory("code")]
[Serializable]
public class PGPDataType
{
  private object[] itemsField;
  private ItemsChoiceType1[] itemsElementNameField;

  [XmlElement("PGPKeyPacket", typeof (byte[]), DataType = "base64Binary")]
  [XmlElement("PGPKeyID", typeof (byte[]), DataType = "base64Binary")]
  [XmlAnyElement]
  [XmlChoiceIdentifier("ItemsElementName")]
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

  [XmlElement("ItemsElementName")]
  [XmlIgnore]
  public ItemsChoiceType1[] ItemsElementName
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
}
