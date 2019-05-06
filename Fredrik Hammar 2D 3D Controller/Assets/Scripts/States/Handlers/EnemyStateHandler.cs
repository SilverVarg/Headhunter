using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateHandler : EnemyStateMachine
{

    [HideInInspector] public MeshRenderer enemyRenderer;
    public LayerMask visionMask;
    
     public GameObject player;
  //  private FieldOfViewDetection FOV;


    protected override void Awake()
    {
       // FOV = GetComponent<FieldOfViewDetection>();

        enemyRenderer = GetComponent<MeshRenderer>();
        base.Awake();
    }
   
}
