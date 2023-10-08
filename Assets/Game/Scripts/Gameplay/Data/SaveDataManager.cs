using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace MissileCommand.Gameplay.Data
{
    public static class SaveDataManager
    {
        public static readonly string fileName = "/SaveData.save";

        /// <summary>
        /// Attempts to save game data
        /// </summary>
        /// <param name="saveData"></param>
        public static void SaveGameData(SaveData saveData)
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            FileStream file;
            file = File.Create(Application.persistentDataPath + fileName);
            binaryFormatter.Serialize(file, saveData);
            file.Close();
        }

        /// <summary>
        /// Attempts to load game data
        /// </summary>
        /// <returns></returns>
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
                }
                catch
                {
                    return null;
                }
            }
            else
            {
                Debug.LogWarning("Save data could not be found!");
                SaveData tempData = new SaveData();
                SaveGameData(tempData);
                return tempData;
            }
        }
    }
}