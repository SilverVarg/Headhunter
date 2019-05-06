using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Enemy/Leap")]
public class Leap : EnemyBaseState
{
    private bool firstJump = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public override void HandleUpdate()
    {
        
        if (getJump() == true && firstJump == true)
        {
            Debug.Log("hit it");
            firstJump = false;
            owner.Transition<ScanState>();
        }
        if (getJump() == true)
        {
            firstJump = true;
            SetLeap(false);
        }
    }
}
