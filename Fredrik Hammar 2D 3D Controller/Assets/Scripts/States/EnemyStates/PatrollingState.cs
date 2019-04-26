using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Enemy/Patrolling")]
public class PatrollingState : EnemyBaseState
{
    // Start is called before the first frame update
    void Start()
    {
      //  owner.gameObject.layer = LayerMask.NameToLayer("PlayerCorporeal");

    }

    // Update is called once per frame
    public override void HandleUpdate()
    {


        if (InFOV() == true)
        {
            setPatrol(false);
            owner.Transition<BeginAttackState>();
        }
    }

}
