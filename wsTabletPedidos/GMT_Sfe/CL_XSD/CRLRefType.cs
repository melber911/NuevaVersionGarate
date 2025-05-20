using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[DesignerCategory("code")]
[GeneratedCode("xsd", "4.0.30319.33440")]
[DebuggerStepThrough]
[XmlType(Namespace = "http://uri.etsi.org/01903/v1.3.2#")]
[Serializable]
public class CRLRefType
{
    private DigestAlgAndValueType digestAlgAndValueField;
    private CRLidentifierFieldType cRLidentifierFieldField;

    public DigestAlgAndValueType DigestAlgAndValue
    {
        get
        {
            return this.digestAlgAndValueField;
        }
        set
        {
            this.digestAlgAndValueField = value;
        }
    }

    public CRLidentifierFieldType CRLidentifierField
    {
        get
        {
            return this.cRLidentifierFieldField;
        }
        set
        {
            this.cRLidentifierFieldField = value;
        }
    }
}
