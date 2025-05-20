
// Type: MeterPropertyType




using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[XmlType(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[XmlRoot("MeterProperty", IsNullable = false, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[GeneratedCode("xsd", "4.0.30319.33440")]
[DebuggerStepThrough]
[DesignerCategory("code")]
[Serializable]
public class MeterPropertyType
{
  private NameType1 nameField;
  private NameCodeType nameCodeField;
  private ValueType valueField;
  private ValueQuantityType valueQuantityField;
  private ValueQualifierType[] valueQualifierField;

  [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
  public NameType1 Name
  {
    get
    {
      return this.nameField;
    }
    set
    {
      this.nameField = value;
    }
  }

  [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
  public NameCodeType NameCode
  {
    get
    {
      return this.nameCodeField;
    }
    set
    {
      this.nameCodeField = value;
    }
  }

  [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
  public ValueType Value
  {
    get
    {
      return this.valueField;
    }
    set
    {
      this.valueField = value;
    }
  }

  [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
  public ValueQuantityType ValueQuantity
  {
    get
    {
      return this.valueQuantityField;
    }
    set
    {
      this.valueQuantityField = value;
    }
  }

  [XmlElement("ValueQualifier", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
  public ValueQualifierType[] ValueQualifier
  {
    get
    {
      return this.valueQualifierField;
    }
    set
    {
      this.valueQualifierField = value;
    }
  }
}
