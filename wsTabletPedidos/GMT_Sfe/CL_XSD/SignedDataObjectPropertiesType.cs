using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[XmlRoot("SignedDataObjectProperties", IsNullable = false, Namespace = "http://uri.etsi.org/01903/v1.3.2#")]
[DebuggerStepThrough]
[XmlType(Namespace = "http://uri.etsi.org/01903/v1.3.2#")]
[GeneratedCode("xsd", "4.0.30319.33440")]
[DesignerCategory("code")]
[Serializable]
public class SignedDataObjectPropertiesType
{
    private DataObjectFormatType[] dataObjectFormatField;
    private CommitmentTypeIndicationType[] commitmentTypeIndicationField;
    private XAdESTimeStampType[] allDataObjectsTimeStampField;
    private XAdESTimeStampType[] individualDataObjectsTimeStampField;
    private string idField;

    [XmlElement("DataObjectFormat")]
    public DataObjectFormatType[] DataObjectFormat
    {
        get
        {
            return this.dataObjectFormatField;
        }
        set
        {
            this.dataObjectFormatField = value;
        }
    }

    [XmlElement("CommitmentTypeIndication")]
    public CommitmentTypeIndicationType[] CommitmentTypeIndication
    {
        get
        {
            return this.commitmentTypeIndicationField;
        }
        set
        {
            this.commitmentTypeIndicationField = value;
        }
    }

    [XmlElement("AllDataObjectsTimeStamp")]
    public XAdESTimeStampType[] AllDataObjectsTimeStamp
    {
        get
        {
            return this.allDataObjectsTimeStampField;
        }
        set
        {
            this.allDataObjectsTimeStampField = value;
        }
    }

    [XmlElement("IndividualDataObjectsTimeStamp")]
    public XAdESTimeStampType[] IndividualDataObjectsTimeStamp
    {
        get
        {
            return this.individualDataObjectsTimeStampField;
        }
        set
        {
            this.individualDataObjectsTimeStampField = value;
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
