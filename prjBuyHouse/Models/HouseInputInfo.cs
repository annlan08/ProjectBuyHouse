namespace prjBuyHouse.Models
{
    public class HouseInputInfo
    {
        /// <summary>
        /// 如需使用Update更新功能，需填入(更新的目標房屋ID)
        /// </summary>
        public int? UpdateHouseID { get; set; } = null;

        public string? HouseName { get; set; }

        public decimal HousePrice { get; set; }

        public string? HouseDescription { get; set;}
    }
}
