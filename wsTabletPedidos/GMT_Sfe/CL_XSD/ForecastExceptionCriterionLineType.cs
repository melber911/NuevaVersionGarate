using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[DebuggerStepThrough]
[XmlRoot("ForecastExceptionCriterionLine", IsNullable = false, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[DesignerCategory("code")]
[XmlType(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[GeneratedCode("xsd", "4.0.30319.33440")]
[Serializable]
public class ForecastExceptionCriterionLineType
{
    private ForecastPurposeCodeType forecastPurposeCodeField;
    private ForecastTypeCodeType forecastTypeCodeField;
    private ComparisonDataSourceCodeType comparisonDataSourceCodeField;
    private DataSourceCodeType dataSourceCodeField;
    private TimeDeltaDaysQuantityType timeDeltaDaysQuantityField;

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

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public ComparisonDataSourceCodeType ComparisonDataSourceCode
    {
        get
        {
            return this.comparisonDataSourceCodeField;
        }
        set
        {
            this.comparisonDataSourceCodeField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public DataSourceCodeType DataSourceCode
    {
        get
        {
            return this.dataSourceCodeField;
        }
        set
        {
            this.dataSourceCodeField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public TimeDeltaDaysQuantityType TimeDeltaDaysQuantity
    {
        get
        {
            return this.timeDeltaDaysQuantityField;
        }
        set
        {
            this.timeDeltaDaysQuantityField = value;
        }
    }
}
