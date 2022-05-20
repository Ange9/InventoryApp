using InventoryApp.Enums;
using System.Collections.Generic;

namespace InventoryApp.DataAccess.Interfaces
{
    public interface IXMLReader<T>
    {
        public List<T> ReadXML(SortParameter sorting);
    }
}
