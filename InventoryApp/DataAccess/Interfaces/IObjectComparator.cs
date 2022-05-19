using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryApp.DataAccess.Interfaces
{
    public interface IObjectComparator<T>
    {
        int Compare( T source,  T destination);
    }
}
