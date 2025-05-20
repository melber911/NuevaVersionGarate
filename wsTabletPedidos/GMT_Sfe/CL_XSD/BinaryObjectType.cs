using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[XmlInclude(typeof(PictureType))]
[DesignerCategory("code")]
[XmlType(Namespace = "urn:un:unece:uncefact:data:specification:CoreComponentTypeSchemaModule:2")]
[XmlInclude(typeof(SoundType))]
[XmlInclude(typeof(BinaryObjectType1))]
[DebuggerStepThrough]
[XmlInclude(typeof(GraphicType))]
[XmlInclude(typeof(VideoType))]
[XmlInclude(typeof(EmbeddedDocumentBinaryObjectType))]
[GeneratedCode("xsd", "4.0.30319.33440")]
[Serializable]
public class BinaryObjectType
{
    private string formatField;
    private string mimeCodeField;
    private string encodingCodeField;
    private string characterSetCodeField;
    private string uriField;
    private string filenameField;
    private byte[] valueField;

    [XmlAttribute]
    public string format
    {
        get
        {
            return this.formatField;
        }
        set
        {
            this.formatField = value;
        }
    }

    [XmlAttribute(DataType = "normalizedString")]
    public string mimeCode
    {
        get
        {
            return this.mimeCodeField;
        }
        set
        {
            this.mimeCodeField = value;
        }
    }

    [XmlAttribute(DataType = "normalizedString")]
    public string encodingCode
    {
        get
        {
            return this.encodingCodeField;
        }
        set
        {
            this.encodingCodeField = value;
        }
    }

    [XmlAttribute(DataType = "normalizedString")]
    public string characterSetCode
    {
        get
        {
            return this.characterSetCodeField;
        }
        set
        {
            this.characterSetCodeField = value;
        }
    }

    [XmlAttribute(DataType = "anyURI")]
    public string uri
    {
        get
        {
            return this.uriField;
        }
        set
        {
            this.uriField = value;
        }
    }

    [XmlAttribute]
    public string filename
    {
        get
        {
            return this.filenameField;
        }
        set
        {
            this.filenameField = value;
        }
    }

    [XmlText(DataType = "base64Binary")]
    public byte[] Value
    {
        get
        {
            return this.valueField;
        }
        set
        {
            this.valueField = value;
        }
    }
}
