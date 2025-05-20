using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[DebuggerStepThrough]
[GeneratedCode("xsd", "4.0.30319.33440")]
[DesignerCategory("code")]
[XmlType(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[XmlRoot("BudgetAccount", IsNullable = false, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[Serializable]
public class BudgetAccountType
{
    private IDType idField;
    private BudgetYearNumericType budgetYearNumericField;
    private ClassificationSchemeType requiredClassificationSchemeField;

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
    public BudgetYearNumericType BudgetYearNumeric
    {
        get
        {
            return this.budgetYearNumericField;
        }
        set
        {
            this.budgetYearNumericField = value;
        }
    }

    public ClassificationSchemeType RequiredClassificationScheme
    {
        get
        {
            return this.requiredClassificationSchemeField;
        }
        set
        {
            this.requiredClassificationSchemeField = value;
        }
    }
}
