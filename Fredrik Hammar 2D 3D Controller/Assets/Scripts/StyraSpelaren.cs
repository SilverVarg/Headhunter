using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StyraSpelaren : MonoBehaviour
{
    // Kacper Robertsson karo2640, Fredrik Hammar frha2022
    private BoxCollider2D boxCollider;
   // private bool grounded = false;
   // private bool jump = false;
    public float gravityStrength = 1;
    public float acceleration = 10;
    public float deceleration = 10;
    public float maxspeed = 10;
    public float dynamicFriction = 0.3F;
    public float airResistance = 0.5F;
    public float staticFriction = 0.6F;
    public float groundCheckDistance = 1;
    public float turnSpeedModifier = 2f;
    public float jumpdistance;
    public float skinWidth; //Should it be a vector or what?
    public LayerMask layerToCollideWith;
    public Transform playerPrefab;
    Vector3 movement = new Vector3(0f, 0f, 0f);

    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        


    //    float horizontalMovement = Input.GetAxisRaw("Horizontal");
    //    float verticalMovement = Input.GetAxisRaw("Vertical");
    //    Vector2 direction = new Vector2(horizontalMovement, 0f);
    //    movement += (Vector3)direction * acceleration * Time.deltaTime; 
        VelocityMovmement();
        movement += new Vector3(0, -1, 0) * gravityStrength * Time.deltaTime;
        bool jump = Input.GetKeyDown(KeyCode.Space);
        bool grounded = Physics2D.BoxCast(transform.position, boxCollider.size, 0.0f, Vector2.down, groundCheckDistance + skinWidth, layerToCollideWith);
        if (grounded && jump)
        {
            movement += Vector3.up * jumpdistance;
        }


        

        RaycastHit2D rayCast = Physics2D.BoxCast(transform.position, boxCollider.size, 0, movement.normalized, movement.magnitude + skinWidth, layerToCollideWith);

        bool hitcollider = true;
        int hitcounter = 0;
        while (hitcollider == true || hitcounter > 5)
        {
            rayCast = Physics2D.BoxCast(transform.position, boxCollider.size, 0, movement.normalized, movement.magnitude + skinWidth, layerToCollideWith);
            if(rayCast == false)
            {
                hitcollider = false;
                break;
            }
            RaycastHit2D normalofraycast = Physics2D.BoxCast(transform.position, boxCollider.size, 0, movement.normalized, rayCast.normal.magnitude + skinWidth, layerToCollideWith);
            transform.position += movement.normalized * (normalofraycast.distance - skinWidth);
            Normalforce(movement, rayCast.point);
            Vector3 Force = ((Vector3)Normalforce(movement, rayCast.normal));
            movement = movement + Force;
            hitcounter++;

           
       //    Friction(Force);

        }
       
     //  movement *= Mathf.Pow(airResistance, Time.deltaTime);
        transform.position += movement;
       

       

    }
    public Vector2 Normalforce(Vector3 velocity, Vector3 normal)
    {

        Vector2 projection = Vector2.Dot(velocity, normal) * normal;
        return -projection;
    }
    public void VelocityMovmement()
    {
        float horizontalMovement = Input.GetAxisRaw("Horizontal");
        float verticalMovement = Input.GetAxisRaw("Vertical");
        Vector2 direction = new Vector2(horizontalMovement, verticalMovement);
        if(direction.magnitude == 0)
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
        if ((direction.normalized.x * movement.normalized.x + direction.normalized.y * movement.normalized.y < 0))
        {
             distance = acceleration * turnSpeedModifier * Time.deltaTime;
        }
        else
        {
             distance = acceleration * Time.deltaTime;
        }
        movement += (Vector3)direction * distance;
        if(movement.magnitude > maxspeed)
        {
            movement = movement.normalized * maxspeed;
        }
    }
    public void Decellerate(Vector3 direction)
    {

        Vector3 tempMovmement = new Vector3(0f, 0f, 0f);
        float distance = deceleration * Time.deltaTime;
        tempMovmement.y = 0f;
        tempMovmement = movement.normalized * -distance;
        if (deceleration > movement.x){
            tempMovmement.x = 0f;
        }
        


        //      Debug.Log(tempMovmement);
        movement = tempMovmement;

    }
    public void Friction(Vector2 normalforce)
    {
        if (movement.magnitude > (normalforce.magnitude * staticFriction))
        {
            movement = new Vector3(0f, 0f, 0f);
        }
        else
        {
            movement += (Vector3)normalforce * dynamicFriction;
        }
    }
}
