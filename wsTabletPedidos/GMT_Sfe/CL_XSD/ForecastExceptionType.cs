using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[XmlType(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[GeneratedCode("xsd", "4.0.30319.33440")]
[XmlRoot("ForecastException", IsNullable = false, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[DebuggerStepThrough]
[DesignerCategory("code")]
[Serializable]
public class ForecastExceptionType
{
    private ForecastPurposeCodeType forecastPurposeCodeField;
    private ForecastTypeCodeType forecastTypeCodeField;
    private IssueDateType issueDateField;
    private IssueTimeType issueTimeField;
    private DataSourceCodeType dataSourceCodeField;
    private ComparisonDataCodeType comparisonDataCodeField;
    private ComparisonForecastIssueTimeType comparisonForecastIssueTimeField;
    private ComparisonForecastIssueDateType comparisonForecastIssueDateField;

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
    public IssueDateType IssueDate
    {
        get
        {
            return this.issueDateField;
        }
        set
        {
            this.issueDateField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public IssueTimeType IssueTime
    {
        get
        {
            return this.issueTimeField;
        }
        set
        {
            this.issueTimeField = value;
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
    public ComparisonDataCodeType ComparisonDataCode
    {
        get
        {
            return this.comparisonDataCodeField;
        }
        set
        {
            this.comparisonDataCodeField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public ComparisonForecastIssueTimeType ComparisonForecastIssueTime
    {
        get
        {
            return this.comparisonForecastIssueTimeField;
        }
        set
        {
            this.comparisonForecastIssueTimeField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public ComparisonForecastIssueDateType ComparisonForecastIssueDate
    {
        get
        {
            return this.comparisonForecastIssueDateField;
        }
        set
        {
            this.comparisonForecastIssueDateField = value;
        }
    }
}
