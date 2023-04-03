using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using prjBuyHouse.Models;
using prjBuyHouse.Services.Interfaces;

namespace prjBuyHouse.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HouseController : ControllerBase
    {
        private readonly IHouseService _houseService;

        public HouseController(IHouseService houseService)
        {
            _houseService = houseService;
        }


        [HttpGet]
        public async Task<HouseResponseInfo> GetHouseList(int id)
        {
            var result =await _houseService.GetHouseByID(id);
            return result;
        }

        /// <summary>
        /// 依照type來決定依照何種方式來當關鍵字搜尋房屋
        /// </summary>
        /// <param name="keyword"></param>
        /// <param name="type">關鍵字類別 1是ID 2是GUID 3是房屋名稱 4是模糊比對</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<HouseResponseInfo> SearchHouse(string keyword, int type)
        {
            var result = await _houseService.SearchHouse(keyword, type);
            return result;
        }

        [HttpPost]
        public async Task<HouseResponseInfo> CreateNewHouse(HouseInputInfo houseInputInfo)
        {
            var result=await _houseService.CreateNewHouseObject(houseInputInfo);
            return result;
        }

        [HttpDelete]
        public async Task<HouseResponseInfo> DeleteHouse(int id)
        {
            var result = await _houseService.DeleteHouseByID(id);
            return result;
        }

        [HttpPatch]
        public async Task<HouseResponseInfo> UpdateHouse(HouseInputInfo houseInputInfo) 
        {
            var result = await _houseService.UpdateHouseInfo(houseInputInfo);
            return result;
        }
    }
}
