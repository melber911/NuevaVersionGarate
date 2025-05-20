
// Type: SignaturePropertyType




using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml;
using System.Xml.Serialization;

[DebuggerStepThrough]
[XmlRoot("SignatureProperty", IsNullable = false, Namespace = "http://www.w3.org/2000/09/xmldsig#")]
[DesignerCategory("code")]
[XmlType(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
[GeneratedCode("xsd", "4.0.30319.33440")]
[Serializable]
public class SignaturePropertyType
{
  private XmlElement[] itemsField;
  private string[] textField;
  private string targetField;
  private string idField;

  [XmlAnyElement]
  public XmlElement[] Items
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

  [XmlAttribute(DataType = "anyURI")]
  public string Target
  {
    get
    {
      return this.targetField;
    }
    set
    {
      this.targetField = value;
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
