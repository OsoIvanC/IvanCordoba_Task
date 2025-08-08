using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public static InventoryUI Instance;

    [SerializeField]
    GameObject ItemSlotPrefab;

    [SerializeField]
    GameObject Content;
    private void Awake()
    {
        Instance = this;
    }

    public void AddSlot(Item i)
    {
        ItemSlot slot = Instantiate(ItemSlotPrefab,Content.transform).GetComponent<ItemSlot>();
        slot.Item = i;
    }
}
