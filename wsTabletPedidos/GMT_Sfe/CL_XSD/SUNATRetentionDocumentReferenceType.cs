using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[DebuggerStepThrough]
[XmlType(Namespace = "urn:sunat:names:specification:ubl:peru:schema:xsd:SunatAggregateComponents-1")]
[XmlRoot("SUNATRetentionDocumentReference", IsNullable = false, Namespace = "urn:sunat:names:specification:ubl:peru:schema:xsd:SunatAggregateComponents-1")]
[DesignerCategory("code")]
[GeneratedCode("xsd", "4.0.30319.1")]
[Serializable]
public class SUNATRetentionDocumentReferenceType
{
    private IDType idField;
    private IssueDateType issueDateField;
    private TotalInvoiceAmountType totalInvoiceAmountField;
    private PaymentType paymentField;
    private SUNATRetentionInformationType sUNATRetentionInformationField;

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
    public TotalInvoiceAmountType TotalInvoiceAmount
    {
        get
        {
            return this.totalInvoiceAmountField;
        }
        set
        {
            this.totalInvoiceAmountField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
    public PaymentType Payment
    {
        get
        {
            return this.paymentField;
        }
        set
        {
            this.paymentField = value;
        }
    }

    [XmlElement(Namespace = "urn:sunat:names:specification:ubl:peru:schema:xsd:SunatAggregateComponents-1")]
    public SUNATRetentionInformationType SUNATRetentionInformation
    {
        get
        {
            return this.sUNATRetentionInformationField;
        }
        set
        {
            this.sUNATRetentionInformationField = value;
        }
    }
}
