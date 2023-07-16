using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Unity.IO.LowLevel.Unsafe;
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
}
