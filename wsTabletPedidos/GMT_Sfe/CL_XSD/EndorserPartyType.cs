using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[DebuggerStepThrough]
[DesignerCategory("code")]
[XmlType(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[XmlRoot("EndorserParty", IsNullable = false, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[GeneratedCode("xsd", "4.0.30319.33440")]
[Serializable]
public class EndorserPartyType
{
    private RoleCodeType roleCodeField;
    private SequenceNumericType sequenceNumericField;
    private PartyType partyField;
    private ContactType signatoryContactField;

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public RoleCodeType RoleCode
    {
        get
        {
            return this.roleCodeField;
        }
        set
        {
            this.roleCodeField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public SequenceNumericType SequenceNumeric
    {
        get
        {
            return this.sequenceNumericField;
        }
        set
        {
            this.sequenceNumericField = value;
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

    public ContactType SignatoryContact
    {
        get
        {
            return this.signatoryContactField;
        }
        set
        {
            this.signatoryContactField = value;
        }
    }
}
