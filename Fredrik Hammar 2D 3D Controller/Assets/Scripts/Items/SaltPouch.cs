using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Item/SaltPouch")]
public class SaltPouch : Action
{
    public GameObject Item;
    GameObject player;
    public bool doThisOnce = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public override void HandleUpdate()
    {
        if (Input.GetKeyUp(KeyCode.Q)){
            if (Item != null && doThisOnce == true)
            {
                player = GameObject.FindGameObjectWithTag("Player");
                owner.SetItemDestroyed(true);
                doThisOnce = false;
                GameObject DropSalt = Instantiate(Item, player.transform.position, player.transform.rotation);
                
                
            }
        }
    }
    public override void Enter()
    {
        doThisOnce = true;
    }
}
