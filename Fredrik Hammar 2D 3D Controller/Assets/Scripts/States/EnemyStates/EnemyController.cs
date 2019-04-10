using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : StateMachine
{
    [HideInInspector] public MeshRenderer enemyRenderer;
    [HideInInspector] public NavMeshAgent enemyAgent;
    public LayerMask visionMask;
    public SpelarentreD player;

    protected override void Awake()
    {
        enemyRenderer = GetComponent<MeshRenderer>();
        enemyAgent = GetComponent<NavMeshAgent>();
        base.Awake();
    }
}
