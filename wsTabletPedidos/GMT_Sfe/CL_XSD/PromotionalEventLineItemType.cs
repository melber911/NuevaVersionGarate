
// Type: PromotionalEventLineItemType




using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[DebuggerStepThrough]
[XmlRoot("PromotionalEventLineItem", IsNullable = false, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[GeneratedCode("xsd", "4.0.30319.33440")]
[DesignerCategory("code")]
[XmlType(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[Serializable]
public class PromotionalEventLineItemType
{
  private AmountType2 amountField;
  private EventLineItemType eventLineItemField;

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

  public EventLineItemType EventLineItem
  {
    get
    {
      return this.eventLineItemField;
    }
    set
    {
      this.eventLineItemField = value;
    }
  }
}
