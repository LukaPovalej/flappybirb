using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeController : MonoBehaviour
{
    Rigidbody2D body;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 6f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(-Vector3.right * 2.5f * Time.deltaTime);
    }
}
