using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[DebuggerStepThrough]
[XmlType(Namespace = "http://uri.etsi.org/01903/v1.3.2#")]
[XmlRoot("SignerRole", IsNullable = false, Namespace = "http://uri.etsi.org/01903/v1.3.2#")]
[GeneratedCode("xsd", "4.0.30319.33440")]
[DesignerCategory("code")]
[Serializable]
public class SignerRoleType
{
    private AnyType[] claimedRolesField;
    private EncapsulatedPKIDataType[] certifiedRolesField;

    [XmlArrayItem("ClaimedRole", IsNullable = false)]
    public AnyType[] ClaimedRoles
    {
        get
        {
            return this.claimedRolesField;
        }
        set
        {
            this.claimedRolesField = value;
        }
    }

    [XmlArrayItem("CertifiedRole", IsNullable = false)]
    public EncapsulatedPKIDataType[] CertifiedRoles
    {
        get
        {
            return this.certifiedRolesField;
        }
        set
        {
            this.certifiedRolesField = value;
        }
    }
}
