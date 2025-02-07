using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class FileDataHandler
{
    private readonly string dataDirPath = "";

    private readonly string dataFileName = "";
    public FileDataHandler(string dataDirPath, string dataFileName)
    {
        this.dataDirPath = dataDirPath;
        this.dataFileName = dataFileName;
    }

    public GameData Load()
    {
        string fullPath = Path.Combine(dataDirPath, dataFileName);
        GameData loadedData = null;
        if (File.Exists(fullPath))
        {
            //Debug.Log("have file");
            try
            {
                string dataToLoad = "";
                using (FileStream stream = new FileStream(fullPath, FileMode.Open))
                {
                    using StreamReader reader = new StreamReader(stream);
                    dataToLoad = reader.ReadToEnd();
                }

                loadedData = JsonUtility.FromJson<GameData>(dataToLoad);
            }
            catch (Exception e)
            {
                Debug.LogError("Error occured when trying to load data from file: " + fullPath + "\n" + e);
            }

        }
        return loadedData;
    }
    public void Save(GameData data) 
    {
        string fullPath = Path.Combine(dataDirPath, dataFileName);
        try
        {
            
            Directory.CreateDirectory(Path.GetDirectoryName(fullPath)); 
            string dataToStore = JsonUtility.ToJson(data, true);
            //Debug.Log(dataToStore);
            using FileStream stream = new FileStream(fullPath, FileMode.Create);
            using StreamWriter writer = new StreamWriter(stream);
            writer.Write(dataToStore);
        }
        catch (Exception e)
        {
            Debug.LogError("Error occured when trying to save data to file: " + fullPath + "\n" + e);
        }
    }

    public void Delete()
    {
        string fullPath = Path.Combine(dataDirPath, dataFileName);
        //Debug.Log(fullPath);
        try
        {
            if (File.Exists(fullPath))
            {
                File.Delete(fullPath);
            }
            else
            {
                Debug.LogWarning("Failed to delete data.");
            }
        }
        catch (Exception e)
        {
            Debug.LogError("Error occured when trying to delete data file: " + fullPath + "\n" + e);
        }
    }
}
