using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[XmlType(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[XmlRoot("BillingReferenceLine", IsNullable = false, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[GeneratedCode("xsd", "4.0.30319.33440")]
[DebuggerStepThrough]
[DesignerCategory("code")]
[Serializable]
public class BillingReferenceLineType
{
  private IDType idField;
  private AmountType2 amountField;
  private AllowanceChargeType[] allowanceChargeField;

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
  public AmountType2 Amount
  {
    get
    {
      return this.amountField;
    }
    set
    {
      this.amountField = value;
    }
  }

  [XmlElement("AllowanceCharge")]
  public AllowanceChargeType[] AllowanceCharge
  {
    get
    {
      return this.allowanceChargeField;
    }
    set
    {
      this.allowanceChargeField = value;
    }
  }
}
