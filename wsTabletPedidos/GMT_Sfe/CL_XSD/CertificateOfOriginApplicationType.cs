using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[XmlRoot("CertificateOfOriginApplication", IsNullable = false, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[XmlType(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[DebuggerStepThrough]
[DesignerCategory("code")]
[GeneratedCode("xsd", "4.0.30319.33440")]
[Serializable]
public class CertificateOfOriginApplicationType
{
    private ReferenceIDType referenceIDField;
    private CertificateTypeType certificateTypeField;
    private ApplicationStatusCodeType applicationStatusCodeField;
    private OriginalJobIDType originalJobIDField;
    private PreviousJobIDType previousJobIDField;
    private RemarksType[] remarksField;
    private ShipmentType shipmentField;
    private EndorserPartyType[] endorserPartyField;
    private PartyType preparationPartyField;
    private PartyType issuerPartyField;
    private PartyType exporterPartyField;
    private PartyType importerPartyField;
    private CountryType issuingCountryField;
    private DocumentDistributionType[] documentDistributionField;
    private DocumentReferenceType[] supportingDocumentReferenceField;
    private SignatureType[] signatureField;

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public ReferenceIDType ReferenceID
    {
        get
        {
            return this.referenceIDField;
        }
        set
        {
            this.referenceIDField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public CertificateTypeType CertificateType
    {
        get
        {
            return this.certificateTypeField;
        }
        set
        {
            this.certificateTypeField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public ApplicationStatusCodeType ApplicationStatusCode
    {
        get
        {
            return this.applicationStatusCodeField;
        }
        set
        {
            this.applicationStatusCodeField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public OriginalJobIDType OriginalJobID
    {
        get
        {
            return this.originalJobIDField;
        }
        set
        {
            this.originalJobIDField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public PreviousJobIDType PreviousJobID
    {
        get
        {
            return this.previousJobIDField;
        }
        set
        {
            this.previousJobIDField = value;
        }
    }

    [XmlElement("Remarks", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public RemarksType[] Remarks
    {
        get
        {
            return this.remarksField;
        }
        set
        {
            this.remarksField = value;
        }
    }

    public ShipmentType Shipment
    {
        get
        {
            return this.shipmentField;
        }
        set
        {
            this.shipmentField = value;
        }
    }

    [XmlElement("EndorserParty")]
    public EndorserPartyType[] EndorserParty
    {
        get
        {
            return this.endorserPartyField;
        }
        set
        {
            this.endorserPartyField = value;
        }
    }

    public PartyType PreparationParty
    {
        get
        {
            return this.preparationPartyField;
        }
        set
        {
            this.preparationPartyField = value;
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

    public PartyType ExporterParty
    {
        get
        {
            return this.exporterPartyField;
        }
        set
        {
            this.exporterPartyField = value;
        }
    }

    public PartyType ImporterParty
    {
        get
        {
            return this.importerPartyField;
        }
        set
        {
            this.importerPartyField = value;
        }
    }

    public CountryType IssuingCountry
    {
        get
        {
            return this.issuingCountryField;
        }
        set
        {
            this.issuingCountryField = value;
        }
    }

    [XmlElement("DocumentDistribution")]
    public DocumentDistributionType[] DocumentDistribution
    {
        get
        {
            return this.documentDistributionField;
        }
        set
        {
            this.documentDistributionField = value;
        }
    }

    [XmlElement("SupportingDocumentReference")]
    public DocumentReferenceType[] SupportingDocumentReference
    {
        get
        {
            return this.supportingDocumentReferenceField;
        }
        set
        {
            this.supportingDocumentReferenceField = value;
        }
    }

    [XmlElement("Signature")]
    public SignatureType[] Signature
    {
        get
        {
            return this.signatureField;
        }
        set
        {
            this.signatureField = value;
        }
    }
}
