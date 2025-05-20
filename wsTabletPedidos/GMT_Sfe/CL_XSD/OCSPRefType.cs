using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[GeneratedCode("xsd", "4.0.30319.33440")]
[DesignerCategory("code")]
[XmlType(Namespace = "http://uri.etsi.org/01903/v1.3.2#")]
[DebuggerStepThrough]
[Serializable]
public class OCSPRefType
{
    private OCSPidentifierFieldType oCSPidentifierFieldField;
    private DigestAlgAndValueType digestAlgAndValueField;

    public OCSPidentifierFieldType OCSPidentifierField
    {
        get
        {
            return this.oCSPidentifierFieldField;
        }
        set
        {
            this.oCSPidentifierFieldField = value;
        }
    }

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
}
