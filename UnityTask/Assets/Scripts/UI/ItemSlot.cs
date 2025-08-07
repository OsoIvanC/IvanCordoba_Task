using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour, IDropHandler, IPointerEnterHandler , IPointerExitHandler
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

    public void OnPointerEnter(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }
}