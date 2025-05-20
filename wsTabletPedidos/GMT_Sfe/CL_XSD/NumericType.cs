
// Type: NumericType




using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[XmlInclude(typeof (ValueType1))]
[XmlInclude(typeof (BudgetYearNumericType))]
[GeneratedCode("xsd", "4.0.30319.33440")]
[XmlInclude(typeof (HumidityPercentType))]
[XmlType(Namespace = "urn:un:unece:uncefact:data:specification:CoreComponentTypeSchemaModule:2")]
[XmlInclude(typeof (TargetCurrencyBaseRateType))]
[XmlInclude(typeof (SourceCurrencyBaseRateType))]
[XmlInclude(typeof (RateType1))]
[XmlInclude(typeof (OrderableUnitFactorRateType))]
[XmlInclude(typeof (CalculationRateType))]
[XmlInclude(typeof (AmountRateType))]
[XmlInclude(typeof (PercentType))]
[XmlInclude(typeof (TierRatePercentType))]
[XmlInclude(typeof (TargetServicePercentType))]
[XmlInclude(typeof (SettlementDiscountPercentType))]
[XmlInclude(typeof (ReliabilityPercentType))]
[XmlInclude(typeof (ProgressPercentType))]
[XmlInclude(typeof (PercentType1))]
[XmlInclude(typeof (PenaltySurchargePercentType))]
[XmlInclude(typeof (PaymentPercentType))]
[XmlInclude(typeof (ParticipationPercentType))]
[XmlInclude(typeof (PartecipationPercentType))]
[XmlInclude(typeof (MinimumPercentType))]
[XmlInclude(typeof (MaximumPercentType))]
[XmlInclude(typeof (RateType))]
[XmlInclude(typeof (AirFlowPercentType))]
[XmlInclude(typeof (NumericType1))]
[XmlInclude(typeof (WeightNumericType))]
[XmlInclude(typeof (SequenceNumericType))]
[XmlInclude(typeof (ResidentOccupantsNumericType))]
[XmlInclude(typeof (ReminderSequenceNumericType))]
[XmlInclude(typeof (PackSizeNumericType))]
[XmlInclude(typeof (OrderQuantityIncrementNumericType))]
[XmlInclude(typeof (OrderIntervalDaysNumericType))]
[XmlInclude(typeof (MultiplierFactorNumericType))]
[XmlInclude(typeof (MinimumNumberNumericType))]
[XmlInclude(typeof (MaximumPaymentInstructionsNumericType))]
[XmlInclude(typeof (MaximumNumberNumericType))]
[XmlInclude(typeof (MaximumCopiesNumericType))]
[XmlInclude(typeof (LineNumberNumericType))]
[XmlInclude(typeof (LineCountNumericType))]
[XmlInclude(typeof (FrozenPeriodDaysNumericType))]
[XmlInclude(typeof (CalculationSequenceNumericType))]
[DebuggerStepThrough]
[DesignerCategory("code")]
[Serializable]
public class NumericType
{
  private string formatField;
  private Decimal valueField;

  [XmlAttribute]
  public string format
  {
    get
    {
      return this.formatField;
    }
    set
    {
      this.formatField = value;
    }
  }

  [XmlText]
  public Decimal Value
  {
    get
    {
      return this.valueField;
    }
    set
    {
      this.valueField = value;
    }
  }
}
