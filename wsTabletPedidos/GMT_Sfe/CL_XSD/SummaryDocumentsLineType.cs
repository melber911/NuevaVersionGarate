using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[GeneratedCode("xsd", "4.0.30319.1")]
[XmlType(Namespace = "urn:sunat:names:specification:ubl:peru:schema:xsd:SunatAggregateComponents-1")]
[XmlRoot("SummaryDocumentsLine", IsNullable = false, Namespace = "urn:sunat:names:specification:ubl:peru:schema:xsd:SunatAggregateComponents-1")]
[DebuggerStepThrough]
[DesignerCategory("code")]
[Serializable]
public class SummaryDocumentsLineType
{
    private LineIDType lineIDField;
    private IDType idField;
    private BillingReferenceType billingReferenceField;
    private CustomerPartyType accountingCustomerPartyField;
    private SUNATPerceptionSummaryDocumentReferenceType sUNATPerceptionSummaryDocumentReferenceField;
    private StatusType statusField;
    private DocumentTypeCodeType documentTypeCodeField;
    private identifierFieldType documentSerialIDField;
    private identifierFieldType startDocumentNumberIDField;
    private identifierFieldType endDocumentNumberIDField;
    private AmountType1 totalAmountField;
    private PaymentType[] billingPaymentField;
    private AllowanceChargeType[] allowanceChargeField;
    private TaxTotalType[] taxTotalField;

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public LineIDType LineID
    {
        get
        {
            return this.lineIDField;
        }
        set
        {
            this.lineIDField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public DocumentTypeCodeType DocumentTypeCode
    {
        get
        {
            return this.documentTypeCodeField;
        }
        set
        {
            this.documentTypeCodeField = value;
        }
    }

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

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
    public CustomerPartyType AccountingCustomerParty
    {
        get
        {
            return this.accountingCustomerPartyField;
        }
        set
        {
            this.accountingCustomerPartyField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
    public BillingReferenceType BillingReference
    {
        get
        {
            return this.billingReferenceField;
        }
        set
        {
            this.billingReferenceField = value;
        }
    }

    public SUNATPerceptionSummaryDocumentReferenceType SUNATPerceptionSummaryDocumentReference
    {
        get
        {
            return this.sUNATPerceptionSummaryDocumentReferenceField;
        }
        set
        {
            this.sUNATPerceptionSummaryDocumentReferenceField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
    public StatusType Status
    {
        get
        {
            return this.statusField;
        }
        set
        {
            this.statusField = value;
        }
    }

    public identifierFieldType DocumentSerialID
    {
        get
        {
            return this.documentSerialIDField;
        }
        set
        {
            this.documentSerialIDField = value;
        }
    }

    public identifierFieldType StartDocumentNumberID
    {
        get
        {
            return this.startDocumentNumberIDField;
        }
        set
        {
            this.startDocumentNumberIDField = value;
        }
    }

    public identifierFieldType EndDocumentNumberID
    {
        get
        {
            return this.endDocumentNumberIDField;
        }
        set
        {
            this.endDocumentNumberIDField = value;
        }
    }

    public AmountType1 TotalAmount
    {
        get
        {
            return this.totalAmountField;
        }
        set
        {
            this.totalAmountField = value;
        }
    }

    [XmlElement("BillingPayment")]
    public PaymentType[] BillingPayment
    {
        get
        {
            return this.billingPaymentField;
        }
        set
        {
            this.billingPaymentField = value;
        }
    }

    [XmlElement("AllowanceCharge", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
    public AllowanceChargeType[] AllowanceCharge
    {
        get
        {
            return this.allowanceChargeField;
        }
        set
        {
            this.allowanceChargeField = value;
        }
    }

    [XmlElement("TaxTotal", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
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
}
