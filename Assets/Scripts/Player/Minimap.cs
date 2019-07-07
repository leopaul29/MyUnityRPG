using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Can add options:
 * zoom on the minimap by changing the size
 * add icones
 * add style and masks
 */
public class Minimap : MonoBehaviour
{
    public Transform player;

    // Called after Update and FixedUpdate once per frame
    void LateUpdate()
    {
        // Move to follow the player
        Vector3 newPosition = player.position;
        // Reset Y axis of the camera to standard position then apply the position
        newPosition.y = transform.position.y;
        transform.position = newPosition;

        // Rotation
        transform.rotation = Quaternion.Euler(90.0f, player.eulerAngles.y, 0);
    }
}
