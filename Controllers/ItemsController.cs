using System;
using System.Collections.Generic;
using System.Linq;
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
        /*
        NOTE: This snipped was changed by an interface to avoid a brand new repository to be created
        every time we send a Http request. As ItemsController is instantiated every time we send a request.
        Now the repository is created out of this class, within Startup.

        private readonly InMemoryItemsRepository repository;
        public ItemsController()
        {
            repository = new InMemoryItemsRepository();
        }
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
        public IEnumerable<ItemDto> GetItems()
        {
            var items = repository.GetItems().Select(
                // item => item.AsDto() OR
                item => Extensions.AsDto(item)
                );

            return items;
        }

        // Route: GET/items/id
        [HttpGet("{id}")]
        public ActionResult<ItemDto> GetItem(Guid id)
        {
            var item = repository.GetItem(id:id);

            if (item is null)
            {
                return NotFound();
            }

            // return item => Extensions.AsDto(item) // OR
            return item.AsDto();
            
        }
    }
}