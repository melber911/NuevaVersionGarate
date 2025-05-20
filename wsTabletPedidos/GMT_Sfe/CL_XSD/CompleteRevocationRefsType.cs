using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[XmlRoot("CompleteRevocationRefs", IsNullable = false, Namespace = "http://uri.etsi.org/01903/v1.3.2#")]
[DebuggerStepThrough]
[XmlType(Namespace = "http://uri.etsi.org/01903/v1.3.2#")]
[GeneratedCode("xsd", "4.0.30319.33440")]
[DesignerCategory("code")]
[Serializable]
public class CompleteRevocationRefsType
{
    private CRLRefType[] cRLRefsField;
    private OCSPRefType[] oCSPRefsField;
    private AnyType[] otherRefsField;
    private string idField;

    [XmlArrayItem("CRLRef", IsNullable = false)]
    public CRLRefType[] CRLRefs
    {
        get
        {
            return this.cRLRefsField;
        }
        set
        {
            this.cRLRefsField = value;
        }
    }

    [XmlArrayItem("OCSPRef", IsNullable = false)]
    public OCSPRefType[] OCSPRefs
    {
        get
        {
            return this.oCSPRefsField;
        }
        set
        {
            this.oCSPRefsField = value;
        }
    }

    [XmlArrayItem("OtherRef", IsNullable = false)]
    public AnyType[] OtherRefs
    {
        get
        {
            return this.otherRefsField;
        }
        set
        {
            this.otherRefsField = value;
        }
    }

    [XmlAttribute(DataType = "ID")]
    public string Id
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
}
