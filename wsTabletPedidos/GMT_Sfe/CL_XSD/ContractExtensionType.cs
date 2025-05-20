using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[XmlType(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[XmlRoot("ContractExtension", IsNullable = false, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[DebuggerStepThrough]
[DesignerCategory("code")]
[GeneratedCode("xsd", "4.0.30319.33440")]
[Serializable]
public class ContractExtensionType
{
    private OptionsDescriptionType[] optionsDescriptionField;
    private MinimumNumberNumericType minimumNumberNumericField;
    private MaximumNumberNumericType maximumNumberNumericField;
    private PeriodType optionValidityPeriodField;
    private RenewalType[] renewalField;

    [XmlElement("OptionsDescription", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public OptionsDescriptionType[] OptionsDescription
    {
        get
        {
            return this.optionsDescriptionField;
        }
        set
        {
            this.optionsDescriptionField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public MinimumNumberNumericType MinimumNumberNumeric
    {
        get
        {
            return this.minimumNumberNumericField;
        }
        set
        {
            this.minimumNumberNumericField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public MaximumNumberNumericType MaximumNumberNumeric
    {
        get
        {
            return this.maximumNumberNumericField;
        }
        set
        {
            this.maximumNumberNumericField = value;
        }
    }

    public PeriodType OptionValidityPeriod
    {
        get
        {
            return this.optionValidityPeriodField;
        }
        set
        {
            this.optionValidityPeriodField = value;
        }
    }

    [XmlElement("Renewal")]
    public RenewalType[] Renewal
    {
        get
        {
            return this.renewalField;
        }
        set
        {
            this.renewalField = value;
        }
    }
}
