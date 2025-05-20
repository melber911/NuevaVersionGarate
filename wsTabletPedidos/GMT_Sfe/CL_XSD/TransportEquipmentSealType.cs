using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[DebuggerStepThrough]
[XmlRoot("TransportEquipmentSeal", IsNullable = false, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[GeneratedCode("xsd", "4.0.30319.33440")]
[DesignerCategory("code")]
[XmlType(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[Serializable]
public class TransportEquipmentSealType
{
    private IDType idField;
    private SealIssuerTypeCodeType sealIssuerTypeCodeField;
    private ConditionType conditionField;
    private SealStatusCodeType sealStatusCodeField;
    private SealingPartyTypeType sealingPartyTypeField;

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

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public SealIssuerTypeCodeType SealIssuerTypeCode
    {
        get
        {
            return this.sealIssuerTypeCodeField;
        }
        set
        {
            this.sealIssuerTypeCodeField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public ConditionType Condition
    {
        get
        {
            return this.conditionField;
        }
        set
        {
            this.conditionField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public SealStatusCodeType SealStatusCode
    {
        get
        {
            return this.sealStatusCodeField;
        }
        set
        {
            this.sealStatusCodeField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public SealingPartyTypeType SealingPartyType
    {
        get
        {
            return this.sealingPartyTypeField;
        }
        set
        {
            this.sealingPartyTypeField = value;
        }
    }
}
