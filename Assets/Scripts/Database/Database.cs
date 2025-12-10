using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "Database", menuName = "Scriptable Objects/Database")]
public class Database : ScriptableObject
{
    [SerializeField]
    public List<ItemData> items;
    private Dictionary<string, ItemData> db;
}
