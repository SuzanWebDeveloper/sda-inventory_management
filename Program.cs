

namespace InventoryManagement
{

  public class Item
  {
    private readonly string? name; // ? removes Non-nullable field 'name' must contain a non-null value when exiting constructor. Consider declaring the field as nullable.CS8618
    private int quantity;
    private DateTime createdDate;
    public string Name { get; }
    public int Quantity  // try later with just get; set;
    {
      get;
      set;
    }
    public DateTime CreatedDate { get; set; }

    public Item(string name, int quantity, DateTime createdDate = default)  // createdDate optional
    {
      if (quantity < 0)
      {
        //error argument exception can't be negative
      }
      Name = name;
      Quantity = quantity;
      createdDate = createdDate == default ? DateTime.Now : createdDate;
    }

    // override ToString method to display an object
    public override string ToString()
    {
      return $"Item Name: {Name}, Quantity: {Quantity}, Created Date: {CreatedDate}";
    }

  }


  public class Store
  {
    private List<Item> items = new List<Item>();

    public void AddItem(Item item)
    {
      //Do not allow to add items with same name to the store
      bool isExist = items.Any(i => i.Name.ToLower() == item.Name.ToLower());
      if (isExist)
      {
        //msg exists
        Console.WriteLine($"item is exists");
        return;
      }
      items.Add(item);
      Console.WriteLine($"added {item.Name}");

    }
    public void DeleteItem(string itemName)
    {
      if (items != null)
      {
        // ? removes Converting null literal or possible null value to non-nullable type.CS8600 // ArgumentNullException
        Item? itemToDelete = items.FirstOrDefault(oneItem => oneItem.Name.ToLower() == itemName.ToLower());
        if (itemToDelete != null)
        {
          items.Remove(itemToDelete);
          Console.WriteLine($"item deleted successfully");
        }
        else
        {
          //msg not exists
          Console.WriteLine($"item is not exists");
        }
      }
    }
    public int GetCurrentVolume()
    {
      //compute the total amount of items in the store
      int totalItems = items.Sum(item => item.Quantity);
      return totalItems;
    }
    public void FindItemByName(string itemName)
    {
      // find an item by name.
      if (!string.IsNullOrEmpty(itemName))
      {
        Item? itemFound = items.FirstOrDefault(item => item.Name.ToLower() == itemName.ToLower());  //NullReferenceException
        if (itemFound != null)
        {
          //msg found 
          Console.WriteLine($"item {itemName} is found");
        }
        else
        {
          //msg not exists 
          Console.WriteLine($"item {itemName} is not found");
        }
      }
    }
    public static void SortByNameAscto(string name)
    {
      // get the sorted collection by name in ascending order.
    }

    static void Main(string[] args)
    {
      var waterBottle = new Item("Water Bottle", 10, new DateTime(2023, 1, 1));
      var waterBottle2 = new Item("Bottle", 20, new DateTime(2023, 1, 1));
      var umbrella = new Item("Umbrella", 5);
      var store1 = new Store();
      store1.AddItem(waterBottle);
      store1.AddItem(waterBottle2);
      store1.AddItem(umbrella);
      store1.FindItemByName("umbrella");
      Console.WriteLine($"umbrella obj: {umbrella}");
      int currentVolume = store1.GetCurrentVolume();
      Console.WriteLine($"{currentVolume}");
      store1.DeleteItem("Umbrella");
      store1.FindItemByName("umbrella");
    }
  }

}


