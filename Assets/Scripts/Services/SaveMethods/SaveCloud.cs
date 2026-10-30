using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.Services.Authentication;
using Unity.Services.Core;
using Unity.Services.CloudSave;
using UnityEngine;

public class SaveCloud : SaveBase
{
    const string KEY_NAME = "name";
    const string KEY_LEVEL = "level";
    const string KEY_CURRENCY = "currency";


    async void Start()
    {
        await UnityServices.InitializeAsync();
        await AuthenticationService.Instance.SignInAnonymouslyAsync();

        throw new System.Exception("No te olvide de probar lo de levantar del CLoud que no lo probamos");
    }

    //Wrapper
    public async void BTN_SaveAsync()
    {
        await SaveAsync();
    }

    public async Task SaveAsync()
    {
        Dictionary<string, object> dicData = new Dictionary<string, object>();
        dicData.Add(KEY_NAME, name_to_save);
        dicData.Add(KEY_LEVEL, level_to_save);
        dicData.Add(KEY_CURRENCY, currency_to_save);
        await CloudSaveService.Instance.Data.Player.SaveAsync(dicData);

    }

    //Wrapper
    public async void BTN_LoadAsync()
    {
        var data = await LoadAsync();

        name_to_save = data.Name;
        level_to_save = data.Level;
        currency_to_save = data.Currency;

    }

    public async Task<SaveData> LoadAsync()
    {
        HashSet<string> keys = new HashSet<string>();
        keys.Add(KEY_NAME);
        keys.Add(KEY_LEVEL);
        keys.Add(KEY_CURRENCY);

        var loaded = await CloudSaveService.Instance.Data.Player.LoadAsync(keys);

        SaveData data = new SaveData();

        if (loaded.TryGetValue(KEY_NAME, out var item))
        {
            data.Set_Name(item.Value.GetAs<string>());
        }
        if (loaded.TryGetValue(KEY_LEVEL, out var item1))
        {
            data.Set_Level(item1.Value.GetAs<int>());
        }
        if (loaded.TryGetValue(KEY_CURRENCY, out var item2))
        {
            data.Set_Currency(item2.Value.GetAs<float>());
        }

        return data;

    }








    protected override SaveData OnLoad()
    {
        return new SaveData();
    }

    protected override void OnSave(SaveData _data)
    {
        
    }
    
}
