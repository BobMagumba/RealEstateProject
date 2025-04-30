using RealEstateClassLibrary.DAL;
using RealEstateClassLibrary.DTOs;

namespace RealEstateClassLibrary.BLL
{
    public interface IRealEstateServices
    {
        bool AddHouse(HouseViewModel houseViewModel);
        bool DeleteHouse(int id);
        List<House> GetAllHouses();
        House GetHouseById(int id);
        List<House> SearchHouses(string searchTerm);
        bool UpdateHouse(HouseViewModel houseViewModel);
    }
}