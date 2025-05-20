using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[DebuggerStepThrough]
[XmlType(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[XmlRoot("CatalogueRequestLine", IsNullable = false, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[GeneratedCode("xsd", "4.0.30319.33440")]
[DesignerCategory("code")]
[Serializable]
public class CatalogueRequestLineType
{
  private IDType idField;
  private ContractSubdivisionType contractSubdivisionField;
  private NoteType[] noteField;
  private PeriodType lineValidityPeriodField;
  private ItemLocationQuantityType[] requiredItemLocationQuantityField;
  private ItemType itemField;

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
  public ContractSubdivisionType ContractSubdivision
  {
    get
    {
      return this.contractSubdivisionField;
    }
    set
    {
      this.contractSubdivisionField = value;
    }
  }

  [XmlElement("Note", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
  public NoteType[] Note
  {
    get
    {
      return this.noteField;
    }
    set
    {
      this.noteField = value;
    }
  }

  public PeriodType LineValidityPeriod
  {
    get
    {
      return this.lineValidityPeriodField;
    }
    set
    {
      this.lineValidityPeriodField = value;
    }
  }

  [XmlElement("RequiredItemLocationQuantity")]
  public ItemLocationQuantityType[] RequiredItemLocationQuantity
  {
    get
    {
      return this.requiredItemLocationQuantityField;
    }
    set
    {
      this.requiredItemLocationQuantityField = value;
    }
  }

  public ItemType Item
  {
    get
    {
      return this.itemField;
    }
    set
    {
      this.itemField = value;
    }
  }
}
