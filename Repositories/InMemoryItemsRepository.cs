/*
    This list o items will be replaced at later stage by a proper database.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace WebApiDEMO.Repositories
{
    class InMemoryItemsRepository : IItemsRepository
    {
        /* InMemoryItemsRepository
            Implementation fof the IItemsRepository interface.

            Turned all methods into async Tasks to gain efficiency and
            to fullfill the IItemsRepository interface definition.
        */
        private readonly List<Item> items = new()
        {
            new Item { Id=Guid.NewGuid(), Name = "Potion", Price = 9, CreatedDate = DateTimeOffset.UtcNow },
            new Item { Id=Guid.NewGuid(), Name = "Iron Sword", Price = 20, CreatedDate = DateTimeOffset.UtcNow },
            new Item { Id=Guid.NewGuid(), Name = "Bronze Shield", Price = 18, CreatedDate = DateTimeOffset.UtcNow },
        };

        public async Task<IEnumerable<Item>> GetItemsAsync()
        {
            /*The following syntax simply means that given we do not
                have any task to call and wait for, we just create a
                'finished' task and insert the item we want to return
                with it.
            */

            return await Task.FromResult(items);
        }

        public async Task<Item> GetItemAsync(Guid id)
        {
            var item = items.Where(item => item.Id == id).SingleOrDefault();
            return await Task.FromResult(item);
        }

        public async Task CreateItemAsync(Item item)
        {
            items.Add(item);
            await Task.CompletedTask;
        }

        public async Task UpdateItemAsync(Item item)
        {
            var index = items.FindIndex(existingItem => existingItem.Id == item.Id);
            items[index] = item;
            await Task.CompletedTask;
        }

        public async Task DeleteItemAsync(Guid id)
        {
            var index = items.FindIndex(existingItem => existingItem.Id == id);
            items.RemoveAt(index);
            await Task.CompletedTask;
        }
    }
}