using CardapioOnlineAPI.Entities;

namespace CardapioOnlineAPI.Repositories
{
    public interface IMenuRepository
    {
        void AddMenuItem(MenuItem menuItem);
        List<MenuItem> GetAllMenuItems();
        MenuItem GetMenuItemById(int id);
        void UpdateMenuItem(MenuItem menuItem);
        void DeleteMenuItem(int id);
    }
}
