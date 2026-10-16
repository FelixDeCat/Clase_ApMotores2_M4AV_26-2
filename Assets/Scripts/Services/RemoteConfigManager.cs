using UnityEngine;

using Unity.Services.Core;
using Unity.Services.Authentication;
using Unity.Services.RemoteConfig;
using System;
using System.Threading.Tasks;



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


    RuntimeConfig runtime;
    async void Start()
    {
        await UnityServices.InitializeAsync();

        if (!AuthenticationService.Instance.IsSignedIn)
        {
            await AuthenticationService.Instance.SignInAnonymouslyAsync();
        }

        AuthenticationService.Instance.SignedIn += EVENT_OnSignedIn;
        RemoteConfigService.Instance.FetchCompleted += Apply;

        runtime = await RemoteConfigService.Instance.FetchConfigsAsync(new MyCustomUserAttributes(7), new MyCustomAppAttributes());


        int initialLife = runtime.GetInt("InitialLife", 100);

        //Debug.Log(initialLife); // 120 -- 300 si es mayor o igual a nivel 5

    }

    void EVENT_OnSignedIn()
    {

    }

    public async static void ReFetch()
    {
        instance._reFetch();
    }
    async void _reFetch()
    {
        runtime = await RemoteConfigService.Instance.FetchConfigsAsync(new MyCustomUserAttributes(5), new MyCustomAppAttributes());

    }

    public void SubscribeString(string key, string defVal)
    {

    }
    public void SubscribeInt(string key, int defVal)
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

    [System.Serializable]
    struct MyCustomUserAttributes
    {
        public int level;
        public MyCustomUserAttributes(int level)
        {
            this.level = level;
        }
    }
}


struct MyCustomAppAttributes
{

}
