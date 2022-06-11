using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using TMPro;
using UnityEngine.SceneManagement;


public class Login : MonoBehaviour
{
    [SerializeField] TMP_InputField userName, userPassword;

    public void OnButtonLoginUserName()
    {
        var loginRequest = new LoginWithPlayFabRequest
        {
            Username = userName.text,
            Password = userPassword.text,

            // to get player profile, including displayname
            InfoRequestParameters = new GetPlayerCombinedInfoRequestParams
            {
                GetPlayerProfile = true
            }
        };

        PlayFabClientAPI.LoginWithPlayFab(loginRequest, OnLoginSuccess, OnError);
    }
    void OnLoginSuccess(LoginResult r)
    {
        UpdateMsg("Login Success!" + r.PlayFabId + r.InfoResultPayload.PlayerProfile.DisplayName);
        LoadScene("Game Page");
    }

    public void LoadScene(string scn)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(scn);
    }
    
    //private void RecoverUser()
    //{
    //    var request  new SendAccountRecoveryEmailRequest()
    //    {
    //        Email = EmailRecoveryInput.text,
    //        TitleId = ""
    //    }
    //}
    void UpdateMsg(string msg) //to display in console and messagebox
    {
        Debug.Log(msg);
    }

    void OnError(PlayFabError e)
    {
        UpdateMsg(e.GenerateErrorReport());
    }

    
}
