
namespace InventoryManagement;

public enum SortOrder
{
  ASC,
  DESC
}

public class Store
{
  private List<Item> _items = new List<Item>();
  private readonly int _maxItemsCapacity;

  public Store(int maxItemsCapacity)
  {
    _maxItemsCapacity = maxItemsCapacity;
  }

  public void AddItem(Item item)
  {
    try
    {
      if (GetCurrentVolume() + item.Quantity > _maxItemsCapacity)
        throw new ArgumentOutOfRangeException();

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
    catch (ArgumentOutOfRangeException)
    {
      Console.WriteLine($"Max capacity is reached, can't add {item}");
    }
  }
  public void DeleteItem(string itemName)
  {
    Item itemFound = FindItemByName(itemName);
    if (itemFound != null)
    {
      _items.Remove(itemFound);
      Console.WriteLine($"item is deleted successfully");
    }
    else
    {
      Console.WriteLine($"item does not exist");
    }
  }
  public int GetCurrentVolume()
  {
    //compute the total amount of items in the store
    int totalItems = _items.Sum(item => item.Quantity);
    return totalItems;
  }
  public Item FindItemByName(string itemName)
  {
    return _items.FirstOrDefault(item => item.Name.ToLower() == itemName.ToLower());  //NullReferenceException
  }

  // Why this code gets error?
  // if (!string.IsNullOrEmpty(itemName))
  // {
  //   Item? itemFound = _items.FirstOrDefault(item => item.Name.ToLower() == itemName.ToLower());  //NullReferenceException
  //   if (itemFound != null)
  //   {
  //     Console.WriteLine($"item {itemName} is found");
  //     return itemFound;
  //   }
  //   else
  //   {
  //     Console.WriteLine($"item {itemName} is not found");
  //     return null;
  //   }
  // }
  //}
  public List<Item> SortByNameAsc()
  {
    // get the sorted collection by name in ascending order.
    return _items.OrderBy(item => item.Name).ToList();
  }

  public List<Item> SortByDate(SortOrder sortOrder)
  {
    // get the sorted collection by date in ascending or descending order.
    if (sortOrder == SortOrder.ASC)
      return _items.OrderBy(item => item.CreatedDate).ToList();
    else
    {
      return _items.OrderByDescending(item => item.CreatedDate).ToList();
    }
  }

  public void Display(List<Item> items)
  {
    foreach (var item in items)
      Console.WriteLine($"{item}");
  }
}



