using Assignment3.Question3.Exceptions;
using Assignment3.Question3.Interfaces;

namespace Assignment3.Question3.Repositories
{
    public class InventoryRepository<T> where T : IInventoryItem
    {
        private Dictionary<int, T> _items;

        public InventoryRepository()
        {
            _items = new Dictionary<int, T>();
        }

        public void AddItem(T item)
        {
            if (_items.ContainsKey(item.Id))
            {
                throw new DuplicateItemException($"Item with ID {item.Id} already exists in the inventory.");
            }
            _items.Add(item.Id, item);
            Console.WriteLine($"Added {typeof(T).Name}: {item.Name} (ID: {item.Id})");
        }

        public T GetItemById(int id)
        {
            if (!_items.TryGetValue(id, out T? item))
            {
                throw new ItemNotFoundException($"Item with ID {id} not found in the inventory.");
            }
            return item;
        }

        public void RemoveItem(int id)
        {
            if (!_items.Remove(id))
            {
                throw new ItemNotFoundException($"Item with ID {id} not found to remove.");
            }
            Console.WriteLine($"Removed {typeof(T).Name} with ID: {id}");
        }

        public List<T> GetAllItems()
        {
            return _items.Values.ToList();
        }

        public void UpdateQuantity(int id, int newQuantity)
        {
            if (!_items.TryGetValue(id, out T? item))
            {
                throw new ItemNotFoundException($"Item with ID {id} not found to update quantity.");
            }

            if (newQuantity < 0)
            {
                throw new InvalidQuantityException($"Invalid quantity for item ID {id}. Quantity cannot be negative: {newQuantity}");
            }

            item.Quantity = newQuantity;
            Console.WriteLine($"Updated quantity for {typeof(T).Name} '{item.Name}' (ID: {id}) to {newQuantity}.");
        }
    }
}