using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[DebuggerStepThrough]
[GeneratedCode("xsd", "4.0.30319.33440")]
[DesignerCategory("code")]
[XmlRoot("ItemInstance", IsNullable = false, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[XmlType(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[Serializable]
public class ItemInstanceType
{
    private ProductTraceIDType productTraceIDField;
    private ManufactureDateType manufactureDateField;
    private ManufactureTimeType manufactureTimeField;
    private BestBeforeDateType bestBeforeDateField;
    private RegistrationIDType registrationIDField;
    private SerialIDType serialIDField;
    private ItemPropertyType[] additionalItemPropertyField;
    private LotIdentificationType lotIdentificationField;

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public ProductTraceIDType ProductTraceID
    {
        get
        {
            return this.productTraceIDField;
        }
        set
        {
            this.productTraceIDField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public ManufactureDateType ManufactureDate
    {
        get
        {
            return this.manufactureDateField;
        }
        set
        {
            this.manufactureDateField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public ManufactureTimeType ManufactureTime
    {
        get
        {
            return this.manufactureTimeField;
        }
        set
        {
            this.manufactureTimeField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public BestBeforeDateType BestBeforeDate
    {
        get
        {
            return this.bestBeforeDateField;
        }
        set
        {
            this.bestBeforeDateField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public RegistrationIDType RegistrationID
    {
        get
        {
            return this.registrationIDField;
        }
        set
        {
            this.registrationIDField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public SerialIDType SerialID
    {
        get
        {
            return this.serialIDField;
        }
        set
        {
            this.serialIDField = value;
        }
    }

    [XmlElement("AdditionalItemProperty")]
    public ItemPropertyType[] AdditionalItemProperty
    {
        get
        {
            return this.additionalItemPropertyField;
        }
        set
        {
            this.additionalItemPropertyField = value;
        }
    }

    public LotIdentificationType LotIdentification
    {
        get
        {
            return this.lotIdentificationField;
        }
        set
        {
            this.lotIdentificationField = value;
        }
    }
}
