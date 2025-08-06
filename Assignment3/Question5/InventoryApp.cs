using Assignment3.Question5.Loggers;
using Assignment3.Question5.Models;

namespace Assignment3.Question5
{
    public class InventoryApp
    {
        private InventoryLogger<InventoryItem> _logger;
        private const string LogFileName = "inventory_log.json";

        public InventoryApp()
        {
            _logger = new InventoryLogger<InventoryItem>(LogFileName);
        }

        public void SeedSampleData()
        {
            _logger.Add(new InventoryItem(1, "Laptop", 10, DateTime.Now.AddDays(-30)));
            _logger.Add(new InventoryItem(2, "Mouse", 50, DateTime.Now.AddDays(-15)));
            _logger.Add(new InventoryItem(3, "Keyboard", 30, DateTime.Now.AddDays(-7)));
            _logger.Add(new InventoryItem(4, "Monitor", 5, DateTime.Now.AddDays(-60)));
        }

        public void SaveData()
        {
            _logger.SaveToFile();
        }

        public void LoadData()
        {
            _logger.LoadFromFile();
        }

        public void PrintAllItems()
        {
            List<InventoryItem> items = _logger.GetAll();
            if (items.Any())
            {
                foreach (var item in items)
                {
                    Console.WriteLine($"Item: ID={item.Id}, Name='{item.Name}', Quantity={item.Quantity}, Date Added={item.DateAdded.ToShortDateString()}");
                }
            }
            else
            {
                Console.WriteLine("No inventory items to display.");
            }
        }
    }
}