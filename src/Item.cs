
namespace InventoryManagement;

public class Item
{
  private readonly string? _name; // ? removes Non-nullable field 'name' must contain a non-null value when exiting constructor. Consider declaring the field as nullable.CS8618
  private int _quantity;
  private DateTime _createdDate;
  public string? Name { get; }
  public int Quantity { get; set; }
  public DateTime CreatedDate { get; set; }

  public Item(string name, int quantity, DateTime createdDate = default)  // createdDate is optional
  {
    try
    {
      if (quantity < 0)
        throw new ArgumentException();

      Name = name;
      Quantity = quantity;
      CreatedDate = createdDate == default ? DateTime.Now : createdDate;
    }
    catch (ArgumentException)
    {
      Console.WriteLine($"quantity can't be negative");
    }
  }

  // override ToString method to display an object
  public override string ToString()
  {
    return $"Item Name: {Name}, Quantity: {Quantity}, Created Date: {CreatedDate}";
  }
}
