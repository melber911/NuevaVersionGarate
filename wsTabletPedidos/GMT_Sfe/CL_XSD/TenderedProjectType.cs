using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[XmlType(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[XmlRoot("AwardedTenderedProject", IsNullable = false, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[GeneratedCode("xsd", "4.0.30319.33440")]
[DebuggerStepThrough]
[DesignerCategory("code")]
[Serializable]
public class TenderedProjectType
{
    private VariantIDType variantIDField;
    private FeeAmountType feeAmountField;
    private FeeDescriptionType[] feeDescriptionField;
    private TenderEnvelopeIDType tenderEnvelopeIDField;
    private TenderEnvelopeTypeCodeType tenderEnvelopeTypeCodeField;
    private ProcurementProjectLotType procurementProjectLotField;
    private DocumentReferenceType[] evidenceDocumentReferenceField;
    private TaxTotalType[] taxTotalField;
    private MonetaryTotalType legalMonetaryTotalField;
    private TenderLineType[] tenderLineField;
    private AwardingCriterionResponseType[] awardingCriterionResponseField;

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public VariantIDType VariantID
    {
        get
        {
            return this.variantIDField;
        }
        set
        {
            this.variantIDField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public FeeAmountType FeeAmount
    {
        get
        {
            return this.feeAmountField;
        }
        set
        {
            this.feeAmountField = value;
        }
    }

    [XmlElement("FeeDescription", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public FeeDescriptionType[] FeeDescription
    {
        get
        {
            return this.feeDescriptionField;
        }
        set
        {
            this.feeDescriptionField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public TenderEnvelopeIDType TenderEnvelopeID
    {
        get
        {
            return this.tenderEnvelopeIDField;
        }
        set
        {
            this.tenderEnvelopeIDField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public TenderEnvelopeTypeCodeType TenderEnvelopeTypeCode
    {
        get
        {
            return this.tenderEnvelopeTypeCodeField;
        }
        set
        {
            this.tenderEnvelopeTypeCodeField = value;
        }
    }

    public ProcurementProjectLotType ProcurementProjectLot
    {
        get
        {
            return this.procurementProjectLotField;
        }
        set
        {
            this.procurementProjectLotField = value;
        }
    }

    [XmlElement("EvidenceDocumentReference")]
    public DocumentReferenceType[] EvidenceDocumentReference
    {
        get
        {
            return this.evidenceDocumentReferenceField;
        }
        set
        {
            this.evidenceDocumentReferenceField = value;
        }
    }

    [XmlElement("TaxTotal")]
    public TaxTotalType[] TaxTotal
    {
        get
        {
            return this.taxTotalField;
        }
        set
        {
            this.taxTotalField = value;
        }
    }

    public MonetaryTotalType LegalMonetaryTotal
    {
        get
        {
            return this.legalMonetaryTotalField;
        }
        set
        {
            this.legalMonetaryTotalField = value;
        }
    }

    [XmlElement("TenderLine")]
    public TenderLineType[] TenderLine
    {
        get
        {
            return this.tenderLineField;
        }
        set
        {
            this.tenderLineField = value;
        }
    }

    [XmlElement("AwardingCriterionResponse")]
    public AwardingCriterionResponseType[] AwardingCriterionResponse
    {
        get
        {
            return this.awardingCriterionResponseField;
        }
        set
        {
            this.awardingCriterionResponseField = value;
        }
    }
}
