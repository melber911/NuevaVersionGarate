using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[DebuggerStepThrough]
[DesignerCategory("code")]
[GeneratedCode("xsd", "4.0.30319.33440")]
[XmlType(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[XmlRoot("CorporateRegistrationScheme", IsNullable = false, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[Serializable]
public class CorporateRegistrationSchemeType
{
    private IDType idField;
    private NameType1 nameField;
    private CorporateRegistrationTypeCodeType corporateRegistrationTypeCodeField;
    private AddressType[] jurisdictionRegionAddressField;

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public IDType ID
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

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public NameType1 Name
    {
        get
        {
            return this.nameField;
        }
        set
        {
            this.nameField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public CorporateRegistrationTypeCodeType CorporateRegistrationTypeCode
    {
        get
        {
            return this.corporateRegistrationTypeCodeField;
        }
        set
        {
            this.corporateRegistrationTypeCodeField = value;
        }
    }

    [XmlElement("JurisdictionRegionAddress")]
    public AddressType[] JurisdictionRegionAddress
    {
        get
        {
            return this.jurisdictionRegionAddressField;
        }
        set
        {
            this.jurisdictionRegionAddressField = value;
        }
    }
}
