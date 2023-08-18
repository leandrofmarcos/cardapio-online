using CardapioOnlineAPI.Entities;

namespace CardapioOnlineAPI.Dto
{
    public class UpdateRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string? ImageUrl { get; set; }

        public static MenuItem FromUpdateRequest(UpdateRequest request)
        {
            return new MenuItem
            {
                Name = request.Name,
                Description = request.Description,
                Price = request.Price,
                ImageUrl = request.ImageUrl,
                Id = request.Id
            };
        }

        public static UpdateRequest FromMenuItem(MenuItem menuItem)
        {
            return new UpdateRequest
            {
                Name = menuItem.Name,
                Description = menuItem.Description,
                Price = menuItem.Price,
                ImageUrl = menuItem.ImageUrl,
                Id = menuItem.Id
            };
        }
    }
}
