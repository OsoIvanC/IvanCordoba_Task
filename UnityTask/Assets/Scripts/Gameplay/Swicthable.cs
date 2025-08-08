using NUnit.Framework;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public  class Switchable : MonoBehaviour
{
    [field: SerializeField] List<GameObject> ObjectsToActivate { get; set; }
    [field: SerializeField] int LayerIndexToGive { get; set; }


    public  void Activate()
    {
        foreach (GameObject obj in ObjectsToActivate)
        {
            obj.layer = LayerIndexToGive;
            obj.GetComponent<SpriteRenderer>().color = Color.blue;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (Inventory.Instance.GetItems.Count <= 0)
                DialogueManaager.Instance.UpdateText("You have no gems to use");
            else
            {
                Inventory.Instance.CanUseItem = true;
                Inventory.Instance.SwitchToActivate = this;
                DialogueManaager.Instance.UpdateText("Choose a gem to use");
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Inventory.Instance.CanUseItem = true;

            Inventory.Instance.SwitchToActivate = null;
        }
    }

}

