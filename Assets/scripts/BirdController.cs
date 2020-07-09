using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour
{
    
    public float flyvelocity = 400f;
    private Rigidbody2D body;

    private Vector3 initPosition;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        initPosition = transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            body.velocity = Vector2.zero;
            body.AddForce(new Vector2(0, flyvelocity));

        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Danger")
        {
            reset();
        }
    }

    void reset() 
    {
        transform.position = initPosition;
    }
}