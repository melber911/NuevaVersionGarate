
// Type: ItemsChoiceType1




using System;
using System.CodeDom.Compiler;
using System.Xml.Serialization;

[GeneratedCode("xsd", "4.0.30319.33440")]
[XmlType(IncludeInSchema = false, Namespace = "http://www.w3.org/2000/09/xmldsig#")]
[Serializable]
public enum ItemsChoiceType1
{
  [XmlEnum("##any:")] Item,
  PGPKeyID,
  PGPKeyPacket,
}
