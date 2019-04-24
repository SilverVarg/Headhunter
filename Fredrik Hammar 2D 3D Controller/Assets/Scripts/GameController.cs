using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController gameControllerInstance;
    public Slider healthSlider;
    public float playerHealth;

    // Start is called before the first frame update
    void Start()
    {
        gameControllerInstance = this;

    }

    // Update is called once per frame
    void Update()
    {
        healthSlider.value = playerHealth;
    }
}
