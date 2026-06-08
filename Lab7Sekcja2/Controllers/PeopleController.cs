using Contracts;
using Contracts.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace Lab7Sekcja2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private readonly IPeopleService peopleService;

        public PeopleController(IPeopleService peopleService)
        {
            this.peopleService = peopleService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var res = await this.peopleService.GetAsync();
            return Ok(res);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIDAsync(int id)
        {
            var res = await this.peopleService.GetByIDAsync(id);
            if (res == null) 
            {
                return NotFound();
            }

            return Ok(res);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] NewPersonDTO newPersonDTO)
        {
            var res = await peopleService.PostAsync(newPersonDTO);
            return Ok(res);
        }

        [HttpGet("{id}/Addresses")] 
        public async Task<IActionResult> GetAddressesAsync(int id)
        {
            return Ok(await this.peopleService.GetAddresses(id));
        }


        [HttpPost("{id}/Addresses")]
        public async Task<IActionResult> GetAddressesAsync(int id, [FromBody] NewAddressDTO newAddressDTO)
        {
            await this.peopleService.PostAddressAsync(id, newAddressDTO.PostalCode, newAddressDTO.City, newAddressDTO.Street);
            return Ok();
        }
    }
}
