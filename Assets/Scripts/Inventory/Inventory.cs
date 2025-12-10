using UnityEngine;
using UnityEngine.Events;

public class Inventory : MonoBehaviour
{
    public static Inventory Instance;

    private ItemData[] data = new ItemData[8];

    public ItemData[] Data
    {
        get { return data; }
        private set { data = value; }
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

    public int AddToInventory(ItemData newData)
    {
        int slotIndex = FindObjectInArray(null, data);
        if (slotIndex >= 0) data[slotIndex] = newData;

        inventoryUpdated.Invoke();

        return slotIndex;
    }

    public int DeleteFromInventory(ItemData toBeDeleted)
    {
        int slotIndex = FindObjectInArray(toBeDeleted, data);
        if (slotIndex >= 0) data[slotIndex] = null;

        return slotIndex;
    }

    public int SearchInventoryForItem(ItemData target)
    {
        return FindObjectInArray(target, data);
    }

    private int FindObjectInArray(object obj, ItemData[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] == obj)
            {
                return i;
            }
        }
        return -1;
    }
}
