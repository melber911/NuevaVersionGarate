using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[GeneratedCode("xsd", "4.0.30319.33440")]
[XmlRoot("NotificationRequirement", IsNullable = false, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[DebuggerStepThrough]
[DesignerCategory("code")]
[XmlType(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[Serializable]
public class NotificationRequirementType
{
    private NotificationTypeCodeType notificationTypeCodeField;
    private PostEventNotificationDurationMeasureType postEventNotificationDurationMeasureField;
    private PreEventNotificationDurationMeasureType preEventNotificationDurationMeasureField;
    private PartyType[] notifyPartyField;
    private PeriodType[] notificationPeriodField;
    private LocationType1[] notificationLocationField;

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public NotificationTypeCodeType NotificationTypeCode
    {
        get
        {
            return this.notificationTypeCodeField;
        }
        set
        {
            this.notificationTypeCodeField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public PostEventNotificationDurationMeasureType PostEventNotificationDurationMeasure
    {
        get
        {
            return this.postEventNotificationDurationMeasureField;
        }
        set
        {
            this.postEventNotificationDurationMeasureField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public PreEventNotificationDurationMeasureType PreEventNotificationDurationMeasure
    {
        get
        {
            return this.preEventNotificationDurationMeasureField;
        }
        set
        {
            this.preEventNotificationDurationMeasureField = value;
        }
    }

    [XmlElement("NotifyParty")]
    public PartyType[] NotifyParty
    {
        get
        {
            return this.notifyPartyField;
        }
        set
        {
            this.notifyPartyField = value;
        }
    }

    [XmlElement("NotificationPeriod")]
    public PeriodType[] NotificationPeriod
    {
        get
        {
            return this.notificationPeriodField;
        }
        set
        {
            this.notificationPeriodField = value;
        }
    }

    [XmlElement("NotificationLocation")]
    public LocationType1[] NotificationLocation
    {
        get
        {
            return this.notificationLocationField;
        }
        set
        {
            this.notificationLocationField = value;
        }
    }
}
