using UnityEngine;

using System.Collections.Generic;
public class Inventory : MonoBehaviour
{
    public static Inventory Instance {  get; private set; }
    
    bool canUseItem;

    [field: SerializeField] List<Item> items;
    [field: SerializeField] Switchable switchToActivate;
    
    public bool CanUseItem { get => canUseItem;  set => canUseItem = value;  }
    public List<Item>  GetItems {  get { return items; } }
    public Switchable SwitchToActivate { get => switchToActivate ; set => switchToActivate = value; }
    private void Awake()
    {
        Instance = this;
    }
}
