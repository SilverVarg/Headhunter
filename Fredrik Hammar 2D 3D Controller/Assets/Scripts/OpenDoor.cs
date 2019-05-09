using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class OpenDoor : MonoBehaviour
{
    private bool opened = false;
    public GameObject LeftDoor;
    public GameObject RightDoor;
    public GameObject TargetLeft;
    public GameObject TargetRight;
    public GameObject ItemNr1;
    private Text Instruction;


    public float speed = 1.0f;
    private DoAction doAction;
    // Start is called before the first frame update
    void Start()
    {
        Instruction = ItemNr1.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (opened == true)
        {
            Debug.Log("opened");
            LeftDoor.transform.position = Vector3.MoveTowards(LeftDoor.transform.position, TargetLeft.transform.position, speed);
            RightDoor.transform.position = Vector3.MoveTowards(RightDoor.transform.position, TargetRight.transform.position, speed);


        }
    }
    private void OnTriggerExit(Collider other)
    {

        if (other.tag == "Player")
        {
            Instruction.text = "";
        }
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Songbird" && opened == false)
        {
            Instruction.text = "Press Q to Open door";
            doAction = other.GetComponent<DoAction>();
            if(doAction.Donewiththelevel() == true) { 
            if (Input.GetKeyUp(KeyCode.Q)){
            Debug.Log("opened");
            opened = true;
            }
            
                
            }


        }
        else if(other.tag == "Player" && opened == false)
        {
            Instruction.text = "You need to record 3 melodies to proceed";
        }
    }
}
