using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBaseState : State
{
    [SerializeField] protected float moveSpeed;
    [SerializeField] protected Material material;

    private FieldOfViewDetection FOV;
    protected EnemyStateHandler owner;
    private EnemyPatrolPoints PatrolPoints;

    public override void Enter()
    {
        owner.enemyRenderer.material = material;
        FOV = owner.GetComponent<FieldOfViewDetection>();
        PatrolPoints = owner.GetComponent<EnemyPatrolPoints>();
        // owner.enemyAgent.speed = moveSpeed;
    }

    public override void Initialize(StateMachine owner)
    {
        this.owner = (EnemyStateHandler)owner;
    }

    protected bool CanSeePlayer()
    {
        return !Physics.Linecast(owner.transform.position, owner.player.transform.position, owner.visionMask);
    }
    protected bool InFOV()
    {
        return FOV.getInFov();
    }
    protected void setPatrol(bool patrol)
    {
        PatrolPoints.setPatrolling(patrol);
    }
}
