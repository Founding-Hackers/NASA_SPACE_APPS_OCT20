using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M_Platform : MonoBehaviour
{

    private M_PlatformManager manager;

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision Enter");
    }

    private IEnumerator OnTriggerExit(Collider other)
    {
        Debug.Log("CollisionExit");
        if (other.CompareTag("Player"))
        {
            yield return new WaitForSeconds(1.5f);
            Debug.Log("Reached end of platform");
            manager.RecyclePlatform(this.transform.parent.gameObject);
        }
    }

    private void OnEnable()
    {
        manager = GameObject.FindObjectOfType<M_PlatformManager>();
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
