using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy/AlertState")]

public class AlertState : EnemyBaseState
{
    [SerializeField] private float chaseDistance;

    public override void Enter()
    {
        base.Enter();
        owner.enemyAgent.SetDestination(owner.player.transform.position);
    }

    public override void HandleUpdate()
    {
        if (CanSeePlayer() && Vector3.Distance(owner.transform.position, owner.player.transform.position) < chaseDistance)
            owner.Transition<ChaseState>();
        if (owner.enemyAgent.remainingDistance < 1)
            owner.Transition<PatrolState>();
    }
}
