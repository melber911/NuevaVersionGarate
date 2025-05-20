using System.Xml.Serialization;

[XmlRoot("VoidedDocuments", IsNullable = false, Namespace = "urn:sunat:names:specification:ubl:peru:schema:xsd:VoidedDocuments-1")]
[XmlType(Namespace = "urn:sunat:names:specification:ubl:peru:schema:xsd:VoidedDocuments-1")]
public class VoidedDocumentsType
{
    private UBLExtensionType[] uBLExtensionsField;
    private UBLVersionIDType uBLVersionIDField;
    private CustomizationIDType customizationIDField;
    private IDType idField;
    private ReferenceDateType referenceDateField;
    private IssueDateType issueDateField;
    private NoteType[] noteField;
    private SignatureType[] signatureField;
    private SupplierPartyType accountingSupplierPartyField;
    private VoidedDocumentsLineType[] voidedDocumentsLineField;

    [XmlArrayItem("UBLExtension", IsNullable = false)]
    [XmlArray(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonExtensionComponents-2")]
    public UBLExtensionType[] UBLExtensions
    {
        get
        {
            return this.uBLExtensionsField;
        }
        set
        {
            this.uBLExtensionsField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public UBLVersionIDType UBLVersionID
    {
        get
        {
            return this.uBLVersionIDField;
        }
        set
        {
            this.uBLVersionIDField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public CustomizationIDType CustomizationID
    {
        get
        {
            return this.customizationIDField;
        }
        set
        {
            this.customizationIDField = value;
        }
    }

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
    public ReferenceDateType ReferenceDate
    {
        get
        {
            return this.referenceDateField;
        }
        set
        {
            this.referenceDateField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public IssueDateType IssueDate
    {
        get
        {
            return this.issueDateField;
        }
        set
        {
            this.issueDateField = value;
        }
    }

    [XmlElement("Note", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public NoteType[] Note
    {
        get
        {
            return this.noteField;
        }
        set
        {
            this.noteField = value;
        }
    }

    [XmlElement("Signature", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
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

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
    public SupplierPartyType AccountingSupplierParty
    {
        get
        {
            return this.accountingSupplierPartyField;
        }
        set
        {
            this.accountingSupplierPartyField = value;
        }
    }

    [XmlElement("VoidedDocumentsLine", Namespace = "urn:sunat:names:specification:ubl:peru:schema:xsd:SunatAggregateComponents-1")]
    public VoidedDocumentsLineType[] VoidedDocumentsLine
    {
        get
        {
            return this.voidedDocumentsLineField;
        }
        set
        {
            this.voidedDocumentsLineField = value;
        }
    }
}
