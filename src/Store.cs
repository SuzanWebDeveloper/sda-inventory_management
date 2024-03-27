
using System.Net.Http.Headers;

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
        throw new ArgumentOutOfRangeException(null, $"Max capacity is reached, can't add {item}\n");

      //Do not allow to add items with same name to the store
      Console.WriteLine($"Item to be added: {item}");
      if (item.Name != null)
      {
        bool isExist = _items.Any(i => string.Equals(i.Name, item.Name, StringComparison.OrdinalIgnoreCase));
        if (isExist)
          throw new ArgumentException("item exists, can't be added");

        _items.Add(item);
        Console.WriteLine($"added {item.Name}\n");
      }
    }
    catch (ArgumentOutOfRangeException e)
    {
      Console.WriteLine($"{e.Message}\n");
    }
    catch (ArgumentException e)
    {
      Console.WriteLine($"{e.Message}\n");
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
    return _items.FirstOrDefault(item => string.Equals(item.Name, itemName, StringComparison.OrdinalIgnoreCase));  //NullReferenceException

  }

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

  public Dictionary<string, List<Item>> GroupByDate()
  {
    //three months ago
    DateTime threeMonthsAgo = DateTime.Now.AddMonths(-3);

    var groupByDate = _items.GroupBy(item =>
      DateTime.Compare(item.CreatedDate, threeMonthsAgo) >= 0 ?
         "New Arrival" : "Old").ToDictionary(group => group.Key, group => group.ToList());
  
    return groupByDate;
  }

  public void Display(List<Item> items)
  {
    foreach (var item in items)
      Console.WriteLine($"{item}");
  }
}



