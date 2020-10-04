using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M_MoveForward : MonoBehaviour
{
    /*
    * Author: Matthew Thompson, 10/3/20
    * This is a generic/placeholder script to make my placeholder player object move forward
    */

    public int currentLane = 2; // 1 = left, 2 = middle, 3 = right
    [SerializeField] int speed = 50;
    float newXLocation;
    float targetX = 0;
    [SerializeField] float lerpSpeed = .05f;

    void Start()
    {
        
    }

    void Update()
    {
        transform.position += Vector3.forward * speed * Time.deltaTime; // move forward at a given speed per update

        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (currentLane > 1)
            {
                currentLane -= 1;
                newXLocation = transform.position.x - 10;
                targetX -= 10;
            }
        }

        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (currentLane < 3)
            {
                currentLane += 1;
                newXLocation = transform.position.x + 10;
                targetX += 10;
            }
        }

        transform.position = Vector3.Lerp(transform.position, new Vector3(targetX, transform.position.y, transform.position.z), .01f);
    }
}
