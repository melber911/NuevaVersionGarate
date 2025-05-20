
// Type: ItemsChoiceType




using System;
using System.CodeDom.Compiler;
using System.Xml.Serialization;

[GeneratedCode("xsd", "4.0.30319.33440")]
[XmlType(IncludeInSchema = false, Namespace = "http://www.w3.org/2000/09/xmldsig#")]
[Serializable]
public enum ItemsChoiceType
{
  [XmlEnum("##any:")] Item,
  X509CRL,
  X509Certificate,
  X509IssuerSerial,
  X509SKI,
  X509SubjectName,
}
