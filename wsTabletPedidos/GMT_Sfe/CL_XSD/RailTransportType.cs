using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[GeneratedCode("xsd", "4.0.30319.33440")]
[DesignerCategory("code")]
[XmlType(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[DebuggerStepThrough]
[XmlRoot("RailTransport", IsNullable = false, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[Serializable]
public class RailTransportType
{
    private TrainIDType trainIDField;
    private RailCarIDType railCarIDField;

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public TrainIDType TrainID
    {
        get
        {
            return this.trainIDField;
        }
        set
        {
            this.trainIDField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public RailCarIDType RailCarID
    {
        get
        {
            return this.railCarIDField;
        }
        set
        {
            this.railCarIDField = value;
        }
    }
}
