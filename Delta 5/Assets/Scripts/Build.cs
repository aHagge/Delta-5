using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Build : MonoBehaviour {

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
        if(Inventory.itemselected == "Builder tool")
        {
            gameObject.SetActive(true);
        } else
        {
            gameObject.SetActive(false);
        }
        if(over && Input.GetMouseButtonDown(0))
        {
            Instantiate(Basic_Room, gameObject.transform.position, gameObject.transform.rotation);
            Destroy(gameObject);
        }
    }
}
