using RealEstateClassLibrary.DTOs;

namespace DekhaRealEstate.Client.services.HouseServices
{
    public interface IHouseServices
    {
        Task<bool> AddHouse(HouseViewModel houseViewModel);
        Task<bool> DeleteHouse(int id);
        Task<List<HouseViewModel>> GetAllHouses();
        Task<HouseViewModel> GetHouseById(int id);
        Task<List<HouseViewModel>> SearchHouses(string searchTerm);
        Task<bool> UpdateHouse(HouseViewModel houseViewModel);
    }
}