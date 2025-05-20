using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[XmlRoot("UBLExtensions", IsNullable = false, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonExtensionComponents-2")]
[DebuggerStepThrough]
[XmlType(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonExtensionComponents-2")]
[GeneratedCode("xsd", "4.0.30319.33440")]
[DesignerCategory("code")]
[Serializable]
public class UBLExtensionsType
{
    private UBLExtensionType[] uBLExtensionField;

    [XmlElement("UBLExtension")]
    public UBLExtensionType[] UBLExtension
    {
        get
        {
            return this.uBLExtensionField;
        }
        set
        {
            this.uBLExtensionField = value;
        }
    }
}
