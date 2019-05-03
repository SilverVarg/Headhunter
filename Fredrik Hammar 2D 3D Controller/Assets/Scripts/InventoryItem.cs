using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InventoryItem : MonoBehaviour
{

    public enum ITEMTYPE { OILCAN, POWERUP, SALTBOTTLE };
    public ITEMTYPE Type;
    public Sprite GUI_Icon = null;

    void OnTriggerEnter(Collider Col)
    {
        if (!Col.CompareTag("Player"))
            return;

        
       // Add this item to the inventory
        Inventory.AddItem(gameObject);
        Debug.Log("Added object");
        
    }




    void Start()
    {


    }


    //void Update(Collider Col)
    //{
    //    if (Input.GetKeyDown(KeyCode.E) && !Col.CompareTag("Player") && )
    //        return;

    //    // Add this item to the inventory
    //    Inventory.AddItem(gameObject);

    //if (Input.GetKeyDown(KeyCode.E))
    //{
    //    if (CompareTag("Saltbottle") || CompareTag("Powerup") || CompareTag("Oilcan") && (player.transform.position - this.transform.position).sqrMagnitude < 3 * 3)
    //    {
    //        //CheckPickUp(GetComponent<Collider>());
    //        if (transform.parent = null)
    //        {
    //            Inventory.AddItem(gameObject);
    //        }

    //    }
    //}


    //void CheckPickUp(Collider Col)
    //{
    //    if (!Col.CompareTag("Player"))
    //        return;

    //    Inventory.AddItem(gameObject);
    //}


}
