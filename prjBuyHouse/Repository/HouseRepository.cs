using Microsoft.EntityFrameworkCore;
using prjBuyHouse.Models;
using prjBuyHouse.Repository.Interfaces;
using Dapper;
using Microsoft.Data.SqlClient;

namespace prjBuyHouse.Repository
{
    public class HouseRepository:IHouseRepository
    {
        private HouseContext _context;
        private string? _connectionString;

        public HouseRepository(HouseContext context, string? connectionString)
        {
            this._context = context;
            this._connectionString = connectionString;
        }

        public async Task<List<HouseObject>> GetAllHouse()
        {
            //var result=await this._context.HouseObjects.ToListAsync();
            //return result;
            using(var conn=new SqlConnection(_connectionString))
            {
                var sql = "SELECT * FROM [House].[dbo].[HouseObject]";
                var results = await conn.QueryAsync<HouseObject>(sql);
                return results.ToList();
            }
        }

        public async Task<HouseObject> GetHouseObjectById(int id)
        {
            //var result=this._context.HouseObjects.Where(x=>x.FId==id).FirstOrDefaultAsync();
            using (var conn=new SqlConnection(_connectionString))
            {
                string sql = "SELECT * FROM [House].[dbo].[HouseObject] " +
                             "WHERE fId = @fid";
                var result = conn.QueryFirstOrDefaultAsync<HouseObject>(sql, new { fid = id });
                if (result != null)
                {
                    return await result;
                }
                else
                {
                    throw new Exception("未找到資料");
                }
            }

        }

        public async Task<HouseObject> GetHouseObjectByName(string name)
        {
            //var result = this._context.HouseObjects.Where(x => x.FName == name).FirstOrDefaultAsync();
            using (var conn = new SqlConnection(_connectionString))
            {
                string sql = "SELECT * FROM [House].[dbo].[HouseObject] " +
                             "WHERE fName = @fname";
                var result = conn.QueryFirstOrDefaultAsync<HouseObject>(sql, new { fname = name });
                if (result != null)
                {
                    return await result;
                }
                else
                {
                    throw new Exception("未找到資料");
                }
            }
        }

        public async Task<HouseObject> GetHouseObjectByGuid(Guid id)
        {
            //var result = this._context.HouseObjects.Where(x => x.FGuid==id).FirstOrDefaultAsync();
            using (var conn = new SqlConnection(_connectionString))
            {
                string sql = "SELECT * FROM [House].[dbo].[HouseObject] " +
                             "WHERE fguid = @fguid";
                var query = conn.QueryFirstOrDefaultAsync<HouseObject>(sql, new { fguid = id });
                var result = await query;
                if (result != null)
                {
                    return result;
                }
                else
                {
                    throw new Exception("未找到資料");
                }
            }
        }

        public async Task<List<HouseObject>> GetHouseObjectsListByKeyword(string keyword)
        {
            //var result = this._context.HouseObjects.Where(x => x.FName.Contains(keyword) || x.FDescription.Contains(keyword)).ToListAsync();
            using (var conn = new SqlConnection(_connectionString))
            {
                string sql = "SELECT * FROM [House].[dbo].[HouseObject] " +
                             "WHERE  (fName like @Keyword) OR (fDescription like @Keyword)";
                var result = await conn.QueryAsync<HouseObject>(sql, new { Keyword = $"%{keyword}%" });
                if (result.Count() != 0)
                {
                    return result.ToList();
                }
                else
                {
                    throw new Exception("未找到資料");
                }
            }
        }

        public async Task<bool> CreateNewHouseObject(HouseObject houseObject)
        {
            await this._context.HouseObjects.AddAsync(houseObject);
            await this._context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateHouseObject(int id, HouseObject houseObject)
        {
            var targetHouse = await GetHouseObjectById(id);
            if (targetHouse != null)
            {
                //targetHouse.FName = houseObject.FName;
                //targetHouse.FPrice = houseObject.FPrice;
                //targetHouse.FDescription = houseObject.FDescription;
                //this._context.SaveChanges();
                using (var conn = new SqlConnection(_connectionString))
                {
                    var sql = "UPDATE [dbo].[HouseObject] " +
                              "SET [fName] = @fName " +
                              ",[fPrice] = @fPrice " +
                              ",[fDescription] = @fDescription " +
                              "WHERE fId=@fid ";
                    var para = new { fName = houseObject.FName,
                                     fPrice = houseObject.FPrice,
                                     fDescription = houseObject.FDescription,
                                     fId = id };
                    conn.Execute(sql, para);
                }
                    return true;
            }
            else
            {
                throw new Exception("未找到指定房屋");
            }
        }

        public async Task<bool> DeleteHouseObjectById(int id)
        {

            var targetHouse = await GetHouseObjectById(id);
            if (targetHouse != null)
            {
                //this._context.HouseObjects.Remove(targetHouse);
                //this._context.SaveChanges();
                using (var conn = new SqlConnection(_connectionString))
                {
                    var sql = "DELETE FROM [dbo].[HouseObject] " +
                              "WHERE fId=@fid";
                    var para = new
                    {
                        fId = id
                    };
                    conn.Execute(sql, para);
                }
                return true;
            }
            else
            {
                throw new Exception("無此房屋");
            }

        }

    }
}
