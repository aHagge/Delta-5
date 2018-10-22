using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buildsystem : MonoBehaviour {

    public GameObject Basic_Room;
    bool over;

    public void OnMouseEnter()
    {
        over = true;
    }

    public void OnMouseExit()
    {
        over = false;
    }

    private void Update()
    {
        if(over && Input.GetMouseButtonDown(0))
        {
            Instantiate(Basic_Room, gameObject.transform.position, gameObject.transform.rotation);
            Destroy(gameObject);
        }
    }
}
