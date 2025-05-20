using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[XmlRoot("SUNATPerceptionDocumentReference", IsNullable = false, Namespace = "urn:sunat:names:specification:ubl:peru:schema:xsd:SunatAggregateComponents-1")]
[GeneratedCode("xsd", "4.0.30319.1")]
[DebuggerStepThrough]
[DesignerCategory("code")]
[XmlType(Namespace = "urn:sunat:names:specification:ubl:peru:schema:xsd:SunatAggregateComponents-1")]
[Serializable]
public class SUNATPerceptionDocumentReferenceType
{
    private IDType idField;
    private IssueDateType issueDateField;
    private TotalInvoiceAmountType totalInvoiceAmountField;
    private PaymentType paymentField;
    private SUNATPerceptionInformationType sUNATPerceptionInformationField;

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
    public SUNATPerceptionInformationType SUNATPerceptionInformation
    {
        get
        {
            return this.sUNATPerceptionInformationField;
        }
        set
        {
            this.sUNATPerceptionInformationField = value;
        }
    }
}
