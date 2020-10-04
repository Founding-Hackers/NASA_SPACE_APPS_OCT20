using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M_MoveForward : MonoBehaviour
{
      /*
      * Author: Matthew Thompson, 10/3/20
      * This is a generic/placeholder script to make my placeholder player object move forward
      */

    public int speed = 50;

    void Start()
    {
        
    }

    void Update()
    {
        transform.position += Vector3.forward * speed * Time.deltaTime; // move forward at a given speed per update
    }
}
