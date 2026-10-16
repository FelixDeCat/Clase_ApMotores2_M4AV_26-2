using UnityEngine;

//BACK-END

[System.Serializable]
public class SaveData
{
    public SaveData()
    {
        name = "defaultPlayer";
        level = 0;
        currency = 0;
    }

    public SaveData(string _name, int _level, float _currency)
    {
        name = _name;
        level = _level;
        currency = _currency;
    }

    #region Name
    [SerializeField] string name;
    public string Name
    {
        get { return name; }
    }
    public void Set_Name(string _name)
    {
        name = _name;
    }
    #endregion
    #region Level
    [SerializeField] int level;
    public int Level
    {
        get
        {
            return level;
        }
    }
    public void Set_Level(int _level)
    {
        level = _level;
    }
    #endregion
    #region Currency
    [SerializeField] float currency;
    public float Currency
    {
        get
        {
            return currency;
        }
    }
    public void Set_Currency(float _currency)
    {
        currency = _currency;
    }
    #endregion
}
