using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "Item", menuName = "Scriptable Objects/DatabaseItems/Item")]
public class ItemData : ScriptableObject
{
    public string id;
    public Sprite sprite;
}
