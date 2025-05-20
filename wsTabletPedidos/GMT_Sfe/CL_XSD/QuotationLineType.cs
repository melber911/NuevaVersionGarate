using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[GeneratedCode("xsd", "4.0.30319.33440")]
[DebuggerStepThrough]
[DesignerCategory("code")]
[XmlType(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[XmlRoot("QuotationLine", IsNullable = false, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[Serializable]
public class QuotationLineType
{
    private IDType idField;
    private NoteType[] noteField;
    private QuantityType2 quantityField;
    private LineExtensionAmountType lineExtensionAmountField;
    private TotalTaxAmountType totalTaxAmountField;
    private RequestForQuotationLineIDType requestForQuotationLineIDField;
    private DocumentReferenceType[] documentReferenceField;
    private LineItemType lineItemField;
    private LineItemType[] sellerProposedSubstituteLineItemField;
    private LineItemType[] alternativeLineItemField;
    private LineReferenceType requestLineReferenceField;

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
    public QuantityType2 Quantity
    {
        get
        {
            return this.quantityField;
        }
        set
        {
            this.quantityField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public LineExtensionAmountType LineExtensionAmount
    {
        get
        {
            return this.lineExtensionAmountField;
        }
        set
        {
            this.lineExtensionAmountField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public TotalTaxAmountType TotalTaxAmount
    {
        get
        {
            return this.totalTaxAmountField;
        }
        set
        {
            this.totalTaxAmountField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public RequestForQuotationLineIDType RequestForQuotationLineID
    {
        get
        {
            return this.requestForQuotationLineIDField;
        }
        set
        {
            this.requestForQuotationLineIDField = value;
        }
    }

    [XmlElement("DocumentReference")]
    public DocumentReferenceType[] DocumentReference
    {
        get
        {
            return this.documentReferenceField;
        }
        set
        {
            this.documentReferenceField = value;
        }
    }

    public LineItemType LineItem
    {
        get
        {
            return this.lineItemField;
        }
        set
        {
            this.lineItemField = value;
        }
    }

    [XmlElement("SellerProposedSubstituteLineItem")]
    public LineItemType[] SellerProposedSubstituteLineItem
    {
        get
        {
            return this.sellerProposedSubstituteLineItemField;
        }
        set
        {
            this.sellerProposedSubstituteLineItemField = value;
        }
    }

    [XmlElement("AlternativeLineItem")]
    public LineItemType[] AlternativeLineItem
    {
        get
        {
            return this.alternativeLineItemField;
        }
        set
        {
            this.alternativeLineItemField = value;
        }
    }

    public LineReferenceType RequestLineReference
    {
        get
        {
            return this.requestLineReferenceField;
        }
        set
        {
            this.requestLineReferenceField = value;
        }
    }
}
