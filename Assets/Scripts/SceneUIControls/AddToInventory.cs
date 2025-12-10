using UnityEngine;

public class AddToInventory : MonoBehaviour
{
    [SerializeField]
    public ItemData dataToBeAdded;
    public void addToInventory()
    {
        Inventory.Instance.AddToInventory(dataToBeAdded);
    }
}
