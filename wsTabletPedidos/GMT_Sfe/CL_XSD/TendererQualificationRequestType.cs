using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[XmlType(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[XmlRoot("TendererQualificationRequest", IsNullable = false, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[GeneratedCode("xsd", "4.0.30319.33440")]
[DebuggerStepThrough]
[DesignerCategory("code")]
[Serializable]
public class TendererQualificationRequestType
{
    private CompanyLegalFormCodeType companyLegalFormCodeField;
    private CompanyLegalFormType companyLegalFormField;
    private PersonalSituationType[] personalSituationField;
    private OperatingYearsQuantityType qperatingYearsQuantityField;
    private EmployeeQuantityType employeeQuantityField;
    private DescriptionType[] descriptionField;
    private ClassificationSchemeType[] requiredBusinessClassificationSchemeField;
    private EvaluationCriterionType[] technicalEvaluationCriterionField;
    private EvaluationCriterionType[] financialEvaluationCriterionField;
    private TendererRequirementType[] specificTendererRequirementField;
    private EconomicOperatorRoleType[] economicOperatorRoleField;

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public CompanyLegalFormCodeType CompanyLegalFormCode
    {
        get
        {
            return this.companyLegalFormCodeField;
        }
        set
        {
            this.companyLegalFormCodeField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public CompanyLegalFormType CompanyLegalForm
    {
        get
        {
            return this.companyLegalFormField;
        }
        set
        {
            this.companyLegalFormField = value;
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

    [XmlElement("RequiredBusinessClassificationScheme")]
    public ClassificationSchemeType[] RequiredBusinessClassificationScheme
    {
        get
        {
            return this.requiredBusinessClassificationSchemeField;
        }
        set
        {
            this.requiredBusinessClassificationSchemeField = value;
        }
    }

    [XmlElement("TechnicalEvaluationCriterion")]
    public EvaluationCriterionType[] TechnicalEvaluationCriterion
    {
        get
        {
            return this.technicalEvaluationCriterionField;
        }
        set
        {
            this.technicalEvaluationCriterionField = value;
        }
    }

    [XmlElement("FinancialEvaluationCriterion")]
    public EvaluationCriterionType[] FinancialEvaluationCriterion
    {
        get
        {
            return this.financialEvaluationCriterionField;
        }
        set
        {
            this.financialEvaluationCriterionField = value;
        }
    }

    [XmlElement("SpecificTendererRequirement")]
    public TendererRequirementType[] SpecificTendererRequirement
    {
        get
        {
            return this.specificTendererRequirementField;
        }
        set
        {
            this.specificTendererRequirementField = value;
        }
    }

    [XmlElement("EconomicOperatorRole")]
    public EconomicOperatorRoleType[] EconomicOperatorRole
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
