using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy/AlertState")]
public class AlertState : EnemyBaseState
{
    // Attributes
    [SerializeField] private float chaseDistance;

    // Methods
    public override void Enter()
    {
        base.Enter();
        owner.agent.SetDestination(owner.player.transform.position);
    }

    public override void HandleUpdate()
    {
        if (CanSeePlayer() && Vector3.Distance(owner.transform.position, owner.player.transform.position) < chaseDistance)
            owner.Transition<ChaseState>();
        if (owner.agent.remainingDistance < 1)
            owner.Transition<PatrolState>();
    }
}