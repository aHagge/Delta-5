using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Camera_Follow : MonoBehaviour {

    public Transform target;
    public Vector3 offset;
    public float smoothSpeed;


    void FixedUpdate()
    { 

        if (target != null)
        {
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, target.position + offset, smoothSpeed * Time.deltaTime);
            transform.position = smoothedPosition;
        }

        transform.rotation = target.rotation;
    }
}

