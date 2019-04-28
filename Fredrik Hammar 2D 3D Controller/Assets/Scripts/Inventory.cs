using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public int objectsInInventory = 0;
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

    

    public static void Start()
    {
       
        //ThisInstance.GetComponent<Inventory>();
        
    }

    public static void Update()
    {
        //if (Input.GetKeyDown(KeyCode.I))
        //{
            
        //    ThisInstance.enabled = !ThisInstance.enabled;
        //    Debug.Log("Knappen i trycktes ned");
        //}
    }


//----------------------------------------------------
    public static void AddItem(GameObject GO)
    {
        {
            //Disable all colliders for added object
            foreach (Collider C in GO.GetComponents<Collider>())
                C.enabled = false;

            // Disable renderers
            foreach (MeshRenderer MR in GO.GetComponents<MeshRenderer>())
                MR.enabled = false;

            // Add to first available slot
            for (int i = 0; i < ThisInstance.ItemList.childCount; i++)
            {
                Transform Item = ThisInstance.ItemList.GetChild(i);
                // If item is not active, then it becomes new slot
                if (!Item.gameObject.activeSelf)
                {
                    Item.GetComponent<Image>().sprite = GO.GetComponent<PickUp>().GUI_Icon;
                    Item.gameObject.SetActive(true);
                    return;
                }
            }
        }

    }
}
