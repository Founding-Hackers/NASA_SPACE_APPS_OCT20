using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Input controls for the cannon
/// </summary>
public class RotationControl : MonoBehaviour
{
    /// <summary>
    /// When true, if input axis is 1, then the cannon is at 1.
    /// When false,if input axis is 1, the cannon will rotate up at speed * 1
    /// </summary>
    [SerializeField] bool absoluteAxis = true;

    /// <summary>
    /// Current rotation
    /// </summary>
    [SerializeField] float rotation = 0f;
    [SerializeField] float min = -1f;
    [SerializeField] float max = 1f;

    [SerializeField] Vector3 rotationAxis = Vector3.forward;

    /// <summary>
    /// Current rotation
    /// </summary>
    public float Rotation { get => rotation; }

    public float InputAxis { set { 
            if (absoluteAxis)
                rotation = Mathf.Clamp(value, min, max);
            else
                rotation = Mathf.Clamp(rotation + (value * speed * Time.deltaTime), min, max);
            transform.localRotation = Quaternion.AngleAxis(rotation, rotationAxis);
        } 
    }

    public bool InputButton
    {
        set
        {
            rotation = Mathf.Clamp(1 * speed * Time.deltaTime, min, max);
        }
    }


    /// <summary>
    /// Speed at which object is turned
    /// </summary>
    [SerializeField] float speed = 1f;

    /// <summary>
    /// Vertical input axis
    /// </summary>
    [SerializeField] string inputName = "Rotation Control";


    // Gather the input
    void Update()
    {
        InputAxis = Input.GetAxis(inputName);
    }
}
