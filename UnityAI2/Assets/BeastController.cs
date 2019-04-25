using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeastController : MonoBehaviour
{
    private float waitTime;
    public float maxX;
    public float maxZ;
    public float minX;
    public float minZ;
    public float speed;
    public float startWaitTime;
    public Transform moveSpot;

    private void Start()
    {
        waitTime = startWaitTime;

        moveSpot.position = new Vector3(Random.Range(minX, maxX), 0, Random.Range(minZ, maxZ));
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, moveSpot.position, speed * Time.deltaTime);
        if (Vector2.Distance(transform.position, moveSpot.position) < 0.2f)
        {
            if (waitTime <= 0)
            {
                moveSpot.position = new Vector3(Random.Range(minX, maxX), 0, Random.Range(minZ, maxZ));
                transform.position = Vector2.MoveTowards(transform.position, moveSpot.position, speed * Time.deltaTime);
                waitTime = startWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
    }
}
