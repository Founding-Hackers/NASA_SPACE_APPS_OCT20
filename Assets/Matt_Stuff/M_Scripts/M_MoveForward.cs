using System.Collections;
using System.Collections.Generic;
using System.Security.AccessControl;
using UnityEngine;

public class M_MoveForward : MonoBehaviour
{
    /*
    * Author: Matthew Thompson, 10/3/20
    * This is a generic/placeholder script to make my placeholder player object move forward
    */

    public int HLane = 2; // 1 = left, 2 = middle, 3 = right
    public int VLane = 2; // 1 = down, 2 = middle, 3 = up
    [SerializeField] int speed = 50;
    float targetX = 0;
    float targetY = 15;
    [SerializeField] float lerpSpeed = .05f;

    void Start()
    {
        
    }

    void Update()
    {
        transform.position += Vector3.forward * speed * Time.deltaTime; // move forward at a given speed per update

        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) // left
        {
            Debug.Log("Left");
            if (HLane > 1)
            {
                HLane-= 1;
                targetX -= 10;
            }
        }
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) // right
        {
            if (HLane < 3)
            {
                HLane += 1;
                targetX += 10;
            }
        }
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)) // down
        {
            if (VLane > 2)
            {
                VLane -= 1;
                targetY -= 10;
            }
        }
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) // up
        {
            if (VLane < 3)
            {
                VLane += 1;
                targetY += 10;
            }
        }

        // move to newly calculated target position
        transform.position = Vector3.Lerp(transform.position, new Vector3(targetX, targetY, transform.position.z), lerpSpeed);
    }
}
