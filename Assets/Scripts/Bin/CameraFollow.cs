using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Target position
    public Transform target;
    // Cam position
    public Transform camTransform;

    public Vector3 offsetPosition;
    public Space offsetPositionSpace = Space.Self;
    public bool lookAt = true;

    // distance between the player and the camera
    private float distance = 5.0f;
    private const float DISTANCE_MIN = 0.5f;
    private const float DISTANCE_MAX = 20.0f;
    private readonly float sensitivityWheel = 10.0f;

    // Mouse position to move the camera around the player
    private float currentX = 0.0f;
    private float currentY = 0.0f;
    private readonly float sensitivityX = 4.1f;
    private readonly float sensitivityY = 1.0f;
    private const float Y_ANGLE_MIN = -50.0f;
    private const float Y_ANGLE_MAX = 50.0f;

    private void Start()
    {
        camTransform = transform;
    }

    private void Update()
    {
        // Manage Camera distance with Mouse ScrollWheel
        float newDistance = distance - Input.GetAxis("Mouse ScrollWheel") * sensitivityWheel * Time.deltaTime;
        distance = Mathf.Clamp(newDistance, DISTANCE_MIN, DISTANCE_MAX);
        offsetPosition = new Vector3(0, 0, -distance);

        // Mouve the camera around the player when Left click
        if (Input.GetButton("Fire1")|| Input.GetButton("Fire2"))
        {
            currentX += Input.GetAxis("Mouse X") * sensitivityX;
            currentY -= Input.GetAxis("Mouse Y") * sensitivityY;

            currentY = Mathf.Clamp(currentY, Y_ANGLE_MIN, Y_ANGLE_MAX);

            Quaternion localRotation = Quaternion.Euler(currentY, currentX, 0.0f);
            camTransform.rotation = localRotation;
        }

        float moveAxis = Input.GetAxis("Vertical");
        if (moveAxis != 0)
        {
            lookAt = false;
        } else
        {
            lookAt = true;
            currentX = 0;
            currentY = 0;
        }
    }

    // LateUpdate is called once per frame after Updating Player position
    void LateUpdate()
    {
        CameraUpdater();
    }

    private void CameraUpdater()
    {
        /*
       // Camera distance
       Vector3 dir = new Vector3(0, 0, -distance);
       // Mouse rotate
       Quaternion rotation = Quaternion.Euler(currentY, currentX, 0.0f);
       // Set Camera position
       camTransform.position = target.position + rotation * dir;
       camTransform.LookAt(target);*/


        if (target == null)
        {
            Debug.LogWarning("Missing target ref !", this);

            return;
        }

        // compute position
        if (offsetPositionSpace == Space.Self)
        {
            transform.position = target.TransformPoint(offsetPosition);
        }
        else
        {
            transform.position = target.position + offsetPosition;
        }

        // compute rotation
        if (lookAt)
        {
            transform.LookAt(target);
        }
        else
        {
            transform.rotation = target.rotation;
        }
    }
}
