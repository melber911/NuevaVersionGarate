using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[XmlType(Namespace = "http://uri.etsi.org/01903/v1.3.2#")]
[GeneratedCode("xsd", "4.0.30319.33440")]
[DebuggerStepThrough]
[DesignerCategory("code")]
[Serializable]
public class NoticeReferenceType
{
    private string organizationField;
    private string[] noticeNumbersField;

    public string Organization
    {
        get
        {
            return this.organizationField;
        }
        set
        {
            this.organizationField = value;
        }
    }

    [XmlArrayItem("int", DataType = "integer", IsNullable = false)]
    public string[] NoticeNumbers
    {
        get
        {
            return this.noticeNumbersField;
        }
        set
        {
            this.noticeNumbersField = value;
        }
    }
}
