using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Enemy/Patrolling")]
public class PatrollingState : EnemyBaseState
{
    private float timer = 0;
    private float waitTime;
    private int randomSpot;
    private int Aposition = 0;
 
    private Vector3 checkIfAtStandStill;
    private Vector3 BackTrack;
    private bool BackwardsMove = false;
    private bool timerChecked = false;
    private bool patrolling = true;

    public float speed;
    public float startWaitTime;





    // Start is called before the first frame update
    void Start()
    {
       
        
        waitTime = startWaitTime;
        randomSpot = 0;
    }

    // Update is called once per frame
    public override void HandleUpdate()
    {
        if (owner.Disable == true)
        {
            owner.Transition<Disabled>();
        }
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
                  
                    Aposition++;
                    if (Aposition > owner.moveSpots.Length - 1)
                    {
                    
                        
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
        

        if (InFOV() == true && IsThePlayerAGhost() == false)
        {
        
            owner.Transition<BeginAttackState>();
        }
    }

}
