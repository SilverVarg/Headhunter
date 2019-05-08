using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostTeleport : MonoBehaviour
{
    public Transform Teleport;
    private MeshRenderer ghostrenderer;
    private bool invisible = true;
    private bool flashingInvisible = true;
    private float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        ghostrenderer = GetComponent<MeshRenderer>();
        ghostrenderer.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (invisible == true)
        {
            timer += 3 * Time.deltaTime;
           
            if (timer > 13 && timer < 13.2)
            {
                ghostrenderer.enabled = true;
                flashingInvisible = false;
            }
            if (timer > 13.2 && timer < 13.4 && flashingInvisible == false)
            {
                ghostrenderer.enabled = false;
                flashingInvisible = true;
            }
            if (timer > 13.4 && timer < 13.6 && flashingInvisible == true)
            {
                ghostrenderer.enabled = true;
                flashingInvisible = false;
            }
            if (timer > 13.8 && timer < 14 && flashingInvisible == false)
            {
                ghostrenderer.enabled = false;
                flashingInvisible = true;
                
            }
            if (timer > 14 && timer < 14.2 && flashingInvisible == true)
            {
                ghostrenderer.enabled = true;
                flashingInvisible = false;
                timer = 0;
                invisible = false;
            }
        }
        if (invisible == false)
        {
            timer += 3 * Time.deltaTime;

            if (timer > 11 && timer < 11.2)
            {
                ghostrenderer.enabled = true;
                flashingInvisible = false;
            }
            if (timer > 11.2 && timer < 11.4 && flashingInvisible == false)
            {
                ghostrenderer.enabled = false;
                flashingInvisible = true;
            }
            if (timer > 11.4 && timer < 11.6 && flashingInvisible == true)
            {
                ghostrenderer.enabled = true;
                flashingInvisible = false;
            }
            if (timer > 11.8 && timer < 12 && flashingInvisible == false)
            {
                ghostrenderer.enabled = false;
                flashingInvisible = true;

            }
            if (timer > 12 && timer < 12.2 && flashingInvisible == true)
            {
                ghostrenderer.enabled = true;
                flashingInvisible = false;
               
            }
            if (timer > 12.2 && timer < 12.4 && flashingInvisible == false)
            {
                ghostrenderer.enabled = false;
                flashingInvisible = true;
                timer = 0;
                invisible = true;

            }
        }


    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("hitGhostTrigger");
        if (other.tag == "Player")
        {
            transform.position = Teleport.transform.position;
        }
    }
}
