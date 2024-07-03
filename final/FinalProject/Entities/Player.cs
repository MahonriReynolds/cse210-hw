

public class Player:Entity
{
    private List<Item> _inventory;

    public Player(char[] model, int maxHealth)
    : base (model, maxHealth)
    {
        this._inventory = [];
    }

    public void PickUpItem(Item newItem)
    {
        this._inventory.Add(newItem);
    }

    public string[] CheckInventory()
    {
        List<string> itemDescriptions = [];
        foreach (Item item in this._inventory)
        {
            itemDescriptions.Add(item.Describe());
        }
        return itemDescriptions.ToArray();
    }

}
