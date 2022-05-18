using System.Collections.Generic;

namespace InventoryApp.BusinessLogic.Interfaces
{
    public interface IItemBL<T>
    {
        IEnumerable<T> GetItems(int sorting);

    }
}