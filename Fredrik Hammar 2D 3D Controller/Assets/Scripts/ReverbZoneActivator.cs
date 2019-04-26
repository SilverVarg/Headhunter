using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReverbZoneActivator : MonoBehaviour
{

    public GameObject reverbZone;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            reverbZone.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            reverbZone.SetActive(false);
        }
    }
}
