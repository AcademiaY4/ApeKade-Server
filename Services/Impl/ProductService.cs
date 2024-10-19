using apekade.Models;
using apekade.Models.Dto;
using apekade.Models.Dto.ProductDto;
using AutoMapper;
using MongoDB.Bson.IO;
using MongoDB.Driver;

namespace apekade.Services.Impl;

public class ProductService : IProductService
{
  private readonly IMapper _mapper;
  private readonly IMongoCollection<Product> _products;

  // Constructor to initialize the service with database collection and mapper
  public ProductService(IMapper mapper, IMongoDatabase database)
  {
    _mapper = mapper;
    _products = database.GetCollection<Product>("Products");
  }
  public async Task<ApiRes> CreateProduct(CreateProductReqDto createProductReqDto)
  {
    try
    {
      // Validate that the DTO is not null and contains required fields
      if (createProductReqDto == null || string.IsNullOrWhiteSpace(createProductReqDto.Name) || createProductReqDto.Price <= 0 || createProductReqDto.Quantity <= 0)
      {
        return new ApiRes(400, false, "Invalid input data", new { });
      }

      var newProduct = new Product
      {
        Name = createProductReqDto.Name,
        Price = createProductReqDto.Price,
        Discount = createProductReqDto.Discount,
        Description = createProductReqDto.Description,
        Quantity = createProductReqDto.Quantity,
        ImageUrl = createProductReqDto.ImageUrl,
        Colors = createProductReqDto.Colors,
        Sizes = createProductReqDto.Sizes,
        Category = createProductReqDto.Category,
        SubCategory = createProductReqDto.SubCategory,
        Brand = createProductReqDto.Brand,
        VendorID = createProductReqDto.VendorID
      };

      await _products.InsertOneAsync(newProduct);

      return new ApiRes(201, true, "Product created successfully", new { ProductId = newProduct.Id });
    }
    catch (Exception ex)
    {
      return new ApiRes(500, false, ex.Message, new { });
    }
  }

  public async Task<ApiRes> GetAllProducts()
  {
    try
    {
      var products = await _products.Find(_ => true).ToListAsync();
      return new ApiRes(200, true, "Products retrieved successfully", products);
    }
    catch (Exception ex)
    {
      return new ApiRes(500, false, ex.Message, new { });
    }
  }

  public async Task<ApiRes> GetProductById(string productId)
  {
    try
    {
      var product = await _products.Find(p => p.Id == productId).FirstOrDefaultAsync();
      if (product == null)
      {
        return new ApiRes(404, false, "Product not found", new { });
      }
      return new ApiRes(200, true, "Product retrieved successfully", product);
    }
    catch (Exception ex)
    {
      return new ApiRes(500, false, ex.Message, new { });
    }
  }

  public async Task<ApiRes> DeleteProduct(string productId)
  {
    try
    {
      var product = await _products.Find(p => p.Id == productId).FirstOrDefaultAsync();
      if (product == null)
      {
        return new ApiRes(404, false, "Product not found", new { });
      }

      var result = await _products.DeleteOneAsync(s => s.Id == productId);
      if (result.DeletedCount == 0)
      {
        return new ApiRes(404, false, "Product not found", new { });
      }
      return new ApiRes(200, true, "Product  deleted successfully", new { });
    }
    catch (Exception ex)
    {
      return new ApiRes(500, false, ex.Message, new { });
    }
  }

  public Task<ApiRes> UpdateProduct(string productId, UpdateProductReqDto updateProductReqDto)
  {
    throw new NotImplementedException();
  }
}