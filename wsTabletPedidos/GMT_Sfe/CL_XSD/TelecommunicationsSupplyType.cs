using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[GeneratedCode("xsd", "4.0.30319.33440")]
[DebuggerStepThrough]
[DesignerCategory("code")]
[XmlType(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[XmlRoot("TelecommunicationsSupply", IsNullable = false, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[Serializable]
public class TelecommunicationsSupplyType
{
    private TelecommunicationsSupplyTypeType telecommunicationsSupplyType1Field;
    private TelecommunicationsSupplyTypeCodeType telecommunicationsSupplyTypeCodeField;
    private PrivacyCodeType privacyCodeField;
    private DescriptionType[] descriptionField;
    private TotalAmountType totalAmountField;
    private TelecommunicationsSupplyLineType[] telecommunicationsSupplyLineField;

    [XmlElement("TelecommunicationsSupplyType", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public TelecommunicationsSupplyTypeType TelecommunicationsSupplyType1
    {
        get
        {
            return this.telecommunicationsSupplyType1Field;
        }
        set
        {
            this.telecommunicationsSupplyType1Field = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public TelecommunicationsSupplyTypeCodeType TelecommunicationsSupplyTypeCode
    {
        get
        {
            return this.telecommunicationsSupplyTypeCodeField;
        }
        set
        {
            this.telecommunicationsSupplyTypeCodeField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public PrivacyCodeType PrivacyCode
    {
        get
        {
            return this.privacyCodeField;
        }
        set
        {
            this.privacyCodeField = value;
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
    public TotalAmountType TotalAmount
    {
        get
        {
            return this.totalAmountField;
        }
        set
        {
            this.totalAmountField = value;
        }
    }

    [XmlElement("TelecommunicationsSupplyLine")]
    public TelecommunicationsSupplyLineType[] TelecommunicationsSupplyLine
    {
        get
        {
            return this.telecommunicationsSupplyLineField;
        }
        set
        {
            this.telecommunicationsSupplyLineField = value;
        }
    }
}
