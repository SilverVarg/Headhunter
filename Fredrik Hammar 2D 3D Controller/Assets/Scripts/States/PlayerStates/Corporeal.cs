using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Player/Corporeal")]
public class Corporeal : PlayerBaseState
{
    private bool doThisOnce = true;
    // Start is called before the first frame update
    void Awake()
    {
        

    }

    // Update is called once per frame
    public override void HandleUpdate()
    {
        if (doThisOnce)
        {
            Debug.Log("ChangeState");
            owner.gameObject.layer = 11;
            Debug.Log(owner.gameObject.layer);
            // owner.gameObject.layer = LayerMask.NameToLayer("PlayerCorporeal");
            owner.ActiveState.sprite = owner.NonActiveGhostMode;
            doThisOnce = false;
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            doThisOnce = true;
            owner.Transition<NonCorporeal>();
        }
    }

  }
