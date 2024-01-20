using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApiDEMO.Repositories
{
    public interface IItemsRepository
    {
        /* We are making all methods async.
            Renaming and turning them into Tasks.
            This means that each method will reference
            a task that will be completed eventually.
        */

        Task<Item> GetItemAsync(Guid id);
        Task<IEnumerable<Item>> GetItemsAsync();

        Task CreateItemAsync(Item item);

        Task UpdateItemAsync(Item item);

        Task DeleteItemAsync(Guid id);
    }
}