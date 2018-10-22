using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cross : MonoBehaviour {

    public GameObject Planet;
    public GameObject Plus;

    public float distance;
    private float xs, ys;

    public float circum;

	void Start () {
        xs = transform.position.x - Planet.transform.position.x;
        ys = transform.position.y - Planet.transform.position.y;

        distance = Mathf.Sqrt(xs * xs + ys * ys);

        circum = Mathf.PI * (distance * 2);
        float times = Mathf.RoundToInt(circum / 25);


        for (int i = 0; i < times; i++)
        {
            Vector3 forward = Planet.transform.up * distance;
            Planet.transform.Rotate(0, 0,(float) 360 / times);
            Debug.DrawRay(Planet.transform.position, forward, Color.magenta, 50, false);
            GameObject spawn = Instantiate(Plus, new Vector3(Planet.transform.position.x,Planet.transform.position.y, Planet.transform.position.z - 1), Planet.transform.rotation);
            spawn.transform.position += spawn.transform.up * distance; 
        }

    }
	
	// Update is called once per frame
	void Update () {
        
    }
}
