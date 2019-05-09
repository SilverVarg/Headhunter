using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SaltShed : MonoBehaviour
{
    private bool SaltActive = false;
    public GameObject SaltItem;
    GameObject SaltItemClone;
    public GameObject SaltDispenser;
    private PickUp pick;
    private bool SaltIsDestroyed = false;
    private PlayerInventory playerInventory;
    GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
      Player = GameObject.FindGameObjectWithTag("Player");
      playerInventory = Player.GetComponent<PlayerInventory>();


    }

    // Update is called once per frame
    void Update()
    {
        if( playerInventory.getSaltDestroyed() == true)
        {
            Debug.Log("GoSalt");
            SaltItemClone = SaltItem;
            pick = SaltItemClone.GetComponent<PickUp>();
            pick.Player = GameObject.FindGameObjectWithTag("Player");
            pick.ItemNr1 = GameObject.FindGameObjectWithTag("PickUpCanvas");
            pick.Instruction = pick.ItemNr1.GetComponent<Text>();
            
            SaltItemClone = Instantiate(SaltItem, SaltDispenser.transform.position, SaltDispenser.transform.rotation);
            playerInventory.SetSaltDestoyed(false);

            SaltActive = true;
        }
    }
    private void OnTriggerStay(Collider other)
    {

        if (other.tag == "Saltbottle")
        {

            SaltActive = true;
        }
     }
    private void OnTriggerExit(Collider other)
    {

        if (other.tag == "Saltbottle")
        {
            SaltActive = false;
        }
    }

}
