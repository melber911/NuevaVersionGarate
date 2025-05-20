using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[XmlType(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[GeneratedCode("xsd", "4.0.30319.33440")]
[DebuggerStepThrough]
[DesignerCategory("code")]
[XmlRoot("ContractingPartyType", IsNullable = false, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[Serializable]
public class ContractingPartyTypeType
{
    private PartyTypeCodeType partyTypeCodeField;
    private PartyTypeType partyTypeField;

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public PartyTypeCodeType PartyTypeCode
    {
        get
        {
            return this.partyTypeCodeField;
        }
        set
        {
            this.partyTypeCodeField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public PartyTypeType PartyType
    {
        get
        {
            return this.partyTypeField;
        }
        set
        {
            this.partyTypeField = value;
        }
    }
}
