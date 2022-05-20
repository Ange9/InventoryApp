namespace InventoryApp.DataAccess.Interfaces
{
    public interface IObjectComparator<T>
    {
        int Compare( T source,  T destination);
    }
}
