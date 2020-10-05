using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class M_Pickups : MonoBehaviour
{
   
    protected int healthGained = 10;
    protected int xpGained = 10;

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
        if (this.CompareTag("Pickup"))
        {
            transform.Rotate(rotationDirection * Time.deltaTime);
        }

    }

    public void OnBecameInvisible()
    {
        //foreach (Transform child in this.gameObject.transform)
        //{
        //    Destroy(child.gameObject);
        //}

        Destroy(this.gameObject);
    }


    void PickUp()
    {
        if (this.CompareTag("Obstacle"))
        {
            V_PlayerManager.instance.charStats.TakeDamage(healthGained);
            V_PlayerManager.instance.charStats.gainXP(-xpGained);
        }

        if (this.CompareTag("PickUp"))
        {
           V_PlayerManager.instance.charStats.Heal(healthGained); //references character stats in the Playermanager Health
           V_PlayerManager.instance.charStats.gainXP(xpGained); //references character stats in the Playermanager XP
        }
    
            Destroy(gameObject);
        
    }

    void OnCollisionEnter(Collision collision)
    {
        PickUp();
    }

}
