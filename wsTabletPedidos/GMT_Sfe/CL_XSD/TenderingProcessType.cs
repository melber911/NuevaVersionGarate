using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[DesignerCategory("code")]
[XmlType(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[XmlRoot("TenderingProcess", IsNullable = false, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[GeneratedCode("xsd", "4.0.30319.33440")]
[DebuggerStepThrough]
[Serializable]
public class TenderingProcessType
{
    private IDType idField;
    private OriginalContractingSystemIDType originalContractingSystemIDField;
    private DescriptionType[] descriptionField;
    private NegotiationDescriptionType[] negotiationDescriptionField;
    private ProcedureCodeType procedureCodeField;
    private UrgencyCodeType urgencyCodeField;
    private ExpenseCodeType expenseCodeField;
    private PartPresentationCodeType partPresentationCodeField;
    private ContractingSystemCodeType contractingSystemCodeField;
    private SubmissionMethodCodeType submissionMethodCodeField;
    private CandidateReductionConstraintIndicatorType candidateReductionConstraintIndicatorField;
    private GovernmentAgreementConstraintIndicatorType governmentAgreementConstraintIndicatorField;
    private PeriodType documentAvailabilityPeriodField;
    private PeriodType tenderSubmissionDeadlinePeriodField;
    private PeriodType invitationSubmissionPeriodField;
    private PeriodType participationRequestReceptionPeriodField;
    private DocumentReferenceType[] noticeDocumentReferenceField;
    private DocumentReferenceType[] additionalDocumentReferenceField;
    private ProcessJustificationType[] processJustificationField;
    private EconomicOperatorShortListType economicOperatorShortListField;
    private EventType[] openTenderEventField;
    private AuctionTermsType auctionTermsField;
    private FrameworkAgreementType frameworkAgreementField;

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
    public OriginalContractingSystemIDType OriginalContractingSystemID
    {
        get
        {
            return this.originalContractingSystemIDField;
        }
        set
        {
            this.originalContractingSystemIDField = value;
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

    [XmlElement("NegotiationDescription", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public NegotiationDescriptionType[] NegotiationDescription
    {
        get
        {
            return this.negotiationDescriptionField;
        }
        set
        {
            this.negotiationDescriptionField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public ProcedureCodeType ProcedureCode
    {
        get
        {
            return this.procedureCodeField;
        }
        set
        {
            this.procedureCodeField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public UrgencyCodeType UrgencyCode
    {
        get
        {
            return this.urgencyCodeField;
        }
        set
        {
            this.urgencyCodeField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public ExpenseCodeType ExpenseCode
    {
        get
        {
            return this.expenseCodeField;
        }
        set
        {
            this.expenseCodeField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public PartPresentationCodeType PartPresentationCode
    {
        get
        {
            return this.partPresentationCodeField;
        }
        set
        {
            this.partPresentationCodeField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public ContractingSystemCodeType ContractingSystemCode
    {
        get
        {
            return this.contractingSystemCodeField;
        }
        set
        {
            this.contractingSystemCodeField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public SubmissionMethodCodeType SubmissionMethodCode
    {
        get
        {
            return this.submissionMethodCodeField;
        }
        set
        {
            this.submissionMethodCodeField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public CandidateReductionConstraintIndicatorType CandidateReductionConstraintIndicator
    {
        get
        {
            return this.candidateReductionConstraintIndicatorField;
        }
        set
        {
            this.candidateReductionConstraintIndicatorField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public GovernmentAgreementConstraintIndicatorType GovernmentAgreementConstraintIndicator
    {
        get
        {
            return this.governmentAgreementConstraintIndicatorField;
        }
        set
        {
            this.governmentAgreementConstraintIndicatorField = value;
        }
    }

    public PeriodType DocumentAvailabilityPeriod
    {
        get
        {
            return this.documentAvailabilityPeriodField;
        }
        set
        {
            this.documentAvailabilityPeriodField = value;
        }
    }

    public PeriodType TenderSubmissionDeadlinePeriod
    {
        get
        {
            return this.tenderSubmissionDeadlinePeriodField;
        }
        set
        {
            this.tenderSubmissionDeadlinePeriodField = value;
        }
    }

    public PeriodType InvitationSubmissionPeriod
    {
        get
        {
            return this.invitationSubmissionPeriodField;
        }
        set
        {
            this.invitationSubmissionPeriodField = value;
        }
    }

    public PeriodType ParticipationRequestReceptionPeriod
    {
        get
        {
            return this.participationRequestReceptionPeriodField;
        }
        set
        {
            this.participationRequestReceptionPeriodField = value;
        }
    }

    [XmlElement("NoticeDocumentReference")]
    public DocumentReferenceType[] NoticeDocumentReference
    {
        get
        {
            return this.noticeDocumentReferenceField;
        }
        set
        {
            this.noticeDocumentReferenceField = value;
        }
    }

    [XmlElement("AdditionalDocumentReference")]
    public DocumentReferenceType[] AdditionalDocumentReference
    {
        get
        {
            return this.additionalDocumentReferenceField;
        }
        set
        {
            this.additionalDocumentReferenceField = value;
        }
    }

    [XmlElement("ProcessJustification")]
    public ProcessJustificationType[] ProcessJustification
    {
        get
        {
            return this.processJustificationField;
        }
        set
        {
            this.processJustificationField = value;
        }
    }

    public EconomicOperatorShortListType EconomicOperatorShortList
    {
        get
        {
            return this.economicOperatorShortListField;
        }
        set
        {
            this.economicOperatorShortListField = value;
        }
    }

    [XmlElement("OpenTenderEvent")]
    public EventType[] OpenTenderEvent
    {
        get
        {
            return this.openTenderEventField;
        }
        set
        {
            this.openTenderEventField = value;
        }
    }

    public AuctionTermsType AuctionTerms
    {
        get
        {
            return this.auctionTermsField;
        }
        set
        {
            this.auctionTermsField = value;
        }
    }

    public FrameworkAgreementType FrameworkAgreement
    {
        get
        {
            return this.frameworkAgreementField;
        }
        set
        {
            this.frameworkAgreementField = value;
        }
    }
}
