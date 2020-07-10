using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public GameObject pipePrefab;
    float minY = 0.5f;
    float maxY = 2.5f;
    float delay = 2f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        delay -= Time.deltaTime;

        if (delay < 0)
        {
            delay = 2f; 
            Instantiate(pipePrefab, new Vector3(3, Random.Range(minY, maxY), 0), Quaternion.identity);
        }
    }
}
