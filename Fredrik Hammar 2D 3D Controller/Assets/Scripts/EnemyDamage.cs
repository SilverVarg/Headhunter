using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public float damage = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    

    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            other.GetComponent<PlayerHealth>().Harm(damage);

        }
    }
}
