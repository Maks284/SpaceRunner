using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class SaveSystem
{
    public static void SaveData(PlayerStats player)
    {
        string path = Application.persistentDataPath + "/PlayerStats.data";

        BinaryFormatter formatter = new();
        FileStream stream = new(path, FileMode.Create);
        PlayerSaveData data = new(player);

        formatter.Serialize(stream, data);
        stream.Close(); 
    }

    public static PlayerSaveData LoadData()
    {
        string path = Application.persistentDataPath + "/PlayerStats.data";

        if (File.Exists(path))
        {
            BinaryFormatter formatter = new();
            FileStream stream = new(path, FileMode.Open);
            PlayerSaveData data = formatter.Deserialize(stream) as PlayerSaveData;

            stream.Close();

            return data;
        }
        else
        {
            return null;
        }
    }
}
