using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour {


    public Attractor attractor;
    private Transform myTransform;
    private Rigidbody2D rB;
    // Use this for initialization
    void Start()
    {

        rB = GetComponent<Rigidbody2D>();

        rB.constraints = RigidbodyConstraints2D.FreezeRotation;
        rB.gravityScale = 0;
        myTransform = transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(attractor != null)
        {
            attractor.Attract(gameObject.transform);
        } else
        {
           // GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Planet")
        {
            attractor = collision.gameObject.GetComponent<Attractor>();
            GetComponentInChildren<Jetpack>().jetpackspeed = 600;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Planet")
        {
            attractor = null;
            GetComponentInChildren<Jetpack>().jetpackspeed = 230;           
        }
    }
}
