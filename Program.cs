
namespace InventoryManagement
{
  public class Item
  {
    private readonly string? _name; // ? removes Non-nullable field 'name' must contain a non-null value when exiting constructor. Consider declaring the field as nullable.CS8618
    private int _quantity;
    private DateTime _createdDate;
    public string Name { get; }
    public int Quantity
    {
      get;
      set;
    }
    public DateTime CreatedDate { get; set; }

    public Item(string name, int quantity, DateTime createdDate = default)  // createdDate optional
    {
      try
      {
        if (_quantity < 0)
        {
          throw new ArgumentException();
        }
        Name = name;
        Quantity = quantity;
        createdDate = createdDate == default ? DateTime.Now : createdDate;
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

  public class Store
  {
    private List<Item> _items = new List<Item>();
    private readonly int _maxItemsCapacity;

    public Store()
    {
      _maxItemsCapacity = 100;
    }

    public void AddItem(Item item)
    {
      if (GetCurrentVolume() > _maxItemsCapacity)
      {
        Console.WriteLine($"Max capacity is reached, can't add {item}");
        return;
      }
      //Do not allow to add items with same name to the store
      Console.WriteLine($"Item to be added: {item}");
      if (item.Name != null)
      {
        bool isExist = _items.Any(i => i.Name.ToLower() == item.Name.ToLower());
        if (isExist)
        {
          Console.WriteLine($"item exists");
          return;
        }
        _items.Add(item);
        Console.WriteLine($"added {item.Name}\n");
      }
    }
    public void DeleteItem(string itemName)
    {
      if (_items != null)
      {
        // ? removes Converting null literal or possible null value to non-nullable type.CS8600 // ArgumentNullException
        Item? itemToDelete = _items.FirstOrDefault(oneItem => oneItem.Name.ToLower() == itemName.ToLower());
        if (itemToDelete != null)
        {
          _items.Remove(itemToDelete);
          Console.WriteLine($"item deleted successfully");
        }
        else
        {
          Console.WriteLine($"item is not exists");
        }
      }
    }
    public int GetCurrentVolume()
    {
      //compute the total amount of items in the store
      int totalItems = _items.Sum(item => item.Quantity);
      return totalItems;
    }
    public void FindItemByName(string itemName)
    {
      if (!string.IsNullOrEmpty(itemName))
      {
        Item? itemFound = _items.FirstOrDefault(item => item.Name.ToLower() == itemName.ToLower());  //NullReferenceException
        if (itemFound != null)
        {
          Console.WriteLine($"item {itemName} is found");
        }
        else
        {
          Console.WriteLine($"item {itemName} is not found");
        }
      }
    }
    public List<Item> SortByNameAsc()
    {
      // get the sorted collection by name in ascending order.
      return _items.OrderBy(item => item.Name).ToList();
    }

    public void Display(List<Item> items)
    {
      foreach (var item in items)
        Console.WriteLine($"{item}");
    }

    static void Main(string[] args)
    {
      var waterBottle = new Item("Water Bottle", 10, new DateTime(2023, 1, 1));
      var waterBottle2 = new Item("Bottle2", 20, new DateTime(2023, 1, 1));
      var waterBottle3 = new Item("Bottle3", -5, new DateTime(2023, 1, 1));
      var umbrella = new Item("Umbrella", 5);
      var store1 = new Store();

      store1.AddItem(waterBottle);
      store1.AddItem(waterBottle2);
      store1.AddItem(waterBottle3);
      store1.AddItem(umbrella);

      store1.FindItemByName("umbrella");
      Console.WriteLine($"umbrella obj: {umbrella}");

      int currentVolume = store1.GetCurrentVolume();
      Console.WriteLine($"total quantity: {currentVolume}");

      // test delete:
      //store1.DeleteItem("Umbrella");
      //store1.FindItemByName("umbrella");

      // sorting then displaying
      var sortedItemsAsc = store1.SortByNameAsc();
      Console.WriteLine($"\nSorted collection by name in ascending order:");
      foreach (var item in sortedItemsAsc)
        Console.WriteLine($"{item}");
    }
  }
}


