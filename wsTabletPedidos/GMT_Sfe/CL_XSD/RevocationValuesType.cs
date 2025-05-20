using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[XmlRoot("RevocationValues", IsNullable = false, Namespace = "http://uri.etsi.org/01903/v1.3.2#")]
[DebuggerStepThrough]
[XmlType(Namespace = "http://uri.etsi.org/01903/v1.3.2#")]
[GeneratedCode("xsd", "4.0.30319.33440")]
[DesignerCategory("code")]
[Serializable]
public class RevocationValuesType
{
    private EncapsulatedPKIDataType[] cRLValuesField;
    private EncapsulatedPKIDataType[] oCSPValuesField;
    private AnyType[] otherValuesField;
    private string idField;

    [XmlArrayItem("EncapsulatedCRLValue", IsNullable = false)]
    public EncapsulatedPKIDataType[] CRLValues
    {
        get
        {
            return this.cRLValuesField;
        }
        set
        {
            this.cRLValuesField = value;
        }
    }

    [XmlArrayItem("EncapsulatedOCSPValue", IsNullable = false)]
    public EncapsulatedPKIDataType[] OCSPValues
    {
        get
        {
            return this.oCSPValuesField;
        }
        set
        {
            this.oCSPValuesField = value;
        }
    }

    [XmlArrayItem("OtherValue", IsNullable = false)]
    public AnyType[] OtherValues
    {
        get
        {
            return this.otherValuesField;
        }
        set
        {
            this.otherValuesField = value;
        }
    }

    [XmlAttribute(DataType = "ID")]
    public string Id
    {
        get
        {
            return this.idField;
        }
        set
        {
            this.idField = value;
        }
    }
}
