using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPerson : MonoBehaviour
{
    public Transform lookAt;
    public Transform camTransform;
    public Transform player;

    private Camera cam;
    private float distance = 10f;
    private float currentX = 0.0f;
    private float currentY = 0.0f;
    private float sensitivityX = 4.0f;
    private float sensitivityY = 1.0f;
    float minXY = 0;
    float MaxXY = 50;
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
        Vector3 dir = new Vector3(0, 0, -distance);
        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
        camTransform.position = lookAt.position + rotation * dir;
        camTransform.LookAt(lookAt.position);
    }
}

