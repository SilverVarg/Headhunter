using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItem : MonoBehaviour
{
    public enum ITEMTYPE { BALL, BALL2, BALL3 };
    public ITEMTYPE Type;
    public Sprite GUI_Icon = null;

    void Update()
    {
        if (CompareTag("InventoryItem") && Input.GetKeyDown(KeyCode.E))
        {
            //CheckPickUp(GetComponent<Collider>());

            Inventory.AddItem(gameObject);
        }
    }

    //void CheckPickUp(Collider Col)
    //{
    //    if (!Col.CompareTag("Player"))
    //        return;

    //    Inventory.AddItem(gameObject);
    //}

}
