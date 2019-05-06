using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class PlayerStateHandler : StateMachine
{

    [HideInInspector] public MeshRenderer Renderer;
    public LayerMask visionMask;
    public State NonCorporeal;
    public State current;
    public GameObject CanvasUiNr1;
    [HideInInspector] public Image ActiveState;
    public Sprite ActiveGhostMode;
    public Sprite NonActiveGhostMode;


    // public Player player;

    protected override void Awake()
    {
        Renderer = GetComponent<MeshRenderer>();
        ActiveState = CanvasUiNr1.GetComponent<Image>();
        base.Awake();
      
    }
    void LateUpdate()
    {
        
        current = getCurrentState();
    }
}