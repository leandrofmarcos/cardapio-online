using CardapioOnlineAPI.Db;
using CardapioOnlineAPI.Entities;

namespace CardapioOnlineAPI.Repositories.Impl
{
    public class MenuEFRepositoryImpl : IMenuRepository
    {

        private readonly AppDbContext _dbContext;

        public MenuEFRepositoryImpl(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddMenuItem(MenuItem menuItem)
        {
            _dbContext.MenuItems.Add(menuItem);
            _dbContext.SaveChanges();
        }

        public void DeleteMenuItem(int id)
        {
            var menuItem = _dbContext.MenuItems.Find(id);
            if (menuItem != null)
            {
                _dbContext.MenuItems.Remove(menuItem);
                _dbContext.SaveChanges();
            }
        }

        public List<MenuItem> GetAllMenuItems()
        {
            return _dbContext.MenuItems.ToList();
        }

        public MenuItem GetMenuItemById(int id)
        {
            return _dbContext.MenuItems.Find(id);
        }

        public void UpdateMenuItem(MenuItem menuItem)
        {
            _dbContext.MenuItems.Update(menuItem);
            _dbContext.SaveChanges();
        }
    }
}
