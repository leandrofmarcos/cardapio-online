using CardapioOnlineAPI.Entities;

namespace CardapioOnlineAPI.Repositories.Impl
{
    public class MenuRepository : IMenuRepository
    {
        private static List<MenuItem> menuItems = new List<MenuItem>();

        public void AddMenuItem(MenuItem menuItem)
        {
            menuItem.Id = menuItems.Count + 1;
            menuItems.Add(menuItem);
        }

        public List<MenuItem> GetAllMenuItems()
        {
            return menuItems;
        }

        public MenuItem GetMenuItemById(int id)
        {
            return menuItems.FirstOrDefault(item => item.Id == id);
        }

        public void UpdateMenuItem(MenuItem menuItem)
        {

            var menuItemOld = menuItems.FirstOrDefault(i => i.Id == menuItem.Id);
            menuItemOld.Name = menuItem.Name;
            menuItemOld.Description = menuItem.Description;
            menuItemOld.Price = menuItem.Price;
            menuItemOld.ImageUrl = menuItem.ImageUrl;
        }

        public void DeleteMenuItem(int id)
        {
            var existingItem = menuItems.FirstOrDefault(item => item.Id == id);
            if (existingItem != null)
            {
                menuItems.Remove(existingItem);
            }
        }
    }
}
