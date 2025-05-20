using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[DebuggerStepThrough]
[XmlType(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[GeneratedCode("xsd", "4.0.30319.33440")]
[XmlRoot("AdditionalQualifyingParty", IsNullable = false, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[DesignerCategory("code")]
[Serializable]
public class QualifyingPartyType
{
    private ParticipationPercentType participationPercentField;
    private PersonalSituationType[] personalSituationField;
    private OperatingYearsQuantityType qperatingYearsQuantityField;
    private EmployeeQuantityType employeeQuantityField;
    private BusinessClassificationEvidenceIDType businessClassificationEvidenceIDField;
    private BusinessIdentityEvidenceIDType businessIdentityEvidenceIDField;
    private TendererRoleCodeType tendererRoleCodeField;
    private ClassificationSchemeType businessClassificationSchemeField;
    private CapabilityType[] technicalCapabilityField;
    private CapabilityType[] financialCapabilityField;
    private CompletedTaskType[] completedTaskField;
    private DeclarationType[] declarationField;
    private PartyType partyField;
    private EconomicOperatorRoleType economicOperatorRoleField;

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public ParticipationPercentType ParticipationPercent
    {
        get
        {
            return this.participationPercentField;
        }
        set
        {
            this.participationPercentField = value;
        }
    }

    [XmlElement("PersonalSituation", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public PersonalSituationType[] PersonalSituation
    {
        get
        {
            return this.personalSituationField;
        }
        set
        {
            this.personalSituationField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public OperatingYearsQuantityType OperatingYearsQuantity
    {
        get
        {
            return this.qperatingYearsQuantityField;
        }
        set
        {
            this.qperatingYearsQuantityField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public EmployeeQuantityType EmployeeQuantity
    {
        get
        {
            return this.employeeQuantityField;
        }
        set
        {
            this.employeeQuantityField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public BusinessClassificationEvidenceIDType BusinessClassificationEvidenceID
    {
        get
        {
            return this.businessClassificationEvidenceIDField;
        }
        set
        {
            this.businessClassificationEvidenceIDField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public BusinessIdentityEvidenceIDType BusinessIdentityEvidenceID
    {
        get
        {
            return this.businessIdentityEvidenceIDField;
        }
        set
        {
            this.businessIdentityEvidenceIDField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public TendererRoleCodeType TendererRoleCode
    {
        get
        {
            return this.tendererRoleCodeField;
        }
        set
        {
            this.tendererRoleCodeField = value;
        }
    }

    public ClassificationSchemeType BusinessClassificationScheme
    {
        get
        {
            return this.businessClassificationSchemeField;
        }
        set
        {
            this.businessClassificationSchemeField = value;
        }
    }

    [XmlElement("TechnicalCapability")]
    public CapabilityType[] TechnicalCapability
    {
        get
        {
            return this.technicalCapabilityField;
        }
        set
        {
            this.technicalCapabilityField = value;
        }
    }

    [XmlElement("FinancialCapability")]
    public CapabilityType[] FinancialCapability
    {
        get
        {
            return this.financialCapabilityField;
        }
        set
        {
            this.financialCapabilityField = value;
        }
    }

    [XmlElement("CompletedTask")]
    public CompletedTaskType[] CompletedTask
    {
        get
        {
            return this.completedTaskField;
        }
        set
        {
            this.completedTaskField = value;
        }
    }

    [XmlElement("Declaration")]
    public DeclarationType[] Declaration
    {
        get
        {
            return this.declarationField;
        }
        set
        {
            this.declarationField = value;
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

    public EconomicOperatorRoleType EconomicOperatorRole
    {
        get
        {
            return this.economicOperatorRoleField;
        }
        set
        {
            this.economicOperatorRoleField = value;
        }
    }
}
