using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[GeneratedCode("xsd", "4.0.30319.33440")]
[XmlRoot("SignedInfo", IsNullable = false, Namespace = "http://www.w3.org/2000/09/xmldsig#")]
[DebuggerStepThrough]
[DesignerCategory("code")]
[XmlType(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
[Serializable]
public class SignedInfoType
{
    private CanonicalizationMethodType1 canonicalizationMethodField;
    private SignatureMethodType1 signatureMethodField;
    private ReferenceType1[] referenceField;
    private string idField;

    public CanonicalizationMethodType1 CanonicalizationMethod
    {
        get
        {
            return this.canonicalizationMethodField;
        }
        set
        {
            this.canonicalizationMethodField = value;
        }
    }

    public SignatureMethodType1 SignatureMethod
    {
        get
        {
            return this.signatureMethodField;
        }
        set
        {
            this.signatureMethodField = value;
        }
    }

    [XmlElement("Reference")]
    public ReferenceType1[] Reference
    {
        get
        {
            return this.referenceField;
        }
        set
        {
            this.referenceField = value;
        }
    }

    [XmlAttribute(DataType = "ID")]
    public string Id
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
}
