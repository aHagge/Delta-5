using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Inventory : MonoBehaviour {
    public Item[] Alltheitems;

    [SerializeField]
    public static string itemselected;

    // The actual item in the inventory, later being set to the item of choice.
    public GameObject itemdisplayerprefab;

    public GameObject[] Slots;

    public GameObject Backpack;
    public static bool backpackopen;

    public GameObject Slotselector;

    public int slotselected;

    public TextMeshProUGUI slotinfo;


    void Start () {
        Backpack.SetActive(false);
    }
	
	void Update () {
        if (Input.GetKeyDown(KeyCode.P))
        {
            AddItem(0, 1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Slotselector.transform.position = Slots[0].transform.position;
            slotselected = 0;            
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Slotselector.transform.position = Slots[1].transform.position;
            slotselected = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Slotselector.transform.position = Slots[2].transform.position;
            slotselected = 2;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            Slotselector.transform.position = Slots[3].transform.position;
            slotselected = 3;
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            Slotselector.transform.position = Slots[4].transform.position;
            slotselected = 4;
        }
        itemselected = Slots[slotselected].GetComponent<Slot>().iteminit;

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (Backpack.activeInHierarchy)
            {
                Backpack.SetActive(false);
                backpackopen = false;
            }
            else
            {
                Backpack.SetActive(true);
                backpackopen = true;
            }
        }
    }

    public void AddItem(int id, int amount)
    {
        foreach(GameObject a in Slots)
        {
            if(!a.GetComponent<Slot>().somethingin)
            {
                // Spawn the object in that slot.
                Instantiate(itemdisplayerprefab, a.transform.localPosition, Quaternion.identity, a.gameObject.transform);

                // Making sure the slot is displayed as something in it.
                a.GetComponent<Slot>().somethingin = true;
                a.GetComponentInChildren<Inven_Item>().itemdisplaying = Alltheitems[id];
                a.GetComponentInChildren<Inven_Item>().itemsinit += amount;
                a.GetComponent<Slot>().iteminit = Alltheitems[id].Name;
                if (a.GetComponentInChildren<Inven_Item>().itemsinit >= Alltheitems[id].HowManyCanStack)
                {
                    a.GetComponent<Slot>().full = true;
                }
                break;
            }
            // If there is something in the slot and it's the same as the one you are trying to add.
            else if (a.GetComponent<Slot>().iteminit.Equals(Alltheitems[id].Name) && !a.GetComponent<Slot>().full)
            {
                a.GetComponentInChildren<Inven_Item>().itemsinit += amount;

                // If it's full after you have added the amount of items.
                if (a.GetComponentInChildren<Inven_Item>().itemsinit >= Alltheitems[id].HowManyCanStack)
                {
                    a.GetComponent<Slot>().full = true;
                }
                break;
            }
        }
    }
}
