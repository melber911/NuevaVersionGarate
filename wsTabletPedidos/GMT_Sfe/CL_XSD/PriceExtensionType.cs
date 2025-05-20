
// Type: PriceExtensionType




using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[XmlType(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[XmlRoot("ItemPriceExtension", IsNullable = false, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[GeneratedCode("xsd", "4.0.30319.33440")]
[DebuggerStepThrough]
[DesignerCategory("code")]
[Serializable]
public class PriceExtensionType
{
  private AmountType2 amountField;
  private TaxTotalType[] taxTotalField;

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

  [XmlElement("TaxTotal")]
  public TaxTotalType[] TaxTotal
  {
    get
    {
      return this.taxTotalField;
    }
    set
    {
      this.taxTotalField = value;
    }
  }
}
