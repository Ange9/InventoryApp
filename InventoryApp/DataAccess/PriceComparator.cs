using InventoryApp.DataAccess.Interfaces;
using InventoryApp.Entities;

namespace InventoryApp.DataAccess
{
    public class PriceComparator : IObjectComparator<Product>
    {
        private const int SOURCE_IS_SMALLER= -1;
        private const int SOURCE_IS_GREATER = 1;

        public int Compare(Product source, Product destination)
        {
            return source.Price <= destination.Price ? SOURCE_IS_SMALLER : SOURCE_IS_GREATER;
        }
    }
}
