using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;

public class DataPersistenceManager : MonoBehaviour
{
    [Header("File Storage Config")]
    public string fileName;
    private FileDataHandler dataHandler;

    private GameData gameData;

    private List<IDataPersistence> dataPersistenceObjects;

    [SerializeField] private bool canLoaded = true;
    public static DataPersistenceManager Instance { get; private set;}

    private void Awake()
    {
        if (Instance != null )
        {
            Debug.LogError("Found more than 1 Data Persistence Manager in the scene.");
        }
        Instance = this;

    }

    private void Start()
    {
        this.dataHandler = new FileDataHandler(Application.persistentDataPath, fileName);
        this.dataPersistenceObjects = FindAllDataPersistenceObjects();
        if (canLoaded == true)
        {
            LoadGame();
        }
    }

    public void NewGame()
    {
        
        this.gameData = new GameData();
    }

    public void LoadGame()
    {
        // load any saved data from a file using the data handler
        this.gameData = dataHandler.Load();

        //if no data can be loaded, initialize data to defaults
        if(this.gameData == null)
        {
            Debug.Log("No data was found. A new game needs to be started before data can be loaded.");
            NewGame();
        }
        else
        {
            foreach (IDataPersistence dataPersistenceObj in dataPersistenceObjects)
            {
                dataPersistenceObj.LoadData(gameData);
            }
        }
        
        
    }

    public void SaveGame()
    {
       
        foreach (IDataPersistence dataPersistenceObj in dataPersistenceObjects)
        {
            dataPersistenceObj.SaveData(gameData);
        }
        
        //save data to a file using data handler
        dataHandler.Save(gameData);
        
    }

    public void DeleteData()
    {
        dataHandler.Delete();
    }

    private void OnApplicationQuit()
    {
        if(canLoaded == true)
        {
            SaveGame();
        }
        
    }

    private List<IDataPersistence> FindAllDataPersistenceObjects()
    {
        IEnumerable<IDataPersistence> dataPersistenceObjects = FindObjectsOfType<MonoBehaviour>().OfType<IDataPersistence>();
        return new List<IDataPersistence>(dataPersistenceObjects);
    }

    public bool HasGameData()
    {
        return gameData != null;
    }
}