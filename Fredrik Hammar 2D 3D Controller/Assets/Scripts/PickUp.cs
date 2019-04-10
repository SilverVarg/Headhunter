using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Player;
    public GameObject Item;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay(Collider other)
    {
        Debug.Log("hithit");
        if(other.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("E");
                Item.transform.position = Player.transform.position + new Vector3(0, 1, 0);
               // Item.rigidbody.
                Item.transform.parent = Player.transform;
              //  Item.transform.SetParent(Player.transform.parent);
            }

        }
    }
}
