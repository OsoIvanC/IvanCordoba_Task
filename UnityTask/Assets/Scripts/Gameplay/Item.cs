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

    Inventory PlayerInventory;

    private void Awake()
    {
        PlayerInventory = FindFirstObjectByType<Inventory>();
    }
    private void PickUp()
    {
        PlayerInventory.GetItems.Add(this);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PickUp();
            this.gameObject.SetActive(false);
        }
    }
    
}
