using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[XmlRoot("MainOnAccountPayment", IsNullable = false, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[XmlType(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[DebuggerStepThrough]
[DesignerCategory("code")]
[GeneratedCode("xsd", "4.0.30319.33440")]
[Serializable]
public class OnAccountPaymentType
{
    private EstimatedConsumedQuantityType estimatedConsumedQuantityField;
    private NoteType[] noteField;
    private PaymentTermsType[] paymentTermsField;

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public EstimatedConsumedQuantityType EstimatedConsumedQuantity
    {
        get
        {
            return this.estimatedConsumedQuantityField;
        }
        set
        {
            this.estimatedConsumedQuantityField = value;
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

    [XmlElement("PaymentTerms")]
    public PaymentTermsType[] PaymentTerms
    {
        get
        {
            return this.paymentTermsField;
        }
        set
        {
            this.paymentTermsField = value;
        }
    }
}
