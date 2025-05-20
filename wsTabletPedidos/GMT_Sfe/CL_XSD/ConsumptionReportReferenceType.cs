using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[DesignerCategory("code")]
[DebuggerStepThrough]
[GeneratedCode("xsd", "4.0.30319.33440")]
[XmlRoot("ConsumptionReportReference", IsNullable = false, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[XmlType(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[Serializable]
public class ConsumptionReportReferenceType
{
    private ConsumptionReportIDType consumptionReportIDField;
    private ConsumptionTypeType consumptionTypeField;
    private ConsumptionTypeCodeType consumptionTypeCodeField;
    private TotalConsumedQuantityType totalConsumedQuantityField;
    private PeriodType periodField;

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public ConsumptionReportIDType ConsumptionReportID
    {
        get
        {
            return this.consumptionReportIDField;
        }
        set
        {
            this.consumptionReportIDField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public ConsumptionTypeType ConsumptionType
    {
        get
        {
            return this.consumptionTypeField;
        }
        set
        {
            this.consumptionTypeField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public ConsumptionTypeCodeType ConsumptionTypeCode
    {
        get
        {
            return this.consumptionTypeCodeField;
        }
        set
        {
            this.consumptionTypeCodeField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public TotalConsumedQuantityType TotalConsumedQuantity
    {
        get
        {
            return this.totalConsumedQuantityField;
        }
        set
        {
            this.totalConsumedQuantityField = value;
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
