using UnityEngine;

//FRONT-END


public abstract class SaveBase : MonoBehaviour
{
    public string name_to_save = "";
    public int level_to_save = 0;
    public float currency_to_save = 0f;

    private void Awake()
    {
        GetComponent<SaveFront>().SubscribeToButtons(() => { Load(); }, Save);
    }

    void Save()
    {
        Debug.Log("Intentando Guardar");
        SaveData data = new SaveData(name_to_save, level_to_save, currency_to_save);
        OnSave(data);
    }

    SaveData Load()
    {
        var data = OnLoad();

        name_to_save = data.Name;
        level_to_save = data.Level;
        currency_to_save = data.Currency;

        return data;
    }

    //Conexion con el Backend
    protected abstract void OnSave(SaveData _data);
    protected abstract SaveData OnLoad();

}
