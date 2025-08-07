using UnityEngine;

using System.Collections.Generic;
public class Inventory : MonoBehaviour
{
    [field: SerializeField] List<Item> items;
    public List<Item>  GetItems {  get { return items; } } 
}
