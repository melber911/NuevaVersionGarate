using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[XmlRoot("TenderPreparation", IsNullable = false, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[GeneratedCode("xsd", "4.0.30319.33440")]
[DebuggerStepThrough]
[DesignerCategory("code")]
[XmlType(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[Serializable]
public class TenderPreparationType
{
    private TenderEnvelopeIDType tenderEnvelopeIDField;
    private TenderEnvelopeTypeCodeType tenderEnvelopeTypeCodeField;
    private DescriptionType[] descriptionField;
    private OpenTenderIDType openTenderIDField;
    private ProcurementProjectLotType[] procurementProjectLotField;
    private TenderRequirementType[] documentTenderRequirementField;

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public TenderEnvelopeIDType TenderEnvelopeID
    {
        get
        {
            return this.tenderEnvelopeIDField;
        }
        set
        {
            this.tenderEnvelopeIDField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public TenderEnvelopeTypeCodeType TenderEnvelopeTypeCode
    {
        get
        {
            return this.tenderEnvelopeTypeCodeField;
        }
        set
        {
            this.tenderEnvelopeTypeCodeField = value;
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

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public OpenTenderIDType OpenTenderID
    {
        get
        {
            return this.openTenderIDField;
        }
        set
        {
            this.openTenderIDField = value;
        }
    }

    [XmlElement("ProcurementProjectLot")]
    public ProcurementProjectLotType[] ProcurementProjectLot
    {
        get
        {
            return this.procurementProjectLotField;
        }
        set
        {
            this.procurementProjectLotField = value;
        }
    }

    [XmlElement("DocumentTenderRequirement")]
    public TenderRequirementType[] DocumentTenderRequirement
    {
        get
        {
            return this.documentTenderRequirementField;
        }
        set
        {
            this.documentTenderRequirementField = value;
        }
    }
}
