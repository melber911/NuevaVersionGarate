
// Type: OrderedShipmentType




using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[DebuggerStepThrough]
[XmlRoot("OrderedShipment", IsNullable = false, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[DesignerCategory("code")]
[XmlType(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[GeneratedCode("xsd", "4.0.30319.33440")]
[Serializable]
public class OrderedShipmentType
{
  private ShipmentType shipmentField;
  private PackageType[] packageField;

  public ShipmentType Shipment
  {
    get
    {
      return this.shipmentField;
    }
    set
    {
      this.shipmentField = value;
    }
  }

  [XmlElement("Package")]
  public PackageType[] Package
  {
    get
    {
      return this.packageField;
    }
    set
    {
      this.packageField = value;
    }
  }
}
