using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[GeneratedCode("xsd", "4.0.30319.33440")]
[DesignerCategory("code")]
[DebuggerStepThrough]
[XmlType(Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[XmlRoot("CataloguePricingUpdateLine", IsNullable = false, Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
[Serializable]
public class CataloguePricingUpdateLineType
{
  private IDType idField;
  private CustomerPartyType contractorCustomerPartyField;
  private SupplierPartyType sellerSupplierPartyField;
  private ItemLocationQuantityType[] requiredItemLocationQuantityField;

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

  public CustomerPartyType ContractorCustomerParty
  {
    get
    {
      return this.contractorCustomerPartyField;
    }
    set
    {
      this.contractorCustomerPartyField = value;
    }
  }

  public SupplierPartyType SellerSupplierParty
  {
    get
    {
      return this.sellerSupplierPartyField;
    }
    set
    {
      this.sellerSupplierPartyField = value;
    }
  }

  [XmlElement("RequiredItemLocationQuantity")]
  public ItemLocationQuantityType[] RequiredItemLocationQuantity
  {
    get
    {
      return this.requiredItemLocationQuantityField;
    }
    set
    {
      this.requiredItemLocationQuantityField = value;
    }
  }
}
