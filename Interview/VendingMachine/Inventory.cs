namespace Interview.VendingMachine;

public class Inventory
{
    private List<ItemShelf> _inventory = new List<ItemShelf>();

    public Inventory(List<ItemShelf> inventory)
    {
        _inventory = inventory ?? throw new ArgumentNullException(nameof(inventory), "Inventory cannot be null.");
    }

    public Item getItem(int code)
    {
        foreach (var shelf in _inventory)
        {
            if (shelf.Code == code)
            {
                if (!shelf.SoldOut)
                {
                    return shelf.Item;
                }
                else
                {
                    throw new Exception("Item is sold out.");
                }
            }
            else
            {
                throw new Exception("Item not found.");
            }
        }
    }

    public void AddItem(Item item, int code)
    {
        var itemShelf = _inventory.Where(shelf => shelf.Code == code);
        if (itemShelf.SoldOut)
        {
            itemShelf.SoldOut = false;
            itemShelf.Item = item;
        }
        else
        {
            throw new Exception("Item already exists in the inventory.");
        }
    }

    public void UpdateSoldOutItem(int code)
    {
        var itemShelf = _inventory.FirstOrDefault(shelf => shelf.Code == code);
        if (itemShelf != null)
        {
            itemShelf.SoldOut = true;
        }
        else
        {
            throw new Exception("Item not found in the inventory.");
        }
    }
}
