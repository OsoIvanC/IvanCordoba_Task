using UnityEngine;

public enum Type
{
    GRAY,
    RED, 
    GREEN, 
    BLUE
}
public class Item : MonoBehaviour
{
    [SerializeField] Type ItemType;
    
    private void PickUp()
    {
        Inventory.Instance.GetItems.Add(this);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PickUp();
            DialogueManaager.Instance.UpdateText($"You picked up a {ItemType.ToString().ToLower()} gem");
            InventoryUI.Instance.AddSlot(this);
            gameObject.SetActive(false);
        }
    }
    
}
