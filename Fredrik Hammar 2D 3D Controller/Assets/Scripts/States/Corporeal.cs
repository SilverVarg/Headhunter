using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Player/Corporeal")]
public class Corporeal : PlayerBaseState
{
    // Start is called before the first frame update
    void Awake()
    {
        
    }

    // Update is called once per frame
    public override void HandleUpdate()
    {


        if (Input.GetKeyDown(KeyCode.R))
        {
            owner.Transition<NonCorporeal>();
        }
    }

  }
