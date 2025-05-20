
// Type: RenewalType




using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[GeneratedCode("xsd", "4.0.30319.33440")]
[DebuggerStepThrough]
[DesignerCategory("code")]
[XmlType(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[XmlRoot("Renewal", IsNullable = false, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[Serializable]
public class RenewalType
{
  private AmountType2 amountField;
  private PeriodType periodField;

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

  public PeriodType Period
  {
    get
    {
      return this.periodField;
    }
    set
    {
      this.periodField = value;
    }
  }
}
