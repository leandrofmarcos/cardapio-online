using CardapioOnlineAPI.Dto;
using CardapioOnlineAPI.Entities;
using CardapioOnlineAPI.Repositories;

namespace CardapioOnlineAPI.Services
{
    public class MenuService
    {
        private readonly MenuRepository _repository;

        public MenuService(MenuRepository repository)
        {
            _repository = repository;
        }

        public List<MenuItem> GetAllMenuItems()
        {
            return _repository.GetAllMenuItems();
        }

        public void AddMenuItem(CreateRequest request)
        {
            var menuItem = new MenuItem()
            {
                Description = request.Description,
                Name = request.Name,    
                Price = request.Price,
            };

            _repository.AddMenuItem(menuItem);
        }

        public MenuItem GetMenuItemById(int id) 
        {
            var retorno = _repository.GetMenuItemById(id);

            return retorno;
        }
    
        public void UpdateMenuItem(int id, MenuItem item)
        {
            var exist = GetMenuItemById(id);

            if (exist != null)
            {
                _repository.UpdateMenuItem(item);
            }
        }
    }
}
