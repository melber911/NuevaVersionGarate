using System.Xml.Serialization;

[XmlType(Namespace = "urn:sunat:names:specification:ubl:peru:schema:xsd:Perception-1")]
[XmlRoot("Perception", IsNullable = false, Namespace = "urn:sunat:names:specification:ubl:peru:schema:xsd:Perception-1")]
public class PerceptionType
{
    private UBLExtensionType[] uBLExtensionsField;
    private UBLVersionIDType uBLVersionIDField;
    private CustomizationIDType customizationIDField;
    private SignatureType[] signatureField;
    private IDType idField;
    private IssueDateType issueDateField;
    private PartyType agentPartyField;
    private PartyType receiverPartyField;
    private SUNATPerceptionSystemCodeType sUNATPerceptionSystemCodeField;
    private SUNATPerceptionPercentType sUNATPerceptionPercentField;
    private NoteType[] noteField;
    private TotalInvoiceAmountType totalInvoiceAmountField;
    private TotalInvoiceAmountType sUNATTotalCashedField;
    private SUNATPerceptionDocumentReferenceType[] sUNATPerceptionDocumentReferenceField;

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

    [XmlElement("AgentParty", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
    public PartyType AgentParty
    {
        get
        {
            return this.agentPartyField;
        }
        set
        {
            this.agentPartyField = value;
        }
    }

    [XmlElement("ReceiverParty", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
    public PartyType ReceiverParty
    {
        get
        {
            return this.receiverPartyField;
        }
        set
        {
            this.receiverPartyField = value;
        }
    }

    [XmlElement("SUNATPerceptionSystemCode", Namespace = "urn:sunat:names:specification:ubl:peru:schema:xsd:SunatAggregateComponents-1")]
    public SUNATPerceptionSystemCodeType SUNATPerceptionSystemCode
    {
        get
        {
            return this.sUNATPerceptionSystemCodeField;
        }
        set
        {
            this.sUNATPerceptionSystemCodeField = value;
        }
    }

    [XmlElement(Namespace = "urn:sunat:names:specification:ubl:peru:schema:xsd:SunatAggregateComponents-1")]
    public SUNATPerceptionPercentType SUNATPerceptionPercent
    {
        get
        {
            return this.sUNATPerceptionPercentField;
        }
        set
        {
            this.sUNATPerceptionPercentField = value;
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

    [XmlElement("TotalInvoiceAmount", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public TotalInvoiceAmountType TotalInvoiceAmount
    {
        get
        {
            return this.totalInvoiceAmountField;
        }
        set
        {
            this.totalInvoiceAmountField = value;
        }
    }

    [XmlElement("SUNATTotalCashed", Namespace = "urn:sunat:names:specification:ubl:peru:schema:xsd:SunatAggregateComponents-1")]
    public TotalInvoiceAmountType SUNATTotalCashed
    {
        get
        {
            return this.sUNATTotalCashedField;
        }
        set
        {
            this.sUNATTotalCashedField = value;
        }
    }

    [XmlElement("SUNATPerceptionDocumentReference", Namespace = "urn:sunat:names:specification:ubl:peru:schema:xsd:SunatAggregateComponents-1")]
    public SUNATPerceptionDocumentReferenceType[] SUNATPerceptionDocumentReference
    {
        get
        {
            return this.sUNATPerceptionDocumentReferenceField;
        }
        set
        {
            this.sUNATPerceptionDocumentReferenceField = value;
        }
    }
}
