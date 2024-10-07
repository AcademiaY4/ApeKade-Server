using System;
using apekade.Models.Dto;
using apekade.Models.Dto.StockDto;

namespace apekade.Services;

public interface IStockService
{ 
  Task<ApiRes> CreateStock(CreateStockReqDto createStockReqDto);
}