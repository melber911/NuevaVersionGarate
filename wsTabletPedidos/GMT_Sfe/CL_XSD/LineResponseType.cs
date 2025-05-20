
// Type: LineResponseType




using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[DesignerCategory("code")]
[XmlType(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[DebuggerStepThrough]
[XmlRoot("LineResponse", IsNullable = false, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[GeneratedCode("xsd", "4.0.30319.33440")]
[Serializable]
public class LineResponseType
{
  private LineReferenceType lineReferenceField;
  private ResponseType[] responseField;

  public LineReferenceType LineReference
  {
    get
    {
      return this.lineReferenceField;
    }
    set
    {
      this.lineReferenceField = value;
    }
  }

  [XmlElement("Response")]
  public ResponseType[] Response
  {
    get
    {
      return this.responseField;
    }
    set
    {
      this.responseField = value;
    }
  }
}
