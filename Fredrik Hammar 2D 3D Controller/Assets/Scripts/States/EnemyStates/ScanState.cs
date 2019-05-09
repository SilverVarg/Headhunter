using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Enemy/Scan")]
public class ScanState : EnemyBaseState
{
    private float rotationleft = 360;
    private float rotationspeed = 100;
    private float speed = 10;

    private bool enterScan = true;
    public float waitSecond = 1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public override void HandleUpdate()
    {
        if (owner.Disable == true)
        {
            owner.Transition<Disabled>();
        }
        if (enterScan)
        {
            
         
            owner.StartCoroutine(WaitfewSecs());
           
            
        }
        if (!enterScan)
        {
          
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
                enterScan = true;
                owner.Transition<PatrollingState>();
            }
            owner.transform.Rotate(0, rotation, 0);

            if (InFOV() == true && IsThePlayerAGhost() == false)
            {
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
