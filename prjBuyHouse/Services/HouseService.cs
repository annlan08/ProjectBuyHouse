using prjBuyHouse.Models;
using prjBuyHouse.Repository;
using prjBuyHouse.Repository.Interfaces;
using prjBuyHouse.Services.Interfaces;

namespace prjBuyHouse.Services
{
    public class HouseService : IHouseService
    {
        private readonly IHouseRepository _houseRepository;
        public HouseService(IHouseRepository houseRepository) 
        {
            this._houseRepository = houseRepository;
        }

        public async Task<List<HouseObject>> GetHouse()
        {
            var result=await this._houseRepository.GetAllHouse();
            return result;
        }

        public async Task<HouseResponseInfo> GetHouseByID(int id)
        {
            var result = new HouseResponseInfo();
            try
            {              
                result.HouseResponseObject = await this._houseRepository.GetHouseObjectById(id);
                if (result.HouseResponseObject != null)
                {
                    result.IsSuccess = true;
                }
                else
                {
                    throw new Exception("未找到資料");
                }
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.ErrorInfo = ex.Message;
            }
            return result;

        }

        public async Task<HouseResponseInfo> CreateNewHouseObject(HouseInputInfo houseInputInfo)
        {
            HouseResponseInfo responseInfo= new HouseResponseInfo();
            HouseObject houseObject= new HouseObject()
            {
                FGuid=Guid.NewGuid(),
                FName=houseInputInfo.HouseName,
                FPrice=houseInputInfo.HousePrice,
                FDescription=houseInputInfo.HouseDescription,
            };
            try
            {
                responseInfo.IsSuccess = await this._houseRepository.CreateNewHouseObject(houseObject);
                if (responseInfo.IsSuccess == true)
                {
                    return responseInfo;
                }
                else
                {
                    responseInfo.ErrorInfo = "未預期錯誤，請回報管理員";
                    return responseInfo;
                }
            }
            catch (Exception ex)
            {
                responseInfo.IsSuccess = false;
                responseInfo.ErrorInfo = ex.Message.ToString();
            }
            return responseInfo;
        }

        public async Task<HouseResponseInfo> UpdateHouseInfo(int id, HouseInputInfo houseInputInfo)
        {
            HouseResponseInfo responseInfo = new HouseResponseInfo();
            HouseObject houseObject = new HouseObject()
            {
                FName = houseInputInfo.HouseName,
                FPrice = houseInputInfo.HousePrice,
                FDescription = houseInputInfo.HouseDescription,
            };
            try
            {

                responseInfo.IsSuccess = await this._houseRepository.UpdateHouseObject(id, houseObject);
                if (responseInfo.IsSuccess == true)
                {
                    return responseInfo;
                }
                else
                {
                    responseInfo.ErrorInfo = "未預期錯誤，請回報管理員";
                    return responseInfo;
                }
            }
            catch (Exception ex)
            {
                responseInfo.IsSuccess = false;
                responseInfo.ErrorInfo = ex.Message.ToString();
            }
            return responseInfo;
        }

        public async Task<HouseResponseInfo> DeleteHouseByID(int id)
        {
            HouseResponseInfo responseInfo = new HouseResponseInfo();
            try
            {
                responseInfo.IsSuccess = await this._houseRepository.DeleteHouseObjectById(id);
                if (responseInfo.IsSuccess == true)
                {
                    return responseInfo;
                }
                else
                {
                    responseInfo.ErrorInfo = "未預期錯誤，請回報管理員";
                    return responseInfo;
                }
            }
            catch (Exception ex)
            {
                responseInfo.IsSuccess = false;
                responseInfo.ErrorInfo = ex.Message.ToString();
            }
            return responseInfo;
        }
    }
}
