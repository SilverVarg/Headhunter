using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Enemy/GhostChase")]
public class GhostChase : EnemyBaseState
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
        if(owner.PlayerInArea == true)
        {
            owner.player.transform.position = owner.teleport.transform.position;
        }
        PlayerlastKnownLocation = owner.player.transform.position;
        if (InFOV() == false || IsThePlayerAGhost() == true)
        {
            Debug.Log("chasing last known location" + PlayerlastKnownLocation);
            owner.transform.position = Vector3.MoveTowards(owner.transform.position, PlayerlastKnownLocation, speed * Time.deltaTime);
            if (Vector3.Distance(owner.transform.position, PlayerlastKnownLocation) < 0.3f)
            {
                //   setPatrol(true);
                owner.Transition<GhostPatrol>();
            }
        }

        if ( InFOV() == true && IsThePlayerAGhost() == false)
        {
            owner.transform.LookAt(owner.player.transform.position);
            owner.transform.position = Vector3.MoveTowards(owner.transform.position, owner.player.transform.position, speed * Time.deltaTime);
            // owner.transform.rotation = Quaternion.LookRotation(owner.player.transform.position);
           
            PlayerlastKnownLocation = owner.player.transform.position;


        }
      
    }
    
}
