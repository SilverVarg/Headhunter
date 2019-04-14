using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerStateHandler : StateMachine
{

    [HideInInspector] public MeshRenderer Renderer;
    public LayerMask visionMask;
    public State NonCorporeal;
    public State current;
    // public Player player;

    protected override void Awake()
    {
        Renderer = GetComponent<MeshRenderer>();
        base.Awake();
    }
    void LateUpdate()
    {
        
        current = getCurrentState();
    }
}