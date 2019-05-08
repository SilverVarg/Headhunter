using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float health = 100;
    private float damageTimer;
    public Renderer rend;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        damageTimer += Time.deltaTime;
        GameController.gameControllerInstance.playerHealth = health;
        if (health < 0)
        {
            rend = GetComponent<MeshRenderer>();
            rend.enabled = false;

        }
    }

    public void Harm(float dmg)
    {
        if (damageTimer > 1.0f)
        {
            health -= dmg;
            damageTimer = 0;
        }


    }

    public void DamageFlash()
    {
        if (damaged)
        {
            DamageImage.color = damageFlashColor;
        }
        else
        {
            DamageImage.color = Color.Lerp(DamageImage.color, Color.clear, damageFlashSpeed * Time.deltaTime;)
        }
        damaged = false;
    }
}
