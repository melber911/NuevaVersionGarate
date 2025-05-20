using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[DesignerCategory("code")]
[XmlType(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[XmlRoot("EconomicOperatorRole", IsNullable = false, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[GeneratedCode("xsd", "4.0.30319.33440")]
[DebuggerStepThrough]
[Serializable]
public class EconomicOperatorRoleType
{
    private RoleCodeType roleCodeField;
    private RoleDescriptionType[] roleDescriptionField;

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public RoleCodeType RoleCode
    {
        get
        {
            return this.roleCodeField;
        }
        set
        {
            this.roleCodeField = value;
        }
    }

    [XmlElement("RoleDescription", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public RoleDescriptionType[] RoleDescription
    {
        get
        {
            return this.roleDescriptionField;
        }
        set
        {
            this.roleDescriptionField = value;
        }
    }
}
