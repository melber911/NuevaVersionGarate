using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml;
using System.Xml.Serialization;

[XmlType(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonExtensionComponents-2")]
[DebuggerStepThrough]
[XmlRoot("UBLExtension", IsNullable = false, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonExtensionComponents-2")]
[DesignerCategory("code")]
[GeneratedCode("xsd", "4.0.30319.33440")]
[Serializable]
public class UBLExtensionType
{
    private IDType idField;
    private NameType1 nameField;
    private ExtensionAgencyIDType extensionAgencyIDField;
    private ExtensionAgencyNameType extensionAgencyNameIDField;
    private ExtensionVersionIDType extensionVersionIDField;
    private ExtensionAgencyURIType extensionAgencyURIField;
    private ExtensionURIType extensionURIField;
    private ExtensionReasonCodeType extensionReasonCodeField;
    private ExtensionReasonType extensionReasonField;
    private XmlElement extensionContentField;

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
    public NameType1 Name
    {
        get
        {
            return this.nameField;
        }
        set
        {
            this.nameField = value;
        }
    }

    public ExtensionAgencyIDType ExtensionAgencyID
    {
        get
        {
            return this.extensionAgencyIDField;
        }
        set
        {
            this.extensionAgencyIDField = value;
        }
    }

    public ExtensionAgencyNameType ExtensionAgencyName
    {
        get
        {
            return this.extensionAgencyNameIDField;
        }
        set
        {
            this.extensionAgencyNameIDField = value;
        }
    }

    public ExtensionVersionIDType ExtensionVersionID
    {
        get
        {
            return this.extensionVersionIDField;
        }
        set
        {
            this.extensionVersionIDField = value;
        }
    }

    public ExtensionAgencyURIType ExtensionAgencyURI
    {
        get
        {
            return this.extensionAgencyURIField;
        }
        set
        {
            this.extensionAgencyURIField = value;
        }
    }

    public ExtensionURIType ExtensionURI
    {
        get
        {
            return this.extensionURIField;
        }
        set
        {
            this.extensionURIField = value;
        }
    }

    public ExtensionReasonCodeType ExtensionReasonCode
    {
        get
        {
            return this.extensionReasonCodeField;
        }
        set
        {
            this.extensionReasonCodeField = value;
        }
    }

    public ExtensionReasonType ExtensionReason
    {
        get
        {
            return this.extensionReasonField;
        }
        set
        {
            this.extensionReasonField = value;
        }
    }

    public XmlElement ExtensionContent
    {
        get
        {
            return this.extensionContentField;
        }
        set
        {
            this.extensionContentField = value;
        }
    }
}
