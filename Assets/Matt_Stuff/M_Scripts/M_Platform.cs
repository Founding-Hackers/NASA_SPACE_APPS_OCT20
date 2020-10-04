using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M_Platform : MonoBehaviour
{
      /*
      * Author: Matthew Thompson, 10/3/20
      * This script deals with collisions to trigger deleting a platform that is no longer in the player's view
      */

    private M_PlatformManager manager; // object containing platform manager script, should only be one
    private M_MoveForward player;
    private float timeToWait = 1.0f; // time between trigger and delete


    private IEnumerator OnTriggerExit(Collider other)
    {
        // Debug.Log("CollisionExit");
        // if the player leaves the collision box, wait two seconds and then recycle the platform
        if (other.CompareTag("Player"))
        {
            yield return new WaitForSeconds(timeToWait);
            //Debug.Log("Reached end of platform");
            manager.RecyclePlatform(this.transform.parent.gameObject);
            player.platformsPassed += 1;
            player.ChangeSpeed(1);
        }
    }

    // finds and sets game manager on object enable
    private void OnEnable()
    {
        manager = GameObject.FindObjectOfType<M_PlatformManager>();
        player = GameObject.FindObjectOfType<M_MoveForward>();
    }

}
