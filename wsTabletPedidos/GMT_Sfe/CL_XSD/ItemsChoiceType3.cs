
// Type: ItemsChoiceType3




using System;
using System.CodeDom.Compiler;
using System.Xml.Serialization;

[GeneratedCode("xsd", "4.0.30319.33440")]
[XmlType(IncludeInSchema = false, Namespace = "http://uri.etsi.org/01903/v1.3.2#")]
[Serializable]
public enum ItemsChoiceType3
{
  [XmlEnum("##any:")] Item,
  ArchiveTimeStamp,
  AttrAuthoritiesCertValues,
  AttributeCertificateRefs,
  AttributeRevocationRefs,
  AttributeRevocationValues,
  CertificateValues,
  CompleteCertificateRefs,
  CompleteRevocationRefs,
  CounterSignature,
  RefsOnlyTimeStamp,
  RevocationValues,
  SigAndRefsTimeStamp,
  SignatureTimeStamp,
}
