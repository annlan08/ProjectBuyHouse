using prjBuyHouse.Models;

namespace prjBuyHouse.Repository.Interfaces
{
    public interface IHouseRepository
    {
        Task<List<HouseObject>> GetAllHouse();
        Task<HouseObject> GetHouseObjectById(int id);
        Task<HouseObject> GetHouseObjectByName(string name);
        Task<HouseObject> GetHouseObjectByGuid(Guid id);
        Task<List<HouseObject>> GetHouseObjectsListByKeyword(string keyword);
        Task<bool> CreateNewHouseObject(HouseObject houseObject);
        Task<bool> UpdateHouseObject(int id, HouseObject houseObject);
        Task<bool> DeleteHouseObjectById(int id);
    }
}
