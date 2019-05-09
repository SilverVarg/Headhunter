using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaltDisableEnemy : MonoBehaviour
{
    private EnemyStateHandler enemyStateHandler;
    public int destroyTime = 10;
    private bool Deployed;
    // Start is called before the first frame update
    void Start()
    {
        
        StartCoroutine(WaitfewSecs());
    }

    // Update is called once per frame
    void Update()
    {
        
           
        
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("hitSaltrigger");
        if (other.tag == "Enemy")
        {
            Debug.Log("hitSaltTrigger");
            enemyStateHandler = other.GetComponent<EnemyStateHandler>();
            enemyStateHandler.SetDisabled(true);
        }
    }
    IEnumerator WaitfewSecs()
    {

        yield return new WaitForSeconds(destroyTime);
     
        Destroy(this.gameObject);
    }
}
