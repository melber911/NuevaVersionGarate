using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[DebuggerStepThrough]
[DesignerCategory("code")]
[XmlType(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[XmlRoot("SubscriberConsumption", IsNullable = false, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[GeneratedCode("xsd", "4.0.30319.33440")]
[Serializable]
public class SubscriberConsumptionType
{
    private ConsumptionIDType consumptionIDField;
    private SpecificationTypeCodeType specificationTypeCodeField;
    private NoteType[] noteField;
    private TotalMeteredQuantityType totalMeteredQuantityField;
    private PartyType subscriberPartyField;
    private ConsumptionPointType utilityConsumptionPointField;
    private OnAccountPaymentType[] onAccountPaymentField;
    private ConsumptionType consumptionField;
    private SupplierConsumptionType[] supplierConsumptionField;

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public ConsumptionIDType ConsumptionID
    {
        get
        {
            return this.consumptionIDField;
        }
        set
        {
            this.consumptionIDField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public SpecificationTypeCodeType SpecificationTypeCode
    {
        get
        {
            return this.specificationTypeCodeField;
        }
        set
        {
            this.specificationTypeCodeField = value;
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
    public TotalMeteredQuantityType TotalMeteredQuantity
    {
        get
        {
            return this.totalMeteredQuantityField;
        }
        set
        {
            this.totalMeteredQuantityField = value;
        }
    }

    public PartyType SubscriberParty
    {
        get
        {
            return this.subscriberPartyField;
        }
        set
        {
            this.subscriberPartyField = value;
        }
    }

    public ConsumptionPointType UtilityConsumptionPoint
    {
        get
        {
            return this.utilityConsumptionPointField;
        }
        set
        {
            this.utilityConsumptionPointField = value;
        }
    }

    [XmlElement("OnAccountPayment")]
    public OnAccountPaymentType[] OnAccountPayment
    {
        get
        {
            return this.onAccountPaymentField;
        }
        set
        {
            this.onAccountPaymentField = value;
        }
    }

    public ConsumptionType Consumption
    {
        get
        {
            return this.consumptionField;
        }
        set
        {
            this.consumptionField = value;
        }
    }

    [XmlElement("SupplierConsumption")]
    public SupplierConsumptionType[] SupplierConsumption
    {
        get
        {
            return this.supplierConsumptionField;
        }
        set
        {
            this.supplierConsumptionField = value;
        }
    }
}
