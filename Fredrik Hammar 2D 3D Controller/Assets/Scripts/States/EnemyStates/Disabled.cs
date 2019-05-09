using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Enemy/Disabled")]
public class Disabled : EnemyBaseState
{
    public float waitSecond = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public override void HandleUpdate()
    {
        owner.StartCoroutine(WaitfewSecs());
    }
    IEnumerator WaitfewSecs()
    {

        yield return new WaitForSeconds(waitSecond);
        owner.SetDisabled(false);
        owner.Transition<PatrollingState>();
    }
}
