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
    private SpelarentreD TreD;
    private float OriginalSpeed;
    private float speed = 10;
    private float speedAcceleration = 0.1f;
    private bool calculateEnterpoint = false;
    private float skinwidth = 0.3f;
    public LayerMask visionMask;
    // Start is called before the first frame update
    void Awake()
    {
        OriginalSpeed = speed;
        Renderer = GetComponent<MeshRenderer>();
        originalMaterial = Renderer.material;
        playerStateHandler = player.GetComponent<PlayerStateHandler>();
        TreD = player.GetComponent<SpelarentreD>();


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
              //  player.layer = LayerMask.NameToLayer("PlayerNonCorporeal");

            }
            else if (!(playerStateHandler.current.GetType().Equals(nonCorporeal.GetType())) && this.gameObject.layer == LayerMask.NameToLayer("Transparent") || !CanSeePlayer())
            {
                if (PlayerInWall)
                {
                    Debug.Log("PlayerInWall");
                    speed += 1f * Time.deltaTime;
                    TreD.nullMovement();
                    if( calculateEnterpoint == false){

                        
                            EnterPoint.x -= player.transform.position.x - EnterPoint.x;
                        
                           
                        
                            EnterPoint.z -= player.transform.position.z - EnterPoint.z;
                       
                       
                        
                        
                        calculateEnterpoint = true;
                    }
                    player.transform.position = Vector3.MoveTowards(player.transform.position, EnterPoint, speed * Time.deltaTime);
                    Debug.Log("playerpos" + player.transform.position);
                    Debug.Log("Enterpoint" + EnterPoint);
                    if (Vector3.Distance(player.transform.position, EnterPoint) < 0.1f)
                    {
                        Debug.Log("hited");
                        Renderer.material = originalMaterial;
                        this.gameObject.layer = LayerMask.NameToLayer("Geometry");
                      //  player.layer = LayerMask.NameToLayer("PlayerCorporeal");
                        speed = OriginalSpeed;
                        calculateEnterpoint = false;
                        PlayerInWall = false;
                        

                    }
                }
                else
                {
                    
                    Renderer.material = originalMaterial;
                    this.gameObject.layer = LayerMask.NameToLayer("Geometry");
                   // player.layer = LayerMask.NameToLayer("PlayerCorporeal");
                    calculateEnterpoint = false;
                    PlayerInWall = false;
                }
                
            }
        }
    }
    protected bool CanSeePlayer()
    {
        return !Physics.Linecast(transform.position, player.transform.position, visionMask);
    }
    void OnCollisionEnter(Collision col)
    {
        Debug.Log("Phit1");
        if (col.gameObject.tag == "Player")
        {
            Debug.Log("Playerhit1");
            RaycastHit ray = TreD.getHitWall();
            EnterPoint = player.transform.position;
            
        }
    }
    void OnCollisionStay(Collision col)
    {
        if (col.gameObject.tag == "Player")
        {
            Debug.Log("Playerhit2");
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
