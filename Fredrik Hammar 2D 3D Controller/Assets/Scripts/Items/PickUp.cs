using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUp : MonoBehaviour
{
   
   
    public GameObject Player;
    public GameObject Item;
    public bool thisobjectisheld = false;

    private SpelarenTreDController TreD;
    private Rigidbody rigid;
    private float turnSpeed = 5000f;
    private Transform ItemPlacer;
    private GameObject ItemPlacerGameObject;
    private float timer = 0;
    private PlayerInventory inventory;
    public GameObject ItemNr1;
    [HideInInspector]public Text Instruction;

    public Sprite GUI_Icon = null;

    void Awake()
    {
       
        inventory = Player.GetComponent<PlayerInventory>();
        TreD = Player.GetComponent<SpelarenTreDController>();
        rigid = Item.GetComponent<Rigidbody>();
        ItemPlacer = Player.gameObject.transform.Find("LayDownItem");
        ItemPlacerGameObject = ItemPlacer.gameObject;
        if (ItemNr1 != null)
        {
            Instruction = ItemNr1.GetComponent<Text>();
        }

    }

    // Update is called once per frame
    void LateUpdate()
    {
        //if (thisobjectisheld && timer < 1)
        //{
        //    timer += 1 * Time.deltaTime;
        //    Debug.Log(timer);

        //}
        //if (Input.GetKey(KeyCode.E) && TreD.objectHeld == true && timer >= 1)
        //{
        //    ItemPlacerGameObject.SetActive(true);
        //    ItemPlacer.transform.Rotate(0, turnSpeed * Time.deltaTime, 0);
        //    //   turnSpeed += turnSpeed * Time.deltaTime;
           
        //}
        //if (TreD != null)
        //{
        //    if (Input.GetKeyUp(KeyCode.E) && TreD.objectHeld == true && thisobjectisheld == true && timer >= 1 || TreD.playerStateHandler.current.GetType().Equals(TreD.nonCorporeal.GetType()) && thisobjectisheld == true)
        //    {

        //        //ItemPlacer.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        //        rigid.constraints = RigidbodyConstraints.None;
        //        rigid.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezePositionX;
        //        Item.transform.position = ItemPlacer.transform.position;// Player.transform.position - new Vector3(1, -1, 0);
        //        Item.transform.parent = null;
        //        TreD.objectHeld = false;
        //        thisobjectisheld = false;
        //        ItemPlacerGameObject.SetActive(false);
        //        timer = 0;
        //    }
        //}

    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player" && thisobjectisheld == false)
        {
            Instruction.text = "Press E to Pick Up";
        }
    }
    private void OnTriggerExit(Collider other)
    {

        if (other.tag == "Player")
        {
            Instruction.text = "";
        }
    }
    private void OnTriggerStay(Collider other)
    {

        if(other.tag == "Player")
        {
            if (!TreD.NonCorporeal())
            {
                if (Input.GetKeyDown(KeyCode.E)  && thisobjectisheld == false )
                {

               
                   
                    bool added = inventory.Additem(Item, GUI_Icon);
                    if (added)
                    {

                        Instruction.text = "";

                        MeshRenderer mesh = Item.GetComponent<MeshRenderer>();
                        mesh.enabled = false;


                        rigid.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ  | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezePositionX;
                      
                        Item.transform.position = Player.transform.position + new Vector3(0, 1, 0);
                       
                        Item.transform.parent = Player.transform;
                        thisobjectisheld = true;
                    }

                    // Item.transform.SetParent(Player.transform.parent);
                } 
            }
            
                
        }
    }

}
