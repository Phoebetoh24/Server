using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.Events;
using TMPro; // for text mesh pro UI elements



public class Registration : MonoBehaviour
{
    [SerializeField] TMP_InputField userEmail, userPassword, userName;
  
    public void OnButtonRegUser()
    {
        // for button click
          var registerRequest = new RegisterPlayFabUserRequest
            {
                Email = userEmail.text,
                Password = userPassword.text,
                Username = userName.text,
            };

            PlayFabClientAPI.RegisterPlayFabUser(registerRequest, OnRegSuccess, OnError);
    }
    void OnRegSuccess(RegisterPlayFabUserResult r)
    {

        //Debug.Log("Register Success!");
        UpdateMsg("Registration success!");
        LoadScene("Login Page");

        // To create a player display name

        //var req = new UpdateUserTitleDisplayNameRequest
        //{
        //    DisplayName = displayName.text,
        //};

        // update to profile
        //PlayFabClientAPI.UpdateUserTitleDisplayName(req, OnDisplayNameUpdate, OnError);
    }

    public void LoadScene(string scn)
    {
         UnityEngine.SceneManagement.SceneManager.LoadScene(scn);
    }

    void OnDisplayNameUpdate(UpdateUserTitleDisplayNameResult r)
    {
        UpdateMsg("display name updated!" + r.DisplayName);
    }

    void OnError(PlayFabError e)
    {
        UpdateMsg("Error" + e.GenerateErrorReport()); 
    }
    void UpdateMsg(string msg)
    {
        Debug.Log(msg);
    }
    
    
}



