using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItem : MonoBehaviour
{
    public enum ITEMTYPE { BALL };
    public ITEMTYPE Type;
    public Sprite GUI_Icon = null;
    private GameObject player;
    private Inventory thisInventory;

    void Start()
    {
        player = GameObject.Find("Player");

    }


    void Update()
    {
        if (CompareTag("InventoryItem") && Input.GetKeyDown(KeyCode.E) && (player.transform.position-this.transform.position).sqrMagnitude<3*3)
        {
            //CheckPickUp(GetComponent<Collider>());
            if (transform.parent = null)
            {
                thisInventory.AddItem(gameObject);
            }
                
        }
    }

    //void CheckPickUp(Collider Col)
    //{
    //    if (!Col.CompareTag("Player"))
    //        return;

    //    Inventory.AddItem(gameObject);
    //}

}
