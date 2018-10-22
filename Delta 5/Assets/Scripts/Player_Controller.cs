using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{

    public float speed;
    public bool Grounded;

    void FixedUpdate()
    {
        transform.Translate(Vector3.left * -Input.GetAxis("Horizontal") * speed);
    }

}
