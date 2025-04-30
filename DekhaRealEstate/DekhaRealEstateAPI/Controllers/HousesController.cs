using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstateClassLibrary.BLL;
using RealEstateClassLibrary.DTOs;

namespace DekhaRealEstateAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HousesController : ControllerBase
    {
        private readonly IRealEstateServices _realEstateServices;

        public HousesController(IRealEstateServices realEstateServices)
        {
            _realEstateServices = realEstateServices;
        }

        [HttpGet]
        public IActionResult GetAllHouses()
        {
            var houses = _realEstateServices.GetAllHouses();
            return Ok(houses);
        }

        [HttpGet("{id}")]
        public IActionResult GetHouseById(int id)
        {
            var house = _realEstateServices.GetHouseById(id);
            if (house == null)
            {
                return NotFound();
            }
            return Ok(house);
        }

        [HttpPost]
        public IActionResult AddHouse([FromBody] HouseViewModel houseViewModel)
        {
            if (houseViewModel == null)
            {
                return BadRequest("House data is null");
            }
            var result = _realEstateServices.AddHouse(houseViewModel);
            if (result)
            {
                return CreatedAtAction(nameof(GetHouseById), new { id = houseViewModel.Id }, houseViewModel);
            }
            return BadRequest("Failed to add house");
        }

        [HttpPut("{id}")]
        public IActionResult UpdateHouse(int id, [FromBody] HouseViewModel houseViewModel)
        {
            if (houseViewModel == null || id != houseViewModel.Id)
            {
                return BadRequest("House data is invalid");
            }
            var result = _realEstateServices.UpdateHouse(houseViewModel);
            if (result)
            {
                return NoContent();
            }
            return NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteHouse(int id)
        {
            var result = _realEstateServices.DeleteHouse(id);
            if (result)
            {
                return NoContent();
            }
            return NotFound();
        }

    }
}
