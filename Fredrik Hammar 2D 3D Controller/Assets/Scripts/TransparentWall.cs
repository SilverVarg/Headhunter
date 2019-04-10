using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransparentWall : MonoBehaviour
{
    [HideInInspector] public MeshRenderer Renderer;
    private PlayerStateHandler playerStateHandler;
    public GameObject player;
    public State nonCorporeal;
    public Material material;
    private Material originalMaterial;

    public LayerMask visionMask;
    // Start is called before the first frame update
    void Awake()
    {
        Renderer = GetComponent<MeshRenderer>();
        originalMaterial = Renderer.material;
        playerStateHandler = player.GetComponent<PlayerStateHandler>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerStateHandler.current.GetType().Equals(nonCorporeal.GetType()) && !(this.gameObject.layer == LayerMask.NameToLayer("Transparent")))
        {
            //Debug.Log("baboi");
            
            Renderer.material = material;
            this.gameObject.layer = LayerMask.NameToLayer("Transparent");

        }
        else if (!(playerStateHandler.current.GetType().Equals(nonCorporeal.GetType())) && this.gameObject.layer == LayerMask.NameToLayer("Transparent"))
        {
            Renderer.material = originalMaterial;
            this.gameObject.layer = LayerMask.NameToLayer("Geometry");
        }
    }
    protected bool CanSeePlayer()
    {
        Debug.Log("playerpos" + player.transform.position);
        return !Physics.Linecast(transform.position, player.transform.position, visionMask);
    }
}
