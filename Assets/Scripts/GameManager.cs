using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private int totalRedInHouse, totalBlueInHouse, totalGreenInHouse, totalYellowInHouse;

    public GameObject[] frames;
    
    public GameObject[] redBorder;
    public GameObject[] blueBorder;
    public GameObject[] greenBorder;
    public GameObject[] yellowBorder;
    
    public Vector3[] redPlayersPos;
    public Vector3[] bluePlayersPos;
    public Vector3[] greenPlayersPos;
    public Vector3[] yellowPlayersPos;
    
    public Transform[] eachDicePos;
    
    //For Interactivity
    public Button[] redButtons;
    public Button[] blueButtons;
    public Button[] greenButtons;
    public Button[] yellowButtons;
    
    public GameObject[] individualWinningScreen;
    
    private string playerTurn = "RED";
    private string currentPlayer = "none";
    private string currentPlayerName = "none";

    //Movement controller
    public GameObject[] redPlayers;
    public GameObject[] bluePlayers;
    public GameObject[] greenPlayers;
    public GameObject[] yellowPlayers;
   
    private int red1Steps, red2Steps, red3Steps, red4Steps;
    private int blue1Steps, blue2Steps, blue3Steps, blue4Steps;
    private int green1Steps, green2Steps, green3Steps, green4Steps;
    private int yellow1Steps, yellow2Steps, yellow3Steps, yellow4Steps;

    public List<GameObject> redMovementBlock = new List<GameObject>();
    public List<GameObject> blueMovementBlock = new List<GameObject>();
    public List<GameObject> greenMovementBlock = new List<GameObject>();
    public List<GameObject> yellowMovementBlock = new List<GameObject>();

    private int DiceNumAnimation;
    public Transform diceButtonPos;
    public Button diceButton;
    public GameObject[] diceAnimations;

    public GameObject confirmScreen;
    public GameObject gameOverScreen;

    private System.Random randomNum;

    public void Exit()
    {
        SoundManager.buttonAudioSource.Play();
        confirmScreen.SetActive(true);
    }

    public void ExitYesButton()
    {
        SoundManager.buttonAudioSource.Play();
        SceneManager.LoadScene("GameMenu");
    }
     public void ExitNoButton()
    {
        SoundManager.buttonAudioSource.Play();
        confirmScreen.SetActive(false);
    }

    /*IEnumerator GameOver
    {
        yield return new WaitForSeconds(1.5f);
        gameOverScreen.SetActive(true);
    
    }*/

    public void GameOverYesButton()
    {
        SoundManager.buttonAudioSource.Play();
        SceneManager.LoadScene("GamePlay");
    }

    public void GameOverNoButton()
    {
        SoundManager.buttonAudioSource.Play();
        SceneManager.LoadScene("GameMenu");
    }

    // Start is called before the first frame update
    void Start()
    {
        QualitySettings.vSyncCount = 1;
        Application.targetFrameRate = 30;

        randomNum = new System.Random();
        for (int i = 0; i <= 5; i++)
        {
            diceAnimations[i].SetActive(false);
        }

        //Set initial position for players
        for (int i = 0; i <= 3; i++)
        {
            redPlayersPos[i] = redPlayers[i].transform.position;
            bluePlayersPos[i] = bluePlayers[i].transform.position;
            greenPlayersPos[i] = greenPlayers[i].transform.position;
            yellowPlayersPos[i] = yellowPlayers[i].transform.position;
        }

        //Deactivivating player borders
        for (int i = 0; i <= 3; i++)
        {
            redBorder[i].SetActive(false);
            blueBorder[i].SetActive(false);
            greenBorder[i].SetActive(false);
            yellowBorder[i].SetActive(false);
        }

        //Deactivivating winning screen
        for (int i = 0; i <= 3; i++)
        {
            individualWinningScreen[i].SetActive(false);
        }

        switch (MainMenuManager.numberOfPlayers)
        {
            case 2:
                playerTurn = "RED";
                frames[0].SetActive(true);
                /*for (int i = 1; i <= 3; i++)
                {
                    frames[i].SetActive(false);
                }*/
                for (int i = 0; i <= 3; i++)
                {
                    bluePlayers[i].SetActive(false);
                    yellowPlayers[i].SetActive(false);
                }
                break;

            case 4:
                playerTurn = "RED";
                frames[0].SetActive(true);
                /*for (int i = 1; i <= 3; i++)
                {
                    frames[i].SetActive(false);
                }*/
                diceButtonPos.position = eachDicePos[0].position;
                break;
        }
    }


    

   

    // Update is called once per frame
    void Update()
    {
        
    }
}
