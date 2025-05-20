using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[DebuggerStepThrough]
[XmlRoot("EventTacticEnumeration", IsNullable = false, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[GeneratedCode("xsd", "4.0.30319.33440")]
[XmlType(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[DesignerCategory("code")]
[Serializable]
public class EventTacticEnumerationType
{
    private ConsumerIncentiveTacticTypeCodeType consumerIncentiveTacticTypeCodeField;
    private DisplayTacticTypeCodeType displayTacticTypeCodeField;
    private FeatureTacticTypeCodeType featureTacticTypeCodeField;
    private TradeItemPackingLabelingTypeCodeType tradeItemPackingLabelingTypeCodeField;

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public ConsumerIncentiveTacticTypeCodeType ConsumerIncentiveTacticTypeCode
    {
        get
        {
            return this.consumerIncentiveTacticTypeCodeField;
        }
        set
        {
            this.consumerIncentiveTacticTypeCodeField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public DisplayTacticTypeCodeType DisplayTacticTypeCode
    {
        get
        {
            return this.displayTacticTypeCodeField;
        }
        set
        {
            this.displayTacticTypeCodeField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public FeatureTacticTypeCodeType FeatureTacticTypeCode
    {
        get
        {
            return this.featureTacticTypeCodeField;
        }
        set
        {
            this.featureTacticTypeCodeField = value;
        }
    }

    [XmlElement(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    public TradeItemPackingLabelingTypeCodeType TradeItemPackingLabelingTypeCode
    {
        get
        {
            return this.tradeItemPackingLabelingTypeCodeField;
        }
        set
        {
            this.tradeItemPackingLabelingTypeCodeField = value;
        }
    }
}
