using RealEstateClassLibrary.DTOs;
using RealEstateClassLibrary.BLL;
using System.Net.Http.Json;
namespace DekhaRealEstate.Client.services.HouseServices
{

    public class HouseServices : IHouseServices
    {
        private readonly HttpClient _httpClient;

        public HouseServices(HttpClient httpClient)
        {
            _httpClient = httpClient;

        }

        public async Task<List<HouseViewModel>> GetAllHouses()
        {
            HttpResponseMessage response = await _httpClient.GetAsync("api/houses");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<List<HouseViewModel>>();
            }
            return new List<HouseViewModel>();
        }

        public async Task<HouseViewModel> GetHouseById(int id)
        {
            HttpResponseMessage response = await _httpClient.GetAsync($"api/houses/{id}");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<HouseViewModel>();
            }
            return null;
        }

        public async Task<bool> AddHouse(HouseViewModel houseViewModel)
        {
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync("api/houses", houseViewModel);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateHouse(HouseViewModel houseViewModel)
        {
            HttpResponseMessage response = await _httpClient.PutAsJsonAsync($"api/houses/{houseViewModel.Id}", houseViewModel);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteHouse(int id)
        {
            HttpResponseMessage response = await _httpClient.DeleteAsync($"api/houses/{id}");
            return response.IsSuccessStatusCode;
        }

        public async Task<List<HouseViewModel>> SearchHouses(string searchTerm)
        {
            HttpResponseMessage response = await _httpClient.GetAsync($"api/houses/search?term={searchTerm}");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<List<HouseViewModel>>();
            }
            return new List<HouseViewModel>();
        }


    }
}
