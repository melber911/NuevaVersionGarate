using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[GeneratedCode("xsd", "4.0.30319.33440")]
[DesignerCategory("code")]
[XmlType(Namespace = "http://uri.etsi.org/01903/v1.3.2#")]
[XmlRoot("SPUserNotice", IsNullable = false, Namespace = "http://uri.etsi.org/01903/v1.3.2#")]
[DebuggerStepThrough]
[Serializable]
public class SPUserNoticeType
{
    private NoticeReferenceType noticeRefField;
    private string explicitTextField;

    public NoticeReferenceType NoticeRef
    {
        get
        {
            return this.noticeRefField;
        }
        set
        {
            this.noticeRefField = value;
        }
    }

    public string ExplicitText
    {
        get
        {
            return this.explicitTextField;
        }
        set
        {
            this.explicitTextField = value;
        }
    }
}
