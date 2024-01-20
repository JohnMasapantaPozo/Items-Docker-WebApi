using WebApiDEMO.Dtos;

namespace WebApiDEMO
{
    public static class Extensions{

        /*  Extension methods in C#:
        - They allow to add new methods to existing types without modifying them.
        - They are static methods of a static class where the 'this' represents
        the type/class that the method operates on.
        - This extension can be called either by Extensions.AsDto(item) or 
        item.AsDto()
        */

        public static ItemDto AsDto(this Item item)
        {
            return new ItemDto
            {
                Id = item.Id,
                Name = item.Name,
                Price = item.Price,
                CreatedDate = item.CreatedDate
            };
        }
    }
}