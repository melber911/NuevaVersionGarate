using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[DebuggerStepThrough]
[DesignerCategory("code")]
[XmlRoot("Declaration", IsNullable = false, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[XmlType(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[GeneratedCode("xsd", "4.0.30319.33440")]
[Serializable]
public class DeclarationType
{
    private NameType1[] nameField;
    private DeclarationTypeCodeType declarationTypeCodeField;
    private DescriptionType[] descriptionField;
    private EvidenceSuppliedType[] evidenceSuppliedField;

    [XmlElement("Name", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public NameType1[] Name
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
    public DeclarationTypeCodeType DeclarationTypeCode
    {
        get
        {
            return this.declarationTypeCodeField;
        }
        set
        {
            this.declarationTypeCodeField = value;
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

    [XmlElement("EvidenceSupplied")]
    public EvidenceSuppliedType[] EvidenceSupplied
    {
        get
        {
            return this.evidenceSuppliedField;
        }
        set
        {
            this.evidenceSuppliedField = value;
        }
    }
}
