
// Type: RateType




using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[GeneratedCode("xsd", "4.0.30319.33440")]
[XmlInclude(typeof (SourceCurrencyBaseRateType))]
[DebuggerStepThrough]
[XmlInclude(typeof (OrderableUnitFactorRateType))]
[XmlInclude(typeof (CalculationRateType))]
[XmlInclude(typeof (AmountRateType))]
[XmlType(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:UnqualifiedDataTypes-2")]
[DesignerCategory("code")]
[XmlInclude(typeof (RateType1))]
[XmlInclude(typeof (TargetCurrencyBaseRateType))]
[Serializable]
public class RateType : NumericType
{
}
