using UnityEngine;


public class Movable : MonoBehaviour
{
    [SerializeField] Type boxType;
    [SerializeField] int targetLayerID;

    public Type BoxColorType { get { return boxType; } set { boxType = value; } }
   
    public void OnCollisionEnter2D(Collision2D collision)
    {
       if(collision.gameObject.layer == targetLayerID)
        {
            Debug.Log("entered movable");
            collision.gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == targetLayerID)
        {
            Debug.Log("entered movable");
            collision.gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
        }
    }
}
