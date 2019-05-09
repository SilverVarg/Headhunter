using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInventory : MonoBehaviour
{
    //Change the array for list
    public GameObject[] Items;
    private int activeItem = 0;
    private int NonActiveItem = 1;
    
    //Canvas Ui
    public GameObject ItemNr1;
    private Image ImageNr1;
    public GameObject ItemNr2;
    private Image ImageNr2;
    public GameObject ÌtemIndecator1;
    private Image ItemIndecatorImageNr1;
    public GameObject ÌtemIndecator2;
    private Image ItemIndecatorImageNr2;

    //Player Specific Properties
    public GameObject player;
    private SpelarenTreDController TreD;
    private DoAction activeAction;
    private DoAction nonActiveAction;

    private bool SaltDestroyed = true;


    // Start is called before the first frame update
    void Awake()
    {
        TreD = player.GetComponent<SpelarenTreDController>();
        Items = new GameObject[2];
        ImageNr1 = ItemNr1.GetComponent<Image>();
        ImageNr2 = ItemNr2.GetComponent<Image>();
        ImageNr1.sprite = null;
        ImageNr2.sprite = null;
        ItemNr1.SetActive(false);
        ItemNr2.SetActive(false);
        ItemIndecatorImageNr1 = ÌtemIndecator1.GetComponent<Image>();
        ItemIndecatorImageNr2 = ÌtemIndecator2.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        
        // Debug.Log("this is in the array" + Items[activeItem]);
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
           
            activeItem = 0;
            NonActiveItem = 1;
            ItemIndecatorImageNr1.color = new Vector4(255,255,255,1);
            ItemIndecatorImageNr2.color = new Vector4(255, 255, 255, 0.3f);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
          
            ItemIndecatorImageNr1.color = new Vector4(255, 255, 255, 0.3f);
            ItemIndecatorImageNr2.color = new Vector4(255, 255, 255, 1);
            activeItem = 1;
            NonActiveItem = 0;
        }
      
        if (Items[activeItem] != null)
        {
            activeAction = Items[activeItem].GetComponent<DoAction>();
            if (activeAction != null && activeAction.enabled == false)
            {
                activeAction.enabled = true;
                Debug.Log("Why is it not gone?"+  activeAction.ShouldItemBeDestroyed());
                
            }
            if (activeAction.ShouldItemBeDestroyed() == true)
            {
                SetSaltDestoyed(true);
                Debug.Log("DestroySalt");
                Dropitem();
            }

        }
        if(Items[NonActiveItem] != null)
        {
            nonActiveAction = Items[NonActiveItem].GetComponent<DoAction>();
            if (nonActiveAction != null)
            {
               
                nonActiveAction.enabled = false;
                
            }
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            
            Dropitem();
        }
       
        if (TreD.NonCorporeal())
        {
            Dropitem();
        }
    }
    public bool Additem(GameObject go, Sprite Sp)
    {
        Debug.Log(ArraySize());
        if (ArraySize() == 0)
            {
            ItemNr1.SetActive(true);
            ImageNr1.sprite = Sp;
            
            Items[0] = go;
            Debug.Log("this is the gameObject" + go.name + "this is in the array" + Items[activeItem]);
            return true;
            }else if (ArraySize() == 1)
            {
            ItemNr2.SetActive(true);
            ImageNr2.sprite = Sp;
            Items[1] = go;
            return true;
            }
        
        return false;

    }
    public bool getSaltDestroyed()
    {
        return SaltDestroyed;
    }
    public void SetSaltDestoyed(bool salt)
    {
        SaltDestroyed = salt;
    }
    private void Dropitem()
    {
      
        GameObject itemTemp = Items[activeItem];
       
        if (TreD.NonCorporeal() && ArraySize() != 0)
        {
           
            Debug.Log(Items[0]);
            ItemNr1.SetActive(false);
            ItemNr2.SetActive(false);
      
            Vector3 DropLocation = player.transform.position;
            itemTemp = Items[0];
            if (itemTemp != null)
            {
                PickUp pick = itemTemp.GetComponent<PickUp>();
                pick.thisobjectisheld = false;
                itemTemp.transform.parent = null;
                MeshRenderer mesh = itemTemp.GetComponent<MeshRenderer>();
                mesh.enabled = true;
                itemTemp.transform.position = DropLocation;
                Items.SetValue(null, 0);
            }
            itemTemp = Items[1];
            if (itemTemp != null)
            {
                PickUp pick2 = itemTemp.GetComponent<PickUp>();
                pick2.thisobjectisheld = false;

                itemTemp.transform.parent = null;
                MeshRenderer mesh = itemTemp.GetComponent<MeshRenderer>();
                mesh.enabled = true;
                DropLocation = player.transform.position + Vector3.forward;
                itemTemp.transform.position = DropLocation;

                Items.SetValue(null, 1);
            }
        }
        else if(itemTemp != null)
        {
           
            if (activeItem == 0)
            {
               
                Debug.Log("dropItem1");
                ImageNr1.sprite = null;

                activeAction = Items[activeItem].GetComponent<DoAction>();
                if (activeAction != null)
                {
                    if (activeAction.ShouldItemBeDestroyed() == true)
                    {
                        Destroy(Items[activeItem]);
                    }
                }
                Items.SetValue(Items[1], 0);
            
                Items.SetValue(null, 1);
                if(Items[0] != null)
                {
                    ImageNr1.sprite = ImageNr2.sprite;
                    ItemNr2.SetActive(false);
                }
                else
                {
                    ItemNr1.SetActive(false);
                  
                }

            }
            else if (activeItem == 1)
            {
                Debug.Log("dropItem2");
             
                ImageNr2.sprite = null;
                ItemNr2.SetActive(false);
                if(activeAction.ShouldItemBeDestroyed() == true)
                {
                    Destroy(Items[activeItem]);
                }
                Items.SetValue(null, activeItem);
            }
            PickUp pick = itemTemp.GetComponent<PickUp>();
            pick.thisobjectisheld = false;
            itemTemp.transform.parent = null;
            MeshRenderer mesh = itemTemp.GetComponent<MeshRenderer>();
            mesh.enabled = true;
            Vector3 DropLocation = player.transform.position;
            itemTemp.transform.position = DropLocation;

        }
    }
    private void DestroyItem()
    {
        

    }
    public float getActiveItem()
    {
        return activeItem;
    }
    public int ArraySize()
    {
        int i = 0;
        foreach (GameObject go in Items) {
            if (go != null)
            {

                i++;
            }
        }
        return i;
    }
}
