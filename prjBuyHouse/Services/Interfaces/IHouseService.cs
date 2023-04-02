﻿using prjBuyHouse.Models;

namespace prjBuyHouse.Services.Interfaces
{
    public interface IHouseService
    {
        Task<List<HouseObject>> GetHouse();
        Task<HouseObject> GetHouseByID(int id);
        Task<HouseResponseInfo> CreateNewHouseObject(HouseObject houseObject);
        Task<HouseResponseInfo> UpdateHouseInfo(int id, HouseObject newHouseInfo);
        Task<HouseResponseInfo> DeleteHouseByID(int id);
    }
}
