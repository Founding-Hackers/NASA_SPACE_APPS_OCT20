using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class M_Pickups : MonoBehaviour
{
    // Update is called once per frame
    Vector3[] rotationOptions = { new Vector3(10, 20, 30), new Vector3(-10, 20, 30),
                                 new Vector3(-10, -20, 30), new Vector3(-10, -20, -30),
                                 new Vector3(10, -20, 30), new Vector3(10, -20, -30),
                                 new Vector3(10, 20, -30) };
    Vector3 rotationDirection;

    private void Start()
    {
        rotationDirection = rotationOptions[Random.Range(0, rotationOptions.Length)];
    }

    void Update()
    {
       // if (this.CompareTag("Pickup"))
       // {
            transform.Rotate(rotationDirection * Time.deltaTime);
        //}
    }

    public void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }

}
