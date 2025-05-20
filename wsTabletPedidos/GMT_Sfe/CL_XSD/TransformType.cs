
// Type: TransformType




using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[DesignerCategory("code")]
[XmlType(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
[XmlRoot("Transform", IsNullable = false, Namespace = "http://www.w3.org/2000/09/xmldsig#")]
[GeneratedCode("xsd", "4.0.30319.33440")]
[DebuggerStepThrough]
[Serializable]
public class TransformType
{
  private object[] itemsField;
  private string[] textField;
  private string algorithmField;

  [XmlAnyElement]
  [XmlElement("XPath", typeof (string))]
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
  public string Algorithm
  {
    get
    {
      return this.algorithmField;
    }
    set
    {
      this.algorithmField = value;
    }
  }
}
