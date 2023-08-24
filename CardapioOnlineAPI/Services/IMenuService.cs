using CardapioOnlineAPI.Dto;
using CardapioOnlineAPI.Entities;
using CardapioOnlineAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CardapioOnlineAPI.Services
{
    public interface IMenuService
    {
        List<MenuItem> GetAllMenuItems();
        void AddMenuItem(CreateRequest request);
        MenuItem GetMenuItemById(int id);
        void UpdateMenuItem(int id, UpdateRequest request);
        void DeleteMenuItem(int id);
        Task<MenuItem> UploadImage(int id, IFormFile file);
    }
}
