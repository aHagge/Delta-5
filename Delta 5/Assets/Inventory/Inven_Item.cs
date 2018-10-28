using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Inven_Item : MonoBehaviour {

    public Item itemdisplaying;
    public int itemsinit;
    public TextMeshProUGUI itemcounttext;

    public bool mouseisover;
    public bool inhand;
    private void Awake()
    {
        transform.position = transform.parent.position;
    }

    // Update is called once per frame
    void Update () {
        if(itemdisplaying.HowManyCanStack == 1)
        {
            itemcounttext.gameObject.SetActive(false);
        }
        if(itemcounttext != null)
        {
            itemcounttext.text = itemsinit.ToString();
        }
        if (itemdisplaying != null)
        {
            gameObject.GetComponent<Image>().sprite = itemdisplaying.sprite;
        }
    }
}
