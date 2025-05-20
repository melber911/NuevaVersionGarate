using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[DebuggerStepThrough]
[GeneratedCode("xsd", "4.0.30319.33440")]
[XmlRoot("Signature", IsNullable = false, Namespace = "http://www.w3.org/2000/09/xmldsig#")]
[DesignerCategory("code")]
[XmlType(Namespace = "http://www.w3.org/2000/09/xmldsig#", TypeName = "SignatureType")]
[Serializable]
public class SignatureType1
{
    private SignedInfoType signedInfoField;
    private SignatureValueType signatureValueField;
    private KeyInfoType keyInfoField;
    private ObjectType[] objectField;
    private string idField;

    public SignedInfoType SignedInfo
    {
        get
        {
            return this.signedInfoField;
        }
        set
        {
            this.signedInfoField = value;
        }
    }

    public SignatureValueType SignatureValue
    {
        get
        {
            return this.signatureValueField;
        }
        set
        {
            this.signatureValueField = value;
        }
    }

    public KeyInfoType KeyInfo
    {
        get
        {
            return this.keyInfoField;
        }
        set
        {
            this.keyInfoField = value;
        }
    }

    [XmlElement("Object")]
    public ObjectType[] Object
    {
        get
        {
            return this.objectField;
        }
        set
        {
            this.objectField = value;
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
