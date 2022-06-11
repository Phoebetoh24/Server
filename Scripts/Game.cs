using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PlayFab;
using PlayFab.ClientModels;
using TMPro;


public class Game : MonoBehaviour
{
    private int num;

   private int countGuess;

    [SerializeField]
    private InputField input;

    [SerializeField]
    private TMP_Text text;

    [SerializeField]
    public GameObject button;

    //[SerializeField] TMP_InputField currentScore;
    [SerializeField] TextMeshProUGUI Msg;
    private int playerScore;

   
    //[SerializeField] InputField currentScore;
    void Awake()
    {
       
        num = Random.Range(1, 20);
        Debug.Log("The Random Number is:" + num);
        text.text = "Guess A Number Between 1 to 20";
        countGuess = 1;

    }
    public void GetInput(string guess)
    {
        //Debug.Log("You Entered:" + guess);
        CompareGuesses(int.Parse(guess));
        input.text = "";
        countGuess++;
    }
    void CompareGuesses(int guess)
    {
        if (guess == num)
        {
            text.text = "You Guessed Correctly. The Number Was " + guess + "." + " It took You " + countGuess + " " + "tries." + " Do you want to play again?";
            button.SetActive(true);
        }  
        else if(guess < num)
        {
            text.text = "The Number is too low. Try Again";
        }
        else if (guess > num)
        {
            text.text = "The Number is too high. Try Again";
        }
    }
    public void PlayAgain()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Game Page");
        countGuess = 1;
        button.SetActive(false);

    }
    public void LoadScene(string scn)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(scn);
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
