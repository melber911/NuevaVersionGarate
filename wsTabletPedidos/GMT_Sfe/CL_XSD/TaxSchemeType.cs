using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[XmlRoot("TaxScheme", IsNullable = false, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[GeneratedCode("xsd", "4.0.30319.33440")]
[DebuggerStepThrough]
[DesignerCategory("code")]
[XmlType(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[Serializable]
public class TaxSchemeType
{
    private IDType idField;
    private NameType1 nameField;
    private TaxTypeCodeType taxTypeCodeField;
    private CurrencyCodeType currencyCodeField;
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
    public TaxTypeCodeType TaxTypeCode
    {
        get
        {
            return this.taxTypeCodeField;
        }
        set
        {
            this.taxTypeCodeField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public CurrencyCodeType CurrencyCode
    {
        get
        {
            return this.currencyCodeField;
        }
        set
        {
            this.currencyCodeField = value;
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
