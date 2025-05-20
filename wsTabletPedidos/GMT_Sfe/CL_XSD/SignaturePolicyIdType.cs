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
public class SignaturePolicyIdType
{
    private ObjectIdentifierType sigPolicyIdField;
    private TransformType[] transformsField;
    private DigestAlgAndValueType sigPolicyHashField;
    private AnyType[] sigPolicyQualifiersField;

    public ObjectIdentifierType SigPolicyId
    {
        get
        {
            return this.sigPolicyIdField;
        }
        set
        {
            this.sigPolicyIdField = value;
        }
    }

    [XmlArray(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    [XmlArrayItem("Transform", IsNullable = false)]
    public TransformType[] Transforms
    {
        get
        {
            return this.transformsField;
        }
        set
        {
            this.transformsField = value;
        }
    }

    public DigestAlgAndValueType SigPolicyHash
    {
        get
        {
            return this.sigPolicyHashField;
        }
        set
        {
            this.sigPolicyHashField = value;
        }
    }

    [XmlArrayItem("SigPolicyQualifier", IsNullable = false)]
    public AnyType[] SigPolicyQualifiers
    {
        get
        {
            return this.sigPolicyQualifiersField;
        }
        set
        {
            this.sigPolicyQualifiersField = value;
        }
    }
}
