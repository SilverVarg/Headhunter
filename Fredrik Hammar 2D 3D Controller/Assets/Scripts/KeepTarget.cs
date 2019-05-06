using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepTarget : MonoBehaviour
{
    
    private RaycastHit rayCast;
    public Transform enemyOwner;
    public Transform target;
    public Transform KeepItatThisPlace;
    public LayerMask layerToCollideWith;
    private float distance = 2f;
    // Start is called before the first frame update
    void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        target.position = KeepItatThisPlace.position;
        bool CheckForObstruction = Physics.Linecast(enemyOwner.position, target.position, out rayCast, layerToCollideWith, 0);
       // Debug.DrawLine(enemyOwner.position, target.position, Color.yellow, 1);
        if (CheckForObstruction)
        {
            target.position = rayCast.point;
        }
    }
}
