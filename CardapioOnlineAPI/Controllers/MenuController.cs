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
        private readonly MenuService _service;

        public MenuController(MenuService menuService)
        {
            _service = menuService;
        }

        [HttpGet]
        public List<MenuItem> ListarMenu()
        {
            var resposta = _service.GetAllMenuItems();

            return resposta;
        }

        [HttpPost]
        public void AddMenuItem([FromBody] CreateRequest request)
        {
            _service.AddMenuItem(request);
        }

        [HttpPost("{id}")]
        public void UpdateMenuItem(int id, [FromBody] MenuItem item)
        {
            _service.UpdateMenuItem(id, item);
        }
    }
}
