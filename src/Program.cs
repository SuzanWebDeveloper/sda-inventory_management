
using InventoryManagement;
public class Program
{
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



