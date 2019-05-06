using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBaseState : EnemyState
{
    
    [SerializeField] protected Material material;

    private FieldOfViewDetection FOV;
    protected EnemyStateHandler owner;
    private EnemyPatrolPoints PatrolPoints;
    private Boxleap boxleap;

    public override void Enter()
    {
        owner.enemyRenderer.material = material;
        FOV = owner.GetComponent<FieldOfViewDetection>();
        PatrolPoints = owner.GetComponent<EnemyPatrolPoints>();
        boxleap = owner.GetComponent<Boxleap>();
        // owner.enemyAgent.speed = moveSpeed;
    }

    public override void Initialize(EnemyStateMachine owner)
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
    protected void SetLeap(bool set)
    {
        boxleap.setStopJump(set);
    }
    protected bool getJump()
    {
       return boxleap.getJumpBool();
    }
}
