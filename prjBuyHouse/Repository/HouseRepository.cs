using prjBuyHouse.Models;
using prjBuyHouse.Repository.Interfaces;

namespace prjBuyHouse.Repository
{
    public class HouseRepository:IHouseRepository
    {
        private HouseContext _context;
        public HouseRepository(HouseContext context) 
        {
            this._context = context;
        }

        public async Task<HouseObject> GetHouseObjectById(int id)
        {
            var result=this._context.HouseObjects.Where(x=>x.FId==id).FirstOrDefault();
            return result;
        }

        public async Task<bool> CreateNewHouseObject(HouseObject houseObject)
        {
            try
            {
                this._context.HouseObjects.Add(houseObject);
                this._context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> UpdateHouseObject(int id, HouseObject houseObject)
        {
            try
            {
                var targetHouse = this._context.HouseObjects.Where(x => x.FId == id).FirstOrDefault();
                targetHouse.FName= houseObject.FName;
                targetHouse.FPrice= houseObject.FPrice;
                targetHouse.FDescription= houseObject.FDescription;
                this._context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> DeleteHouseObjectById(int id)
        {
            try 
            {
                var targetHouse = this._context.HouseObjects.Where(x => x.FId == id).FirstOrDefault();
                if(targetHouse!=null)
                {
                    this._context.HouseObjects.Remove(targetHouse);
                    this._context.SaveChanges();
                    return true;
                }
                else
                {
                    throw new NullReferenceException();
                }
            }
            catch 
            {
                return false;
            }
        }
    }
}
