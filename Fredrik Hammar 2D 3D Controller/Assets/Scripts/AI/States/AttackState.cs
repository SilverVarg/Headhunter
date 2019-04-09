using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy/AttackState")]
public class AttackState : EnemyBaseState
{
    [SerializeField] private float chaseDistance;
    [SerializeField] private float cooldown;

    private float currentCool;

    public override void Enter()
    {
        base.Enter();
        currentCool = cooldown;
    }

    public override void HandleUpdate()
    {
        owner.enemyAgent.SetDestination(owner.player.transform.position);
        Attack();

        if (!CanSeePlayer())
            owner.Transition<AlertState>();
        if (Vector3.Distance(owner.transform.position, owner.player.transform.position) > chaseDistance)
            owner.Transition<ChaseState>();
        if (Input.GetKeyDown(KeyCode.Space))
            owner.Transition<FleeState>();
    }

    private void Attack()
    {
        currentCool -= Time.deltaTime;

        if (currentCool > 0)
            return;

        // We can insert attack logic here

        currentCool = cooldown;
    }
}
