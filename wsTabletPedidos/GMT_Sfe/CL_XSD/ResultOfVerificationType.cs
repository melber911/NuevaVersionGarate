using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[XmlType(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[DesignerCategory("code")]
[XmlRoot("ResultOfVerification", IsNullable = false, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[GeneratedCode("xsd", "4.0.30319.33440")]
[DebuggerStepThrough]
[Serializable]
public class ResultOfVerificationType
{
    private ValidatorIDType validatorIDField;
    private ValidationResultCodeType validationResultCodeField;
    private ValidationDateType validationDateField;
    private ValidationTimeType validationTimeField;
    private ValidateProcessType validateProcessField;
    private ValidateToolType validateToolField;
    private ValidateToolVersionType validateToolVersionField;
    private PartyType signatoryPartyField;

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public ValidatorIDType ValidatorID
    {
        get
        {
            return this.validatorIDField;
        }
        set
        {
            this.validatorIDField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public ValidationResultCodeType ValidationResultCode
    {
        get
        {
            return this.validationResultCodeField;
        }
        set
        {
            this.validationResultCodeField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public ValidationDateType ValidationDate
    {
        get
        {
            return this.validationDateField;
        }
        set
        {
            this.validationDateField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public ValidationTimeType ValidationTime
    {
        get
        {
            return this.validationTimeField;
        }
        set
        {
            this.validationTimeField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public ValidateProcessType ValidateProcess
    {
        get
        {
            return this.validateProcessField;
        }
        set
        {
            this.validateProcessField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public ValidateToolType ValidateTool
    {
        get
        {
            return this.validateToolField;
        }
        set
        {
            this.validateToolField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public ValidateToolVersionType ValidateToolVersion
    {
        get
        {
            return this.validateToolVersionField;
        }
        set
        {
            this.validateToolVersionField = value;
        }
    }

    public PartyType SignatoryParty
    {
        get
        {
            return this.signatoryPartyField;
        }
        set
        {
            this.signatoryPartyField = value;
        }
    }
}
