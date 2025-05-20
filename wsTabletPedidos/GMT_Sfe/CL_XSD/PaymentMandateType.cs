using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[XmlRoot("PaymentMandate", IsNullable = false, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[XmlType(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[DesignerCategory("code")]
[GeneratedCode("xsd", "4.0.30319.33440")]
[DebuggerStepThrough]
[Serializable]
public class PaymentMandateType
{
    private IDType idField;
    private MandateTypeCodeType mandateTypeCodeField;
    private MaximumPaymentInstructionsNumericType maximumPaymentInstructionsNumericField;
    private MaximumPaidAmountType maximumPaidAmountField;
    private SignatureIDType signatureIDField;
    private PartyType payerPartyField;
    private FinancialAccountType payerFinancialAccountField;
    private PeriodType validityPeriodField;
    private PeriodType paymentReversalPeriodField;
    private ClauseType[] clauseField;

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
    public MandateTypeCodeType MandateTypeCode
    {
        get
        {
            return this.mandateTypeCodeField;
        }
        set
        {
            this.mandateTypeCodeField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public MaximumPaymentInstructionsNumericType MaximumPaymentInstructionsNumeric
    {
        get
        {
            return this.maximumPaymentInstructionsNumericField;
        }
        set
        {
            this.maximumPaymentInstructionsNumericField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public MaximumPaidAmountType MaximumPaidAmount
    {
        get
        {
            return this.maximumPaidAmountField;
        }
        set
        {
            this.maximumPaidAmountField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public SignatureIDType SignatureID
    {
        get
        {
            return this.signatureIDField;
        }
        set
        {
            this.signatureIDField = value;
        }
    }

    public PartyType PayerParty
    {
        get
        {
            return this.payerPartyField;
        }
        set
        {
            this.payerPartyField = value;
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

    public PeriodType ValidityPeriod
    {
        get
        {
            return this.validityPeriodField;
        }
        set
        {
            this.validityPeriodField = value;
        }
    }

    public PeriodType PaymentReversalPeriod
    {
        get
        {
            return this.paymentReversalPeriodField;
        }
        set
        {
            this.paymentReversalPeriodField = value;
        }
    }

    [XmlElement("Clause")]
    public ClauseType[] Clause
    {
        get
        {
            return this.clauseField;
        }
        set
        {
            this.clauseField = value;
        }
    }
}
