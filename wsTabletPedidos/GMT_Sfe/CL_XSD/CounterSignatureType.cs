using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[GeneratedCode("xsd", "4.0.30319.33440")]
[XmlRoot("CounterSignature", IsNullable = false, Namespace = "http://uri.etsi.org/01903/v1.3.2#")]
[DebuggerStepThrough]
[DesignerCategory("code")]
[XmlType(Namespace = "http://uri.etsi.org/01903/v1.3.2#")]
[Serializable]
public class CounterSignatureType
{
  private SignatureType1 signatureField;

  [XmlElement(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
  public SignatureType1 Signature
  {
    get
    {
      return this.signatureField;
    }
    set
    {
      this.signatureField = value;
    }
  }
}
