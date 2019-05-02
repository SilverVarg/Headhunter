using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItem : MonoBehaviour
{
    public enum ITEMTYPE { BALL, BALL2, BALL3 };
    public ITEMTYPE Type;
    public Sprite GUI_Icon = null;

    void OnTriggerEnter(Collider Col)
    {
        if (!Col.CompareTag("Player"))
            return;

        // Add this item to the inventory
        Inventory.AddItem(gameObject);
    }

}
