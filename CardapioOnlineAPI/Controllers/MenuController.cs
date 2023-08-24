using CardapioOnlineAPI.Dto;
using CardapioOnlineAPI.Entities;
using CardapioOnlineAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CardapioOnlineAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private readonly IMenuService _service;

        public MenuController(IMenuService menuService)
        {
            _service = menuService;
        }

        [HttpGet]
        public IActionResult GetAllMenuItems()
        {
            var resposta = _service.GetAllMenuItems();

            if(resposta == null)
            {
                return new NotFoundResult();
            }

            return Ok(resposta);
        }

        [HttpPost]
        public void AddMenuItem([FromBody] CreateRequest request)
        {
            _service.AddMenuItem(request);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateMenuItem(int id, [FromBody] UpdateRequest request)
        {
            if(id != request.Id)
            {
                return BadRequest();
            }

            _service.UpdateMenuItem(id, request);

            return NoContent();
        }

        [HttpGet("{id}")]
        public IActionResult GetMenuItemById(int id)
        {
            var menuItem = _service.GetMenuItemById(id);

            if(menuItem == null)
            {
                return NotFound();
            }

            return Ok(menuItem);
        }

        [HttpDelete]
        public IActionResult DeleteMenuItem(int id)
        {
            var menuItem = _service.GetMenuItemById(id);
            if (menuItem == null)
            {
                return NotFound();
            }

            _service.DeleteMenuItem(id);
            return NoContent();
        }

        [HttpPost("{id}/upload/")]
        public async Task<IActionResult> UploadImage(int id, IFormFile file)
        {
            await _service.UploadImage(id, file);

            return Ok();
        }
    }
}
