using System.Collections.Generic;

namespace InventoryApp.BusinessLogic.Interfaces
{
    public interface ISubjectBL<T>
    {
        IEnumerable<T> GetItems(string sorting);

    }
}