
// Type: QualifyingPropertiesReferenceType




using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[XmlRoot("QualifyingPropertiesReference", IsNullable = false, Namespace = "http://uri.etsi.org/01903/v1.3.2#")]
[DebuggerStepThrough]
[XmlType(Namespace = "http://uri.etsi.org/01903/v1.3.2#")]
[GeneratedCode("xsd", "4.0.30319.33440")]
[DesignerCategory("code")]
[Serializable]
public class QualifyingPropertiesReferenceType
{
  private string uRIField;
  private string idField;

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
