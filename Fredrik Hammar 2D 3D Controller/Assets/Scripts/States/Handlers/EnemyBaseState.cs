using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBaseState : EnemyState
{
    
    [SerializeField] protected Material material;

    private FieldOfViewDetection FOV;
    protected EnemyStateHandler owner;
    private SpelarenTreDController TreD;
    private PlayerStateHandler playerStateHandler;
    

    public override void Enter()
    {
        owner.enemyRenderer.material = material;
        FOV = owner.GetComponent<FieldOfViewDetection>();
        playerStateHandler = owner.player.GetComponent<PlayerStateHandler>();
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
    protected bool IsThePlayerAGhost()
    {
        Debug.Log(playerStateHandler.current.name);
        if (playerStateHandler.current.name == "NonCoporealState(Clone)")
        {
          
            return true;
        }
        else
        {
            return false;
        }
   
    }
   
  
   

}
