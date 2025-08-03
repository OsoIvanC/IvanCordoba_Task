using UnityEngine;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        Dragable droppedItem = eventData.pointerDrag?.GetComponent<Dragable>();
        if (droppedItem == null) return;
        
        if (transform.childCount > 0)
        {
            Transform existingItem = transform.GetChild(0);
            existingItem.SetParent(droppedItem.originalParent);
            existingItem.localPosition = Vector3.zero;
        }

        droppedItem.transform.SetParent(transform);
        droppedItem.transform.localPosition = Vector3.zero;
    }
}