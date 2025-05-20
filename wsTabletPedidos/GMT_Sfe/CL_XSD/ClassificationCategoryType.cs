using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[XmlRoot("CategorizesClassificationCategory", IsNullable = false, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[DebuggerStepThrough]
[GeneratedCode("xsd", "4.0.30319.33440")]
[DesignerCategory("code")]
[XmlType(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[Serializable]
public class ClassificationCategoryType
{
    private NameType1 nameField;
    private CodeValueType codeValueField;
  private DescriptionType[] descriptionField;
    private ClassificationCategoryType[] categorizesClassificationCategoryField;

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
    public CodeValueType CodeValue
    {
        get
        {
            return this.codeValueField;
        }
        set
        {
            this.codeValueField = value;
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

    [XmlElement("CategorizesClassificationCategory")]
    public ClassificationCategoryType[] CategorizesClassificationCategory
    {
        get
        {
            return this.categorizesClassificationCategoryField;
        }
        set
        {
            this.categorizesClassificationCategoryField = value;
        }
    }
}
