
// Type: ObjectType




using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml;
using System.Xml.Serialization;

[DesignerCategory("code")]
[DebuggerStepThrough]
[XmlRoot("Object", IsNullable = false, Namespace = "http://www.w3.org/2000/09/xmldsig#")]
[GeneratedCode("xsd", "4.0.30319.33440")]
[XmlType(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
[Serializable]
public class ObjectType
{
  private XmlNode[] anyField;
  private string idField;
  private string mimeTypeField;
  private string encodingField;

  [XmlText]
  [XmlAnyElement]
  public XmlNode[] Any
  {
    get
    {
      return this.anyField;
    }
    set
    {
      this.anyField = value;
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

  [XmlAttribute]
  public string MimeType
  {
    get
    {
      return this.mimeTypeField;
    }
    set
    {
      this.mimeTypeField = value;
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
}
