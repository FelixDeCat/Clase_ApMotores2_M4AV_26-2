using System;
using System.IO;
using UnityEngine;

public class Save_JSON : SaveBase
{
    string path = string.Empty;
    private void Start()
    {
        path = Application.persistentDataPath + "/SaveJSON.txt";
    }

    protected override void OnSave(SaveData _data)
    {
        string data = JsonUtility.ToJson(_data, true);

        Check();

        if (File.Exists(path))
        {
            File.WriteAllText(path, data);
            Debug.Log("Guardando: " + data + " en... " + path);
        }
    }

    protected override SaveData OnLoad()
    {

        SaveData data = new SaveData();

        if (File.Exists(path))
        {
            string raw = File.ReadAllText(path);
            data = JsonUtility.FromJson<SaveData>(raw);
        }

        return data;
    }



    void Check()
    {
        if (!File.Exists(path))
        {
            File.Create(path).Dispose();

            if (File.Exists(path))
            {
                Debug.Log("El Path se Creo correctamente");
            }
        }
    }


}
