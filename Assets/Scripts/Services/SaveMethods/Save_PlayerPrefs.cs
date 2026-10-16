using UnityEngine;

public class Save_PlayerPrefs : SaveBase
{
    string NAME = "NAME";
    string LEVEL = "LEVEL";
    string CURRENCY = "CURRENCY";

    protected override void OnSave(SaveData _data)
    {
        PlayerPrefs.SetString(NAME, _data.Name);
        PlayerPrefs.SetInt(LEVEL, _data.Level);
        PlayerPrefs.SetFloat(CURRENCY, _data.Currency);

        PlayerPrefs.Save();
    }

    protected override SaveData OnLoad()
    {
        SaveData _data = new SaveData();

        _data.Set_Name(PlayerPrefs.GetString(NAME));
        _data.Set_Level(PlayerPrefs.GetInt(LEVEL));
        _data.Set_Currency(PlayerPrefs.GetFloat(CURRENCY));

        return _data;
    }

    
}
