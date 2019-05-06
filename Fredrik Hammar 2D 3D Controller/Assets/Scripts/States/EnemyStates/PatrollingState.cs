using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Enemy/Patrolling")]
public class PatrollingState : EnemyBaseState
{
    private float waitTime;
    private int randomSpot;
    public float speed;
    private bool patrolling = true;
    public float startWaitTime;
    private RaycastHit rayCast;
    public float gravityStrength = 3;
    private int Aposition = 0;
    private float timer = 0;
    private Vector3 checkIfAtStandStill;
    private Vector3 BackTrack;
    private bool BackwardsMove = false;
    private bool timerChecked = false;

    // Start is called before the first frame update
    void Start()
    {
        //  owner.gameObject.layer = LayerMask.NameToLayer("PlayerCorporeal");
        
        waitTime = startWaitTime;
        randomSpot = 0;
    }

    // Update is called once per frame
    public override void HandleUpdate()
    {
        timer += 1 * Time.deltaTime;
        if(timer > 1 && !timerChecked)
        {
            checkIfAtStandStill = owner.transform.position;
            timerChecked = true;
        }
        if (timer > 2 && !BackwardsMove)
        {
            if (Vector3.Distance(owner.transform.position, checkIfAtStandStill) < 0.1f)
            {
               // Debug.Log("NotMoving");
                BackTrack = (owner.transform.forward * -1) ;
                BackwardsMove = true;
            }
            else
            {
                timerChecked = false;
                timer = 0;
            }
          
               
        }
      
        //  owner.transform.position += new Vector3(0, -6, 0) * gravityStrength * Time.deltaTime;
        //transform.position = Vector3.MoveTowards(transform.position, moveSpots[randomSpot].position, speed * Time.deltaTime);
        // find the target position relative to the player:
        if (!BackwardsMove)
        {
            Vector3 dir = owner.moveSpots[randomSpot].position - owner.transform.position;
            // calculate movement at the desired speed:
            Vector3 movement = dir.normalized * speed * Time.deltaTime;
            // limit movement to never pass the target position:
            if (movement.magnitude > dir.magnitude)
            {
                movement = dir;
            }


            // move the character:
            if (owner.charcon != null)
            {
                owner.charcon.Move(movement);
            }
            else
            {
                Debug.Log("Nocharcon");
            }
            owner.transform.rotation = Quaternion.LookRotation(movement);
            //   owner.transform.rotation = Quaternion.Euler(0f, Quaternion.LookRotation(movement).y, 0f);
            owner.transform.rotation = Quaternion.Euler(0, owner.transform.eulerAngles.y, 0);
        }
        if (BackwardsMove)
        {
            Debug.Log("NotMoving");
            owner.transform.position = owner.moveSpots[randomSpot].position;
            timerChecked = false;
            timer = 0;
            BackwardsMove = false;
        }





        //   transform.rotation = Quaternion.Euler(0f, Quaternion.LookRotation(movement).y, 0f);

        if (Vector3.Distance(owner.transform.position, owner.moveSpots[randomSpot].position) < 0.5f)
            {
                if (waitTime <= 0)
                {
                    // Debug.Log("hitSpot");
                    Aposition++;
                    if (Aposition > owner.moveSpots.Length - 1)
                    {
                    Debug.Log(Aposition);
                        // Debug.Log("hitSpot2" + moveSpots.Length + "this is not the array" + Aposition);
                        Aposition = 0;
                    }
                    randomSpot = Aposition;
                    waitTime = startWaitTime;

                }
                else
                {
                    waitTime -= Time.deltaTime;
                }
            }
        

        if (InFOV() == true)
        {
          //  setPatrol(false);
            owner.Transition<BeginAttackState>();
        }
    }

}
