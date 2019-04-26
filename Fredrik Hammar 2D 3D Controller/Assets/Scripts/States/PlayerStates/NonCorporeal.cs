using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Player/NonCorporeal")]
public class NonCorporeal : PlayerBaseState
{
    
    // Start is called before the first frame update
    void Start()
    {
        owner.gameObject.layer = LayerMask.NameToLayer("PlayerNonCorporeal");

        // Player = owner.GetComponent<SpelarentreD>();
        //   Player.Corporeal = false;
    }

    // Update is called once per frame
    public override void HandleUpdate()
    {

        if (Input.GetKeyDown(KeyCode.R))
        {
            owner.Transition<Corporeal>();
        }
        
    }

}