using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[DesignerCategory("code")]
[XmlRoot("RetrievalMethod", IsNullable = false, Namespace = "http://www.w3.org/2000/09/xmldsig#")]
[XmlType(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
[GeneratedCode("xsd", "4.0.30319.33440")]
[DebuggerStepThrough]
[Serializable]
public class RetrievalMethodType
{
  private TransformType[] transformsField;
  private string uRIField;
  private string typeField;

  [XmlArrayItem("Transform", IsNullable = false)]
  public TransformType[] Transforms
  {
    get
    {
      return this.transformsField;
    }
    set
    {
      this.transformsField = value;
    }
  }

  [XmlAttribute(DataType = "anyURI")]
  public string URI
  {
    get
    {
      return this.uRIField;
    }
    set
    {
      this.uRIField = value;
    }
  }

  [XmlAttribute(DataType = "anyURI")]
  public string Type
  {
    get
    {
      return this.typeField;
    }
    set
    {
      this.typeField = value;
    }
  }
}
