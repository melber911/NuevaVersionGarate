
// Type: ReferenceInfoType




using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[DebuggerStepThrough]
[DesignerCategory("code")]
[XmlRoot("ReferenceInfo", IsNullable = false, Namespace = "http://uri.etsi.org/01903/v1.3.2#")]
[GeneratedCode("xsd", "4.0.30319.33440")]
[XmlType(Namespace = "http://uri.etsi.org/01903/v1.3.2#")]
[Serializable]
public class ReferenceInfoType
{
  private DigestMethodType digestMethodField;
  private byte[] digestValueField;
  private string idField;
  private string uRIField;

  [XmlElement(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
  public DigestMethodType DigestMethod
  {
    get
    {
      return this.digestMethodField;
    }
    set
    {
      this.digestMethodField = value;
    }
  }

  [XmlElement(DataType = "base64Binary", Namespace = "http://www.w3.org/2000/09/xmldsig#")]
  public byte[] DigestValue
  {
    get
    {
      return this.digestValueField;
    }
    set
    {
      this.digestValueField = value;
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
}
