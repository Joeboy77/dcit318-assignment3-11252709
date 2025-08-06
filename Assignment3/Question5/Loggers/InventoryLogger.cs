using Assignment3.Question5.Interfaces;

using System.Text.Json;

namespace Assignment3.Question5.Loggers
{
    public class InventoryLogger<T> where T : IInventoryEntity
    {
        private List<T> _log;
        private string _filePath;

        public InventoryLogger(string filePath)
        {
            _log = new List<T>();
            _filePath = filePath;
        }

        public void Add(T item)
        {
            _log.Add(item);
            Console.WriteLine($"Logged {typeof(T).Name}: ID={item.Id}, Name='{item.Name}'");
        }

        public List<T> GetAll()
        {
            return new List<T>(_log);
        }

        public void SaveToFile()
        {
            try
            {
                string jsonString = JsonSerializer.Serialize(_log, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(_filePath, jsonString);
                Console.WriteLine($"Successfully saved inventory log to '{_filePath}'.");
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Error saving file: {ex.Message}");
            }
            catch (JsonException ex)
            {
                Console.WriteLine($"Error serializing data to JSON: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred while saving: {ex.Message}");
            }
        }

        public void LoadFromFile()
        {
            _log.Clear();

            if (!File.Exists(_filePath))
            {
                Console.WriteLine($"No existing log file found at '{_filePath}'. Starting with empty log.");
                return;
            }

            try
            {
                string jsonString = File.ReadAllText(_filePath);
                List<T>? loadedItems = JsonSerializer.Deserialize<List<T>>(jsonString);

                if (loadedItems != null)
                {
                    _log.AddRange(loadedItems);
                    Console.WriteLine($"Successfully loaded {loadedItems.Count} items from '{_filePath}'.");
                }
                else
                {
                    Console.WriteLine($"File '{_filePath}' is empty or contains no valid data.");
                }
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine($"Error loading file: File not found at '{_filePath}'. {ex.Message}");
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Error reading file: {ex.Message}");
            }
            catch (JsonException ex)
            {
                Console.WriteLine($"Error deserializing data from JSON: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred while loading: {ex.Message}");
            }
        }
    }
}