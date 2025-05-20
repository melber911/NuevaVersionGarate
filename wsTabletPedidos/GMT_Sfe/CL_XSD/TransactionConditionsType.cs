
// Type: TransactionConditionsType




using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[XmlRoot("TransactionConditions", IsNullable = false, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[XmlType(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[GeneratedCode("xsd", "4.0.30319.33440")]
[DebuggerStepThrough]
[DesignerCategory("code")]
[Serializable]
public class TransactionConditionsType
{
  private IDType idField;
  private ActionCodeType actionCodeField;
  private DescriptionType[] descriptionField;
  private DocumentReferenceType[] documentReferenceField;

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
  public ActionCodeType ActionCode
  {
    get
    {
      return this.actionCodeField;
    }
    set
    {
      this.actionCodeField = value;
    }
  }

  [XmlElement("Description", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
  public DescriptionType[] Description
  {
    get
    {
      return this.descriptionField;
    }
    set
    {
      this.descriptionField = value;
    }
  }

  [XmlElement("DocumentReference")]
  public DocumentReferenceType[] DocumentReference
  {
    get
    {
      return this.documentReferenceField;
    }
    set
    {
      this.documentReferenceField = value;
    }
  }
}
