using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    // Start is called before the first frame update
   
    public GameObject Player;
    public GameObject Item;
    private SpelarentreD TreD;
    private bool thisobjectisheld = false;
    private Rigidbody rigid;
    void Start()
    {
        TreD = Player.GetComponent<SpelarentreD>();
        rigid = Item.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay(Collider other)
    {

        if(other.tag == "Player")
        {
            if (!TreD.NonCorporeal())
            {
                if (Input.GetKeyDown(KeyCode.E) && TreD.objectHeld == false && thisobjectisheld == false)
                {
                    rigid.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezePositionX;

                    // Debug.Log("E");
                    Item.transform.position = Player.transform.position + new Vector3(0, 1, 0);
                    // Item.rigidbody.
                    Item.transform.parent = Player.transform;
                    thisobjectisheld = true;
                    TreD.objectHeld = true;

                    // Item.transform.SetParent(Player.transform.parent);
                }
            }

            if (Input.GetKeyDown(KeyCode.Q) && TreD.objectHeld == true && thisobjectisheld == true|| TreD.playerStateHandler.current.GetType().Equals(TreD.nonCorporeal.GetType())&& thisobjectisheld == true)
            {
                rigid.constraints = RigidbodyConstraints.None;
                rigid.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezePositionX;
                Item.transform.position = Player.transform.position - new Vector3(1,-1, 0);
                Item.transform.parent = null;
                TreD.objectHeld = false;
                thisobjectisheld = false;
            }

        }
    }
}
