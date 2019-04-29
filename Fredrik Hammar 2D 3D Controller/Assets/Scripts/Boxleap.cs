using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boxleap : MonoBehaviour
{
    protected float Animation;
    private bool StopJump = true;
    private Vector3 player;
    public Transform target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(StopJump == true)
        {
            if (target != null)
            {
                 player = target.transform.position;
            }
        }
        if (StopJump == false)
        {
            Animation += Time.deltaTime;

            if (Animation != Animation % 2f)
            {
                Debug.Log("AnimationHit");
                StopJump = true;
            //   Animation = Animation % 2f;
            }

            transform.position = MathParabola.Parabola(transform.position, player * 1f, 1f, Animation / 2f);

        }
    }
    public void setStopJump(bool set)
    {
        StopJump = set;
    }
    public bool getJumpBool()
    {
       return StopJump;
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Player1");
        if (other.tag == "Player")
        {
            Debug.Log("Player2");
            Application.LoadLevel(0);
        }
    }
}
