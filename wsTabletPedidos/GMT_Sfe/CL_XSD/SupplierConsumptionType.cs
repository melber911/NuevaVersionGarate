using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[GeneratedCode("xsd", "4.0.30319.33440")]
[DebuggerStepThrough]
[XmlType(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[DesignerCategory("code")]
[XmlRoot("SupplierConsumption", IsNullable = false, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[Serializable]
public class SupplierConsumptionType
{
    private DescriptionType[] descriptionField;
    private PartyType utilitySupplierPartyField;
    private PartyType utilityCustomerPartyField;
    private ConsumptionType consumptionField;
    private ContractType contractField;
    private ConsumptionLineType[] consumptionLineField;

    [XmlElement("Description", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public DescriptionType[] Description
    {
        get
        {
            return this.descriptionField;
        }
        set
        {
            this.descriptionField = value;
        }
    }

    public PartyType UtilitySupplierParty
    {
        get
        {
            return this.utilitySupplierPartyField;
        }
        set
        {
            this.utilitySupplierPartyField = value;
        }
    }

    public PartyType UtilityCustomerParty
    {
        get
        {
            return this.utilityCustomerPartyField;
        }
        set
        {
            this.utilityCustomerPartyField = value;
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

    public ContractType Contract
    {
        get
        {
            return this.contractField;
        }
        set
        {
            this.contractField = value;
        }
    }

    [XmlElement("ConsumptionLine")]
    public ConsumptionLineType[] ConsumptionLine
    {
        get
        {
            return this.consumptionLineField;
        }
        set
        {
            this.consumptionLineField = value;
        }
    }
}
