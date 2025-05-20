using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[XmlRoot("Meter", IsNullable = false, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[GeneratedCode("xsd", "4.0.30319.33440")]
[DebuggerStepThrough]
[DesignerCategory("code")]
[XmlType(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[Serializable]
public class MeterType
{
    private MeterNumberType meterNumberField;
    private MeterNameType meterNameField;
    private MeterConstantType meterConstantField;
    private MeterConstantCodeType meterConstantCodeField;
    private TotalDeliveredQuantityType totalDeliveredQuantityField;
    private MeterReadingType[] meterReadingField;
    private MeterPropertyType[] meterPropertyField;

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public MeterNumberType MeterNumber
    {
        get
        {
            return this.meterNumberField;
        }
        set
        {
            this.meterNumberField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public MeterNameType MeterName
    {
        get
        {
            return this.meterNameField;
        }
        set
        {
            this.meterNameField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public MeterConstantType MeterConstant
    {
        get
        {
            return this.meterConstantField;
        }
        set
        {
            this.meterConstantField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public MeterConstantCodeType MeterConstantCode
    {
        get
        {
            return this.meterConstantCodeField;
        }
        set
        {
            this.meterConstantCodeField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public TotalDeliveredQuantityType TotalDeliveredQuantity
    {
        get
        {
            return this.totalDeliveredQuantityField;
        }
        set
        {
            this.totalDeliveredQuantityField = value;
        }
    }

    [XmlElement("MeterReading")]
    public MeterReadingType[] MeterReading
    {
        get
        {
            return this.meterReadingField;
        }
        set
        {
            this.meterReadingField = value;
        }
    }

    [XmlElement("MeterProperty")]
    public MeterPropertyType[] MeterProperty
    {
        get
        {
            return this.meterPropertyField;
        }
        set
        {
            this.meterPropertyField = value;
        }
    }
}
