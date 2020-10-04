using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M_ObjectSpawning : MonoBehaviour
{

    [SerializeField] GameObject test;
    [SerializeField] GameObject[] trashObjects;
    [SerializeField] GameObject[] fishObjects;

    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform child in test.transform)
        {
            Vector3 coord = child.gameObject.transform.position;
            Destroy(child);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
