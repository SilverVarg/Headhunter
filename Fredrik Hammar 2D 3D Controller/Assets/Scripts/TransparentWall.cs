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
    private Vector3 EnterPoint;
    private bool PlayerInWall = false;

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
        if (playerStateHandler.current != null)
        {
            if (playerStateHandler.current.GetType().Equals(nonCorporeal.GetType()) && !(this.gameObject.layer == LayerMask.NameToLayer("Transparent")) && CanSeePlayer())
            {
                //Debug.Log("baboi");

                Renderer.material = material;
                this.gameObject.layer = LayerMask.NameToLayer("Transparent");
                player.layer = LayerMask.NameToLayer("PlayerNonCorporeal");

            }
            else if (!(playerStateHandler.current.GetType().Equals(nonCorporeal.GetType())) && this.gameObject.layer == LayerMask.NameToLayer("Transparent") || !CanSeePlayer())
            {
                if (PlayerInWall)
                {
                    player.transform.position = EnterPoint;
                    PlayerInWall = false;
                }
                Renderer.material = originalMaterial;
                this.gameObject.layer = LayerMask.NameToLayer("Geometry");
                player.layer = LayerMask.NameToLayer("PlayerCorporeal");
            }
        }
    }
    protected bool CanSeePlayer()
    {
        return !Physics.Linecast(transform.position, player.transform.position, visionMask);
    }
    void OnCollisionEnter(Collision col)
    {
        //Debug.Log("Playerhit1");
        if (col.gameObject.tag == "Player")
        {
            EnterPoint = player.transform.position;
        }
    }
    void OnCollisionStay(Collision col)
    {
        if (col.gameObject.tag == "Player")
        {
            PlayerInWall = true;
        }
    }
    void OnCollisionExit(Collision col)
    {
        if (col.gameObject.tag == "Player")
        {
            PlayerInWall = false;
        }
    }
}
