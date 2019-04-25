// Daniel Fors
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy/FleeState")]
public class FleeState : EnemyBaseState
{
    // Methods
    public override void Enter()
    {
        base.Enter();
        Vector3 position;
        int currentTry = 0;
        do
        {
            position = new Vector3(Random.Range(-30, 30), 0, Random.Range(-30, 30));
            currentTry++;
        } while (Vector3.Dot(position - owner.transform.position, owner.player.transform.position - owner.transform.position) > 0 && currentTry < 100);
        owner.agent.SetDestination(position);
    }

    public override void HandleUpdate()
    {
        if (owner.agent.remainingDistance < 1)
            owner.Transition<PatrolState>();
    }
}
