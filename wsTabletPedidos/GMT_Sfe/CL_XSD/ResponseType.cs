using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[DesignerCategory("code")]
[XmlType(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[XmlRoot("DiscrepancyResponse", IsNullable = false, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[GeneratedCode("xsd", "4.0.30319.33440")]
[DebuggerStepThrough]
[Serializable]
public class ResponseType
{
    private ReferenceIDType referenceIDField;
    private ResponseCodeType responseCodeField;
    private DescriptionType[] descriptionField;
    private EffectiveDateType effectiveDateField;
    private EffectiveTimeType effectiveTimeField;
    private StatusType[] statusField;

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public ReferenceIDType ReferenceID
    {
        get
        {
            return this.referenceIDField;
        }
        set
        {
            this.referenceIDField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public ResponseCodeType ResponseCode
    {
        get
        {
            return this.responseCodeField;
        }
        set
        {
            this.responseCodeField = value;
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

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public EffectiveDateType EffectiveDate
    {
        get
        {
            return this.effectiveDateField;
        }
        set
        {
            this.effectiveDateField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public EffectiveTimeType EffectiveTime
    {
        get
        {
            return this.effectiveTimeField;
        }
        set
        {
            this.effectiveTimeField = value;
        }
    }

    [XmlElement("Status")]
    public StatusType[] Status
    {
        get
        {
            return this.statusField;
        }
        set
        {
            this.statusField = value;
        }
    }
}
