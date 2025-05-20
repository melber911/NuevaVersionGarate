
// Type: TransportEventType




using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[XmlRoot("AcceptanceTransportEvent", IsNullable = false, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[DesignerCategory("code")]
[XmlType(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[DebuggerStepThrough]
[GeneratedCode("xsd", "4.0.30319.33440")]
[Serializable]
public class TransportEventType
{
    private IdentificationIDType identificationIDField;
    private OccurrenceDateType occurrenceDateField;
    private OccurrenceTimeType occurrenceTimeField;
    private TransportEventTypeCodeType transportEventTypeCodeField;
    private DescriptionType[] descriptionField;
    private CompletionIndicatorType completionIndicatorField;
    private ShipmentType reportedShipmentField;
    private StatusType[] currentStatusField;
    private ContactType[] contactField;
    private LocationType1 locationField;
    private SignatureType signatureField;
    private PeriodType[] periodField;

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public IdentificationIDType IdentificationID
    {
        get
        {
            return this.identificationIDField;
        }
        set
        {
            this.identificationIDField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public OccurrenceDateType OccurrenceDate
    {
        get
        {
            return this.occurrenceDateField;
        }
        set
        {
            this.occurrenceDateField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public OccurrenceTimeType OccurrenceTime
    {
        get
        {
            return this.occurrenceTimeField;
        }
        set
        {
            this.occurrenceTimeField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public TransportEventTypeCodeType TransportEventTypeCode
    {
        get
        {
            return this.transportEventTypeCodeField;
        }
        set
        {
            this.transportEventTypeCodeField = value;
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
    public CompletionIndicatorType CompletionIndicator
    {
        get
        {
            return this.completionIndicatorField;
        }
        set
        {
            this.completionIndicatorField = value;
        }
    }

    public ShipmentType ReportedShipment
    {
        get
        {
            return this.reportedShipmentField;
        }
        set
        {
            this.reportedShipmentField = value;
        }
    }

    [XmlElement("CurrentStatus")]
    public StatusType[] CurrentStatus
    {
        get
        {
            return this.currentStatusField;
        }
        set
        {
            this.currentStatusField = value;
        }
    }

    [XmlElement("Contact")]
    public ContactType[] Contact
    {
        get
        {
            return this.contactField;
        }
        set
        {
            this.contactField = value;
        }
    }

    public LocationType1 Location
    {
        get
        {
            return this.locationField;
        }
        set
        {
            this.locationField = value;
        }
    }

    public SignatureType Signature
    {
        get
        {
            return this.signatureField;
        }
        set
        {
            this.signatureField = value;
        }
    }

    [XmlElement("Period")]
    public PeriodType[] Period
    {
        get
        {
            return this.periodField;
        }
        set
        {
            this.periodField = value;
        }
    }
}
