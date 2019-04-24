using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialScript : MonoBehaviour
{
    public GameObject scroll;
    public GameObject text;

    // Start is called before the first frame update
    void Start()
    {
        scroll.SetActive(false);
        text.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("enter trigger");

        if (other.CompareTag("Player"))
        {
            scroll.SetActive(true);
            text.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            scroll.SetActive(false);
            text.SetActive(false);
        }
    }
}
