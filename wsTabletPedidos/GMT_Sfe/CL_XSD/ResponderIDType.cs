
// Type: ResponderIDType




using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[XmlType(Namespace = "http://uri.etsi.org/01903/v1.3.2#")]
[DebuggerStepThrough]
[DesignerCategory("code")]
[GeneratedCode("xsd", "4.0.30319.33440")]
[Serializable]
public class ResponderIDType
{
  private object itemField;

  [XmlElement("ByKey", typeof (byte[]), DataType = "base64Binary")]
  [XmlElement("ByName", typeof (string))]
  public object Item
  {
    get
    {
      return this.itemField;
    }
    set
    {
      this.itemField = value;
    }
  }
}
