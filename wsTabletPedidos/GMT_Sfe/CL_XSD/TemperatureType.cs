
// Type: TemperatureType




using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[GeneratedCode("xsd", "4.0.30319.33440")]
[DebuggerStepThrough]
[DesignerCategory("code")]
[XmlType(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[XmlRoot("AdditionalTemperature", IsNullable = false, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[Serializable]
public class TemperatureType
{
  private AttributeIDType attributeIDField;
  private MeasureType2 measureField;
  private DescriptionType[] descriptionField;

  [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
  public AttributeIDType AttributeID
  {
    get
    {
      return this.attributeIDField;
    }
    set
    {
      this.attributeIDField = value;
    }
  }

  [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
  public MeasureType2 Measure
  {
    get
    {
      return this.measureField;
    }
    set
    {
      this.measureField = value;
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
}
