using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[XmlRoot("Event", IsNullable = false, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[DebuggerStepThrough]
[GeneratedCode("xsd", "4.0.30319.33440")]
[DesignerCategory("code")]
[XmlType(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[Serializable]
public class EventType
{
    private IdentificationIDType identificationIDField;
    private OccurrenceDateType occurrenceDateField;
    private OccurrenceTimeType occurrenceTimeField;
    private TypeCodeType typeCodeField;
    private DescriptionType[] descriptionField;
    private CompletionIndicatorType completionIndicatorField;
    private StatusType[] currentStatusField;
    private ContactType[] contactField;
    private LocationType1 occurenceLocationField;

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
    public TypeCodeType TypeCode
    {
        get
        {
            return this.typeCodeField;
        }
        set
        {
            this.typeCodeField = value;
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

    public LocationType1 OccurenceLocation
    {
        get
        {
            return this.occurenceLocationField;
        }
        set
        {
            this.occurenceLocationField = value;
        }
    }
}
