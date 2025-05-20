using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[XmlRoot("Attachment", IsNullable = false, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[DesignerCategory("code")]
[XmlType(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[GeneratedCode("xsd", "4.0.30319.33440")]
[DebuggerStepThrough]
[Serializable]
public class AttachmentType
{
    private EmbeddedDocumentBinaryObjectType embeddedDocumentBinaryObjectField;
    private ExternalReferenceType externalReferenceField;

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public EmbeddedDocumentBinaryObjectType EmbeddedDocumentBinaryObject
    {
        get
        {
            return this.embeddedDocumentBinaryObjectField;
        }
        set
        {
            this.embeddedDocumentBinaryObjectField = value;
        }
    }

    public ExternalReferenceType ExternalReference
    {
        get
        {
            return this.externalReferenceField;
        }
        set
        {
            this.externalReferenceField = value;
        }
    }
}
