using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Jetpack : MonoBehaviour {

    public GameObject Fireobject;
    public GameObject Player;
    public float jetpackspeed;
    public Image Jetpack_info;
    public float heat;
    public bool IsGrounded;
    public BoxCollider2D bx;
    public LayerMask ly;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Jetpack_info.fillAmount = heat;


        IsGrounded = Physics2D.Raycast(transform.position, -transform.up, 1f, ly);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Fireobject.SetActive(true);
            GetComponentInParent<Rigidbody2D>().velocity = new Vector2(GetComponentInParent<Rigidbody2D>().velocity.x, 0);
        }



        if (Input.GetKey(KeyCode.Space) )
        {
            if(heat < 1.1 && heat >= 0)
            {
                heat -= 0.015f;
                GetComponentInParent<Rigidbody2D>().AddForce(transform.up * jetpackspeed);
            } else
            {
                Fireobject.SetActive(false);
            }
        } 

        if (IsGrounded && heat < 1)
        {
            heat += 0.01f;
        }


        if (Input.GetKeyUp(KeyCode.Space))
        {
            Fireobject.SetActive(false);
            GetComponentInParent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        }
    }
} 
