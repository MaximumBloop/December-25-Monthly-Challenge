using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public ItemData[] inventory = new ItemData[8];
    public Image[] inventoryUI = new Image[8];

    public void Populate()
    {
        ItemData[] slotDatas = Inventory.Instance.Data;
        for (int i = 0; i < slotDatas.Length; i++)
        {
            // clear existing data
            var slotData = slotDatas[i];
            inventory[i] = null;

            // if there is new data in the slot...
            if (slotData == null) continue;

            // ...add new data
            inventory[i] = slotData;
            inventoryUI[i].sprite = inventory[i].sprite;
        }
        Debug.Log(inventory);
    }
}
