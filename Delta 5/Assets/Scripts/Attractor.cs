using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attractor : MonoBehaviour {
    
    public float gravity;
    
    public void Attract(Transform body)
    {
        if(body.gameObject.GetComponent<Gravity>().attractor != null)
        {
            Vector2 gravityUp = (body.position - transform.position).normalized;
            Vector2 bodyUp = body.up;
            Rigidbody2D rB = body.GetComponent<Rigidbody2D>();

            rB.AddForce(gravityUp * gravity);

            Quaternion targetRotation = Quaternion.FromToRotation(bodyUp, gravityUp) * body.rotation;
            body.rotation = Quaternion.Slerp(body.rotation, targetRotation, 10000 * Time.deltaTime);
        }
    }
}
