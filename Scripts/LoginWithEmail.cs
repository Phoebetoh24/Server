using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using TMPro;

public class LoginWithEmail : MonoBehaviour
{
    [SerializeField] TMP_InputField userEmail, userPassword;
    [SerializeField] TextMeshProUGUI Msg;

    public void LoadScene(string scn)
    {
        // Change scene
        UnityEngine.SceneManagement.SceneManager.LoadScene(scn);
    }

    public void OnButtonLoginEmail() // login using email + password
    {
        var loginRequest = new LoginWithEmailAddressRequest
        {
            Email = userEmail.text,
            Password = userPassword.text,

            // to get player profile, to get display name
            InfoRequestParameters = new GetPlayerCombinedInfoRequestParams
            {
                GetPlayerProfile = true
            }
        };

        PlayFabClientAPI.LoginWithEmailAddress(loginRequest, OnLoginSuccess, OnError);
    }
    
    void OnLoginSuccess(LoginResult r)
    {
        UpdateMsg("Login Success!" + r.PlayFabId + r.InfoResultPayload.PlayerProfile.DisplayName);
        LoadScene("Game Page");
      
    }
    void UpdateMsg(string msg)
    {
        Debug.Log(msg);
        Msg.text = msg;
    }
    void OnError(PlayFabError e)
    {
        UpdateMsg("Error" + e.GenerateErrorReport());
    }
    
}
