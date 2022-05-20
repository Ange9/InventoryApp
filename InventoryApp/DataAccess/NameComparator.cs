using InventoryApp.DataAccess.Interfaces;
using InventoryApp.Entities;

namespace InventoryApp.DataAccess
{
    public class NameComparator : IObjectComparator<Product>
    {
        public int Compare(Product source, Product destination)
        {
            return source.Name.CompareTo(destination.Name);
        }
    }
}
