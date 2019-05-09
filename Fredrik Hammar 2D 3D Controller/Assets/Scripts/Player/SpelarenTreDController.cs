using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpelarenTreDController : MonoBehaviour
{

    Vector3 movement = new Vector3(0f, 0f, 0f);
    Vector3 Snap = new Vector3(0f, 0f, 0f);

    public float acceleration = 10;
    public float sprintAcceleration = 6; 
    public float gravityStrength = 1;
    public float skinWidth = 0.01f;
    public float deceleration = 10;
    public float sprintMaxSpeed = 1f;
    public float turnSpeedModifier = 2f;
    public float groundCheckDistance = 0.1f;
    public float jumpdistance = 1f;
    public float maxspeed = 10;
    private float timer = 0;

    private float originalAcceleration;
    private float originalmaxspeed;

    private RaycastHit rayCast2;
    private RaycastHit normalofraycast;
    [HideInInspector] public RaycastHit rayCast;



    bool grounded;
    private bool sprinting = false;
    private bool Jumping = false;

    public float dynamicFriction = 0.3F;
    public float airResistance = 0.5F;
    public float staticFriction = 0.6F;

    private Vector3 point1;
    private Vector3 point2;
    
    public State nonCorporeal;
 
  
    public LayerMask layerToCollideWith;
    private CapsuleCollider capsuleCollider;
    [HideInInspector] public PlayerStateHandler playerStateHandler;
    public GameObject theCamera;

    
    public Transform JumpTarget;
    private Vector3 realJUmpTarget;
    private Vector3 originalPosition;
    public float JumpForwardDistance;

    // Start is called before the first frame update
    void Start()
    {
        originalAcceleration = acceleration;
        originalmaxspeed = maxspeed;
    }
    private void Awake()
    {
       
        playerStateHandler = GetComponent<PlayerStateHandler>();
        capsuleCollider = GetComponent<CapsuleCollider>();
        point1 = Vector3.up * ((capsuleCollider.height / 2) - capsuleCollider.radius);
        point2 = Vector3.down * ((capsuleCollider.height / 2) - capsuleCollider.radius);
    }
    
    // Update is called once per frame
    void Update()
    {
        Vector3 point1 = Vector3.up * ((capsuleCollider.height / 2) - capsuleCollider.radius);
        Vector3 point2 = Vector3.down * ((capsuleCollider.height / 2) - capsuleCollider.radius);

        grounded = Physics.CapsuleCast(transform.position + point1, transform.position + point2, capsuleCollider.radius, Vector2.down, out rayCast2, groundCheckDistance + skinWidth, layerToCollideWith);
  
        
     
        bool jump = Input.GetKeyDown(KeyCode.Space);
        sprinting = Input.GetKey(KeyCode.LeftShift);
        VelocityMovmement();
      
        if (grounded && jump )
        {
            float horizontalMovement = Input.GetAxisRaw("Horizontal");
            float verticalMovement = Input.GetAxisRaw("Vertical");

            Vector3 input = new Vector3(horizontalMovement, 1f, verticalMovement);

            Quaternion cameraRotation = theCamera.transform.rotation;
         
            Debug.Log("jump");
        //    movement.y +=  jumpdistance * 10 * Time.deltaTime;
            realJUmpTarget = cameraRotation * input;
            originalPosition = transform.position;
           //  movement += transform.forward * Time.deltaTime;
            Jumping = true;
           
           // movement += Vector3.up * jumpdistance;
        }
        
       
        if (Jumping) {

            timer += 1 * Time.deltaTime;
            movement.y += jumpdistance * 10 * Time.deltaTime;
            movement += realJUmpTarget * JumpForwardDistance* Time.deltaTime;
            Debug.Log("Jumpheight" + ( jumpdistance * Time.deltaTime - 10 * Time.deltaTime * Time.deltaTime));
            if (timer > 0.1)
            {
                
                // Debug.Log("jump");
                Jumping = false;
                timer = 0;
            }

        }

        if (!grounded)
        {

            movement += new Vector3(0, -1, 0) * gravityStrength * Time.deltaTime;
        }



        bool capsuleCast = Physics.CapsuleCast(transform.position + point1, transform.position + point2, capsuleCollider.radius, movement.normalized, movement.magnitude + skinWidth, layerToCollideWith);

        

   



        collision(); 
      
        
        transform.position += movement - Snap * Time.deltaTime;
        Snap = new Vector3(0f, 0f, 0f);
        acceleration = originalAcceleration;
        maxspeed = originalmaxspeed;
      
    }
    public void collision()
    {

        bool capsuleCast = Physics.CapsuleCast(transform.position + point1, transform.position + point2, capsuleCollider.radius, movement.normalized, out rayCast, movement.magnitude + skinWidth * Time.deltaTime, layerToCollideWith);
        if (capsuleCast == true)
        {
            //   Debug.Log("hit");


            bool checknormalofraycast = Physics.CapsuleCast(transform.position + point1, transform.position + point2, capsuleCollider.radius, -rayCast.normal, out normalofraycast, -rayCast.normal.magnitude + skinWidth, layerToCollideWith);
            if (checknormalofraycast)
            {
                transform.position += -rayCast.normal * (normalofraycast.distance - skinWidth);
                Snap += -rayCast.normal * (normalofraycast.distance - skinWidth);
            }
            Vector3 Force = ((Vector3)Normalforce(movement, rayCast.normal));
           // Friction(Force);
            movement = movement + Force;
      
            
            collision();

        }

    }
    public Vector3 Normalforce(Vector3 velocity, Vector3 normal)
    {
        if(Vector3.Dot(velocity, normal) > 0)
        {
           return Vector3.zero;
        }
        Vector3 projection = Vector3.Dot(velocity, normal) * normal;
        return -projection;
    }
    public void VelocityMovmement()
    {

        float horizontalMovement = Input.GetAxisRaw("Horizontal");
        float verticalMovement = Input.GetAxisRaw("Vertical");
       
        Vector3 input = new Vector3(horizontalMovement, 0f, verticalMovement);
        if(verticalMovement < 0)
        {
            acceleration = originalAcceleration / 10;
        }
        else
        {
            acceleration = originalAcceleration;
        }
        if (sprinting)
        {

         
           // acceleration = sprintAcceleration;

            maxspeed += sprintMaxSpeed;

        }
        Quaternion cameraRotation = theCamera.transform.rotation;
        Vector3 direction = cameraRotation * input;
     //   direction.y = 0f;
        
        
        
       
        direction = direction.normalized;
        
        if (input.magnitude == 0)
        {
            Decellerate(direction);
        }
        else
        {
            Accelerate(direction);
        }
    }
    public void Accelerate(Vector3 direction)
    {
     
        float distance;
        if ((direction.normalized.x * movement.normalized.x + direction.normalized.z * movement.normalized.z < 0))
        {
            distance = acceleration * turnSpeedModifier * Time.deltaTime;
        }
        else
        {
            distance = acceleration * Time.deltaTime;
        }
        movement += (Vector3)direction * distance;
        if (movement.magnitude > maxspeed)
        {
          //  Debug.Log("träffa maxspeed");
            movement = movement.normalized * maxspeed;
        }
    }
    public void Decellerate(Vector3 direction)
    {
        
        Vector3 tempMovmement = new Vector3(0f, 0f, 0f);
        float distance = deceleration * Time.deltaTime;
        tempMovmement.y = 0f;
        tempMovmement = movement.normalized * -distance;
        if (deceleration > movement.x)
        {
          //  Debug.Log("decelerate");
            tempMovmement.x = 0f;
            tempMovmement.z = 0f;
        }



        //      Debug.Log(tempMovmement);
        movement = tempMovmement;

    }
    public void Friction(Vector3 normalforce)
    {
        if (movement.magnitude < (normalforce.magnitude * staticFriction))
        {
            movement = new Vector3(0f, 0f, 0f);
        }
        else
        {
            movement += normalforce * dynamicFriction;
         //   Debug.Log(hitcounter);
            Debug.Log(movement);
        //    Debug.Log(transform.position);
        }
    }
    public bool NonCorporeal()
    {
        
            return playerStateHandler.getCurrentState().GetType().Equals(nonCorporeal.GetType());
       
    }
    public RaycastHit getHitWall()
    {
        return rayCast;
    }
    public void nullMovement()
    {
         movement = new Vector3(0f, 0f, 0f);
    }

}

