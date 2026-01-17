using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class Inventory : MonoBehaviour
{
    public static Inventory Instance;

    private InventorySlot[] inventory = new InventorySlot[8];

    public InventorySlot[] Data
    {
        get { return inventory; }
        private set { inventory = value; }
    }

    public UnityEvent inventoryUpdated;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    // Adds a new instance of ItemData to the inventory, or adds 1 to the inventory.count if data exists
    public int AddToInventory(ItemData newData)
    {
        // Look for a reference to newData in inventory

        int slotIndex = FindItemInInventory(newData, inventory);

        // If there is an instance, increment count at that space in inventory
        if (slotIndex >= 0) 
        {
            Debug.Log($"Instance found, increasing count to {inventory[slotIndex].count + 1}");
            inventory[slotIndex].count += 1;

        // If there is not an instance, check if there is an empty location in the array
        } else
        {
            int emptySlotIndex = FindFirstEmptyInInventory(inventory);

            // If there is not an empty location, invoke err and early return
            if (emptySlotIndex == -1) 
            {
                Debug.Log("No space available");
                // handle err
                return slotIndex;
            }

            Debug.Log($"Creating new data at slot {emptySlotIndex}");
            // otherwise, create new reference to item
            inventory[emptySlotIndex] = new InventorySlot(newData, 1);
            Debug.Log($"InventorySlot: {inventory[emptySlotIndex]}\n Data: {inventory[emptySlotIndex].data}");
            inventory[emptySlotIndex].data = newData;
            inventory[emptySlotIndex].count = 1;
        }

        inventoryUpdated.Invoke();
        return slotIndex;
    }

    // public int DeleteFromInventory(InventorySlot toBeDeleted)
    // {
    //     int slotIndex = FindObjectInArray(toBeDeleted, data);
    //     if (slotIndex >= 0) data[slotIndex] = null;

    //     inventoryUpdated.Invoke();

    //     return slotIndex;
    // }

    // public int SearchInventoryForItem(InventorySlot target)
    // {
    //     return FindObjectInArray(target, data);
    // }

    private int FindItemInInventory(ItemData obj, InventorySlot[] array)
    {
        if (obj == null) return -1;
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] != null && array[i].data == obj)
            {
                return i;
            }
        }
        return -1;
    }

    private int FindFirstEmptyInInventory(InventorySlot[] array)
    {
        for (int i = 0; i <= array.Length; i++)
        {
            if (array[i] == null) return i;
        }
        return -1;
    }
}
