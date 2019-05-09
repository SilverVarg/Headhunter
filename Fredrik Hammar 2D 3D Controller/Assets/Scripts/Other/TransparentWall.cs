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
    public LayerMask visionMask;

    private Material originalMaterial;
    private Vector3 enterPoint;
    private bool PlayerInWall = false;
    private SpelarenTreDController TreD;
    private float OriginalSpeed;
    private float speed = 10;
    private float speedAcceleration = 0.1f;
    private bool calculateEnterpoint = false;
    private float skinwidth = 0.3f;
  
    // Start is called before the first frame update
    void Awake()
    {
        OriginalSpeed = speed;
        Renderer = GetComponent<MeshRenderer>();
        originalMaterial = Renderer.material;
        playerStateHandler = player.GetComponent<PlayerStateHandler>();
        TreD = player.GetComponent<SpelarenTreDController>();


    }

    // Update is called once per frame
    void Update()
    {
        if (playerStateHandler.current != null)
        {
            if (playerStateHandler.current.GetType().Equals(nonCorporeal.GetType()) && !(this.gameObject.layer == LayerMask.NameToLayer("Transparent")) && CanSeePlayer())
            {
             

                Renderer.material = material;
                this.gameObject.layer = LayerMask.NameToLayer("Transparent");

            }
            else if (!(playerStateHandler.current.GetType().Equals(nonCorporeal.GetType())) && this.gameObject.layer == LayerMask.NameToLayer("Transparent") || !CanSeePlayer())
            {
                if (PlayerInWall)
                {
                    Debug.Log("PlayerInWall");
                    speed += 1f * Time.deltaTime;
                    TreD.nullMovement();
                    if( calculateEnterpoint == false){


                        enterPoint.x -= player.transform.position.x - enterPoint.x;



                        enterPoint.z -= player.transform.position.z - enterPoint.z;
                       
                       
                        
                        
                        calculateEnterpoint = true;
                    }
                    player.transform.position = Vector3.MoveTowards(player.transform.position, enterPoint, speed * Time.deltaTime);
                    Debug.Log("playerpos" + player.transform.position);
                    
                    if (Vector3.Distance(player.transform.position, enterPoint) < 0.1f)
                    {
                       
                        Renderer.material = originalMaterial;
                        this.gameObject.layer = LayerMask.NameToLayer("Geometry");
                        speed = OriginalSpeed;
                        calculateEnterpoint = false;
                        PlayerInWall = false;
                        

                    }
                }
                else
                {
                    
                    Renderer.material = originalMaterial;
                    this.gameObject.layer = LayerMask.NameToLayer("Geometry");
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
      
        if (col.gameObject.tag == "Player")
        {
           
            RaycastHit ray = TreD.getHitWall();
            enterPoint = player.transform.position;
            
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
