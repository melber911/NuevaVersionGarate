using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[XmlRoot("ShareholderParty", IsNullable = false, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[DesignerCategory("code")]
[XmlType(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[DebuggerStepThrough]
[GeneratedCode("xsd", "4.0.30319.33440")]
[Serializable]
public class ShareholderPartyType
{
    private PartecipationPercentType partecipationPercentField;
    private PartyType partyField;

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public PartecipationPercentType PartecipationPercent
    {
        get
        {
            return this.partecipationPercentField;
        }
        set
        {
            this.partecipationPercentField = value;
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
