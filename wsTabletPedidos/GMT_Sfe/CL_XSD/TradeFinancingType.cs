using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[XmlType(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[GeneratedCode("xsd", "4.0.30319.33440")]
[DesignerCategory("code")]
[XmlRoot("TradeFinancing", IsNullable = false, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[DebuggerStepThrough]
[Serializable]
public class TradeFinancingType
{
    private IDType idField;
    private FinancingInstrumentCodeType financingInstrumentCodeField;
    private DocumentReferenceType contractDocumentReferenceField;
    private DocumentReferenceType[] documentReferenceField;
    private PartyType financingPartyField;
    private FinancialAccountType financingFinancialAccountField;
    private ClauseType[] clauseField;

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
    public FinancingInstrumentCodeType FinancingInstrumentCode
    {
        get
        {
            return this.financingInstrumentCodeField;
        }
        set
        {
            this.financingInstrumentCodeField = value;
        }
    }

    public DocumentReferenceType ContractDocumentReference
    {
        get
        {
            return this.contractDocumentReferenceField;
        }
        set
        {
            this.contractDocumentReferenceField = value;
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

    public PartyType FinancingParty
    {
        get
        {
            return this.financingPartyField;
        }
        set
        {
            this.financingPartyField = value;
        }
    }

    public FinancialAccountType FinancingFinancialAccount
    {
        get
        {
            return this.financingFinancialAccountField;
        }
        set
        {
            this.financingFinancialAccountField = value;
        }
    }

    [XmlElement("Clause")]
    public ClauseType[] Clause
    {
        get
        {
            return this.clauseField;
        }
        set
        {
            this.clauseField = value;
        }
    }
}
