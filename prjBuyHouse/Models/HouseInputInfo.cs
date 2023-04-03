namespace prjBuyHouse.Models
{
    public class HouseInputInfo
    {
        public int? UpdateHouseID { get; set; } = null;

        public string HouseName { get; set; }

        public decimal HousePrice { get; set; }

        public string HouseDescription { get; set;}
    }
}
