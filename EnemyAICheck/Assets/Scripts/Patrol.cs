using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    private float waitTime;
    private int randomSpot;

    public float minX;
    public float maxX;
    public float minZ;
    public float maxZ;
    public float speed;
    public float startWaitTime;
    public Transform moveSpot;

    private void Start()
    {
        waitTime = startWaitTime;
        moveSpot.position = new Vector3(Random.Range(minX, maxX), 1.5f, Random.Range(minZ, maxZ));
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, moveSpot.position, speed * Time.deltaTime);
        if(Vector3.Distance(transform.position, moveSpot.position) < 0.2f)
        {
            if (waitTime <= 0)
            {
                moveSpot.position = new Vector3(Random.Range(minX, maxX), 1.5f, Random.Range(minZ, maxZ));
                waitTime = startWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
            
        }
    }
}
