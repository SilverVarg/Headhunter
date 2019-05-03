using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float health = 100;
    private float damageTimer;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        damageTimer += Time.deltaTime;
        GameController.gameControllerInstance.playerHealth = health;
    }

    public void Harm(float dmg)
    {
        if (damageTimer > 1.0f)
        {
            health -= dmg;
            damageTimer = 0;
        }


    }
}
