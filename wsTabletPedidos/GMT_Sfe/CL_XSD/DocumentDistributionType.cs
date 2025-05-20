using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[DesignerCategory("code")]
[XmlType(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[DebuggerStepThrough]
[XmlRoot("DocumentDistribution", IsNullable = false, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[GeneratedCode("xsd", "4.0.30319.33440")]
[Serializable]
public class DocumentDistributionType
{
    private PrintQualifierType printQualifierField;
    private MaximumCopiesNumericType maximumCopiesNumericField;
    private PartyType partyField;

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public PrintQualifierType PrintQualifier
    {
        get
        {
            return this.printQualifierField;
        }
        set
        {
            this.printQualifierField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public MaximumCopiesNumericType MaximumCopiesNumeric
    {
        get
        {
            return this.maximumCopiesNumericField;
        }
        set
        {
            this.maximumCopiesNumericField = value;
        }
    }

    public PartyType Party
    {
        get
        {
            return this.partyField;
        }
        set
        {
            this.partyField = value;
        }
    }
}
