
namespace InventoryManagement
{

  public class Item
  {
    public string Name
    {
      get;
    }

    public int Quantity
    {
      get;
      set;
    }
    public DateTime createdDate { get; set; }

    public Item(string name, int quantity, DateTime createdDate = default)
    {
      if (quantity < 0)
      {
        //error argument exception
      }
      Name = name;
      Quantity = quantity;
      createdDate = createdDate == default ? DateTime.Now : createdDate;
    }

  }


  public class Store
  {
    private List<Item> items = new List<Item>();

    public void AddItem(Item item)
    {
      //Do not allow to add items with same name to the store

    }
    public void DeleteItem(string itemName)
    {

    }
    public static int GetCurrentVolume()
    {
      //compute the total amount of items in the store
      return 0;
    }
    public static void FindItemByName(string name)
    {
      // find an item by name.
    }
    public static void SortByNameAscto(string name)
    {
      // get the sorted collection by name in ascending order.
    }
  }
}


