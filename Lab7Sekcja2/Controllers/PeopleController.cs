using Contracts;
using Contracts.Models;
using Microsoft.AspNetCore.Mvc;

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
    }
}
