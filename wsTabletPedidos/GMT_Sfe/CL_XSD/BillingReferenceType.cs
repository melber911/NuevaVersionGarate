using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[XmlRoot("BillingReference", IsNullable = false, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[DebuggerStepThrough]
[XmlType(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[GeneratedCode("xsd", "4.0.30319.33440")]
[DesignerCategory("code")]
[Serializable]
public class BillingReferenceType
{
    private DocumentReferenceType invoiceDocumentReferenceField;
    private DocumentReferenceType selfBilledInvoiceDocumentReferenceField;
    private DocumentReferenceType creditNoteDocumentReferenceField;
    private DocumentReferenceType selfBilledCreditNoteDocumentReferenceField;
    private DocumentReferenceType debitNoteDocumentReferenceField;
    private DocumentReferenceType reminderDocumentReferenceField;
    private DocumentReferenceType additionalDocumentReferenceField;
    private BillingReferenceLineType[] billingReferenceLineField;

    public DocumentReferenceType InvoiceDocumentReference
    {
        get
        {
            return this.invoiceDocumentReferenceField;
        }
        set
        {
            this.invoiceDocumentReferenceField = value;
        }
    }

    public DocumentReferenceType SelfBilledInvoiceDocumentReference
    {
        get
        {
            return this.selfBilledInvoiceDocumentReferenceField;
        }
        set
        {
            this.selfBilledInvoiceDocumentReferenceField = value;
        }
    }

    public DocumentReferenceType CreditNoteDocumentReference
    {
        get
        {
            return this.creditNoteDocumentReferenceField;
        }
        set
        {
            this.creditNoteDocumentReferenceField = value;
        }
    }

    public DocumentReferenceType SelfBilledCreditNoteDocumentReference
    {
        get
        {
            return this.selfBilledCreditNoteDocumentReferenceField;
        }
        set
        {
            this.selfBilledCreditNoteDocumentReferenceField = value;
        }
    }

    public DocumentReferenceType DebitNoteDocumentReference
    {
        get
        {
            return this.debitNoteDocumentReferenceField;
        }
        set
        {
            this.debitNoteDocumentReferenceField = value;
        }
    }

    public DocumentReferenceType ReminderDocumentReference
    {
        get
        {
            return this.reminderDocumentReferenceField;
        }
        set
        {
            this.reminderDocumentReferenceField = value;
        }
    }

    public DocumentReferenceType AdditionalDocumentReference
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

    [XmlElement("BillingReferenceLine")]
    public BillingReferenceLineType[] BillingReferenceLine
    {
        get
        {
            return this.billingReferenceLineField;
        }
        set
        {
            this.billingReferenceLineField = value;
        }
    }
}
