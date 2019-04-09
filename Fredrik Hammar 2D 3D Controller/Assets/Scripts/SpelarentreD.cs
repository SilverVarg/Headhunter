using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpelarentreD : MonoBehaviour
{
    public float acceleration = 10;
    Vector3 movement = new Vector3(0f, 0f, 0f);
    public float gravityStrength = 1;
    public float skinWidth = 0.01f;
  //  public float acceleration = 10;
    public float deceleration = 10;
    private RaycastHit rayCast2;
    public float maxspeed = 10;
    public float turnSpeedModifier = 2f;
    public float groundCheckDistance = 0.1f;
    public float jumpdistance = 1f;
    public float MouseSensitivity;
    bool grounded;
    public float dynamicFriction = 0.3F;
    public float airResistance = 0.5F;
    public float staticFriction = 0.6F;

    public Vector3 jumpie;
    public LayerMask layerToCollideWith;
    private CapsuleCollider capsuleCollider;
    public GameObject theCamera;
    float rotationX = 0;
    float rotationY = 0;
    float minXY = 0;
    float MaxXY = 90;
    
    // Start is called before the first frame update
    void Start()
    {
           
    }
    private void Awake()
    {
        capsuleCollider = GetComponent<CapsuleCollider>();
    }
    // Update is called once per frame
    void Update()
    {
      //  Vector3 CameraRelation = theCamera.transform.position -transform.position;
      //  Quaternion Camerarotation = theCamera.transform.rotation;
      //  CameraRelation = Camerarotation * CameraRelation;
      //  theCamera.transform.rotation = Quaternion.Euler(CameraRelation.x, CameraRelation.y, CameraRelation.z); 
      //  CameraRelation += transform.position;
  //      theCamera.transform.position = CameraRelation;


     //   Debug.Log(CameraRelation);
     //   theCamera.transform.position = CameraRelation;


        //     jumpie = new Vector3(0f, 0f, 0f);
        float mouseX = Input.GetAxisRaw("Mouse X");
        float mouseY = Input.GetAxisRaw("Mouse Y");
        
        rotationX -= Input.GetAxisRaw("Mouse Y") * MouseSensitivity;
        rotationY += Input.GetAxisRaw("Mouse X") * MouseSensitivity;
        rotationX = Mathf.Clamp(rotationX, minXY, MaxXY);
        //    Quaternion.Euler(rotationX, rotationY, 0f);
      //  theCamera.transform.rotation = Quaternion.Euler(rotationX, rotationY, 0f);
        Vector3 point1 = Vector3.up * ((capsuleCollider.height / 2) - capsuleCollider.radius);
        Vector3 point2 = Vector3.down * ((capsuleCollider.height / 2) - capsuleCollider.radius);
        //  Vector3 movement = new Vector3(0f, 0f, 0f);
        //  float horizontalMovement = Input.GetAxisRaw("Horizontal");
        //  float verticalMovement = Input.GetAxisRaw("Vertical");
        //  Vector3 direction = new Vector3(horizontalMovement, 0f, verticalMovement);
        //  direction = direction.normalized;
        //  movement += direction * acceleration * Time.deltaTime;
        grounded = Physics.CapsuleCast(transform.position + point1, transform.position + point2, capsuleCollider.radius, Vector2.down, out rayCast2, groundCheckDistance + skinWidth, layerToCollideWith);
        VelocityMovmement();
        bool jump = Input.GetKeyDown(KeyCode.Space);
        
        if (!movement.Equals(new Vector3(0f, 0f, 0f)))
        {
           //   Debug.Log("movement" + movement);
        }

        if (grounded && rayCast2.normal.magnitude == 1)
        {
          //  Debug.Log("magn" + rayCast2.distance);
        //  transform.rotation = Quaternion.LookRotation(Vector3.Exclude(rayCast2.normal, transform.forward), rayCast2.normal);
        }
        if (grounded && jump)
        {
          //  Debug.Log("heyho");
            movement += Vector3.up * jumpdistance;
        }

        movement += new Vector3(0, -1, 0) * gravityStrength * Time.deltaTime;




        //   Quaternion q = new Vector3(0f, 0f, 0f);
      //  CharacterController charContr = GetComponent<CharacterController>();
          
          bool capsuleCast = Physics.CapsuleCast(transform.position + point1, transform.position + point2, capsuleCollider.radius, movement.normalized, movement.magnitude + skinWidth, layerToCollideWith);
       //   bool capsuleCast2 = Physics.CapsuleCast(point1, point2, capsuleCollider.radius, movement.normalized, movement.magnitude + skinWidth, layerToCollideWith);
        // RaycastHit rayCast = Physics.BoxCast(boxCollider.center, boxCollider.size, movement.normalized, q, movement.magnitude + skinWidth, layerToCollideWith);
        
        // Debug.Log(charContr.center);
        
        bool hitcollider = true;
        if(capsuleCast == false)
        {
            hitcollider = false;
        }
        int hitcounter = 0;
        Vector3 skin = new Vector3(0f,0f,0f);
        while (hitcollider == true && hitcounter < 100)
        {
            RaycastHit rayCast;
            //   bool ray = Physics.BoxCast(boxCollider.center, boxCollider.size, movement.normalized,out rayCast, q, movement.magnitude + skinWidth, layerToCollideWith);
            //     rayCast = Physics.BoxCast(boxCollider.center, boxCollider.size, movement.normalized, q, movement.magnitude + skinWidth, layerToCollideWith);
           
            capsuleCast = Physics.CapsuleCast(transform.position + point1, transform.position + point2, capsuleCollider.radius, movement.normalized, out rayCast, movement.magnitude + skinWidth , layerToCollideWith);
            if (capsuleCast == true)
            {
             //   Debug.Log("hit");
            
                RaycastHit normalofraycast;
                bool checknormalofraycast = Physics.CapsuleCast(transform.position + point1, transform.position + point2, capsuleCollider.radius, movement.normalized, out normalofraycast, rayCast.normal.magnitude + skinWidth, layerToCollideWith);
                //      bool checknormalofraycast = Physics.BoxCast(boxCollider.center, boxCollider.size, movement.normalized, out normalofraycast, q, rayCast.normal.magnitude + skinWidth, layerToCollideWith);
                transform.position += movement.normalized * (normalofraycast.distance - skinWidth);
               
                Normalforce(movement, rayCast.point);
                Vector3 Force = ((Vector3)Normalforce(movement, rayCast.normal));
            
                movement = movement + Force;
            //    Friction(Force);


                hitcounter++;
               
            }
            else
            {
                
                
                   
                
                hitcollider = false;
                break;
            }


            

        }
        //Debug.Log(movement);
        //    movement *= Mathf.Pow(airResistance, Time.deltaTime);
        transform.position += movement;
    }
    public Vector2 Normalforce(Vector3 velocity, Vector3 normal)
    {

        Vector3 projection = Vector3.Dot(velocity, normal) * normal;
        return -projection;
    }
    public void VelocityMovmement()
    {
        float horizontalMovement = Input.GetAxisRaw("Horizontal");
        float verticalMovement = Input.GetAxisRaw("Vertical");
       
        Vector3 input = new Vector3(horizontalMovement, 0f, verticalMovement);
        Quaternion cameraRotation = theCamera.transform.rotation;
        Vector3 direction = cameraRotation * input;
     //   direction.y = 0f;
      
        if (!direction.Equals(new Vector3(0f,0f,0f)))
        {
            
          //  Debug.Log("camera rotation" + cameraRotation + "before" + input + " after" + direction);
            
        }
     //   Vector3 direction = new Vector3(horizontalMo vement, 0f, verticalMovement);
        if (grounded && verticalMovement == 1)
        {
          direction = Vector3.ProjectOnPlane(rayCast2.normal, direction);
        }
        else if(!grounded)
        {
            direction = Vector3.ProjectOnPlane(Vector3.up, direction);
        }
        direction = direction.normalized;
        if (!direction.Equals(new Vector3(0f, 1.0f, 0f)))
        {
            //Debug.Log("input normalized" + direction);
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
        direction.y = 0f;
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
        if (movement.magnitude > maxspeed)
        {
            Debug.Log("träffa maxspeed");
            movement = movement.normalized * maxspeed;
        }
    }
    public void Decellerate(Vector3 direction)
    {
      //  Debug.Log("decelerate");
        Vector3 tempMovmement = new Vector3(0f, 0f, 0f);
        float distance = deceleration * Time.deltaTime;
        tempMovmement.y = 0f;
        tempMovmement = movement.normalized * -distance;
        if (deceleration > movement.x)
        {
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
}
