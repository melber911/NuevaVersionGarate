using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[XmlRoot("ObjectIdentifier", IsNullable = false, Namespace = "http://uri.etsi.org/01903/v1.3.2#")]
[DebuggerStepThrough]
[XmlType(Namespace = "http://uri.etsi.org/01903/v1.3.2#")]
[GeneratedCode("xsd", "4.0.30319.33440")]
[DesignerCategory("code")]
[Serializable]
public class ObjectIdentifierType
{
    private IdentifierType2 identifierField;
    private string descriptionField;
    private DocumentationReferencesType documentationReferencesField;

    public IdentifierType2 Identifier
    {
        get
        {
            return this.identifierField;
        }
        set
        {
            this.identifierField = value;
        }
    }

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

    public DocumentationReferencesType DocumentationReferences
    {
        get
        {
            return this.documentationReferencesField;
        }
        set
        {
            this.documentationReferencesField = value;
        }
    }
}
