using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[GeneratedCode("xsd", "4.0.30319.33440")]
[DebuggerStepThrough]
[DesignerCategory("code")]
[XmlType(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[XmlRoot("CollectedPayment", IsNullable = false, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[Serializable]
public class PaymentType
{
    private IDType idField;
    private PaidAmountType paidAmountField;
    private ReceivedDateType receivedDateField;
    private PaidDateType paidDateField;
    private PaidTimeType paidTimeField;
    private InstructionIDType instructionIDField;

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
    public PaidAmountType PaidAmount
    {
        get
        {
            return this.paidAmountField;
        }
        set
        {
            this.paidAmountField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public ReceivedDateType ReceivedDate
    {
        get
        {
            return this.receivedDateField;
        }
        set
        {
            this.receivedDateField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public PaidDateType PaidDate
    {
        get
        {
            return this.paidDateField;
        }
        set
        {
            this.paidDateField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public PaidTimeType PaidTime
    {
        get
        {
            return this.paidTimeField;
        }
        set
        {
            this.paidTimeField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public InstructionIDType InstructionID
    {
        get
        {
            return this.instructionIDField;
        }
        set
        {
            this.instructionIDField = value;
        }
    }
}
