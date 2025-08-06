namespace Assignment3.Question2.Repositories
{
    public class Repository<T> where T : class
    {
        private List<T> _items;

        public Repository()
        {
            _items = new List<T>();
        }

        public void Add(T item)
        {
            _items.Add(item);
            Console.WriteLine($"Added {typeof(T).Name}: {item}");
        }

        public List<T> GetAll()
        {
            return new List<T>(_items);
        }

        public T? GetById(Func<T, bool> predicate)
        {
            return _items.FirstOrDefault(predicate);
        }

        public bool Remove(Func<T, bool> predicate)
        {
            T? itemToRemove = _items.FirstOrDefault(predicate);
            if (itemToRemove != null)
            {
                _items.Remove(itemToRemove);
                Console.WriteLine($"Removed {typeof(T).Name}: {itemToRemove}");
                return true;
            }
            Console.WriteLine($"Could not find {typeof(T).Name} to remove.");
            return false;
        }
    }
}