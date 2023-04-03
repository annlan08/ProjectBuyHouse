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
        public async Task<HouseObject> GetHouseList(int id)
        {
            var result =await _houseService.GetHouseByID(id);
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
        public async Task<HouseResponseInfo> UpdateHouse(int id, HouseInputInfo houseInputInfo) 
        {
            var result = await _houseService.UpdateHouseInfo(id, houseInputInfo);
            return result;
        }
    }
}
