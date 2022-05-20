using System.Collections.Generic;

namespace InventoryApp.BusinessLogic.Interfaces
{
    public interface ISubjectBL<T>
    {
        List<T> GetItems(string sortingParam);

    }
}