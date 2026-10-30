using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveBinary : SaveBase
{
    string path = string.Empty;

    private void Start()
    {
        path = Path.Combine(Application.persistentDataPath, "SaveBinary.dat");
    }

    protected override SaveData OnLoad()
    {
        if (File.Exists(path))
        {
            SaveData data = new SaveData();

            BinaryFormatter formatter = new BinaryFormatter();

            using (FileStream stream = new FileStream(path, FileMode.Open))
            {
                data = formatter.Deserialize(stream) as SaveData;
            }
            return data;
        }
        else
        {
            return new SaveData();
        }
    }

    protected override void OnSave(SaveData _data)
    {
        BinaryFormatter formatter = new BinaryFormatter();

        using (FileStream stream = new FileStream(path, FileMode.Create, FileAccess.Write))
        {
            formatter.Serialize(stream, _data);
        }
    }
}
