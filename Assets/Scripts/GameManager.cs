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

    IEnumerator GameOver()
    {
        yield return new WaitForSeconds(1.5f);
        gameOverScreen.SetActive(true);
    
    }

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

    private void IntializeDice()
    {
        diceButton.interactable = true;
        for(int i = 0; i <= 5; i++)
        {
            diceAnimations[i].SetActive(false);
        }

        switch (MainMenuManager.numberOfPlayers)
        {
            case 2:
                if (playerTurn == "RED")
                {
                    diceButtonPos.position = eachDicePos[0].position;
                    frames[0].SetActive(true);
                    frames[2].SetActive(false);
                }
                if (playerTurn == "GREEN")
                {
                    diceButtonPos.position = eachDicePos[2].position;
                    frames[0].SetActive(false);
                    frames[2].SetActive(true);
                }
                for (int i = 0; i <= 3; i++)
                {
                    redButtons[i].interactable = false;
                    greenButtons[i].interactable = false;
                    redBorder[i].SetActive(false);
                    greenBorder[i].SetActive(false);
                }
                break;

            case 4:
                if (playerTurn == "RED")
                {
                    diceButtonPos.position = eachDicePos[0].position;
                    frames[0].SetActive(true);
                    for(int i = 1; i <= 3; i++)
                    {
                        frames[i].SetActive(false);
                    }    
                }
                if (playerTurn == "BLUE")
                {
                    diceButtonPos.position = eachDicePos[1].position;
                    for (int i = 0; i <= 3; i++)
                    {
                        if (i == 1)
                        {
                            frames[i].SetActive(true);
                            i++;
                        }
                        frames[i].SetActive(false);
                    }
                }
                if (playerTurn == "GREEN")
                {
                    diceButtonPos.position = eachDicePos[2].position;
                    for (int i = 0; i <= 3; i++)
                    {
                        if (i == 2)
                        {
                            frames[i].SetActive(true);
                            i++;
                        }
                        frames[i].SetActive(false);
                    }
                }
                if (playerTurn == "YELLOW")
                {
                    diceButtonPos.position = eachDicePos[3].position;
                    frames[3].SetActive(true);
                    for (int i = 0; i <= 2; i++)
                    {
                        
                            frames[i].SetActive(false);
                    }
                }
                for (int i = 0; i <= 3; i++)
                {
                    redButtons[i].interactable = false;
                    blueButtons[i].interactable = false;
                    greenButtons[i].interactable = false;
                    yellowButtons[i].interactable = false;
                    redBorder[i].SetActive(false);
                    blueBorder[i].SetActive(false);
                    greenBorder[i].SetActive(false);
                    yellowBorder[i].SetActive(false);
                }
                break;
        }
    }

    public void DiceRoll()
    {
        SoundManager.diceAudioSource.Play();
        diceButton.interactable = false;
        DiceNumAnimation = randomNum.Next(1,7);

        switch (DiceNumAnimation)
        {
            case 1:
                diceAnimations[0].SetActive(true);
                for(int i = 1; i <= 5; i++)
                {
                    diceAnimations[i].SetActive(false);
                }
                break;

            case 2:
                for (int i = 0; i <= 5; i++)
                {
                    if (i == 1)
                    {
                        diceAnimations[i].SetActive(true);
                        i++;
                    }
                    diceAnimations[i].SetActive(false);
                }
                break;

            case 3:
                for (int i = 0; i <= 5; i++)
                {
                    if (i == 2)
                    {
                        diceAnimations[i].SetActive(true);
                        i++;
                    }
                    diceAnimations[i].SetActive(false);
                }
                break;

            case 4:
                for (int i = 0; i <= 5; i++)
                {
                    if (i == 3)
                    {
                        diceAnimations[i].SetActive(true);
                        i++;
                    }
                    diceAnimations[i].SetActive(false);
                }
                break;

            case 5:
                for (int i = 0; i <= 5; i++)
                {
                    if (i == 4)
                    {
                        diceAnimations[i].SetActive(true);
                        i++;
                    }
                    diceAnimations[i].SetActive(false);
                }
                break;

            case 6:
                diceAnimations[5].SetActive(true);
                for (int i = 0; i <= 4;i++)
                {
                    
                        diceAnimations[i].SetActive(false);
                }
                break;
        }
        StartCoroutine("PlayersNotIntialized");
    }

    IEnumerator PlayersNotIntialized()
    {
        yield return new WaitForSeconds(1f);
        switch (playerTurn)
        {
            case "RED":
                if (!redBorder[0].activeInHierarchy && !redBorder[1].activeInHierarchy && !redBorder[2].activeInHierarchy
                    && !redBorder[3].activeInHierarchy)
                {
                    for (int i = 0; i <= 3; i++)
                    {
                        redButtons[i].interactable = false;
                    }
                    switch (MainMenuManager.numberOfPlayers)
                    {
                        case 2:
                            playerTurn = "GREEN";
                            IntializeDice();
                            break;

                        case 4:
                            playerTurn = "BLUE";
                            IntializeDice();
                            break;
                    }
                }
                break;

            case "GREEN":
                if (!greenBorder[0].activeInHierarchy && !greenBorder[1].activeInHierarchy && !greenBorder[2].activeInHierarchy
                    && !greenBorder[3].activeInHierarchy)
                {
                    for (int i = 0; i <= 3; i++)
                    {
                        greenButtons[i].interactable = false;
                    }
                    switch (MainMenuManager.numberOfPlayers)
                    {
                        case 2:
                            playerTurn = "RED";
                            IntializeDice();
                            break;

                        case 4:
                            playerTurn = "YELLOW";
                            IntializeDice();
                            break;
                    }
                }
                break;

            case "BLUE":
                if (!blueBorder[0].activeInHierarchy && !blueBorder[1].activeInHierarchy && !blueBorder[2].activeInHierarchy
                    && !blueBorder[3].activeInHierarchy)
                {
                    for (int i = 0; i <= 3; i++)
                    {
                        blueButtons[i].interactable = false;
                    }
                    switch (MainMenuManager.numberOfPlayers)
                    {
                        case 2:
                            //Blue player is not available
                            break;

                        case 4:
                            playerTurn = "GREEN";
                            IntializeDice();
                            break;
                    }
                }
                break;

            case "YELLOW":
                if (!yellowBorder[0].activeInHierarchy && !yellowBorder[1].activeInHierarchy && !yellowBorder[2].activeInHierarchy
                    && !yellowBorder[3].activeInHierarchy)
                {
                    for (int i = 0; i <= 3; i++)
                    {
                        yellowButtons[i].interactable = false;
                    }
                    switch (MainMenuManager.numberOfPlayers)
                    {
                        case 2:
                            //yellow player is not available
                            break;

                        case 4:
                            playerTurn = "RED";
                            IntializeDice();
                            break;
                    }
                }
                break;
        }
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
