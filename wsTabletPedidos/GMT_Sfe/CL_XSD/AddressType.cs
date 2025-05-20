using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[XmlType(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[GeneratedCode("xsd", "4.0.30319.33440")]
[XmlRoot("Address", IsNullable = false, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[DesignerCategory("code")]
[DebuggerStepThrough]
[Serializable]
public class AddressType
{
    private IDType idField;
    private AddressTypeCodeType addressTypeCodeField;
    private AddressFormatCodeType addressFormatCodeField;
    private PostboxType postboxField;
    private FloorType floorField;
    private RoomType roomField;
    private StreetNameType streetNameField;
    private AdditionalStreetNameType additionalStreetNameField;
    private BlockNameType blockNameField;
    private BuildingNameType buildingNameField;
    private BuildingNumberType buildingNumberField;
    private InhouseMailType inhouseMailField;
    private DepartmentType departmentField;
    private MarkAttentionType markAttentionField;
    private MarkCareType markCareField;
    private PlotIdentificationType plotIdentificationField;
    private CitySubdivisionNameType citySubdivisionNameField;
    private CityNameType cityNameField;
    private PostalZoneType postalZoneField;
    private CountrySubentityType countrySubentityField;
    private CountrySubentityCodeType countrySubentityCodeField;
    private RegionType regionField;
    private DistrictType districtField;
    private TimezoneOffsetType timezoneOffsetField;
    private AddressLineType[] addressLineField;
    private CountryType countryField;
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

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public AddressTypeCodeType AddressTypeCode
    {
        get
        {
            return this.addressTypeCodeField;
        }
        set
        {
            this.addressTypeCodeField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public AddressFormatCodeType AddressFormatCode
    {
        get
        {
            return this.addressFormatCodeField;
        }
        set
        {
            this.addressFormatCodeField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public PostboxType Postbox
    {
        get
        {
            return this.postboxField;
        }
        set
        {
            this.postboxField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public FloorType Floor
    {
        get
        {
            return this.floorField;
        }
        set
        {
            this.floorField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public RoomType Room
    {
        get
        {
            return this.roomField;
        }
        set
        {
            this.roomField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public StreetNameType StreetName
    {
        get
        {
            return this.streetNameField;
        }
        set
        {
            this.streetNameField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public AdditionalStreetNameType AdditionalStreetName
    {
        get
        {
            return this.additionalStreetNameField;
        }
        set
        {
            this.additionalStreetNameField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public BlockNameType BlockName
    {
        get
        {
            return this.blockNameField;
        }
        set
        {
            this.blockNameField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public BuildingNameType BuildingName
    {
        get
        {
            return this.buildingNameField;
        }
        set
        {
            this.buildingNameField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public BuildingNumberType BuildingNumber
    {
        get
        {
            return this.buildingNumberField;
        }
        set
        {
            this.buildingNumberField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public InhouseMailType InhouseMail
    {
        get
        {
            return this.inhouseMailField;
        }
        set
        {
            this.inhouseMailField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public DepartmentType Department
    {
        get
        {
            return this.departmentField;
        }
        set
        {
            this.departmentField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public MarkAttentionType MarkAttention
    {
        get
        {
            return this.markAttentionField;
        }
        set
        {
            this.markAttentionField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public MarkCareType MarkCare
    {
        get
        {
            return this.markCareField;
        }
        set
        {
            this.markCareField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public PlotIdentificationType PlotIdentification
    {
        get
        {
            return this.plotIdentificationField;
        }
        set
        {
            this.plotIdentificationField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public CitySubdivisionNameType CitySubdivisionName
    {
        get
        {
            return this.citySubdivisionNameField;
        }
        set
        {
            this.citySubdivisionNameField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public CityNameType CityName
    {
        get
        {
            return this.cityNameField;
        }
        set
        {
            this.cityNameField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public PostalZoneType PostalZone
    {
        get
        {
            return this.postalZoneField;
        }
        set
        {
            this.postalZoneField = value;
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
    public RegionType Region
    {
        get
        {
            return this.regionField;
        }
        set
        {
            this.regionField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public DistrictType District
    {
        get
        {
            return this.districtField;
        }
        set
        {
            this.districtField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public TimezoneOffsetType TimezoneOffset
    {
        get
        {
            return this.timezoneOffsetField;
        }
        set
        {
            this.timezoneOffsetField = value;
        }
    }

    [XmlElement("AddressLine")]
    public AddressLineType[] AddressLine
    {
        get
        {
            return this.addressLineField;
        }
        set
        {
            this.addressLineField = value;
        }
    }

    public CountryType Country
    {
        get
        {
            return this.countryField;
        }
        set
        {
            this.countryField = value;
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
