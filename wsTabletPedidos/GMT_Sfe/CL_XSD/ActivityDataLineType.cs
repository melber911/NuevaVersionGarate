using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[DebuggerStepThrough]
[GeneratedCode("xsd", "4.0.30319.33440")]
[DesignerCategory("code")]
[XmlType(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[XmlRoot("ActivityDataLine", IsNullable = false, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[Serializable]
public class ActivityDataLineType
{
    private IDType idField;
    private SupplyChainActivityTypeCodeType supplyChainActivityTypeCodeField;
    private CustomerPartyType buyerCustomerPartyField;
    private SupplierPartyType sellerSupplierPartyField;
    private PeriodType activityPeriodField;
    private LocationType1 activityOriginLocationField;
    private LocationType1 activityFinalLocationField;
    private SalesItemType[] salesItemField;

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
    public SupplyChainActivityTypeCodeType SupplyChainActivityTypeCode
    {
        get
        {
            return this.supplyChainActivityTypeCodeField;
        }
        set
        {
            this.supplyChainActivityTypeCodeField = value;
        }
    }

    public CustomerPartyType BuyerCustomerParty
    {
        get
        {
            return this.buyerCustomerPartyField;
        }
        set
        {
            this.buyerCustomerPartyField = value;
        }
    }

    public SupplierPartyType SellerSupplierParty
    {
        get
        {
            return this.sellerSupplierPartyField;
        }
        set
        {
            this.sellerSupplierPartyField = value;
        }
    }

    public PeriodType ActivityPeriod
    {
        get
        {
            return this.activityPeriodField;
        }
        set
        {
            this.activityPeriodField = value;
        }
    }

    public LocationType1 ActivityOriginLocation
    {
        get
        {
            return this.activityOriginLocationField;
        }
        set
        {
            this.activityOriginLocationField = value;
        }
    }

    public LocationType1 ActivityFinalLocation
    {
        get
        {
            return this.activityFinalLocationField;
        }
        set
        {
            this.activityFinalLocationField = value;
        }
    }

    [XmlElement("SalesItem")]
    public SalesItemType[] SalesItem
    {
        get
        {
            return this.salesItemField;
        }
        set
        {
            this.salesItemField = value;
        }
    }
}
