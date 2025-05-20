using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[DebuggerStepThrough]
[GeneratedCode("xsd", "4.0.30319.33440")]
[XmlType(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[XmlRoot("TransportExecutionTerms", IsNullable = false, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[DesignerCategory("code")]
[Serializable]
public class TransportExecutionTermsType
{
    private TransportUserSpecialTermsType[] transportUserSpecialTermsField;
    private TransportServiceProviderSpecialTermsType[] transportServiceProviderSpecialTermsField;
    private ChangeConditionsType[] changeConditionsField;
    private PaymentTermsType[] paymentTermsField;
    private DeliveryTermsType[] deliveryTermsField;
    private PaymentTermsType bonusPaymentTermsField;
    private PaymentTermsType commissionPaymentTermsField;
    private PaymentTermsType penaltyPaymentTermsField;
    private EnvironmentalEmissionType[] environmentalEmissionField;
    private NotificationRequirementType[] notificationRequirementField;
    private PaymentTermsType serviceChargePaymentTermsField;

    [XmlElement("TransportUserSpecialTerms", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public TransportUserSpecialTermsType[] TransportUserSpecialTerms
    {
        get
        {
            return this.transportUserSpecialTermsField;
        }
        set
        {
            this.transportUserSpecialTermsField = value;
        }
    }

    [XmlElement("TransportServiceProviderSpecialTerms", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public TransportServiceProviderSpecialTermsType[] TransportServiceProviderSpecialTerms
    {
        get
        {
            return this.transportServiceProviderSpecialTermsField;
        }
        set
        {
            this.transportServiceProviderSpecialTermsField = value;
        }
    }

    [XmlElement("ChangeConditions", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public ChangeConditionsType[] ChangeConditions
    {
        get
        {
            return this.changeConditionsField;
        }
        set
        {
            this.changeConditionsField = value;
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

    [XmlElement("DeliveryTerms")]
    public DeliveryTermsType[] DeliveryTerms
    {
        get
        {
            return this.deliveryTermsField;
        }
        set
        {
            this.deliveryTermsField = value;
        }
    }

    public PaymentTermsType BonusPaymentTerms
    {
        get
        {
            return this.bonusPaymentTermsField;
        }
        set
        {
            this.bonusPaymentTermsField = value;
        }
    }

    public PaymentTermsType CommissionPaymentTerms
    {
        get
        {
            return this.commissionPaymentTermsField;
        }
        set
        {
            this.commissionPaymentTermsField = value;
        }
    }

    public PaymentTermsType PenaltyPaymentTerms
    {
        get
        {
            return this.penaltyPaymentTermsField;
        }
        set
        {
            this.penaltyPaymentTermsField = value;
        }
    }

    [XmlElement("EnvironmentalEmission")]
    public EnvironmentalEmissionType[] EnvironmentalEmission
    {
        get
        {
            return this.environmentalEmissionField;
        }
        set
        {
            this.environmentalEmissionField = value;
        }
    }

    [XmlElement("NotificationRequirement")]
    public NotificationRequirementType[] NotificationRequirement
    {
        get
        {
            return this.notificationRequirementField;
        }
        set
        {
            this.notificationRequirementField = value;
        }
    }

    public PaymentTermsType ServiceChargePaymentTerms
    {
        get
        {
            return this.serviceChargePaymentTermsField;
        }
        set
        {
            this.serviceChargePaymentTermsField = value;
        }
    }
}
