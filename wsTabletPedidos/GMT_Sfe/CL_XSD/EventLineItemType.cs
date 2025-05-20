using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[GeneratedCode("xsd", "4.0.30319.33440")]
[XmlRoot("EventLineItem", IsNullable = false, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[DebuggerStepThrough]
[XmlType(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[DesignerCategory("code")]
[Serializable]
public class EventLineItemType
{
    private LineNumberNumericType lineNumberNumericField;
    private LocationType1 participatingLocationsLocationField;
    private RetailPlannedImpactType[] retailPlannedImpactField;
    private ItemType supplyItemField;

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public LineNumberNumericType LineNumberNumeric
    {
        get
        {
            return this.lineNumberNumericField;
        }
        set
        {
            this.lineNumberNumericField = value;
        }
    }

    public LocationType1 ParticipatingLocationsLocation
    {
        get
        {
            return this.participatingLocationsLocationField;
        }
        set
        {
            this.participatingLocationsLocationField = value;
        }
    }

    [XmlElement("RetailPlannedImpact")]
    public RetailPlannedImpactType[] RetailPlannedImpact
    {
        get
        {
            return this.retailPlannedImpactField;
        }
        set
        {
            this.retailPlannedImpactField = value;
        }
    }

    public ItemType SupplyItem
    {
        get
        {
            return this.supplyItemField;
        }
        set
        {
            this.supplyItemField = value;
        }
    }
}
