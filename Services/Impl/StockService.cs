using System;
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

  public StockService (IMapper mapper, IMongoDatabase database)
  {
    _mapper = mapper;
    _stocks = database.GetCollection<Stock>("Stocks");
  }
  public async Task<ApiRes> CreateStock(CreateStockReqDto createStockReqDto)
  {
    try
    {
      var newStock = _mapper.Map<Stock>(createStockReqDto);
      await _stocks.InsertOneAsync(newStock);
      return new ApiRes(201, true, "Stock created successfully", new { });
    }
    catch (Exception ex)
    {
      return new ApiRes(500, false, ex.Message, new { });
    }
  }
}