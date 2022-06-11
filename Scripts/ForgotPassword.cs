using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PlayFab;
using PlayFab.ClientModels;
using TMPro;

public class ForgotPassword : MonoBehaviour
{
    void CreatePlayer()
    {
        var loginReq = new LoginWithCustomIDRequest
        {
            CustomId = "BD7E19285065C7D2", // replace with your own Custom ID
            CreateAccount = true // otherwise this will create an account with that ID
        };

        var username = "nutz1234"; // Set this to your username
        var password = "nutz1234"; // Set this to your password
        var emailAddress = "nutz1234@gmail.com"; // Set this to your own email
       

        PlayFabClientAPI.LoginWithCustomID(loginReq, loginRes =>
        {
            Debug.Log("Successfully logged in player with PlayFabId: " + loginRes.PlayFabId);
            AddUserNamePassword(username, password, emailAddress); // Add a username and password
            AddOrUpdateContactEmail(loginRes.PlayFabId, emailAddress);
        }, FailureCallback);
    }

    void AddUserNamePassword(string username, string password, string emailAddress)
    {
        var request = new AddUsernamePasswordRequest
        {
            Username = "yourusername",
            Password = "yourpassword",
            Email = "exampleemail@emaple.com" // Login email
        };
        PlayFabClientAPI.AddUsernamePassword(request, result =>
        {
            Debug.Log("The player's account now has username and password");
        }, FailureCallback);
    }

    void AddOrUpdateContactEmail(string playFabId, string emailAddress)
    {
        var request = new AddOrUpdateContactEmailRequest
        {
            PlayFabId = playFabId,
            EmailAddress = emailAddress
        };
        PlayFabClientAPI.AddOrUpdateContactEmail(request, result =>
        {
            Debug.Log("The player's account has been updated with a contact email");
        }, FailureCallback);
    }
    
    void FailureCallback(PlayFabError error)
    {
        Debug.LogWarning("Something went wrong with your API call. Here's some debug information:");
        Debug.LogError(error.GenerateErrorReport());
    }
}
