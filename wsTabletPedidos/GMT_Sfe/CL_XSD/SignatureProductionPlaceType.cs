using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[XmlRoot("SignatureProductionPlace", IsNullable = false, Namespace = "http://uri.etsi.org/01903/v1.3.2#")]
[DebuggerStepThrough]
[XmlType(Namespace = "http://uri.etsi.org/01903/v1.3.2#")]
[GeneratedCode("xsd", "4.0.30319.33440")]
[DesignerCategory("code")]
[Serializable]
public class SignatureProductionPlaceType
{
    private string cityField;
    private string stateOrProvinceField;
    private string postalCodeField;
    private string countryNameField;

    public string City
    {
        get
        {
            return this.cityField;
        }
        set
        {
            this.cityField = value;
        }
    }

    public string StateOrProvince
    {
        get
        {
            return this.stateOrProvinceField;
        }
        set
        {
            this.stateOrProvinceField = value;
        }
    }

    public string PostalCode
    {
        get
        {
            return this.postalCodeField;
        }
        set
        {
            this.postalCodeField = value;
        }
    }

    public string CountryName
    {
        get
        {
            return this.countryNameField;
        }
        set
        {
            this.countryNameField = value;
        }
    }
}
