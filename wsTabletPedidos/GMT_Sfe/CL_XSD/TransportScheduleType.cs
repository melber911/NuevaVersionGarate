using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[GeneratedCode("xsd", "4.0.30319.33440")]
[XmlRoot("TransportSchedule", IsNullable = false, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[DebuggerStepThrough]
[DesignerCategory("code")]
[XmlType(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[Serializable]
public class TransportScheduleType
{
    private SequenceNumericType sequenceNumericField;
    private ReferenceDateType referenceDateField;
    private ReferenceTimeType referenceTimeField;
    private ReliabilityPercentType reliabilityPercentField;
    private RemarksType[] remarksField;
    private LocationType1 statusLocationField;
    private TransportEventType actualArrivalTransportEventField;
    private TransportEventType actualDepartureTransportEventField;
    private TransportEventType estimatedDepartureTransportEventField;
    private TransportEventType estimatedArrivalTransportEventField;
    private TransportEventType plannedDepartureTransportEventField;
    private TransportEventType plannedArrivalTransportEventField;

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public SequenceNumericType SequenceNumeric
    {
        get
        {
            return this.sequenceNumericField;
        }
        set
        {
            this.sequenceNumericField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public ReferenceDateType ReferenceDate
    {
        get
        {
            return this.referenceDateField;
        }
        set
        {
            this.referenceDateField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public ReferenceTimeType ReferenceTime
    {
        get
        {
            return this.referenceTimeField;
        }
        set
        {
            this.referenceTimeField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public ReliabilityPercentType ReliabilityPercent
    {
        get
        {
            return this.reliabilityPercentField;
        }
        set
        {
            this.reliabilityPercentField = value;
        }
    }

    [XmlElement("Remarks", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public RemarksType[] Remarks
    {
        get
        {
            return this.remarksField;
        }
        set
        {
            this.remarksField = value;
        }
    }

    public LocationType1 StatusLocation
    {
        get
        {
            return this.statusLocationField;
        }
        set
        {
            this.statusLocationField = value;
        }
    }

    public TransportEventType ActualArrivalTransportEvent
    {
        get
        {
            return this.actualArrivalTransportEventField;
        }
        set
        {
            this.actualArrivalTransportEventField = value;
        }
    }

    public TransportEventType ActualDepartureTransportEvent
    {
        get
        {
            return this.actualDepartureTransportEventField;
        }
        set
        {
            this.actualDepartureTransportEventField = value;
        }
    }

    public TransportEventType EstimatedDepartureTransportEvent
    {
        get
        {
            return this.estimatedDepartureTransportEventField;
        }
        set
        {
            this.estimatedDepartureTransportEventField = value;
        }
    }

    public TransportEventType EstimatedArrivalTransportEvent
    {
        get
        {
            return this.estimatedArrivalTransportEventField;
        }
        set
        {
            this.estimatedArrivalTransportEventField = value;
        }
    }

    public TransportEventType PlannedDepartureTransportEvent
    {
        get
        {
            return this.plannedDepartureTransportEventField;
        }
        set
        {
            this.plannedDepartureTransportEventField = value;
        }
    }

    public TransportEventType PlannedArrivalTransportEvent
    {
        get
        {
            return this.plannedArrivalTransportEventField;
        }
        set
        {
            this.plannedArrivalTransportEventField = value;
        }
    }
}
