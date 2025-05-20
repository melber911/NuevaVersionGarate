
// Type: ItemsChoiceType2




using System;
using System.CodeDom.Compiler;
using System.Xml.Serialization;

[GeneratedCode("xsd", "4.0.30319.33440")]
[XmlType(IncludeInSchema = false, Namespace = "http://www.w3.org/2000/09/xmldsig#")]
[Serializable]
public enum ItemsChoiceType2
{
  [XmlEnum("##any:")] Item,
  KeyName,
  KeyValue,
  MgmtData,
  PGPData,
  RetrievalMethod,
  SPKIData,
  X509Data,
}
