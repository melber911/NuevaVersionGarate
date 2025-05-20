using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[XmlType(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[XmlRoot("MeterReading", IsNullable = false, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[GeneratedCode("xsd", "4.0.30319.33440")]
[DebuggerStepThrough]
[DesignerCategory("code")]
[Serializable]
public class MeterReadingType
{
    private IDType idField;
    private MeterReadingTypeType meterReadingType1Field;
    private MeterReadingTypeCodeType meterReadingTypeCodeField;
    private PreviousMeterReadingDateType previousMeterReadingDateField;
    private PreviousMeterQuantityType previousMeterQuantityField;
    private LatestMeterReadingDateType latestMeterReadingDateField;
    private LatestMeterQuantityType latestMeterQuantityField;
    private PreviousMeterReadingMethodType previousMeterReadingMethodField;
    private PreviousMeterReadingMethodCodeType previousMeterReadingMethodCodeField;
    private LatestMeterReadingMethodType latestMeterReadingMethodField;
    private LatestMeterReadingMethodCodeType latestMeterReadingMethodCodeField;
    private MeterReadingCommentsType[] meterReadingCommentsField;
    private DeliveredQuantityType deliveredQuantityField;

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public IDType ID
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

    [XmlElement("MeterReadingType", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public MeterReadingTypeType MeterReadingType1
    {
        get
        {
            return this.meterReadingType1Field;
        }
        set
        {
            this.meterReadingType1Field = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public MeterReadingTypeCodeType MeterReadingTypeCode
    {
        get
        {
            return this.meterReadingTypeCodeField;
        }
        set
        {
            this.meterReadingTypeCodeField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public PreviousMeterReadingDateType PreviousMeterReadingDate
    {
        get
        {
            return this.previousMeterReadingDateField;
        }
        set
        {
            this.previousMeterReadingDateField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public PreviousMeterQuantityType PreviousMeterQuantity
    {
        get
        {
            return this.previousMeterQuantityField;
        }
        set
        {
            this.previousMeterQuantityField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public LatestMeterReadingDateType LatestMeterReadingDate
    {
        get
        {
            return this.latestMeterReadingDateField;
        }
        set
        {
            this.latestMeterReadingDateField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public LatestMeterQuantityType LatestMeterQuantity
    {
        get
        {
            return this.latestMeterQuantityField;
        }
        set
        {
            this.latestMeterQuantityField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public PreviousMeterReadingMethodType PreviousMeterReadingMethod
    {
        get
        {
            return this.previousMeterReadingMethodField;
        }
        set
        {
            this.previousMeterReadingMethodField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public PreviousMeterReadingMethodCodeType PreviousMeterReadingMethodCode
    {
        get
        {
            return this.previousMeterReadingMethodCodeField;
        }
        set
        {
            this.previousMeterReadingMethodCodeField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public LatestMeterReadingMethodType LatestMeterReadingMethod
    {
        get
        {
            return this.latestMeterReadingMethodField;
        }
        set
        {
            this.latestMeterReadingMethodField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public LatestMeterReadingMethodCodeType LatestMeterReadingMethodCode
    {
        get
        {
            return this.latestMeterReadingMethodCodeField;
        }
        set
        {
            this.latestMeterReadingMethodCodeField = value;
        }
    }

    [XmlElement("MeterReadingComments", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public MeterReadingCommentsType[] MeterReadingComments
    {
        get
        {
            return this.meterReadingCommentsField;
        }
        set
        {
            this.meterReadingCommentsField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public DeliveredQuantityType DeliveredQuantity
    {
        get
        {
            return this.deliveredQuantityField;
        }
        set
        {
            this.deliveredQuantityField = value;
        }
    }
}
