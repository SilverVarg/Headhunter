﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    //protected int objectsInInventory = 0;
    
    //public void CountInventory()
    //{
    //    objectsInInventory++;
    //}

    //public void removeOneFromInventory()
    //{
    //    objectsInInventory--;
    //}

    //public int GetAmountOfObjectsInInventory()
    //{
    //    return objectsInInventory;
    //}
    
    // Property for maintaining single instance
    public static Inventory Instance
    {
        get
        {
            if (ThisInstance == null)
            {
                GameObject InventoryObject = new GameObject("Inventory");
                ThisInstance = InventoryObject.AddComponent<Inventory>();
            }
            return ThisInstance;
        }
    }

    // Reference to singleton object
    private static Inventory ThisInstance = null;

    // Root object of item list
    public RectTransform ItemList = null;
    //----------------------------------------------------
    // Use this for initialization
    private void Awake()
    {
        // If single object already exists then destroy
        if (ThisInstance != null)
        {
            DestroyImmediate(gameObject);
            return;
        }

        // Make this single instance
        ThisInstance = this;
    }


 
    public static void AddItem(GameObject GO)
        {
        
            // Disable all colliders for added object
            foreach (Collider C in GO.GetComponents<Collider>())
                C.enabled = false;

            // Disable renderers
            foreach (MeshRenderer MR in GO.GetComponents<MeshRenderer>())
                MR.enabled = false;

            // Add to first available slot
            for (int i=0; i<ThisInstance.ItemList.childCount; i++)
            {
                Transform Item = ThisInstance.ItemList.GetChild(i);

                // If item is not active, then it becomes new slot
                if (!Item.gameObject.activeSelf)
                {
                    Item.GetComponent<Image>().sprite = GO.GetComponent<InventoryItem>().GUI_Icon;
                    Item.gameObject.SetActive(true);
                    return;
                }
            }
        
        }




    //public static void RemoveItem()

    //{
    //    if (Input.GetKeyDown(KeyCode.U))

    //    {
    //        if (Input.GetKeyDown(KeyCode.U))

    //        {
    //            Transform itemToRemove = ThisInstance.ItemList.GetChild(0);
    //            GameObject GO = itemToRemove.gameObject;

    //            foreach (Collider C in GO.GetComponents<Collider>())
    //                C.enabled = true;

    //            foreach (MeshRenderer MR in GO.GetComponents<MeshRenderer>())
    //                MR.enabled = true;

    //            GO.SetActive(true);

    //            GameObject iconToRemove = GameObject.FindGameObjectWithTag("ItemSlot00");
    //            iconToRemove.GetComponent<SpriteRenderer>().enabled = false;
    //            Inventory.Instance.removeOneFromInventory();
    //        }
    //    }
    //}
}
