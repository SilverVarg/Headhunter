using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Enemy/Leap")]
public class Leap : EnemyBaseState
{
    protected float Animation;
    private bool firstJump = true;
    private bool StopJump = true;
    private float groundCheckDistance;
    public float Jumpadjust = 2;
    public float HeightAjust = 1;
    private Vector3 MoveSpot;

    // Start is called before the first frame update
    void Awake()
    {

         Animation = 0;
    }

    // Update is called once per frame
    public override void HandleUpdate()
    {
        if (firstJump)
        {
            Animation = 0;
            firstJump = false;
            StopJump = true;
        }
        Animation += Time.deltaTime;

        owner.transform.rotation = Quaternion.Euler(0, owner.transform.eulerAngles.y, 0);
       
        if (Vector3.Distance(owner.transform.position, owner.target) < 0.1f && StopJump)
            {
           
            Debug.Log("this is the target" + owner.target + "this is the players" +  owner.player.transform.position + "this is the animation" + Animation);
           
         //   bool Checkground = Physics.Linecast(owner.transform.position , owner.transform.position + Vector3.down * 100, out rayCast, owner.FallingVision);
         //   Debug.DrawLine(owner.transform.position, owner.transform.position + Vector3.down * 100, Color.blue, 4);
           
                StopJump = false;
                firstJump = true;

                owner.transform.position = new Vector3 (owner.transform.position.x,owner.player.transform.position.y, owner.transform.position.z);
                owner.transform.rotation = Quaternion.Euler(0, owner.transform.eulerAngles.y, 0);
           // owner.rigid.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ;
           // owner.rigid.useGravity = true;
            owner.Transition<ScanState>();
               // Debug.Log("hitraycast" + rayCast.point + "playpos" + owner.transform.position);
            
           // owner.transform.rotation = Quaternion.Euler(0, owner.transform.eulerAngles.y, 0);
           // owner.Transition<ScanState>();
            }
        if (StopJump)
        {
            owner.transform.position = MathParabola.Parabola(owner.transform.position, owner.target, HeightAjust, Animation / Jumpadjust);
        }


    }

    
}
