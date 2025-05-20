using System.Xml.Serialization;

[XmlType(Namespace = "urn:sunat:names:specification:ubl:peru:schema:xsd:Retention-1")]
[XmlRoot("Retention", IsNullable = false, Namespace = "urn:sunat:names:specification:ubl:peru:schema:xsd:Retention-1")]
public class RetentionType
{
    private UBLExtensionType[] uBLExtensionsField;
    private UBLVersionIDType uBLVersionIDField;
    private CustomizationIDType customizationIDField;
    private SignatureType[] signatureField;
    private IDType idField;
    private IssueDateType issueDateField;
    private PartyType agentPartyField;
    private PartyType receiverPartyField;
    private SUNATRetentionSystemCodeType sUNATRetentionSystemCodeField;
    private SUNATRetentionPercentType sUNATRetentionPercentField;
    private NoteType[] noteField;
    private TotalInvoiceAmountType totalInvoiceAmountField;
    private TotalInvoiceAmountType sUNATTotalPaidField;
    private SUNATRetentionDocumentReferenceType[] sUNATRetentionDocumentReferenceField;

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

    [XmlElement("SUNATRetentionSystemCode", Namespace = "urn:sunat:names:specification:ubl:peru:schema:xsd:SunatAggregateComponents-1")]
    public SUNATRetentionSystemCodeType SUNATRetentionSystemCode
    {
        get
        {
            return this.sUNATRetentionSystemCodeField;
        }
        set
        {
            this.sUNATRetentionSystemCodeField = value;
        }
    }

    [XmlElement(Namespace = "urn:sunat:names:specification:ubl:peru:schema:xsd:SunatAggregateComponents-1")]
    public SUNATRetentionPercentType SUNATRetentionPercent
    {
        get
        {
            return this.sUNATRetentionPercentField;
        }
        set
        {
            this.sUNATRetentionPercentField = value;
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

    [XmlElement("SUNATTotalPaid", Namespace = "urn:sunat:names:specification:ubl:peru:schema:xsd:SunatAggregateComponents-1")]
    public TotalInvoiceAmountType SUNATTotalPaid
    {
        get
        {
            return this.sUNATTotalPaidField;
        }
        set
        {
            this.sUNATTotalPaidField = value;
        }
    }

    [XmlElement("SUNATRetentionDocumentReference", Namespace = "urn:sunat:names:specification:ubl:peru:schema:xsd:SunatAggregateComponents-1")]
    public SUNATRetentionDocumentReferenceType[] SUNATRetentionDocumentReference
    {
        get
        {
            return this.sUNATRetentionDocumentReferenceField;
        }
        set
        {
            this.sUNATRetentionDocumentReferenceField = value;
        }
    }
}
