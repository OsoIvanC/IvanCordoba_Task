using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour, IDropHandler, IPointerEnterHandler , IPointerExitHandler
{
    Button button;
    [SerializeField] Item item;
    public Item Item {  get { return item; } set { item = value; } } 
    private void Awake()
    {
        button = GetComponent<Button>();
    }
    private void Start()
    {
        button.onClick.AddListener(UseItem);
    }
    public void OnDrop(PointerEventData eventData)
    {
        Dragable droppedItem = eventData.pointerDrag?.GetComponent<Dragable>();
        ItemSlot slot = droppedItem?.originalParent.GetComponent<ItemSlot>();

        if (droppedItem == null) return;
        
        if (transform.childCount > 0)
        {
            Transform existingItem = transform.GetChild(0);
            existingItem.SetParent(droppedItem.originalParent);
            existingItem.localPosition = Vector3.zero;
        }

        droppedItem.transform.SetParent(transform);
        droppedItem.transform.localPosition = Vector3.zero;

        
        var temp = slot.Item;
        slot.Item = this.item;
        this.item = temp;

        
    }

    void UseItem()
    {
        if (!Inventory.Instance.CanUseItem) return;
        
        Canvas c = GetComponentInParent<Canvas>();
        
        Inventory.Instance.SwitchToActivate.Activate();
        Inventory.Instance.GetItems.Remove(item);
        gameObject.SetActive(false);
        c.gameObject.SetActive(false);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        
    }

}