using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[XmlRoot("VoidedDocumentsLine", IsNullable = false, Namespace = "urn:sunat:names:specification:ubl:peru:schema:xsd:SunatAggregateComponents-1")]
[DebuggerStepThrough]
[XmlType(Namespace = "urn:sunat:names:specification:ubl:peru:schema:xsd:SunatAggregateComponents-1")]
[GeneratedCode("xsd", "4.0.30319.1")]
[DesignerCategory("code")]
[Serializable]
public class VoidedDocumentsLineType
{
    private LineIDType lineIDField;
    private DocumentTypeCodeType documentTypeCodeField;
    private identifierFieldType documentSerialIDField;
    private identifierFieldType documentNumberIDField;
    private TextType voidReasonDescriptionField;

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public LineIDType LineID
    {
        get
        {
            return this.lineIDField;
        }
        set
        {
            this.lineIDField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public DocumentTypeCodeType DocumentTypeCode
    {
        get
        {
            return this.documentTypeCodeField;
        }
        set
        {
            this.documentTypeCodeField = value;
        }
    }

    public identifierFieldType DocumentSerialID
    {
        get
        {
            return this.documentSerialIDField;
        }
        set
        {
            this.documentSerialIDField = value;
        }
    }

    public identifierFieldType DocumentNumberID
    {
        get
        {
            return this.documentNumberIDField;
        }
        set
        {
            this.documentNumberIDField = value;
        }
    }

    public TextType VoidReasonDescription
    {
        get
        {
            return this.voidReasonDescriptionField;
        }
        set
        {
            this.voidReasonDescriptionField = value;
        }
    }
}
