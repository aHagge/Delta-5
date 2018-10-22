using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public static class SaveLoadManager
{

    public static void Save(Gamemanager gm)
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream stream = new FileStream(Application.persistentDataPath + "/Slot1.sav", FileMode.Create);

        PlayerData data = new PlayerData(gm);

        bf.Serialize(stream, data);
        stream.Close();
        
    }


    public static float[] Load()
    {
        if (File.Exists(Application.persistentDataPath + "/Slot1.sav"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream stream = new FileStream(Application.persistentDataPath + "/Slot1.sav", FileMode.Open);

            PlayerData data = bf.Deserialize(stream) as PlayerData;

            stream.Close();
            return data.stats;
        } else
        {
            Debug.LogError("File does not exist.");
            return new float[2];
        }
    }
}

[System.Serializable]
public class PlayerData
{
    public float[] stats;

    public PlayerData(Gamemanager gm)
    {
        stats = new float[2];
        stats[0] = Gamemanager.player_pos_x;
        stats[1] = Gamemanager.player_pos_y;
    }
}