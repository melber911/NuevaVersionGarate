using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[GeneratedCode("xsd", "4.0.30319.33440")]
[DebuggerStepThrough]
[DesignerCategory("code")]
[XmlRoot("RequestForQuotationLine", IsNullable = false, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[XmlType(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[Serializable]
public class RequestForQuotationLineType
{
    private IDType idField;
    private UUIDType uUIDField;
    private NoteType[] noteField;
    private OptionalLineItemIndicatorType optionalLineItemIndicatorField;
    private PrivacyCodeType privacyCodeField;
    private SecurityClassificationCodeType securityClassificationCodeField;
    private DocumentReferenceType[] documentReferenceField;
    private LineItemType lineItemField;

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
    public UUIDType UUID
    {
        get
        {
            return this.uUIDField;
        }
        set
        {
            this.uUIDField = value;
        }
    }

    [XmlElement("Note", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public NoteType[] Note
    {
        get
        {
            return this.noteField;
        }
        set
        {
            this.noteField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public OptionalLineItemIndicatorType OptionalLineItemIndicator
    {
        get
        {
            return this.optionalLineItemIndicatorField;
        }
        set
        {
            this.optionalLineItemIndicatorField = value;
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

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public SecurityClassificationCodeType SecurityClassificationCode
    {
        get
        {
            return this.securityClassificationCodeField;
        }
        set
        {
            this.securityClassificationCodeField = value;
        }
    }

    [XmlElement("DocumentReference")]
    public DocumentReferenceType[] DocumentReference
    {
        get
        {
            return this.documentReferenceField;
        }
        set
        {
            this.documentReferenceField = value;
        }
    }

    public LineItemType LineItem
    {
        get
        {
            return this.lineItemField;
        }
        set
        {
            this.lineItemField = value;
        }
    }
}
