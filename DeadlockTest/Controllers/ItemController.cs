using DeadlockTest.Business.Interfaces;
using DeadlockTest.Data.Dto.Item;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DeadlockTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly IItemService _service;

        public ItemController(IItemService service)
        {
            _service = service;
        }
        // GET: api/<ItemController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _service.GetList<ItemDto>();
            if (result.Any())
            {
                return Ok(result);
            }
            return NoContent();
        }

        // GET api/<ItemController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var value = await _service.GetById(id);
            return StatusCode(value != null ? 200 : 404, value);
        }

        // POST api/<ItemController>
        [HttpPost("create")]
        public async Task<IActionResult> Create(ItemDto createDto)
        {
            var result = await _service.Create<ItemDto>(createDto);
            return StatusCode(result ? 201 : 500);

        }

        // PUT api/<ItemController>/5
        [HttpPut("update")]
        public async Task<IActionResult> Put(ItemDto value)
        {
            var result = await _service.Edit<ItemDto>(value);
            return StatusCode(result ? 200 : 500);

        }

        // DELETE api/<ItemController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
