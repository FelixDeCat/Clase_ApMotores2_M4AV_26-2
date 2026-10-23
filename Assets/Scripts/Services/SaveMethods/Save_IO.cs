using System.IO;
using UnityEngine;

public class Save_IO : SaveBase
{
    const char SIMPLE_SPLIT = ',';
    string path;
    void Start()
    {
        path = Application.persistentDataPath + "/SaveSimple.txt";

        Debug.Log(path);
    }
    protected override void OnSave(SaveData _data)
    {
        /// serializar a mano
        string data = $"{_data.Name}{SIMPLE_SPLIT}{_data.Level}{SIMPLE_SPLIT}{_data.Currency}"; /// <- esta separado por C O M A S
        
        //path = path.Replace("\\", "\\/");

        Debug.Log("Intentando guardar: " + data + " en... " + path);

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

            string[] converted = raw.Split(SIMPLE_SPLIT);

            data.Set_Name(converted[0]);
            data.Set_Level(int.Parse(converted[1]));
            data.Set_Currency(float.Parse(converted[2]));
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
