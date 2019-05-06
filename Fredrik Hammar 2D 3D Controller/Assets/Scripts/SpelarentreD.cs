using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpelarentreD : MonoBehaviour
{

    
    public float acceleration = 10;
    private float originalAcceleration;
    public float sprintAcceleration = 6;
    Vector3 movement = new Vector3(0f, 0f, 0f);
    public float gravityStrength = 1;
    public float skinWidth = 0.01f;
  //  public float acceleration = 10;
    public float deceleration = 10;
    private RaycastHit rayCast2;
    private RaycastHit rayCast3;
    public float maxspeed = 10;
    private float Originalmaxspeed;
    public float sprintMaxSpeed = 1f;
    public float turnSpeedModifier = 2f;
    public float groundCheckDistance = 0.1f;
    public float jumpdistance = 1f;
    public float MouseSensitivity;
    bool grounded;
    private bool toground = true;

    public float dynamicFriction = 0.3F;
    public float airResistance = 0.5F;
    public float staticFriction = 0.6F;
    private bool sprinting = false;
    private Vector3 point1;
    private Vector3 point2;
    [HideInInspector] public bool objectHeld = false;
    public State nonCorporeal;
    [HideInInspector] public RaycastHit rayCast;
    private RaycastHit normalofraycast;
    public LayerMask layerToCollideWith;
    private CapsuleCollider capsuleCollider;
    [HideInInspector] public PlayerStateHandler playerStateHandler;
    public GameObject theCamera;
    private bool Jumping = false;
    Vector3 Snap = new Vector3(0f, 0f, 0f);

    
    // Start is called before the first frame update
    void Start()
    {
        originalAcceleration = acceleration;
        Originalmaxspeed = maxspeed;
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

        //  Vector3 movement = new Vector3(0f, 0f, 0f);
        //  float horizontalMovement = Input.GetAxisRaw("Horizontal");
        //  float verticalMovement = Input.GetAxisRaw("Vertical");
        //  Vector3 direction = new Vector3(horizontalMovement, 0f, verticalMovement);
        //  direction = direction.normalized;
        //  movement += direction * acceleration * Time.deltaTime;
        grounded = Physics.CapsuleCast(transform.position + point1, transform.position + point2, capsuleCollider.radius, Vector2.down, out rayCast2, groundCheckDistance + skinWidth, layerToCollideWith);
        bool grounded2 = Physics.CapsuleCast(transform.position + point1, transform.position + point2, capsuleCollider.radius, Vector2.down, out rayCast3,  skinWidth, layerToCollideWith);
        VelocityMovmement();

        
        if (movement != new Vector3(0, 0f, 0f))
        {
          //  Debug.Log(movement);
        }
        bool jump = Input.GetKeyDown(KeyCode.Space);
        sprinting = Input.GetKey(KeyCode.LeftShift);
        
        if (grounded && rayCast2.normal.magnitude == 1)
        {
          //  Debug.Log("magn" + rayCast2.distance);
         // transform.rotation = Quaternion.LookRotation(Vector3.Exclude(rayCast2.normal, transform.forward), rayCast2.normal);
        }
        if (grounded && jump)
        {
            Debug.Log("jump");
           movement += Vector3.up * 10f;// jumpdistance * Time.deltaTime - 10 * Time.deltaTime * Time.deltaTime;
           // Debug.Log("jump");
          //  Jumping = true;
           // movement += Vector3.up * jumpdistance;
        }
        if (!grounded)
        {
            movement += new Vector3(0, -1, 0) * gravityStrength * Time.deltaTime;
        }
        if (grounded2 && toground == true)
        {
            toground = false;
            // movement += new Vector3(0, -1, 0) * gravityStrength * Time.deltaTime;
        }
        if (!grounded2)
        {
            toground = true;
          //  movement += new Vector3(0, -1, 0) * gravityStrength * Time.deltaTime;
        }
        if (Jumping) {
            movement.y +=  jumpdistance * Time.deltaTime - 10 * Time.deltaTime * Time.deltaTime;
            Debug.Log("Jumpheight" + ( jumpdistance * Time.deltaTime - 10 * Time.deltaTime * Time.deltaTime));
          
         }
       


        bool capsuleCast = Physics.CapsuleCast(transform.position + point1, transform.position + point2, capsuleCollider.radius, movement.normalized, movement.magnitude + skinWidth, layerToCollideWith);

        

        Ray ray = new Ray(rayCast.point, transform.position);
        Debug.DrawRay(transform.position, rayCast.point, Color.cyan, 5f);
        Debug.DrawLine(transform.position, rayCast.point, Color.green);



        bool hitcollider = true;
        if(capsuleCast == false)
        {
            hitcollider = false;
        }
        collision(); 
      
        if (grounded && movement != new Vector3(0f,0f,0f) && !Jumping)
        {
         //   Quaternion fa = Quaternion.LookRotation(movement);
            transform.rotation = Quaternion.LookRotation(movement);
            transform.rotation = Quaternion.Euler(0f,transform.rotation.y, 0f);
        }
        //Debug.Log(movement);
        //    movement *= Mathf.Pow(airResistance, Time.deltaTime);
        transform.position += movement - Snap * Time.deltaTime;
        Snap = new Vector3(0f, 0f, 0f);
        acceleration = originalAcceleration;
        maxspeed = Originalmaxspeed;
        if (grounded && Jumping)
        {
            //Debug.Log("hitGround");
            Jumping = false;
        }
    }
    public void collision()
    {

        bool capsuleCast = Physics.CapsuleCast(transform.position + point1, transform.position + point2, capsuleCollider.radius, movement.normalized, out rayCast, movement.magnitude + skinWidth * Time.deltaTime, layerToCollideWith);
        if (capsuleCast == true)
        {
            //   Debug.Log("hit");


            bool checknormalofraycast = Physics.CapsuleCast(transform.position + point1, transform.position + point2, capsuleCollider.radius, -rayCast.normal, out normalofraycast, -rayCast.normal.magnitude + skinWidth, layerToCollideWith);
            //      bool checknormalofraycast = Physics.BoxCast(boxCollider.center, boxCollider.size, movement.normalized, out normalofraycast, q, rayCast.normal.magnitude + skinWidth, layerToCollideWith);
            if (checknormalofraycast)
            {
                transform.position += -rayCast.normal * (normalofraycast.distance - skinWidth);
                Snap += -rayCast.normal * (normalofraycast.distance - skinWidth);
            }
            // Normalforce(movement, rayCast.point);
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

            Debug.Log("Springting");
           // acceleration = sprintAcceleration;

            maxspeed += sprintMaxSpeed;

        }
        Quaternion cameraRotation = theCamera.transform.rotation;
        Vector3 direction = cameraRotation * input;
     //   direction.y = 0f;
        
        if (!direction.Equals(new Vector3(0f,0f,0f)))
        {
            
        //    Debug.Log("camera rotation" + cameraRotation + "before" + input + " after" + direction);
            
        }
     //   Vector3 direction = new Vector3(horizontalMo vement, 0f, verticalMovement);
        if (grounded)//&& verticalMovement == 1
        {
        //  direction = Vector3.ProjectOnPlane(rayCast2.normal, direction);
        }
        else if(!grounded)
        {
          //  Debug.Log("getHitWall");
         //   direction = Vector3.ProjectOnPlane(Vector3.up, direction);
        }
        direction = direction.normalized;
        if (!direction.Equals(new Vector3(0f, 1.0f, 0f)))
        {
         //   Debug.Log("input normalized" + direction);
        }
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
       // direction.y = 0f;
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
        return playerStateHandler.current.GetType().Equals(nonCorporeal.GetType());
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

