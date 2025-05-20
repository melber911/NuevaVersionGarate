using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[GeneratedCode("xsd", "4.0.30319.33440")]
[XmlRoot("PromotionalEvent", IsNullable = false, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[DebuggerStepThrough]
[DesignerCategory("code")]
[XmlType(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[Serializable]
public class PromotionalEventType
{
    private PromotionalEventTypeCodeType promotionalEventTypeCodeField;
    private SubmissionDateType submissionDateField;
    private FirstShipmentAvailibilityDateType firstShipmentAvailibilityDateField;
    private LatestProposalAcceptanceDateType latestProposalAcceptanceDateField;
    private PromotionalSpecificationType[] promotionalSpecificationField;

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public PromotionalEventTypeCodeType PromotionalEventTypeCode
    {
        get
        {
            return this.promotionalEventTypeCodeField;
        }
        set
        {
            this.promotionalEventTypeCodeField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public SubmissionDateType SubmissionDate
    {
        get
        {
            return this.submissionDateField;
        }
        set
        {
            this.submissionDateField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public FirstShipmentAvailibilityDateType FirstShipmentAvailibilityDate
    {
        get
        {
            return this.firstShipmentAvailibilityDateField;
        }
        set
        {
            this.firstShipmentAvailibilityDateField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public LatestProposalAcceptanceDateType LatestProposalAcceptanceDate
    {
        get
        {
            return this.latestProposalAcceptanceDateField;
        }
        set
        {
            this.latestProposalAcceptanceDateField = value;
        }
    }

    [XmlElement("PromotionalSpecification")]
    public PromotionalSpecificationType[] PromotionalSpecification
    {
        get
        {
            return this.promotionalSpecificationField;
        }
        set
        {
            this.promotionalSpecificationField = value;
        }
    }
}
