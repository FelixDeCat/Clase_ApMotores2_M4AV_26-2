using UnityEngine;
using Unity.Services.Core;
using System.Threading.Tasks;
using Unity.Services.Authentication.PlayerAccounts;
using Unity.Services.Authentication;

public class LogUnity : MonoBehaviour
{
    async void Start()
    {
        await UnityServices.InitializeAsync();

        PlayerAccountService.Instance.SignedIn += EVENT_ONSignedIn;
    }

    public async void Button_SignInWithUnity()
    {
        await SignIn();
    }

    async Task SignIn()
    {
        await PlayerAccountService.Instance.StartSignInAsync();
    }

    async void EVENT_ONSignedIn()
    {
        try
        {
            string token = PlayerAccountService.Instance.AccessToken;
            print(token);

            await AuthenticationService.Instance.SignInWithUnityAsync(token);

            print("Auth OK");
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

}
