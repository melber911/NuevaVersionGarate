using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[DesignerCategory("code")]
[DebuggerStepThrough]
[XmlRoot("UBLDocumentSignatures", IsNullable = false, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonSignatureComponents-2")]
[GeneratedCode("xsd", "4.0.30319.33440")]
[XmlType(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonSignatureComponents-2")]
[Serializable]
public class UBLDocumentSignaturesType
{
    private SignatureInformationType[] signatureInformationField;

    [XmlElement("SignatureInformation", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:SignatureAggregateComponents-2")]
    public SignatureInformationType[] SignatureInformation
    {
        get
        {
            return this.signatureInformationField;
        }
        set
        {
            this.signatureInformationField = value;
        }
    }
}
