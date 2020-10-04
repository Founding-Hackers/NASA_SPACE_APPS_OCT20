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
    [SerializeField] int minSpeed = 30;
    [SerializeField] int speed = 30;
    [SerializeField] int maxSpeed = 60;
    float targetX = 0;
    float targetY = 25;
    [SerializeField] float lerpSpeed = .05f;
    [SerializeField] public int platformsPassed = 0;

    private Vector3 firstTouch;
    private Vector3 lastTouch;
    private float swipeDistanceVert;
    private float swipeDistanceHoriz;

    void Start()
    {
        // minimum distance for swipe is 10% of screen
        swipeDistanceVert = Screen.height * 10 / 100;
        swipeDistanceHoriz = Screen.width * 10 / 100;
    }

    public void ChangeSpeed(int amount)
    {
        speed += amount;     
        
        if (speed < minSpeed) { speed = minSpeed; }
        if (speed > maxSpeed) { speed = maxSpeed; }

    }


    void Update()
    {
        transform.position += Vector3.forward * speed * Time.deltaTime; // move forward at a given speed per update

        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                firstTouch = touch.position;
                lastTouch = touch.position;
            }
            else if (touch.phase == TouchPhase.Moved)
            {
                lastTouch = touch.position;
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                lastTouch = touch.position;

                if (Mathf.Abs(lastTouch.x - firstTouch.x) > swipeDistanceVert || Mathf.Abs(lastTouch.y - firstTouch.y) > swipeDistanceHoriz)
                {
                    if (Mathf.Abs(lastTouch.x - firstTouch.x) > Mathf.Abs(lastTouch.y - firstTouch.y))
                    {
                        if ((lastTouch.x > firstTouch.x)) // move right
                        {
                            if (HLane < 3)
                            {
                                HLane += 1;
                                targetX += 10;
                            }
                        }
                        else
                        {
                            if (HLane > 1) // move left
                            {
                                HLane -= 1;
                                targetX -= 10;
                            }
                        }
                    }
                    else
                    {
                        if (lastTouch.y > firstTouch.y)
                        {
                            if (VLane < 3) // up
                            {
                                VLane += 1;
                                targetY += 10;
                            }
                        }
                        else
                        {
                            if (VLane < 3) // down
                            {
                                VLane += 1;
                                targetY += 10;
                            }
                        }
                    }
                }
                else
                {
                    // tap
                }
            }



        }


        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) // left
        {
            // Debug.Log("Left");
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
