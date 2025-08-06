using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public  class Switchable : MonoBehaviour
{
    [field: SerializeField] List<GameObject> ObjectsToActivate { get; set; }
    [field: SerializeField] int LayerIndexToGive { get; set; }


    public  void Activate()
    {
        foreach (GameObject obj in ObjectsToActivate)
        {
            obj.layer = LayerIndexToGive; //LOGIC
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("entered");
        if (collision.gameObject.CompareTag("box")){
            Activate();
            collision.gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        }
    }

}

