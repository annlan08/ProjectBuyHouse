using prjBuyHouse.Models;

namespace prjBuyHouse.Repository.Interfaces
{
    public interface IHouseRepository
    {
        Task<List<HouseObject>> GetAllHouse();
        Task<HouseObject> GetHouseObjectById(int id);
        Task<bool> CreateNewHouseObject(HouseObject houseObject);
        Task<bool> UpdateHouseObject(int id, HouseObject houseObject);
        Task<bool> DeleteHouseObjectById(int id);
    }
}
