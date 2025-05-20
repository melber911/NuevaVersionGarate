
// Type: X509DataType




using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[XmlType(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
[DebuggerStepThrough]
[DesignerCategory("code")]
[XmlRoot("X509Data", IsNullable = false, Namespace = "http://www.w3.org/2000/09/xmldsig#")]
[GeneratedCode("xsd", "4.0.30319.33440")]
[Serializable]
public class X509DataType
{
  private object[] itemsField;
  private ItemsChoiceType[] itemsElementNameField;

  [XmlElement("X509CRL", typeof (byte[]), DataType = "base64Binary")]
  [XmlAnyElement]
  [XmlElement("X509SKI", typeof (byte[]), DataType = "base64Binary")]
  [XmlElement("X509IssuerSerial", typeof (X509IssuerSerialType))]
  [XmlElement("X509SubjectName", typeof (string))]
  [XmlChoiceIdentifier("ItemsElementName")]
  [XmlElement("X509Certificate", typeof (byte[]), DataType = "base64Binary")]
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
  public ItemsChoiceType[] ItemsElementName
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
