using UnityEngine;
using Unity.Services.Core;
using Unity.Services.Authentication;
using System.Threading.Tasks;

public class LogAnonimo : MonoBehaviour
{
    
    async void Start()
    {
        await UnityServices.InitializeAsync();

        AuthenticationService.Instance.SignedIn += EVENT_OnSignedIn;
        AuthenticationService.Instance.SignedOut += EVENT_OnSignedOut;
        AuthenticationService.Instance.SignInFailed += EVENT_OnFailed;

        if (! AuthenticationService.Instance.IsSignedIn)
        {
            await SingInAnonimously();
        }
    }

    void EVENT_OnSignedIn() => Debug.Log("Log Exitoso");
    void EVENT_OnSignedOut() => Debug.Log("se Deslogueo");
    void EVENT_OnFailed(RequestFailedException ex) => Debug.Log("Fallo: " + ex.Message);

    async Task SingInAnonimously()
    {
        try
        {
            await AuthenticationService.Instance.SignInAnonymouslyAsync();
        }
        catch (AuthenticationException ex)
        {
            print("AuthException: " + ex.Message);
        }
        catch (RequestFailedException ex)
        {
            print("RequestFailedException: " + ex.Message);
        }

    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
