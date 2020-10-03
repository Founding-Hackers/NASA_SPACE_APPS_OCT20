using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M_PlatformManager : MonoBehaviour
{
    [SerializeField] private GameObject[] platformPrefabs;
    [SerializeField] private float prefabLength = 100;
    [SerializeField] private float offset = 0;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < platformPrefabs.Length; i++)
        {
            Instantiate(platformPrefabs[i], new Vector3(0, 0, prefabLength * i), Quaternion.Euler(0, 0, 0));
            offset += prefabLength;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RecyclePlatform(GameObject platform)
    {
        platform.transform.position = new Vector3(0, 0, offset);
        offset += prefabLength;
    }

}
