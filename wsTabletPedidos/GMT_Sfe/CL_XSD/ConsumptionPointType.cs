using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[DebuggerStepThrough]
[DesignerCategory("code")]
[XmlType(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[GeneratedCode("xsd", "4.0.30319.33440")]
[XmlRoot("ConsumptionPoint", IsNullable = false, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[Serializable]
public class ConsumptionPointType
{
    private IDType idField;
    private DescriptionType[] descriptionField;
    private SubscriberIDType subscriberIDField;
    private SubscriberTypeType subscriberTypeField;
    private SubscriberTypeCodeType subscriberTypeCodeField;
    private TotalDeliveredQuantityType totalDeliveredQuantityField;
    private AddressType addressField;
    private WebSiteAccessType webSiteAccessField;
    private MeterType[] utilityMeterField;

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

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public SubscriberIDType SubscriberID
    {
        get
        {
            return this.subscriberIDField;
        }
        set
        {
            this.subscriberIDField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public SubscriberTypeType SubscriberType
    {
        get
        {
            return this.subscriberTypeField;
        }
        set
        {
            this.subscriberTypeField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public SubscriberTypeCodeType SubscriberTypeCode
    {
        get
        {
            return this.subscriberTypeCodeField;
        }
        set
        {
            this.subscriberTypeCodeField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public TotalDeliveredQuantityType TotalDeliveredQuantity
    {
        get
        {
            return this.totalDeliveredQuantityField;
        }
        set
        {
            this.totalDeliveredQuantityField = value;
        }
    }

    public AddressType Address
    {
        get
        {
            return this.addressField;
        }
        set
        {
            this.addressField = value;
        }
    }

    public WebSiteAccessType WebSiteAccess
    {
        get
        {
            return this.webSiteAccessField;
        }
        set
        {
            this.webSiteAccessField = value;
        }
    }

    [XmlElement("UtilityMeter")]
    public MeterType[] UtilityMeter
    {
        get
        {
            return this.utilityMeterField;
        }
        set
        {
            this.utilityMeterField = value;
        }
    }
}
