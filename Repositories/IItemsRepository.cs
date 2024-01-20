using System;
using System.Collections.Generic;

namespace WebApiDEMO.Repositories
{
    public interface IItemsRepository
    {
        Item GetItem(Guid id);
        IEnumerable<Item> GetItems();
    }
}