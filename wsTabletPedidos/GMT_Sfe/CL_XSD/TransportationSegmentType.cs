using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[XmlRoot("TransportationSegment", IsNullable = false, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[DebuggerStepThrough]
[XmlType(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[GeneratedCode("xsd", "4.0.30319.33440")]
[DesignerCategory("code")]
[Serializable]
public class TransportationSegmentType
{
    private SequenceNumericType sequenceNumericField;
    private TransportExecutionPlanReferenceIDType transportExecutionPlanReferenceIDField;
    private TransportationServiceType transportationServiceField;
    private PartyType transportServiceProviderPartyField;
    private ConsignmentType referencedConsignmentField;
    private ShipmentStageType[] shipmentStageField;

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
    public TransportExecutionPlanReferenceIDType TransportExecutionPlanReferenceID
    {
        get
        {
            return this.transportExecutionPlanReferenceIDField;
        }
        set
        {
            this.transportExecutionPlanReferenceIDField = value;
        }
    }

    public TransportationServiceType TransportationService
    {
        get
        {
            return this.transportationServiceField;
        }
        set
        {
            this.transportationServiceField = value;
        }
    }

    public PartyType TransportServiceProviderParty
    {
        get
        {
            return this.transportServiceProviderPartyField;
        }
        set
        {
            this.transportServiceProviderPartyField = value;
        }
    }

    public ConsignmentType ReferencedConsignment
    {
        get
        {
            return this.referencedConsignmentField;
        }
        set
        {
            this.referencedConsignmentField = value;
        }
    }

    [XmlElement("ShipmentStage")]
    public ShipmentStageType[] ShipmentStage
    {
        get
        {
            return this.shipmentStageField;
        }
        set
        {
            this.shipmentStageField = value;
        }
    }
}
