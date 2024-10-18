// ------------------------------------------------------------
// File: IStockService.cs
// Description: This interface defines the operations for managing
//              stock-related business logic, including creating,
//              updating, retrieving, and deleting stock entries.
// Author: Perera K.A.S.N.
// ------------------------------------------------------------

using System;
using apekade.Models.Dto;
using apekade.Models.Dto.StockDto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace apekade.Services;

public interface IStockService
{
  // Method to create a new stock entry in the database
  Task<ApiRes> CreateStock(CreateStockReqDto createStockReqDto);

  // Method to update an existing stock entry
  Task<ApiRes> UpdateStock(string stockId, UpdateStockReqDto updateStockReqDto);

  Task<ApiRes> UpdateLowStockAlert(string stockId, UpdateLowStockAlertReqDto updateLowStockAlertReqDto);

  Task<ApiRes> UpdateStockQuantity(string stockId, UpdateStockQtyReqDto updateStockQtyReqDto);

  // Method to retrieve a list of all stock entries
  Task<ApiRes> GetAllStocks();

  // Method to retrieve a stock entry by its ID
  Task<ApiRes> GetStockById(string stockId);

  // Method to delete a stock entry by its ID
  Task<ApiRes> DeleteStock(string stockId);
}

