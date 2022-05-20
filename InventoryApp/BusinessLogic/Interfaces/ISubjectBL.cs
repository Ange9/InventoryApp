using InventoryApp.Enums;
using System.Collections.Generic;

namespace InventoryApp.BusinessLogic.Interfaces
{
    public interface ISubjectBL<T>
    {
        List<T> GetItems(SortParameter sortingParam);
    }
}