using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Enemy/BeginAttack")]
public class BeginAttackState : EnemyBaseState
{
    private float speed = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public override void HandleUpdate()
    {
        owner.transform.LookAt(owner.player.transform.position);
        owner.transform.position = Vector3.MoveTowards(owner.transform.position, owner.player.transform.position, speed * Time.deltaTime);
       // owner.transform.rotation = Quaternion.LookRotation(owner.player.transform.position);
        if (Vector3.Distance(owner.transform.position, owner.player.transform.position) < 20f)
        {
            Debug.Log("hitLeap");
            owner.Transition<Leap>();
        }
        if (InFOV() == false)
        {
            setPatrol(true);
            owner.Transition<PatrollingState>();
        }
    }
}
