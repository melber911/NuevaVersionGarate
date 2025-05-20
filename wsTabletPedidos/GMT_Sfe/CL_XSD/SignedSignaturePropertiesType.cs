using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[XmlRoot("SignedSignatureProperties", IsNullable = false, Namespace = "http://uri.etsi.org/01903/v1.3.2#")]
[DebuggerStepThrough]
[XmlType(Namespace = "http://uri.etsi.org/01903/v1.3.2#")]
[GeneratedCode("xsd", "4.0.30319.33440")]
[DesignerCategory("code")]
[Serializable]
public class SignedSignaturePropertiesType
{
    private DateTime signingTimeField;
    private bool signingTimeSpecifiedField;
    private CertIDType[] signingCertificateField;
    private SignaturePolicyidentifierFieldType signaturePolicyidentifierFieldField;
    private SignatureProductionPlaceType signatureProductionPlaceField;
    private SignerRoleType signerRoleField;
    private string idField;

    public DateTime SigningTime
    {
        get
        {
            return this.signingTimeField;
        }
        set
        {
            this.signingTimeField = value;
        }
    }

    [XmlIgnore]
    public bool SigningTimeSpecified
    {
        get
        {
            return this.signingTimeSpecifiedField;
        }
        set
        {
            this.signingTimeSpecifiedField = value;
        }
    }

    [XmlArrayItem("Cert", IsNullable = false)]
    public CertIDType[] SigningCertificate
    {
        get
        {
            return this.signingCertificateField;
        }
        set
        {
            this.signingCertificateField = value;
        }
    }

    public SignaturePolicyidentifierFieldType SignaturePolicyidentifierField
    {
        get
        {
            return this.signaturePolicyidentifierFieldField;
        }
        set
        {
            this.signaturePolicyidentifierFieldField = value;
        }
    }

    public SignatureProductionPlaceType SignatureProductionPlace
    {
        get
        {
            return this.signatureProductionPlaceField;
        }
        set
        {
            this.signatureProductionPlaceField = value;
        }
    }

    public SignerRoleType SignerRole
    {
        get
        {
            return this.signerRoleField;
        }
        set
        {
            this.signerRoleField = value;
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
