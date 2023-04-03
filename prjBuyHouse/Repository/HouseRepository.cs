﻿using Microsoft.EntityFrameworkCore;
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

        public async Task<List<HouseObject>> GetAllHouse()
        {
            var result=await this._context.HouseObjects.ToListAsync();
            return result;
        }

        public Task<HouseObject?> GetHouseObjectById(int id)
        {
            var result=this._context.HouseObjects.Where(x=>x.FId==id).FirstOrDefaultAsync();
            if (result != null)
            {
                return result;
            }
            else
            {
                throw new Exception("未找到資料");
            }
        }

        public Task<HouseObject?> GetHouseObjectByName(string name)
        {
            var result = this._context.HouseObjects.Where(x => x.FName == name).FirstOrDefaultAsync();
            if (result != null)
            {
                return result;
            }
            else
            {
                throw new Exception("未找到資料");
            }
        }

        public Task<HouseObject?> GetHouseObjectByGuid(Guid id)
        {
            var result = this._context.HouseObjects.Where(x => x.FGuid==id).FirstOrDefaultAsync();
            if (result != null)
            {
                return result;
            }
            else
            {
                throw new Exception("未找到資料");
            }
        }

        public Task<List<HouseObject>> GetHouseObjectsListByKeyword(string keyword)
        {
            var result = this._context.HouseObjects.Where(x => x.FName.Contains(keyword) || x.FDescription.Contains(keyword)).ToListAsync();
            return result;
        }

        public async Task<bool> CreateNewHouseObject(HouseObject houseObject)
        {
            await this._context.HouseObjects.AddAsync(houseObject);
            await this._context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateHouseObject(int id, HouseObject houseObject)
        {
            try
            {
                var targetHouse = await GetHouseObjectById(id);
                if (targetHouse != null)
                {
                    targetHouse.FName = houseObject.FName;
                    targetHouse.FPrice = houseObject.FPrice;
                    targetHouse.FDescription = houseObject.FDescription;
                    this._context.SaveChanges();
                    return true;
                }
                else
                {
                    throw new Exception("未找到指定房屋");
                }
            }
            catch
            {
                throw new Exception("房屋修改失敗");
            }
        }

        public async Task<bool> DeleteHouseObjectById(int id)
        {
            try 
            {
                var targetHouse = await GetHouseObjectById(id);
                if(targetHouse!=null)
                {
                    this._context.HouseObjects.Remove(targetHouse);
                    this._context.SaveChanges();
                    return true;
                }
                else
                {
                    throw new Exception("無此房屋");
                }
            }
            catch 
            {
                throw new Exception("房屋刪除失敗");
            }
        }
    }
}
