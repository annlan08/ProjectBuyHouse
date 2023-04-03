namespace prjBuyHouse.Models
{
    public class HouseResponseInfo
    {
        public bool IsSuccess { get; set; }
        public string? ErrorInfo { get; set; }
        public HouseObject? HouseResponseObject { get; set; }=null;
        public List<HouseObject>? HouseResponseList { get; set; } = null;
    }

    //public class HouseResponseObject
    //{
    //    public Guid FGuid { get; set; }

    //    public string FName { get; set; } = null!;

    //    public decimal FPrice { get; set; }

    //    public string FDescription { get; set; } = null!;
    //}

}
