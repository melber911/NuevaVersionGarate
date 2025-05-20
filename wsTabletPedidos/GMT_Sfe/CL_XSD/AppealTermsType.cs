using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[XmlRoot("AppealTerms", IsNullable = false, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[DebuggerStepThrough]
[XmlType(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[GeneratedCode("xsd", "4.0.30319.33440")]
[DesignerCategory("code")]
[Serializable]
public class AppealTermsType
{
    private DescriptionType[] descriptionField;
    private PeriodType presentationPeriodField;
    private PartyType appealInformationPartyField;
    private PartyType appealReceiverPartyField;
    private PartyType mediationPartyField;

    [XmlElement("Description", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public DescriptionType[] Description
    {
        get
        {
            return this.descriptionField;
        }
        set
        {
            this.descriptionField = value;
        }
    }

    public PeriodType PresentationPeriod
    {
        get
        {
            return this.presentationPeriodField;
        }
        set
        {
            this.presentationPeriodField = value;
        }
    }

    public PartyType AppealInformationParty
    {
        get
        {
            return this.appealInformationPartyField;
        }
        set
        {
            this.appealInformationPartyField = value;
        }
    }

    public PartyType AppealReceiverParty
    {
        get
        {
            return this.appealReceiverPartyField;
        }
        set
        {
            this.appealReceiverPartyField = value;
        }
    }

    public PartyType MediationParty
    {
        get
        {
            return this.mediationPartyField;
        }
        set
        {
            this.mediationPartyField = value;
        }
    }
}
