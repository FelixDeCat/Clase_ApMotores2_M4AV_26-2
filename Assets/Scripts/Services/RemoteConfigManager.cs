using UnityEngine;

using Unity.Services.Core;
using Unity.Services.Authentication;
using Unity.Services.RemoteConfig;
using System;



public class RemoteConfigManager : MonoBehaviour
{
    static RemoteConfigManager instance;
    private void Awake()
    {
        if (instance == null) instance = this;
        else
        {
            Destroy(this.gameObject);
        }
    }

    public static void SubscribeKey(string key, Action<object> onValueChange)
    {
        instance._subscribeKey(key);
    }

    void _subscribeKey(string key)
    {
        
    }

    async void Start()
    {
        await UnityServices.InitializeAsync();

        if (!AuthenticationService.Instance.IsSignedIn)
        {
            await AuthenticationService.Instance.SignInAnonymouslyAsync();
        }

        AuthenticationService.Instance.SignedIn += EVENT_OnSignedIn;
        RemoteConfigService.Instance.FetchCompleted += Apply;

       var runtime =  await RemoteConfigService.Instance.FetchConfigsAsync(new MyCustomUserAttributes(5), new MyCustomAppAttributes());


        int initialLife = runtime.GetInt("InitialLife", 100);

        Debug.Log(initialLife); // 120

    }

    void EVENT_OnSignedIn()
    {

    }

    void Apply(ConfigResponse response)
    {
        switch (response.status)
        {
            case ConfigRequestStatus.None:
                break;
            case ConfigRequestStatus.Failed:
                break;
            case ConfigRequestStatus.Success:
                break;
            case ConfigRequestStatus.Pending:
                break;
        }
    }


}

struct MyCustomUserAttributes
{
    int level;
    public MyCustomUserAttributes(int level)
    {
        this.level = level;
    }
}
struct MyCustomAppAttributes
{

}
