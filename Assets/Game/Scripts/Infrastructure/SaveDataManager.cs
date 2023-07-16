using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Unity.IO.LowLevel.Unsafe;
using UnityEditor;
using UnityEngine;

public static class SaveDataManager
{
    public static readonly string fileName = "/SaveData.save";

    public static void SaveGameData(SaveData saveData)
    {
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        FileStream file;
        file = File.Create(Application.persistentDataPath + fileName);
        binaryFormatter.Serialize(file, saveData);
        file.Close();
    }

    public static SaveData LoadGameData()
    {
        if (File.Exists(Application.persistentDataPath + fileName))
        {
            try
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                FileStream file = File.Open(Application.persistentDataPath + fileName, FileMode.Open);
                SaveData saveData = (SaveData)binaryFormatter.Deserialize(file);
                file.Close();
                return saveData;
            } catch
            {

            }
        }
        else
            return null;
    }
}
