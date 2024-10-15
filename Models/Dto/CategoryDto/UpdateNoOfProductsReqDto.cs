public class UpdateNoOfProductsReqDto
{
  public string CategoryId { get; set; }   // MongoDB ObjectId of the category
  public string SubCategoryId { get; set; }   // MongoDB ObjectId of the subcategory
  public int Amount { get; set; }  // Amount to add to NoOfProducts
}
