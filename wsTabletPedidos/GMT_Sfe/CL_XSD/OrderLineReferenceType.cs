using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[DebuggerStepThrough]
[XmlRoot("OrderLineReference", IsNullable = false, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[XmlType(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[DesignerCategory("code")]
[GeneratedCode("xsd", "4.0.30319.33440")]
[Serializable]
public class OrderLineReferenceType
{
    private LineIDType lineIDField;
    private SalesOrderLineIDType salesOrderLineIDField;
    private UUIDType uUIDField;
    private LineStatusCodeType lineStatusCodeField;
    private OrderReferenceType orderReferenceField;

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public LineIDType LineID
    {
        get
        {
            return this.lineIDField;
        }
        set
        {
            this.lineIDField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public SalesOrderLineIDType SalesOrderLineID
    {
        get
        {
            return this.salesOrderLineIDField;
        }
        set
        {
            this.salesOrderLineIDField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public UUIDType UUID
    {
        get
        {
            return this.uUIDField;
        }
        set
        {
            this.uUIDField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public LineStatusCodeType LineStatusCode
    {
        get
        {
            return this.lineStatusCodeField;
        }
        set
        {
            this.lineStatusCodeField = value;
        }
    }

    public OrderReferenceType OrderReference
    {
        get
        {
            return this.orderReferenceField;
        }
        set
        {
            this.orderReferenceField = value;
        }
    }
}
