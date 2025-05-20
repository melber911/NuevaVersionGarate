using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[DebuggerStepThrough]
[DesignerCategory("code")]
[XmlRoot("EncapsulatedPKIData", IsNullable = false, Namespace = "http://uri.etsi.org/01903/v1.3.2#")]
[GeneratedCode("xsd", "4.0.30319.33440")]
[XmlType(Namespace = "http://uri.etsi.org/01903/v1.3.2#")]
[Serializable]
public class EncapsulatedPKIDataType
{
  private string idField;
  private string encodingField;
  private byte[] valueField;

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

  [XmlAttribute(DataType = "anyURI")]
  public string Encoding
  {
    get
    {
      return this.encodingField;
    }
    set
    {
      this.encodingField = value;
    }
  }

  [XmlText(DataType = "base64Binary")]
  public byte[] Value
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
