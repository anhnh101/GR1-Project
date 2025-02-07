using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objects : MonoBehaviour, IDataPersistence
{
    [SerializeField] private string id;

    [ContextMenu("Generate guid for id")]

    
    private void GenerateGuid()
    {
        id = System.Guid.NewGuid().ToString();
    }

    private Vector3 objectPosition = Vector3.zero;

    public void LoadData(GameData data)
    {
        data.objects.TryGetValue(id, out objectPosition);
        this.transform.position = objectPosition;
    }

    public void SaveData(GameData data) 
    {
        if (data.objects.ContainsKey(id))
        {
            data.objects.Remove(id);
        }
        data.objects.Add(id, this.transform.position);
    }
}
