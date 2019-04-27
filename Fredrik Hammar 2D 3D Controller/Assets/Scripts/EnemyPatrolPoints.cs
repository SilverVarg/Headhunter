//This script makes an enemy patrol from point to point, where points are
//game objects that can be attached to the script.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrolPoints : MonoBehaviour
{
    private float waitTime;
    private int randomSpot;
    public float speed;
    private bool patrolling = true;
    public float startWaitTime;
    public Transform[] moveSpots;
    private int Aposition = 0;
    private CharacterController charcon;

    private void Start()
    {
        charcon = GetComponent<CharacterController>();
        waitTime = startWaitTime;
        randomSpot = 0;
    }

    private void Update()
    {
        if (patrolling)
        {
            //transform.position = Vector3.MoveTowards(transform.position, moveSpots[randomSpot].position, speed * Time.deltaTime);
            // find the target position relative to the player:
            Vector3 dir = moveSpots[randomSpot].position - transform.position;
            // calculate movement at the desired speed:
            Vector3 movement = dir.normalized * speed * Time.deltaTime;
            // limit movement to never pass the target position:
            if (movement.magnitude > dir.magnitude)
            {
                movement = dir;
            }
            // move the character:
            charcon.Move(movement);
            transform.rotation = Quaternion.LookRotation(movement);
            //   transform.rotation = Quaternion.Euler(0f, Quaternion.LookRotation(movement).y, 0f);

            if (Vector3.Distance(transform.position, moveSpots[randomSpot].position) < 0.2f)
            {
                if (waitTime <= 0)
                {
                    Debug.Log("hitSpot");
                    Aposition++;
                    if (Aposition > moveSpots.Length - 1)
                    {
                        Debug.Log("hitSpot2" + moveSpots.Length + "this is not the array" + Aposition);
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
        }
    }
    public void setPatrolling(bool ChangePatrol)
    {
        patrolling = ChangePatrol;
    }
}