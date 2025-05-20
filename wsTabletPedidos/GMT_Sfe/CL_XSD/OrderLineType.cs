using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[DebuggerStepThrough]
[GeneratedCode("xsd", "4.0.30319.33440")]
[XmlType(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[XmlRoot("OrderLine", IsNullable = false, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[DesignerCategory("code")]
[Serializable]
public class OrderLineType
{
    private SubstitutionStatusCodeType substitutionStatusCodeField;
    private NoteType[] noteField;
    private LineItemType lineItemField;
    private LineItemType[] sellerProposedSubstituteLineItemField;
    private LineItemType[] sellerSubstitutedLineItemField;
    private LineItemType[] buyerProposedSubstituteLineItemField;
    private LineReferenceType catalogueLineReferenceField;
    private LineReferenceType quotationLineReferenceField;
    private OrderLineReferenceType[] orderLineReferenceField;
    private DocumentReferenceType[] documentReferenceField;

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public SubstitutionStatusCodeType SubstitutionStatusCode
    {
        get
        {
            return this.substitutionStatusCodeField;
        }
        set
        {
            this.substitutionStatusCodeField = value;
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

    [XmlElement("SellerSubstitutedLineItem")]
    public LineItemType[] SellerSubstitutedLineItem
    {
        get
        {
            return this.sellerSubstitutedLineItemField;
        }
        set
        {
            this.sellerSubstitutedLineItemField = value;
        }
    }

    [XmlElement("BuyerProposedSubstituteLineItem")]
    public LineItemType[] BuyerProposedSubstituteLineItem
    {
        get
        {
            return this.buyerProposedSubstituteLineItemField;
        }
        set
        {
            this.buyerProposedSubstituteLineItemField = value;
        }
    }

    public LineReferenceType CatalogueLineReference
    {
        get
        {
            return this.catalogueLineReferenceField;
        }
        set
        {
            this.catalogueLineReferenceField = value;
        }
    }

    public LineReferenceType QuotationLineReference
    {
        get
        {
            return this.quotationLineReferenceField;
        }
        set
        {
            this.quotationLineReferenceField = value;
        }
    }

    [XmlElement("OrderLineReference")]
    public OrderLineReferenceType[] OrderLineReference
    {
        get
        {
            return this.orderLineReferenceField;
        }
        set
        {
            this.orderLineReferenceField = value;
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
}
