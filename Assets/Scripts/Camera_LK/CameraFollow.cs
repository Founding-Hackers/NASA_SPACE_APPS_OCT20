using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    /// <summary>
    /// object to be followed by camera
    /// </summary>
    public Transform target;

    /// <summary>
    /// speed at which camera should follow object
    /// </summary>
    public float followSpeed;

    /// <summary>
    /// offset between target and camera, currently not used (?)
    /// </summary>
    public Vector3 offset;

    /// <summary>
    /// camera's "goal" location, based on target position's x and y but not z, as camera z should be static (?)
    /// </summary>
    public Vector3 cameraGoTo;

    /// <summary>
    /// max bounds for camera, set manually in editor, may not be needed (?)
    /// </summary>
    public float maxX, minX, maxY, minY;

    private void Start()
    {
        //offset = transform.position - target.position;

        // generic / placeholder values for camera max bounds, again maybe not needed (?)
        maxX = 100;
        maxY = 100;
        minX = -100;
        minY = -100;
    }


    private void FixedUpdate()
    {
        // original lerp / smoothing code
        // transform.position = Vector3.Lerp(transform.position, target.position + offset, followSpeed * Time.deltaTime);

        #region Matt's attempt
        // rather than setting follow speed manually it is based on the current velocity magnitude of the object being followed (95% of it so it should still "lag" a bit)
        followSpeed = target.GetComponent<Rigidbody>().velocity.magnitude * .95f;

        if (transform.position != target.position)
        {
            // camera's target position, different from target.position as Z should not be changing in our perspective
            cameraGoTo = new Vector3(target.position.x + offset.x, target.position.y + offset.y, transform.position.z);

            // for capping/flooring camera min/max bounds
            if (cameraGoTo.x >= maxX) { cameraGoTo.x = maxX; }
            else if (cameraGoTo.x <= minX) { cameraGoTo.x = minX; }
            else if (cameraGoTo.y >= maxY) { cameraGoTo.y = maxY; }
            else if (cameraGoTo.x <= minY) { cameraGoTo.y = minY; }

            // lerp/smooth transition from camera's current position to its goal position
            transform.position = Vector3.Lerp(transform.position, cameraGoTo, followSpeed * Time.deltaTime);
        }
        #endregion
    }
}
