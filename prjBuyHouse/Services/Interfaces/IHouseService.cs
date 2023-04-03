using prjBuyHouse.Models;

namespace prjBuyHouse.Services.Interfaces
{
    public interface IHouseService
    {
        Task<List<HouseObject>> GetHouse();
        Task<HouseResponseInfo> GetHouseByID(int id);
        Task<HouseResponseInfo> CreateNewHouseObject(HouseInputInfo houseInputInfo);
        Task<HouseResponseInfo> UpdateHouseInfo(HouseInputInfo houseInputInfo);
        Task<HouseResponseInfo> DeleteHouseByID(int id);
    }
}
