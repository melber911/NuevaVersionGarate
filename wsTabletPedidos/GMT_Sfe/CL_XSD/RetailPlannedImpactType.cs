
// Type: RetailPlannedImpactType




using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[XmlType(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[DebuggerStepThrough]
[XmlRoot("RetailPlannedImpact", IsNullable = false, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[GeneratedCode("xsd", "4.0.30319.33440")]
[DesignerCategory("code")]
[Serializable]
public class RetailPlannedImpactType
{
  private AmountType2 amountField;
  private ForecastPurposeCodeType forecastPurposeCodeField;
  private ForecastTypeCodeType forecastTypeCodeField;
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

  [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
  public ForecastPurposeCodeType ForecastPurposeCode
  {
    get
    {
      return this.forecastPurposeCodeField;
    }
    set
    {
      this.forecastPurposeCodeField = value;
    }
  }

  [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
  public ForecastTypeCodeType ForecastTypeCode
  {
    get
    {
      return this.forecastTypeCodeField;
    }
    set
    {
      this.forecastTypeCodeField = value;
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
