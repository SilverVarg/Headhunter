using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Enemy/Scan")]
public class ScanState : EnemyBaseState
{
    private float rotationleft = 360;
    private float rotationspeed = 100;
    private RaycastHit rayCast;
    private bool enterScan = true;
    public float waitSecond = 1f;
    private float speed = 10;
    private bool Checkground;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public override void HandleUpdate()
    {
        if (enterScan)
        {
            
            if (Vector3.Distance(owner.transform.position, owner.Leaptarget.transform.position) < 1f)
            {
                Debug.Log("hitWAll");
              //  owner.transform.position = Vector3.MoveTowards( owner.transform.position,transform.forward * -1, speed * Time.deltaTime);
            }
            owner.StartCoroutine(WaitfewSecs());
           
            
        }
        if (!enterScan)
        {
            Checkground = Physics.Linecast(owner.transform.position, owner.transform.position + Vector3.down * 100, out rayCast, owner.FallingVision);
            Debug.DrawLine(owner.transform.position, owner.transform.position + Vector3.down * 100, Color.blue, 4);
            if (Checkground)
            {
                //  Debug.Log("enterScan");
                // Debug.Log("hitraycast");

                //   owner.transform.position = new Vector3(owner.transform.position.x, rayCast.point.y, owner.transform.position.z);
            }
            float rotation = rotationspeed * Time.deltaTime;
            if (rotationleft > rotation)
            {
                rotationleft -= rotation;
            }
            else
            {
                rotation = rotationleft;
                rotationleft = 0;
            }
            if (rotation == 0)
            {
                // setPatrol(true);
                enterScan = true;
                owner.Transition<PatrollingState>();
            }
            owner.transform.Rotate(0, rotation, 0);

            if (InFOV() == true)
            {
                // setPatrol(false);
                Debug.Log("enterbeginAttackFromScan");

                enterScan = true;
                owner.Transition<BeginAttackState>();
            }
        }
    }
    IEnumerator WaitfewSecs()
    {

        yield return new WaitForSeconds(waitSecond);
        rotationleft = 360;
        enterScan = false;
    }

}
