using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Enemy/BeginAttack")]
public class BeginAttackState : EnemyBaseState
{
    private float speed = 14;
    private bool StopbeginAttack = false;
    public float waitSecond = 0.3f;
    public float StartLeapWhenThisClose = 10f;
    private Vector3 PlayerlastKnownLocation;
    // Start is called before the first frame update
    void Start()
    {
      //  PlayerlastKnownLocation = owner.player.transform.position;

    }

    // Update is called once per frame
    public override void HandleUpdate()
    {
        if(owner.Disable == true)
        {
            owner.Transition<Disabled>();
        }
        if (InFOV() == false || IsThePlayerAGhost() == true)
        {
            Debug.Log("chasing last known location" + PlayerlastKnownLocation);
            owner.transform.position = Vector3.MoveTowards(owner.transform.position, PlayerlastKnownLocation, speed * Time.deltaTime);
         
            if (Vector3.Distance(owner.transform.position, PlayerlastKnownLocation) < 0.3f)
            {
                //   setPatrol(true);
                owner.Transition<PatrollingState>();
            }
        }
        if (StopbeginAttack)
        {
            owner.StartCoroutine(WaitfewSecs());
        }
        
        if (!StopbeginAttack && InFOV() == true && IsThePlayerAGhost() == false)
        {
            owner.transform.LookAt(owner.player.transform.position);
            owner.transform.position = Vector3.MoveTowards(owner.transform.position, owner.player.transform.position, speed * Time.deltaTime);
            // owner.transform.rotation = Quaternion.LookRotation(owner.player.transform.position);
            PlayerlastKnownLocation = owner.player.transform.position;
            if (Vector3.Distance(owner.transform.position, owner.player.transform.position) < StartLeapWhenThisClose)
            {
               // owner.rigid.useGravity = false;
               // owner.rigid.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ;
                owner.target = owner.Leaptarget.transform.position;
                Debug.Log("hitLeap");
                StopbeginAttack = true;

                
            }
           


        }
      
    }
    IEnumerator WaitfewSecs()
    {

        yield return new WaitForSeconds(waitSecond);
        StopbeginAttack = false;
        owner.Transition<Leap>();
    }
}
