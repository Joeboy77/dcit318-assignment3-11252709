using Assignment3.Question3.Interfaces;
using Assignment3.Question3.Models;
using Assignment3.Question3.Repositories;
using Assignment3.Question3.Exceptions;

namespace Assignment3.Question3
{
    public class WarehouseManager
    {
        private InventoryRepository<ElectronicItem> _electronics;
        private InventoryRepository<GroceryItem> _groceries;

        public WarehouseManager()
        {
            _electronics = new InventoryRepository<ElectronicItem>();
            _groceries = new InventoryRepository<GroceryItem>();
        }

        public InventoryRepository<ElectronicItem> GetElectronicRepository() => _electronics;
        public InventoryRepository<GroceryItem> GetGroceryRepository() => _groceries;

        public void SeedData()
        {
            Console.WriteLine("--- Seeding Warehouse Data ---");
            try
            {
                _electronics.AddItem(new ElectronicItem(101, "Laptop", 10, "HP", 12));
                _electronics.AddItem(new ElectronicItem(102, "Smartphone", 25, "Samsung", 24));
                _electronics.AddItem(new ElectronicItem(103, "Headphones", 50, "Sony", 6));

                _groceries.AddItem(new GroceryItem(1, "Milk", 100, DateTime.Now.AddDays(7)));
                _groceries.AddItem(new GroceryItem(2, "Bread", 75, DateTime.Now.AddDays(3)));
                _groceries.AddItem(new GroceryItem(3, "Eggs", 60, DateTime.Now.AddDays(14)));
            }
            catch (DuplicateItemException ex)
            {
                Console.WriteLine($"Error during seeding: {ex.Message}");
            }
            Console.WriteLine("Warehouse data seeded.");
        }

        public void PrintAllItems<T>(InventoryRepository<T> repo) where T : IInventoryItem
        {
            List<T> items = repo.GetAllItems();
            if (items.Any())
            {
                foreach (var item in items)
                {
                    Console.WriteLine(item);
                }
            }
            else
            {
                Console.WriteLine($"No {typeof(T).Name}s found.");
            }
        }

        public void IncreaseStock<T>(InventoryRepository<T> repo, int id, int quantity) where T : IInventoryItem
        {
            try
            {
                T item = repo.GetItemById(id);
                int newQuantity = item.Quantity + quantity;
                repo.UpdateQuantity(id, newQuantity);
            }
            catch (ItemNotFoundException ex)
            {
                Console.WriteLine($"Error increasing stock: {ex.Message}");
            }
            catch (InvalidQuantityException ex)
            {
                Console.WriteLine($"Error increasing stock: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred while increasing stock: {ex.Message}");
            }
        }

        public void RemoveItemById<T>(InventoryRepository<T> repo, int id) where T : IInventoryItem
        {
            try
            {
                repo.RemoveItem(id);
            }
            catch (ItemNotFoundException ex)
            {
                Console.WriteLine($"Error removing item: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred while removing item: {ex.Message}");
            }
        }
    }
}