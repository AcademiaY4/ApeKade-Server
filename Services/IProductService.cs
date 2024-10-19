using apekade.Models.Dto;
using apekade.Models.Dto.ProductDto;

public interface IProductService
{
  Task<ApiRes> CreateProduct(CreateProductReqDto createProductReqDto);
  Task<ApiRes> GetAllProducts();
  Task<ApiRes> GetProductById(string productId);
  Task<ApiRes> UpdateProduct(string productId, UpdateProductReqDto updateProductReqDto);
  Task<ApiRes> DeleteProduct(string productId);
  
}