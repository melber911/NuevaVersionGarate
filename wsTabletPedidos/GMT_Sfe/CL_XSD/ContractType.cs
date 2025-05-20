using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[DesignerCategory("code")]
[XmlType(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[XmlRoot("Contract", IsNullable = false, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[GeneratedCode("xsd", "4.0.30319.33440")]
[DebuggerStepThrough]
[Serializable]
public class ContractType
{
    private IDType idField;
    private IssueDateType issueDateField;
    private IssueTimeType issueTimeField;
    private NominationDateType nominationDateField;
    private NominationTimeType nominationTimeField;
    private ContractTypeCodeType contractTypeCodeField;
    private ContractTypeType contractType1Field;
    private NoteType[] noteField;
    private VersionIDType versionIDField;
    private DescriptionType[] descriptionField;
    private PeriodType validityPeriodField;
    private DocumentReferenceType[] contractDocumentReferenceField;
    private PeriodType nominationPeriodField;
    private DeliveryType contractualDeliveryField;

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
    public IssueDateType IssueDate
    {
        get
        {
            return this.issueDateField;
        }
        set
        {
            this.issueDateField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public IssueTimeType IssueTime
    {
        get
        {
            return this.issueTimeField;
        }
        set
        {
            this.issueTimeField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public NominationDateType NominationDate
    {
        get
        {
            return this.nominationDateField;
        }
        set
        {
            this.nominationDateField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public NominationTimeType NominationTime
    {
        get
        {
            return this.nominationTimeField;
        }
        set
        {
            this.nominationTimeField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public ContractTypeCodeType ContractTypeCode
    {
        get
        {
            return this.contractTypeCodeField;
        }
        set
        {
            this.contractTypeCodeField = value;
        }
    }

    [XmlElement("ContractType", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public ContractTypeType ContractType1
    {
        get
        {
            return this.contractType1Field;
        }
        set
        {
            this.contractType1Field = value;
        }
    }

    [XmlElement("Note", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public NoteType[] Note
    {
        get
        {
            return this.noteField;
        }
        set
        {
            this.noteField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public VersionIDType VersionID
    {
        get
        {
            return this.versionIDField;
        }
        set
        {
            this.versionIDField = value;
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

    public PeriodType ValidityPeriod
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

    [XmlElement("ContractDocumentReference")]
    public DocumentReferenceType[] ContractDocumentReference
    {
        get
        {
            return this.contractDocumentReferenceField;
        }
        set
        {
            this.contractDocumentReferenceField = value;
        }
    }

    public PeriodType NominationPeriod
    {
        get
        {
            return this.nominationPeriodField;
        }
        set
        {
            this.nominationPeriodField = value;
        }
    }

    public DeliveryType ContractualDelivery
    {
        get
        {
            return this.contractualDeliveryField;
        }
        set
        {
            this.contractualDeliveryField = value;
        }
    }
}
