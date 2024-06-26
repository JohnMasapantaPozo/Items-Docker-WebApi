using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApiDEMO.Dtos;
using WebApiDEMO.Repositories;

/*  DEPENDENCY INJECTION AND DEPENDENCY INVERSION:
        Visit README.
*/

namespace WebApiDEMO.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class ItemsController : ControllerBase
    {
        /* NOTE: This snipped was changed by an interface to avoid a brand new
            repository to be created every time we send a Http request. As
            ItemsController is instantiated every time we send a request.
            Now the repository is created out of this class, within Startup.

        private readonly InMemoryItemsRepository repository;

        public ItemsController()
        {
            repository = new InMemoryItemsRepository();
        }

          Async:
            Turned all methods into async Tasks to gain efficiency and
            to fullfill the IItemsRepository interface definition and 
            MongoDbItemsRepository interface implementation.
        */

        private readonly IItemsRepository repository;

        public ItemsController( IItemsRepository repository)
        {
            this.repository = repository;
        }

        /* Route: GET/items
        Projecting our stored data model/entity
        into our desired Dto.
        Created an Extension static class to handle this.*/

        [HttpGet]
        public async Task<IEnumerable<ItemDto>> GetItemsAsync()
        {
            var items = (await this.repository.GetItemsAsync())
            .Select(
                // item => item.AsDto() OR
                item => Extensions.AsDto(item)
            );

            return items;
        }

        // Route: GET/items/id
        [HttpGet("{id}", Name = nameof(GetItemAsync))]
        public async Task<ActionResult<ItemDto>> GetItemAsync(Guid id)
        {
            var item = await this.repository.GetItemAsync(id:id);

            if (item is null)
            {
                return NotFound();
            }

            // return item => Extensions.AsDto(item) // OR
            return item.AsDto();
            
        }

        // Route: POST/items
        [HttpPost]
        public async Task<ActionResult<ItemDto>> CreateItemAsync(CreateItemDto itemDto)
        {
            Item item = new(){
                Id = Guid.NewGuid(),
                Name = itemDto.Name,
                Price = itemDto.Price,
                CreatedDate = DateTimeOffset.UtcNow
            };

            await this.repository.CreateItemAsync(item);

            /* CreatedAtAction:
                Heps us creating the location URL where our newly created resurce can be found.

                Response e.g., 

                content-type: application/json; charset=utf-8 
                date: Sat20 Jan 2024 12:38:08 GMT 
                location: https://localhost:5001/Items/b2a1186d-cf1d-4d27-829d-072c2a8cf1dd 
                server: Kestrel
            */

            return CreatedAtAction(
                nameof(GetItemAsync),
                new { id = item.Id },
                item.AsDto()
            );
        }

        // Route: UPDATE/items/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateItemAsync(Guid id, UpdateItemDto itemDto)
        {
            var existingItem = await this.repository.GetItemAsync(id);
            if (existingItem is null)
            {
                return NotFound();
            }

            Item updatedItem = existingItem with {
                Name = itemDto.Name,
                Price = itemDto.Price                
            };

            await this.repository.UpdateItemAsync(updatedItem);

            return NoContent();
        }

        // Route: DELETE/items/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteItemAsync(Guid id)
        {
            var existingItem = await this.repository.GetItemAsync(id);
            if (existingItem is null)
            {
                return NotFound();
            }

            await this.repository.DeleteItemAsync(id);

            return NoContent();
        }
    }
}