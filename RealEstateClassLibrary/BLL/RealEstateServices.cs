using RealEstateClassLibrary.DAL;
using RealEstateClassLibrary.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateClassLibrary.BLL
{
    public class RealEstateServices : IRealEstateServices
    {
        private readonly RealEstateContext _context;

        public RealEstateServices(RealEstateContext realEstateContext)
        {
            _context = realEstateContext;

        }

        public List<House> GetAllHouses()
        {
            return _context.Houses.ToList();
        }

        public House GetHouseById(int id)
        {
            return _context.Houses.FirstOrDefault(h => h.Id == id);
        }

        public bool AddHouse(HouseViewModel houseViewModel)
        {
            var house = new House
            {
                Name = houseViewModel.Name,
                Mode = houseViewModel.Mode,
                Type = houseViewModel.Type,
                Price = houseViewModel.Price,
                Location = houseViewModel.Location,
                Size = houseViewModel.Size,
                NoOfBeds = houseViewModel.NoOfBeds,
                NoOfBaths = houseViewModel.NoOfBaths,
                Image = houseViewModel.Image,
                Description = houseViewModel.Description,
                CreatedDate = DateTime.Now
            };
            _context.Houses.Add(house);
            return _context.SaveChanges() > 0;
        }

        public bool UpdateHouse(HouseViewModel houseViewModel)
        {
            var house = _context.Houses.FirstOrDefault(h => h.Id == houseViewModel.Id);
            if (house == null)
            {
                return false;
            }
            house.Name = houseViewModel.Name;
            house.Mode = houseViewModel.Mode;
            house.Type = houseViewModel.Type;
            house.Price = houseViewModel.Price;
            house.Location = houseViewModel.Location;
            house.Size = houseViewModel.Size;
            house.NoOfBeds = houseViewModel.NoOfBeds;
            house.NoOfBaths = houseViewModel.NoOfBaths;
            house.Image = houseViewModel.Image;
            house.Description = houseViewModel.Description;
            return _context.SaveChanges() > 0;
        }

        public bool DeleteHouse(int id)
        {
            var house = _context.Houses.FirstOrDefault(h => h.Id == id);
            if (house == null)
            {
                return false;
            }
            _context.Houses.Remove(house);
            return _context.SaveChanges() > 0;
        }

        public List<House> SearchHouses(string searchTerm)
        {
            return _context.Houses
                .Where(h => h.Name.ToLower().Contains(searchTerm.ToLower()) || h.Location.Contains(searchTerm.ToLower()))
                .ToList();
        }
    }
}
