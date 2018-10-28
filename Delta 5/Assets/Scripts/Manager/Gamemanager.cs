using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;
using UnityEngine.UI;


public class Gamemanager : MonoBehaviour
{

    public GameObject ESC;
    public Vector3 temp;
    public GameObject Player;
    public static Vector2 playerpos;



    public static float player_pos_x, player_pos_y;
    public static float air, health, water, hunger, energy;
    public void Save()
    {
        SaveLoadManager.Save(this);
    }

    public void Load()
    {
        float[] loadedstats = SaveLoadManager.Load();

        player_pos_x = loadedstats[0];
        player_pos_y = loadedstats[1];

        temp = new Vector3(player_pos_x, player_pos_y, Player.transform.position.z);
        Player.transform.position = temp;

    }

    // Use this for initialization
    void Start()
    {
        ESC.SetActive(false);
        Load();
    }

    // Update is called once per frame
    void Update()
    {

        player_pos_x = Player.transform.position.x;
        player_pos_y = Player.transform.position.y;


        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (ESC.activeInHierarchy)
            {
                ESC.SetActive(false);
            }
            else
            {
                ESC.SetActive(true);
            }
        }
    }
}
