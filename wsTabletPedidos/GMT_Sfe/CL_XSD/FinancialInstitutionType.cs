
// Type: FinancialInstitutionType




using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[DesignerCategory("code")]
[XmlRoot("FinancialInstitution", IsNullable = false, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[XmlType(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[DebuggerStepThrough]
[GeneratedCode("xsd", "4.0.30319.33440")]
[Serializable]
public class FinancialInstitutionType
{
  private IDType idField;
  private NameType1 nameField;
  private AddressType addressField;

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

  [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
  public NameType1 Name
  {
    get
    {
      return this.nameField;
    }
    set
    {
      this.nameField = value;
    }
  }

  public AddressType Address
  {
    get
    {
      return this.addressField;
    }
    set
    {
      this.addressField = value;
    }
  }
}
