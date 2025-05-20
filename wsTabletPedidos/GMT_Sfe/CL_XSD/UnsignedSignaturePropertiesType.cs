
// Type: UnsignedSignaturePropertiesType




using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[DebuggerStepThrough]
[XmlType(Namespace = "http://uri.etsi.org/01903/v1.3.2#")]
[XmlRoot("UnsignedSignatureProperties", IsNullable = false, Namespace = "http://uri.etsi.org/01903/v1.3.2#")]
[GeneratedCode("xsd", "4.0.30319.33440")]
[DesignerCategory("code")]
[Serializable]
public class UnsignedSignaturePropertiesType
{
  private object[] itemsField;
  private ItemsChoiceType3[] itemsElementNameField;
  private string idField;

  [XmlElement("AttributeRevocationValues", typeof (RevocationValuesType))]
  [XmlElement("CounterSignature", typeof (CounterSignatureType))]
  [XmlAnyElement]
  [XmlElement("ArchiveTimeStamp", typeof (XAdESTimeStampType))]
  [XmlElement("AttrAuthoritiesCertValues", typeof (CertificateValuesType))]
  [XmlElement("AttributeCertificateRefs", typeof (CompleteCertificateRefsType))]
  [XmlElement("AttributeRevocationRefs", typeof (CompleteRevocationRefsType))]
  [XmlElement("CertificateValues", typeof (CertificateValuesType))]
  [XmlElement("CompleteCertificateRefs", typeof (CompleteCertificateRefsType))]
  [XmlElement("CompleteRevocationRefs", typeof (CompleteRevocationRefsType))]
  [XmlChoiceIdentifier("ItemsElementName")]
  [XmlElement("RefsOnlyTimeStamp", typeof (XAdESTimeStampType))]
  [XmlElement("SignatureTimeStamp", typeof (XAdESTimeStampType))]
  [XmlElement("SigAndRefsTimeStamp", typeof (XAdESTimeStampType))]
  [XmlElement("RevocationValues", typeof (RevocationValuesType))]
  public object[] Items
  {
    get
    {
      return this.itemsField;
    }
    set
    {
      this.itemsField = value;
    }
  }

  [XmlElement("ItemsElementName")]
  [XmlIgnore]
  public ItemsChoiceType3[] ItemsElementName
  {
    get
    {
      return this.itemsElementNameField;
    }
    set
    {
      this.itemsElementNameField = value;
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
