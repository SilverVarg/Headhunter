using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Enemy/Scan")]
public class ScanState : EnemyBaseState
{
    private float rotationleft = 360;
    private float rotationspeed = 100;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public override void HandleUpdate()
    {
        float rotation = rotationspeed * Time.deltaTime;
        if (rotationleft > rotation)
        {
            rotationleft -= rotation;
        }else
        {
            rotation = rotationleft;
            rotationleft = 0;
        }
        if(rotation == 0)
        {
            setPatrol(true);
            owner.Transition<PatrollingState>();
        }
        owner.transform.Rotate(0, rotation, 0);
        
        if (InFOV() == true)
        {
            setPatrol(false);
            owner.Transition<BeginAttackState>();
        }
    }
}
