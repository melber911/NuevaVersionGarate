using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[DesignerCategory("code")]
[XmlType(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[XmlRoot("AdditionalItemIdentification", IsNullable = false, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[GeneratedCode("xsd", "4.0.30319.33440")]
[DebuggerStepThrough]
[Serializable]
public class ItemIdentificationType
{
    private IDType idField;
    private ExtendedIDType extendedIDField;
    private BarcodeSymbologyIDType barcodeSymbologyIDField;
    private PhysicalAttributeType[] physicalAttributeField;
    private DimensionType[] measurementDimensionField;
    private PartyType issuerPartyField;

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
    public ExtendedIDType ExtendedID
    {
        get
        {
            return this.extendedIDField;
        }
        set
        {
            this.extendedIDField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public BarcodeSymbologyIDType BarcodeSymbologyID
    {
        get
        {
            return this.barcodeSymbologyIDField;
        }
        set
        {
            this.barcodeSymbologyIDField = value;
        }
    }

    [XmlElement("PhysicalAttribute")]
    public PhysicalAttributeType[] PhysicalAttribute
    {
        get
        {
            return this.physicalAttributeField;
        }
        set
        {
            this.physicalAttributeField = value;
        }
    }

    [XmlElement("MeasurementDimension")]
    public DimensionType[] MeasurementDimension
    {
        get
        {
            return this.measurementDimensionField;
        }
        set
        {
            this.measurementDimensionField = value;
        }
    }

    public PartyType IssuerParty
    {
        get
        {
            return this.issuerPartyField;
        }
        set
        {
            this.issuerPartyField = value;
        }
    }
}
