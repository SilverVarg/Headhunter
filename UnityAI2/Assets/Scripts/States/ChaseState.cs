// Daniel Fors
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy/ChaseState")]
public class ChaseState : EnemyBaseState
{
    // Attributes
    [SerializeField] private float attackDistance;
    [SerializeField] private float lostTargetDistance;

    // Methods
    public override void HandleUpdate()
    {
        owner.agent.SetDestination(owner.player.transform.position);

        if (!CanSeePlayer())
            owner.Transition<AlertState>();
        else if (Vector3.Distance(owner.transform.position, owner.player.transform.position) < attackDistance)
            owner.Transition<AttackState>();
        else if (Vector3.Distance(owner.transform.position, owner.player.transform.position) > lostTargetDistance)
            owner.Transition<PatrolState>();
    }
}
