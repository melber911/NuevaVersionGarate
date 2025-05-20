using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[DebuggerStepThrough]
[XmlRoot("AccountingContact", IsNullable = false, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[GeneratedCode("xsd", "4.0.30319.33440")]
[DesignerCategory("code")]
[XmlType(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[Serializable]
public class ContactType
{
    private IDType idField;
    private NameType1 nameField;
    private TelephoneType telephoneField;
    private TelefaxType telefaxField;
    private ElectronicMailType electronicMailField;
    private NoteType[] noteField;
    private CommunicationType[] otherCommunicationField;

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
    public TelephoneType Telephone
    {
        get
        {
            return this.telephoneField;
        }
        set
        {
            this.telephoneField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public TelefaxType Telefax
    {
        get
        {
            return this.telefaxField;
        }
        set
        {
            this.telefaxField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public ElectronicMailType ElectronicMail
    {
        get
        {
            return this.electronicMailField;
        }
        set
        {
            this.electronicMailField = value;
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

    [XmlElement("OtherCommunication")]
    public CommunicationType[] OtherCommunication
    {
        get
        {
            return this.otherCommunicationField;
        }
        set
        {
            this.otherCommunicationField = value;
        }
    }
}
