using System.Threading.Tasks;
using TMPro;
using Unity.Services.Authentication;
using Unity.Services.Core;
using UnityEngine;

public class LogByEmail : MonoBehaviour
{
    //[SerializeField] TMP_InputField email;

    //private void Start()
    //{
    //    //email.onValueChanged.AddListener(INPUTFIELD_SetEmail);
    //}

    string email = string.Empty;
    string password = string.Empty;


    async void Start()
    {
        await UnityServices.InitializeAsync();

        AuthenticationService.Instance.SignedIn += EVENT_OnSignedIn;
        AuthenticationService.Instance.SignedOut += EVENT_OnSignedOut;
        AuthenticationService.Instance.SignInFailed += EVENT_OnFailed;
    }

    void EVENT_OnSignedIn() => Debug.Log("Log Exitoso");
    void EVENT_OnSignedOut() => Debug.Log("se Deslogueo");
    void EVENT_OnFailed(RequestFailedException ex) => Debug.Log("Fallo: " + ex.Message);


    public void INPUTFIELD_SetEmail(string val)
    {
        email = val;
    }
    public void INPUTFIELD_SetPassword(string val)
    {
        password = val;
    }

    public async void BTN_SignIn()
    {
        await Sign_IN_UserPass(email, password);
    }
    public async void BTN_SignUp()
    {
        await Sign_Up_UserPass(email, password);
    }

    async Task Sign_Up_UserPass(string email, string password)
    {
        try
        {
            await AuthenticationService.Instance.SignUpWithUsernamePasswordAsync(email, password);

            
            Debug.Log("Sign Up Succesful!");
        }
        catch (AuthenticationException ex)
        {
            // Compare error code to AuthenticationErrorCodes
            // Notify the player with the proper error message
            Debug.LogException(ex);
        }
        catch (RequestFailedException ex)
        {
            // Compare error code to CommonErrorCodes
            // Notify the player with the proper error message
            Debug.LogException(ex);
        }
    }
    async Task Sign_IN_UserPass(string email, string password)
    {
        try
        {
            await AuthenticationService.Instance.SignInWithUsernamePasswordAsync(email, password);
            Debug.Log("Sign Up Succesful!");
        }
        catch (AuthenticationException ex)
        {
            // Compare error code to AuthenticationErrorCodes
            // Notify the player with the proper error message
            Debug.LogException(ex);
        }
        catch (RequestFailedException ex)
        {
            // Compare error code to CommonErrorCodes
            // Notify the player with the proper error message
            Debug.LogException(ex);
        }
        catch (System.Exception ex)
        {
            Debug.Log("Error raro: " + ex);
        }
    }

}
