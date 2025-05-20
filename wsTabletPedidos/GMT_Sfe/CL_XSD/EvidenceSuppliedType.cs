
// Type: EvidenceSuppliedType




using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[DebuggerStepThrough]
[DesignerCategory("code")]
[GeneratedCode("xsd", "4.0.30319.33440")]
[XmlRoot("EvidenceSupplied", IsNullable = false, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[XmlType(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[Serializable]
public class EvidenceSuppliedType
{
  private IDType idField;

  [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
  public IDType ID
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
