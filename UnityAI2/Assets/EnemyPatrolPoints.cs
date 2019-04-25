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
    public float startWaitTime;
    public Transform[] moveSpots;
    private int Aposition = 0;

    private void Start()
    {
        waitTime = startWaitTime;
        randomSpot = 0;
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, moveSpots[randomSpot].position, speed * Time.deltaTime);
        if (Vector3.Distance(transform.position, moveSpots[randomSpot].position) < 0.2f)
        {
            if (waitTime <= 0)
            {
                Debug.Log("hitSpot");
                Aposition++;
                if(Aposition > moveSpots.Length - 1)
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