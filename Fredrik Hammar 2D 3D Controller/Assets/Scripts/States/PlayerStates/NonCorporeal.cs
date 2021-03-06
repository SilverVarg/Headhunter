﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Player/NonCorporeal")]
public class NonCorporeal : PlayerBaseState
{
    private bool doThisOnceNonCorporeal = true;
    // Start is called before the first frame update
    void Awake()
    {
      

     
    }
    

    // Update is called once per frame
    public override void HandleUpdate()
    {
        if (doThisOnceNonCorporeal)
        {
            Debug.Log("ChangeState");
            owner.gameObject.layer = 12;
            Debug.Log(owner.gameObject.layer);
            owner.ActiveState.sprite = owner.ActiveGhostMode;
            doThisOnceNonCorporeal = false;
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            doThisOnceNonCorporeal = true;
            owner.Transition<Corporeal>();
        }
        
    }

}