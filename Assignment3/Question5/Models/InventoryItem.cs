using Assignment3.Question5.Interfaces;

namespace Assignment3.Question5.Models
{
    public record InventoryItem(int Id, string Name, int Quantity, DateTime DateAdded) : IInventoryEntity;
}