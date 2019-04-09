using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBaseState : State
{
    [SerializeField] protected float moveSpeed;
    [SerializeField] protected Material material;

    protected EnemyController owner;

    public override void Enter()
    {
        owner.enemyRenderer.material = material;
        owner.enemyAgent.speed = moveSpeed;
    }

    public override void Initialize(StateMachine owner)
    {
        this.owner = (EnemyController)owner;
    }

    protected bool CanSeePlayer()
    {
        return !Physics.Linecast(owner.transform.position, owner.player.transform.position, owner.visionMask);
    }
}
