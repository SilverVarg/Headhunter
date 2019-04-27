using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Enemy/BeginAttack")]
public class BeginAttackState : EnemyBaseState
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public override void HandleUpdate()
    {
        if (InFOV() == false)
        {
            setPatrol(true);
        }
    }
}
