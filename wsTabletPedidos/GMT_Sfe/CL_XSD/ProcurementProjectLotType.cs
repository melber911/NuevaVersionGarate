using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[GeneratedCode("xsd", "4.0.30319.33440")]
[DesignerCategory("code")]
[XmlRoot("InterestedProcurementProjectLot", IsNullable = false, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[DebuggerStepThrough]
[XmlType(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[Serializable]
public class ProcurementProjectLotType
{
    private IDType idField;
    private TenderingTermsType tenderingTermsField;
    private ProcurementProjectType procurementProjectField;

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

    public TenderingTermsType TenderingTerms
    {
        get
        {
            return this.tenderingTermsField;
        }
        set
        {
            this.tenderingTermsField = value;
        }
    }

    public ProcurementProjectType ProcurementProject
    {
        get
        {
            return this.procurementProjectField;
        }
        set
        {
            this.procurementProjectField = value;
        }
    }
}
