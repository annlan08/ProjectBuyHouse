namespace prjBuyHouse.Services.Interfaces
{
    public interface ISearchAddressService
    {
        Task<string> SearchCityName(int cityCode);
    }
}
