using UnityEngine;

public class InventorySlot
{
    public ItemData data;
    public int count;

    // Construct from raw data
    public InventorySlot(ItemData item, int quantity)
    {
        this.data = data;
        this.count = quantity;
    }

    // Construct using InventorySlot obj reference
    public InventorySlot(InventorySlot slot)
    {
        this.data = slot.data;
        this.count = slot.count;
    }
}
