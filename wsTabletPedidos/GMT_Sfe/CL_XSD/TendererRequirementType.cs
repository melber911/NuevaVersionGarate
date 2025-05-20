using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[XmlType(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[XmlRoot("SpecificTendererRequirement", IsNullable = false, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[DesignerCategory("code")]
[GeneratedCode("xsd", "4.0.30319.33440")]
[DebuggerStepThrough]
[Serializable]
public class TendererRequirementType
{
    private NameType1[] nameField;
    private TendererRequirementTypeCodeType tendererRequirementTypeCodeField;
    private DescriptionType[] descriptionField;
    private LegalReferenceType legalReferenceField;
    private EvidenceType[] suggestedEvidenceField;

    [XmlElement("Name", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public NameType1[] Name
    {
        get
        {
            return this.nameField;
        }
        set
        {
            this.nameField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public TendererRequirementTypeCodeType TendererRequirementTypeCode
    {
        get
        {
            return this.tendererRequirementTypeCodeField;
        }
        set
        {
            this.tendererRequirementTypeCodeField = value;
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

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public LegalReferenceType LegalReference
    {
        get
        {
            return this.legalReferenceField;
        }
        set
        {
            this.legalReferenceField = value;
        }
    }

    [XmlElement("SuggestedEvidence")]
    public EvidenceType[] SuggestedEvidence
    {
        get
        {
            return this.suggestedEvidenceField;
        }
        set
        {
            this.suggestedEvidenceField = value;
        }
    }
}
