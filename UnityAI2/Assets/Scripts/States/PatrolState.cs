// Daniel Fors
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy/PatrolState")]
public class PatrolState : EnemyBaseState
{
    // Attributes
    [SerializeField] private Vector3[] patrolPoints;
    [SerializeField] private float chaseDistance;
    [SerializeField] private float hearingRange;

    private int currentPoint = 0;

    // Methods
    public override void Enter()
    {
        base.Enter();
        ChooseClosest();
    }

    public override void HandleUpdate()
    {
        owner.agent.SetDestination(patrolPoints[currentPoint]);
        if (Vector3.Distance(owner.transform.position, patrolPoints[currentPoint]) < 1)
            currentPoint = (currentPoint + 1) % patrolPoints.Length;

        if (CanSeePlayer() && Vector3.Distance(owner.transform.position, owner.player.transform.position) < chaseDistance)
            owner.Transition<ChaseState>();
        else if (Input.GetKeyDown(KeyCode.Space) && Vector3.Distance(owner.transform.position, owner.player.transform.position) < hearingRange)
            owner.Transition<AlertState>();
    }

    private void ChooseClosest()
    {
        int closest = 0;
        for (int i = 0; i < patrolPoints.Length; i++)
        {
            float dist = Vector3.Distance(owner.transform.position, patrolPoints[i]);
            if (dist < Vector3.Distance(owner.transform.position, patrolPoints[closest]))
                closest = i;
        }
        currentPoint = closest;
    }
}
