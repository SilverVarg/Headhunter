using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy/FleeState")]

public class FleeState : EnemyBaseState
{
    public override void Enter()
    {
        base.Enter();
        Vector3 position;
        int currentTry = 0;
        do
        {
            position = new Vector3(Random.Range(-50, 50), 0, Random.Range(-50, 50));
            currentTry++;
        } while (Vector3.Dot(position - owner.transform.position, owner.player.transform.position - owner.transform.position) > 0 && currentTry < 100);
        owner.enemyAgent.SetDestination(position);
    }

    public override void HandleUpdate()
    {
        if (owner.enemyAgent.remainingDistance < 1)
            owner.Transition<PatrolState>();
    }
}
