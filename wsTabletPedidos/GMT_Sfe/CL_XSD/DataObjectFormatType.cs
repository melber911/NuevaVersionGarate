using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[DebuggerStepThrough]
[XmlRoot("DataObjectFormat", IsNullable = false, Namespace = "http://uri.etsi.org/01903/v1.3.2#")]
[GeneratedCode("xsd", "4.0.30319.33440")]
[DesignerCategory("code")]
[XmlType(Namespace = "http://uri.etsi.org/01903/v1.3.2#")]
[Serializable]
public class DataObjectFormatType
{
    private string descriptionField;
    private ObjectIdentifierType objectidentifierFieldField;
    private string mimeTypeField;
    private string encodingField;
    private string objectReferenceField;

    public string Description
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

    public ObjectIdentifierType ObjectidentifierField
    {
        get
        {
            return this.objectidentifierFieldField;
        }
        set
        {
            this.objectidentifierFieldField = value;
        }
    }

    public string MimeType
    {
        get
        {
            return this.mimeTypeField;
        }
        set
        {
            this.mimeTypeField = value;
        }
    }

    [XmlElement(DataType = "anyURI")]
    public string Encoding
    {
        get
        {
            return this.encodingField;
        }
        set
        {
            this.encodingField = value;
        }
    }

    [XmlAttribute(DataType = "anyURI")]
    public string ObjectReference
    {
        get
        {
            return this.objectReferenceField;
        }
        set
        {
            this.objectReferenceField = value;
        }
    }
}
