﻿using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[XmlRoot("ActivityFinalLocation", IsNullable = false, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[DebuggerStepThrough]
[XmlType(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2", TypeName = "LocationType")]
[GeneratedCode("xsd", "4.0.30319.33440")]
[DesignerCategory("code")]
[Serializable]
public class LocationType1
{
    private IDType idField;
    private DescriptionType[] descriptionField;
    private ConditionsType[] conditionsField;
    private CountrySubentityType countrySubentityField;
    private CountrySubentityCodeType countrySubentityCodeField;
    private LocationTypeCodeType locationTypeCodeField;
    private InformationURIType informationURIField;
    private NameType1 nameField;
    private PeriodType[] validityPeriodField;
    private AddressType addressField;
    private LocationType1[] subsidiaryLocationField;
    private LocationCoordinateType[] locationCoordinateField;

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

    [XmlElement("Description", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public DescriptionType[] Description
    {
        get
        {
            return this.descriptionField;
        }
        set
        {
            this.descriptionField = value;
        }
    }

    [XmlElement("Conditions", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public ConditionsType[] Conditions
    {
        get
        {
            return this.conditionsField;
        }
        set
        {
            this.conditionsField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public CountrySubentityType CountrySubentity
    {
        get
        {
            return this.countrySubentityField;
        }
        set
        {
            this.countrySubentityField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public CountrySubentityCodeType CountrySubentityCode
    {
        get
        {
            return this.countrySubentityCodeField;
        }
        set
        {
            this.countrySubentityCodeField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public LocationTypeCodeType LocationTypeCode
    {
        get
        {
            return this.locationTypeCodeField;
        }
        set
        {
            this.locationTypeCodeField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public InformationURIType InformationURI
    {
        get
        {
            return this.informationURIField;
        }
        set
        {
            this.informationURIField = value;
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

    [XmlElement("ValidityPeriod")]
    public PeriodType[] ValidityPeriod
    {
        get
        {
            return this.validityPeriodField;
        }
        set
        {
            this.validityPeriodField = value;
        }
    }

    public AddressType Address
    {
        get
        {
            return this.addressField;
        }
        set
        {
            this.addressField = value;
        }
    }

    [XmlElement("SubsidiaryLocation")]
    public LocationType1[] SubsidiaryLocation
    {
        get
        {
            return this.subsidiaryLocationField;
        }
        set
        {
            this.subsidiaryLocationField = value;
        }
    }

    [XmlElement("LocationCoordinate")]
    public LocationCoordinateType[] LocationCoordinate
    {
        get
        {
            return this.locationCoordinateField;
        }
        set
        {
            this.locationCoordinateField = value;
        }
    }
}
