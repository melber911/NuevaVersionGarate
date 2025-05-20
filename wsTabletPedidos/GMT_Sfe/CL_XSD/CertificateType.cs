using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[DebuggerStepThrough]
[XmlType(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[XmlRoot("Certificate", IsNullable = false, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[GeneratedCode("xsd", "4.0.30319.33440")]
[DesignerCategory("code")]
[Serializable]
public class CertificateType
{
    private IDType idField;
    private CertificateTypeCodeType certificateTypeCodeField;
  private CertificateTypeType certificateType1Field;
  private RemarksType[] remarksField;
    private PartyType issuerPartyField;
    private DocumentReferenceType[] documentReferenceField;
    private SignatureType[] signatureField;

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
    public CertificateTypeCodeType CertificateTypeCode
    {
        get
        {
            return this.certificateTypeCodeField;
        }
        set
        {
            this.certificateTypeCodeField = value;
        }
    }

    [XmlElement("CertificateType", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public CertificateTypeType CertificateType1
    {
        get
        {
            return this.certificateType1Field;
        }
        set
        {
            this.certificateType1Field = value;
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

    [XmlElement("DocumentReference")]
    public DocumentReferenceType[] DocumentReference
    {
        get
        {
            return this.documentReferenceField;
        }
        set
        {
            this.documentReferenceField = value;
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
