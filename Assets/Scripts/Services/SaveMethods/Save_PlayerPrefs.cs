using UnityEngine;

public class Save_PlayerPrefs : SaveBase
{
    string NAME = "NAME";
    string LEVEL = "LEVEL";
    string CURRENCY = "CURRENCY";
    //string GAMEDATA = "GameData";

    protected override void OnSave(SaveData _data)
    {
        ///serializar
        PlayerPrefs.SetString(NAME, _data.Name);
        
        PlayerPrefs.SetInt(LEVEL, _data.Level);
        PlayerPrefs.SetFloat(CURRENCY, _data.Currency);

        //PlayerPrefs.SetString(GAMEDATA, JsonUtility.ToJson(_data));

        //guardar
        PlayerPrefs.Save();
    }

    protected override SaveData OnLoad()
    {
        // Deserializar
        SaveData _data = new SaveData();
        _data.Set_Name(PlayerPrefs.GetString(NAME));
        _data.Set_Level(PlayerPrefs.GetInt(LEVEL));
        _data.Set_Currency(PlayerPrefs.GetFloat(CURRENCY));

        //string raw = PlayerPrefs.GetString(GAMEDATA);
        //_data = JsonUtility.FromJson<SaveData>(raw);

        // retornar
        return _data;
    }

    
}
