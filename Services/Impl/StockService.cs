// ------------------------------------------------------------
// File: StockService.cs
// Description: This class implements the IStockService interface,
//              providing methods for managing stock-related business
//              logic, including creating, updating, retrieving, and
//              deleting stock entries in the database.
// Author: Perera K.A.S.N.
// ------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using apekade.Models;
using apekade.Models.Dto;
using apekade.Models.Dto.StockDto;
using apekade.Repositories;
using apekade.Services;
using AutoMapper;
using MongoDB.Driver;

namespace apekade.Services.Impl;

public class StockService : IStockService
{
  private readonly IMapper _mapper;
  private readonly IMongoCollection<Stock> _stocks;

  public StockService(IMapper mapper, IMongoDatabase database)
  {
    _mapper = mapper;
    _stocks = database.GetCollection<Stock>("Stocks");
  }

  // Method to create a new stock entry in the database
  public async Task<ApiRes> CreateStock(CreateStockReqDto createStockReqDto)
  {
    try
    {
      var newStock = new Stock
      {
        Id = createStockReqDto.ProductId,
        ProductId = createStockReqDto.ProductId,
        SubCategory = createStockReqDto.SubCategory,
        Category = createStockReqDto.Category,
        Quantity = createStockReqDto.Quantity,
      };
      await _stocks.InsertOneAsync(newStock);
      return new ApiRes(201, true, "Stock created successfully", new { });
    }
    catch (Exception ex)
    {
      return new ApiRes(500, false, ex.Message, new { });
    }
  }

  // Method to update an existing stock entry in the database
  public async Task<ApiRes> UpdateStock(string stockId, UpdateStockReqDto updateStockReqDto)
  {
    try
    {
      var stock = await _stocks.Find(s => s.Id == stockId).FirstOrDefaultAsync();
      if (stock == null)
      {
        return new ApiRes(404, false, "Stock not found", new { });
      }

      var updatedStock = new Stock
      {
        Id = stock.Id,
        ProductId = stock.ProductId,
        SubCategory = updateStockReqDto.SubCategory,
        Category = updateStockReqDto.Category,
        Quantity = stock.Quantity,
        LowStockAlert = stock.LowStockAlert
      };
      
      await _stocks.ReplaceOneAsync(s => s.Id == stockId, updatedStock);
      return new ApiRes(200, true, "Stock updated successfully", new { });
    }
    catch (Exception ex)
    {
      return new ApiRes(500, false, ex.Message, new { });
    }
  }
  
  public async Task<ApiRes> UpdateStockQuantity(string stockId, UpdateStockQtyReqDto updateStockQtyReqDto)
  {
    try
    {
      var stock = await _stocks.Find(s => s.Id == stockId).FirstOrDefaultAsync();
      if (stock == null)
      {
        return new ApiRes(404, false, "Stock not found", new { });
      }

      var updatedStock = new Stock
      {
        Id = stock.Id,
        ProductId = stock.ProductId,
        SubCategory = stock.SubCategory,
        Category = stock.Category,
        Quantity = updateStockQtyReqDto.Quantity,
        LowStockAlert = stock.LowStockAlert
      };
      
      await _stocks.ReplaceOneAsync(s => s.Id == stockId, updatedStock);
      return new ApiRes(200, true, "Stock qty updated successfully", new { });
    }
    catch (Exception ex)
    {
      return new ApiRes(500, false, ex.Message, new { });
    }
  }
  
  public async Task<ApiRes> UpdateLowStockAlert(string stockId, UpdateLowStockAlertReqDto updateLowStockAlertReqDto)
  {
    try
    {
      var stock = await _stocks.Find(s => s.Id == stockId).FirstOrDefaultAsync();
      if (stock == null)
      {
        return new ApiRes(404, false, "Stock not found", new { });
      }

      var updatedStock = new Stock
      {
        Id = stock.Id,
        ProductId = stock.ProductId,
        SubCategory = stock.SubCategory,
        Category = stock.Category,
        Quantity = stock.Quantity,
        LowStockAlert = updateLowStockAlertReqDto.LowStockAlert
      };
      
      await _stocks.ReplaceOneAsync(s => s.Id == stockId, updatedStock);
      return new ApiRes(200, true, "Stock qty updated successfully", new { });
    }
    catch (Exception ex)
    {
      return new ApiRes(500, false, ex.Message, new { });
    }
  }

  // Method to retrieve a list of all stock entries from the database
  public async Task<ApiRes> GetAllStocks()
  {
    try
    {
      var stocks = await _stocks.Find(_ => true).ToListAsync();
      return new ApiRes(200, true, "Stocks retrieved successfully", stocks);
    }
    catch (Exception ex)
    {
      return new ApiRes(500, false, ex.Message, new { });
    }
  }

  // Method to retrieve a stock entry by its ID
  public async Task<ApiRes> GetStockById(string stockId)
  {
    try
    {
      var stock = await _stocks.Find(s => s.Id == stockId).FirstOrDefaultAsync();
      if (stock == null)
      {
        return new ApiRes(404, false, "Stock not found", new { });
      }
      return new ApiRes(200, true, "Stock retrieved successfully", stock);
    }
    catch (Exception ex)
    {
      return new ApiRes(500, false, ex.Message, new { });
    }
  }

  // Method to delete a stock entry by its ID
  public async Task<ApiRes> DeleteStock(string stockId)
  {
    try
    {
      var stock = await _stocks.Find(s => s.Id == stockId).FirstOrDefaultAsync();
      if (stock == null)
      {
        return new ApiRes(404, false, "Stock not found", new { });
      }
      
      var result = await _stocks.DeleteOneAsync(s => s.Id == stockId);
      if (result.DeletedCount == 0)
      {
        return new ApiRes(404, false, "Stock not found", new { });
      }
      return new ApiRes(200, true, "Stock deleted successfully", new { });
    }
    catch (Exception ex)
    {
      return new ApiRes(500, false, ex.Message, new { });
    }
  }
}

