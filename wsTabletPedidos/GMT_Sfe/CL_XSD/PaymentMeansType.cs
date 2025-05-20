using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[DesignerCategory("code")]
[XmlRoot("PaymentMeans", IsNullable = false, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[DebuggerStepThrough]
[XmlType(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[GeneratedCode("xsd", "4.0.30319.33440")]
[Serializable]
public class PaymentMeansType
{
    private IDType idField;
    private PaymentMeansCodeType paymentMeansCodeField;
    private PaymentDueDateType paymentDueDateField;
    private PaymentChannelCodeType paymentChannelCodeField;
    private InstructionIDType instructionIDField;
    private InstructionNoteType[] instructionNoteField;
    private PaymentIDType[] paymentIDField;
    private CardAccountType cardAccountField;
    private FinancialAccountType payerFinancialAccountField;
    private FinancialAccountType payeeFinancialAccountField;
    private CreditAccountType creditAccountField;
    private PaymentMandateType paymentMandateField;
    private TradeFinancingType tradeFinancingField;

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
    public PaymentMeansCodeType PaymentMeansCode
    {
        get
        {
            return this.paymentMeansCodeField;
        }
        set
        {
            this.paymentMeansCodeField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public PaymentDueDateType PaymentDueDate
    {
        get
        {
            return this.paymentDueDateField;
        }
        set
        {
            this.paymentDueDateField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public PaymentChannelCodeType PaymentChannelCode
    {
        get
        {
            return this.paymentChannelCodeField;
        }
        set
        {
            this.paymentChannelCodeField = value;
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

    [XmlElement("InstructionNote", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public InstructionNoteType[] InstructionNote
    {
        get
        {
            return this.instructionNoteField;
        }
        set
        {
            this.instructionNoteField = value;
        }
    }

    [XmlElement("PaymentID", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public PaymentIDType[] PaymentID
    {
        get
        {
            return this.paymentIDField;
        }
        set
        {
            this.paymentIDField = value;
        }
    }

    public CardAccountType CardAccount
    {
        get
        {
            return this.cardAccountField;
        }
        set
        {
            this.cardAccountField = value;
        }
    }

    public FinancialAccountType PayerFinancialAccount
    {
        get
        {
            return this.payerFinancialAccountField;
        }
        set
        {
            this.payerFinancialAccountField = value;
        }
    }

    public FinancialAccountType PayeeFinancialAccount
    {
        get
        {
            return this.payeeFinancialAccountField;
        }
        set
        {
            this.payeeFinancialAccountField = value;
        }
    }

    public CreditAccountType CreditAccount
    {
        get
        {
            return this.creditAccountField;
        }
        set
        {
            this.creditAccountField = value;
        }
    }

    public PaymentMandateType PaymentMandate
    {
        get
        {
            return this.paymentMandateField;
        }
        set
        {
            this.paymentMandateField = value;
        }
    }

    public TradeFinancingType TradeFinancing
    {
        get
        {
            return this.tradeFinancingField;
        }
        set
        {
            this.tradeFinancingField = value;
        }
    }
}
