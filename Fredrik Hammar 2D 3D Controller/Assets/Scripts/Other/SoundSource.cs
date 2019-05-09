using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundSource : MonoBehaviour
{
    public GameObject Item;
    public AudioClip audioClip;
    private DoAction doAction;
    public Songbird songBird;
    public GameObject ItemNr1;
    private Text Instruction;
    private bool play = true;
    private bool added = false;
    private bool PlayerPresent = false;

    // Start is called before the first frame update
    void Start()
    {
        Instruction = ItemNr1.GetComponent<Text>();
        //  doAction = Item.GetComponent<DoAction>();
        //   songBird = doAction.getUsingAction();
    }

    // Update is called once per frame
    void Update()
    {
      

    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            PlayerPresent = true;
        }
        if (other.tag == "Songbird" && added == false && PlayerPresent == true)
        {
            Instruction.text = "Press Q to Record song";
        }
    }
    private void OnTriggerExit(Collider other)
    {

        if (other.tag == "Player")
        {
            PlayerPresent = false;
            Instruction.text = "";
        }
    }

    private void OnTriggerStay(Collider other)
    {

        if (other.tag == "Songbird" && added == false)
        {
            if (audioClip != null)
            {
                if (Input.GetKeyUp(KeyCode.Q))
                {
                    doAction = other.GetComponent<DoAction>();
                    doAction.AddMusic(audioClip);
                    added = true;
                }
            }
        }
     }
}
