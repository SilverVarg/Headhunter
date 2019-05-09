using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPerson : MonoBehaviour
{
    public Transform lookAt;
    public Transform camTransform;
    public Transform player;
    public LayerMask layerToCollideWith;

    private Camera cam;
    public float distance = 10f;
    private float currentX = 0.0f;
    private float currentY = 0.0f;
    public float sensitivityX = 4.0f;
    public float sensitivityY = 1.0f;
    private RaycastHit CameraRayCast;
    float minXY = -30;
    float MaxXY = 70;
    //  private float MouseSensitivity = 1f;
    // Start is called before the first frame update
    void Start()
    {
        camTransform = transform;
        cam = Camera.main;
    }
    void Update()
    {
        currentX += Input.GetAxisRaw("Mouse X") * sensitivityX;
        currentY += Input.GetAxisRaw("Mouse Y") * sensitivityY;
        currentY = Mathf.Clamp(currentY, minXY, MaxXY);
       
        //   player.Rotate(0, currentY, 0);
    }
    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 dir = new Vector3(-distance, 0, -distance);
        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
        camTransform.position = lookAt.position + rotation * dir;
        camTransform.LookAt(lookAt.position);
        player.transform.rotation = cam.transform.rotation;
        player.transform.rotation = Quaternion.Euler(0, player.transform.eulerAngles.y, 0); 
       
       // player.transform.localEulerAngles = cam.transform.rotation;
       //  player.transform.localEulerAngles = new Vector3(0f, player.transform.rotation.y, 0f);
       // player.transform.rotation = Quaternion.Euler(0f, transform.rotation.y, 0f);
       // transform.rotation = Quaternion.Euler(0f, transform.rotation.y, 0f);
        bool PlayerToCam = Physics.Linecast(player.position, camTransform.position, out CameraRayCast, layerToCollideWith,0);
        Debug.DrawLine(player.position, camTransform.position, Color.red, 1);
        if (PlayerToCam)
        {
            camTransform.position = CameraRayCast.point;
        }
    }
}

