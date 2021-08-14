using DeadlockTest.Business.Interfaces;
using DeadlockTest.Data.Dto.Item;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DeadlockTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        // GET: api/<OrderController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _orderService.GetList());
        }

        // GET api/<OrderController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _orderService.GetById(id);
            return StatusCode(result != null ? 200 : 404, result);
        }

        // POST api/<OrderController>
        [HttpPost("create")]
        public async Task<IActionResult> Create()
        {
            return Ok(await _orderService.CreateOrder());
        }

        [HttpPost("addItem")]
        public async Task<IActionResult> AddItem(ItemOrderDto item)
        {
            return Ok(await _orderService.AddItem(item));
        }

        [HttpPost("removeItem")]
        public async Task<IActionResult> RemoveItem(ItemOrderDto item)
        {
            return Ok(await _orderService.RemoveItem(item));
        }

    }
}
