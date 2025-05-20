using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[XmlType(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[XmlRoot("PreviousPriceList", IsNullable = false, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[GeneratedCode("xsd", "4.0.30319.33440")]
[DebuggerStepThrough]
[DesignerCategory("code")]
[Serializable]
public class PriceListType
{
    private IDType idField;
    private StatusCodeType statusCodeField;
    private PeriodType[] validityPeriodField;
    private PriceListType previousPriceListField;

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
    public StatusCodeType StatusCode
    {
        get
        {
            return this.statusCodeField;
        }
        set
        {
            this.statusCodeField = value;
        }
    }

    [XmlElement("ValidityPeriod")]
    public PeriodType[] ValidityPeriod
    {
        get
        {
            return this.validityPeriodField;
        }
        set
        {
            this.validityPeriodField = value;
        }
    }

    public PriceListType PreviousPriceList
    {
        get
        {
            return this.previousPriceListField;
        }
        set
        {
            this.previousPriceListField = value;
        }
    }
}
