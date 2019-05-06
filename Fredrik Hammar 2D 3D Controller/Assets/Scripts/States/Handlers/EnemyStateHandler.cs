﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateHandler : EnemyStateMachine
{

    [HideInInspector] public MeshRenderer enemyRenderer;
    public LayerMask visionMask;
    public LayerMask FallingVision;
    public Transform[] moveSpots;
    [HideInInspector] public CharacterController charcon;
    public GameObject player;
    public GameObject Leaptarget;
    [HideInInspector] public Vector3 target;
    [HideInInspector] public Rigidbody rigid;
    [HideInInspector] public BoxCollider boxCollider;

    //  private FieldOfViewDetection FOV;


    protected override void Awake()
    {
        // FOV = GetComponent<FieldOfViewDetection>();
        boxCollider = GetComponent<BoxCollider>();
        enemyRenderer = GetComponent<MeshRenderer>();
        charcon = GetComponent<CharacterController>();
        rigid = GetComponent<Rigidbody>(); 
        base.Awake();
    }
    IEnumerator WaitfewSecs()
    {
        Debug.Log("WaitfewSec");
        yield return new WaitForSeconds(2f);
    }

}
