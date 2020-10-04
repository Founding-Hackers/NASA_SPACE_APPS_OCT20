using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Transition : MonoBehaviour
{
    /// <summary>
    /// how much camera will shift on x or y upon triggering, set in editor
    /// </summary>
    public Vector2 cameraChange;

    /// <summary>
    /// how much cannon object will shift with camera/room transition if needed, set in editor
    /// </summary>
    public Vector3 cannonChange;

    /// <summary>
    /// gets the component of the CameraFollow script from the main camera
    /// </summary>
    public CameraFollow cam;

    // bool for testing but could be useful
    public bool hasTriggered = false;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main.GetComponent<CameraFollow>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        // Change tag as needed, Cannon tag didnt exist so I used player for now
        //if (other.CompareTag("Cannon"))
        if (other.CompareTag("Player"))
        {
            // adjust camera by desired amount
            cam.maxX += cameraChange.x;
            cam.minX += cameraChange.x;
            cam.maxY += cameraChange.y;
            cam.minY += cameraChange.y;

            // adjusts position of cannon or object being followed
            other.transform.position += cannonChange;
            hasTriggered = true;
        }


    }
}
