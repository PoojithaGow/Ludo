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
    
    public Vector3[] redTokensPos;
    public Vector3[] blueTokensPos;
    public Vector3[] greenTokensPos;
    public Vector3[] yellowTokensPos;
    
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
    public GameObject[] redTokens;
    public GameObject[] blueTokens;
    public GameObject[] greenTokens;
    public GameObject[] yellowTokens;

    private int[] redSteps;
    private int[] blueSteps;
    private int[] greenSteps;
    private int[] yellowSteps;

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
        //Winning condition
        switch (MainMenuManager.numberOfPlayers)
        {
            case 2:
                if (totalRedInHouse > 3)
                {
                    SoundManager.winAudioSource.Play();
                    individualWinningScreen[0].SetActive(true);
                    StartCoroutine("GameOver");
                    playerTurn = "none";
                }
                if (totalGreenInHouse > 3)
                {
                    SoundManager.winAudioSource.Play();
                    individualWinningScreen[2].SetActive(true);
                    StartCoroutine("GameOver");
                    playerTurn = "none";
                }
                break;
            case 4: 
                //1 of 4 players wins the game
                if(totalRedInHouse>3 && totalBlueInHouse<4 && totalGreenInHouse<4 && totalYellowInHouse < 4 && playerTurn=="RED")
                {
                    if (!individualWinningScreen[0].activeInHierarchy)
                    {
                        SoundManager.winAudioSource.Play();
                    }

                    individualWinningScreen[0].SetActive(true);
                    playerTurn = "BLUE";
                }
                if (totalBlueInHouse > 3 && totalRedInHouse < 4 && totalGreenInHouse < 4 && totalYellowInHouse < 4 && playerTurn == "BLUE")
                {
                    if (!individualWinningScreen[1].activeInHierarchy)
                    {
                        SoundManager.winAudioSource.Play();
                    }

                    individualWinningScreen[1].SetActive(true);
                    playerTurn = "GREEN";
                }
                if (totalGreenInHouse > 3 && totalRedInHouse < 4 && totalBlueInHouse < 4 && totalYellowInHouse < 4 && playerTurn == "GREEN")
                {
                    if (!individualWinningScreen[2].activeInHierarchy)
                    {
                        SoundManager.winAudioSource.Play();
                    }

                    individualWinningScreen[2].SetActive(true);
                    playerTurn = "YELLOW";
                }
                if (totalYellowInHouse > 3 && totalRedInHouse < 4 && totalBlueInHouse < 4 && totalGreenInHouse < 4 && playerTurn == "YELLOW")
                {
                    if (!individualWinningScreen[3].activeInHierarchy)
                    {
                        SoundManager.winAudioSource.Play();
                    }

                    individualWinningScreen[3].SetActive(true);
                    playerTurn = "RED";
                }
                //2 of 4 players wins the game
                if (totalRedInHouse > 3 && totalBlueInHouse > 3 && totalGreenInHouse < 4 && totalYellowInHouse < 4 && (playerTurn == "RED" || playerTurn == "BLUE"))
                {
                    if (!individualWinningScreen[0].activeInHierarchy)
                    {
                        SoundManager.winAudioSource.Play();
                    }
                    if (!individualWinningScreen[1].activeInHierarchy)
                    {
                        SoundManager.winAudioSource.Play();
                    }
                    individualWinningScreen[0].SetActive(true);
                    individualWinningScreen[1].SetActive(true);
                    playerTurn = "GREEN";
                }
                if (totalBlueInHouse > 3 && totalGreenInHouse > 3 && totalRedInHouse < 4 && totalYellowInHouse < 4 && (playerTurn == "BLUE" || playerTurn == "GREEN"))
                {
                    if (!individualWinningScreen[1].activeInHierarchy)
                    {
                        SoundManager.winAudioSource.Play();
                    }
                    if (!individualWinningScreen[2].activeInHierarchy)
                    {
                        SoundManager.winAudioSource.Play();
                    }
                    individualWinningScreen[1].SetActive(true);
                    individualWinningScreen[2].SetActive(true);
                    playerTurn = "YELLOW";
                }

                if (totalGreenInHouse > 3 && totalYellowInHouse > 3 && totalBlueInHouse < 4 && totalRedInHouse < 4 && (playerTurn == "GREEN" || playerTurn == "YELLOW"))
                {
                    if (!individualWinningScreen[2].activeInHierarchy)
                    {
                        SoundManager.winAudioSource.Play();
                    }
                    if (!individualWinningScreen[3].activeInHierarchy)
                    {
                        SoundManager.winAudioSource.Play();
                    }
                    individualWinningScreen[2].SetActive(true);
                    individualWinningScreen[3].SetActive(true);
                    playerTurn = "RED";
                }

                if (totalYellowInHouse > 3 && totalRedInHouse > 3 && totalBlueInHouse < 4 && totalGreenInHouse < 4 && (playerTurn == "YELLOW" || playerTurn == "RED"))
                {
                    if (!individualWinningScreen[0].activeInHierarchy)
                    {
                        SoundManager.winAudioSource.Play();
                    }
                    if (!individualWinningScreen[3].activeInHierarchy)
                    {
                        SoundManager.winAudioSource.Play();
                    }
                    individualWinningScreen[0].SetActive(true);
                    individualWinningScreen[3].SetActive(true);
                    playerTurn = "BLUE";
                }

                //	Diagonally----Red Vs Green ... Yellow Vs Blue winning
                if (totalYellowInHouse > 3 && totalBlueInHouse > 3 && totalRedInHouse < 4 && totalGreenInHouse < 4 && (playerTurn == "YELLOW" || playerTurn == "BLUE"))
                {
                    if (!individualWinningScreen[3].activeInHierarchy)
                    {
                        SoundManager.winAudioSource.Play();
                    }
                    if (!individualWinningScreen[1].activeInHierarchy)
                    {
                        SoundManager.winAudioSource.Play();
                    }
                    individualWinningScreen[3].SetActive(true);
                    individualWinningScreen[1].SetActive(true);
                    if (playerTurn == "BLUE")
                    {
                        playerTurn = "GREEN";
                    }
                    else
                    {
                        if (playerTurn == "YELLOW")
                        {
                            playerTurn = "RED";
                        }
                    }
                }
                if (totalRedInHouse > 3 && totalGreenInHouse > 3 && totalYellowInHouse < 4 && totalBlueInHouse < 4 && (playerTurn == "RED" || playerTurn == "GREEN"))
                {
                    if (!individualWinningScreen[0].activeInHierarchy)
                    {
                        SoundManager.winAudioSource.Play();
                    }
                    if (!individualWinningScreen[2].activeInHierarchy)
                    {
                        SoundManager.winAudioSource.Play();
                    }
                    individualWinningScreen[0].SetActive(true);
                    individualWinningScreen[2].SetActive(true);
                    if (playerTurn == "RED")
                    {
                        playerTurn = "BLUE";
                    }
                    else
                    {
                        if (playerTurn == "GREEN")
                        {
                            playerTurn = "YELLOW";
                        }
                    }
                }
                if (totalRedInHouse > 3 && totalGreenInHouse > 3 && totalBlueInHouse > 3 && totalYellowInHouse < 4)
                {
                    if (!individualWinningScreen[0].activeInHierarchy)
                    {
                        SoundManager.winAudioSource.Play();
                    }
                    if (!individualWinningScreen[2].activeInHierarchy)
                    {
                        SoundManager.winAudioSource.Play();
                    }
                    if (!individualWinningScreen[1].activeInHierarchy)
                    {
                        SoundManager.winAudioSource.Play();
                    }
                    individualWinningScreen[0].SetActive(true);
                    individualWinningScreen[2].SetActive(true);
                    individualWinningScreen[1].SetActive(true);
                    StartCoroutine("GameOver");
                    playerTurn = "NONE";
                }

                if (totalRedInHouse > 3 && totalGreenInHouse > 3 && totalYellowInHouse > 3 && totalBlueInHouse < 4)
                {
                    if (!individualWinningScreen[0].activeInHierarchy)
                    {
                        SoundManager.winAudioSource.Play();
                    }
                    if (!individualWinningScreen[2].activeInHierarchy)
                    {
                        SoundManager.winAudioSource.Play();
                    }
                    if (!individualWinningScreen[3].activeInHierarchy)
                    {
                        SoundManager.winAudioSource.Play();
                    }
                    individualWinningScreen[0].SetActive(true);
                    individualWinningScreen[2].SetActive(true);
                    individualWinningScreen[3].SetActive(true);
                    StartCoroutine("GameOver");
                    playerTurn = "NONE";
                }

                if (totalBlueInHouse > 3 && totalGreenInHouse > 3 && totalYellowInHouse > 3 && totalRedInHouse < 4)
                {
                    if (!individualWinningScreen[1].activeInHierarchy)
                    {
                        SoundManager.winAudioSource.Play();
                    }
                    if (!individualWinningScreen[2].activeInHierarchy)
                    {
                        SoundManager.winAudioSource.Play();
                    }
                    if (!individualWinningScreen[3].activeInHierarchy)
                    {
                        SoundManager.winAudioSource.Play();
                    }
                    individualWinningScreen[1].SetActive(true);
                    individualWinningScreen[2].SetActive(true);
                    individualWinningScreen[3].SetActive(true);
                    StartCoroutine("GameOver");
                    playerTurn = "NONE";
                }

                if (totalBlueInHouse > 3 && totalRedInHouse > 3 && totalYellowInHouse > 3 && totalGreenInHouse < 4)
                {
                    if (!individualWinningScreen[1].activeInHierarchy)
                    {
                        SoundManager.winAudioSource.Play();
                    }
                    if (!individualWinningScreen[0].activeInHierarchy)
                    {
                        SoundManager.winAudioSource.Play();
                    }
                    if (!individualWinningScreen[3].activeInHierarchy)
                    {
                        SoundManager.winAudioSource.Play();
                    }
                    individualWinningScreen[1].SetActive(true);
                    individualWinningScreen[0].SetActive(true);
                    individualWinningScreen[3].SetActive(true);
                    StartCoroutine("GameOver");
                    playerTurn = "NONE";
                }
                break;
        }


        if (currentPlayerName.Contains("RED TOKEN")) 
        {
            if(currentPlayerName=="RED TOKEN 1")
            {
                currentPlayer = RedToken1.redToken1Collider;
            }
            if (currentPlayerName == "RED TOKEN 2")
            {
                currentPlayer = RedToken2.redToken2Collider;
            }
            if (currentPlayerName == "RED TOKEN 3")
            {
                currentPlayer = RedToken3.redToken3Collider;
            }
            if (currentPlayerName == "RED TOKEN 4")
            {
                currentPlayer = RedToken4.redToken4Collider;
            }
        }
        if (currentPlayerName.Contains("BLUE TOKEN")) 
        {
            if (currentPlayerName == "BLUE TOKEN 1")
            {
                currentPlayer = BlueToken1.blueToken1Collider;
            }
            if (currentPlayerName == "BLUE TOKEN 2")
            {
                currentPlayer = BlueToken2.blueToken2Collider;
            }
            if (currentPlayerName == "BLUE TOKEN 3")
            {
                currentPlayer = BlueToken3.blueToken3Collider;
            }
            if (currentPlayerName == "BLUE TOKEN 4")
            {
                currentPlayer = BlueToken4.blueToken4Collider;
            }
        }
        if (currentPlayerName.Contains("GREEN TOKEN")) 
        {
            if (currentPlayerName == "GREEN TOKEN 1")
            {
                currentPlayer = GreenToken1.greenToken1Collider;
            }
            if (currentPlayerName == "GREEN TOKEN 2")
            {
                currentPlayer = GreenToken2.greenToken2Collider;
            }
            if (currentPlayerName == "GREEN TOKEN 3")
            {
                currentPlayer = GreenToken3.greenToken3Collider;
            }
            if (currentPlayerName == "GREEN TOKEN 4")
            {
                currentPlayer = GreenToken4.greenToken4Collider;
            }
        }
        if (currentPlayerName.Contains("YELLOW TOKEN")) 
        {
            if (currentPlayerName == "YELLOW TOKEN 1")
            {
                currentPlayer = YellowToken1.yellowToken1Collider;
            }
            if (currentPlayerName == "YELLOW TOKEN 2")
            {
                currentPlayer = YellowToken2.yellowToken2Collider;
            }
            if (currentPlayerName == "YELLOW TOKEN 3")
            {
                currentPlayer = YellowToken3.yellowToken3Collider;
            }
            if (currentPlayerName == "YELLOW TOKEN 4")
            {
                currentPlayer = YellowToken4.yellowToken4Collider;
            }
        }

        //Eliminating enemy
        if (currentPlayerName != "none")
        {
            switch (MainMenuManager.numberOfPlayers)
            {
                case 2: 
                    if(currentPlayerName.Contains("RED TOKEN"))
                    {
                        if (currentPlayer == GreenToken1.greenToken1Collider && currentPlayer!= "Safe_Spot")
                        {
                            SoundManager.dismissalAudioSource.Play();
                            greenTokens[0].transform.position = greenTokensPos[0];
                            GreenToken1.greenToken1Collider = "none";
                            greenSteps[0] = 0;
                            playerTurn = "RED";
                        }
                        if (currentPlayer == GreenToken2.greenToken2Collider && currentPlayer != "Safe_Spot")
                        {
                            SoundManager.dismissalAudioSource.Play();
                            greenTokens[1].transform.position = greenTokensPos[1];
                            GreenToken2.greenToken2Collider = "none";
                            greenSteps[1] = 0;
                            playerTurn = "RED";
                        }
                        if (currentPlayer == GreenToken3.greenToken3Collider && currentPlayer != "Safe_Spot")
                        {
                            SoundManager.dismissalAudioSource.Play();
                            greenTokens[2].transform.position = greenTokensPos[2];
                            GreenToken3.greenToken3Collider = "none";
                            greenSteps[2] = 0;
                            playerTurn = "RED";
                        }
                        if (currentPlayer == GreenToken4.greenToken4Collider && currentPlayer != "Safe_Spot")
                        {
                            SoundManager.dismissalAudioSource.Play();
                            greenTokens[3].transform.position = greenTokensPos[3];
                            GreenToken4.greenToken4Collider = "none";
                            greenSteps[3] = 0;
                            playerTurn = "RED";
                        }
                    }
                    if(currentPlayerName.Contains("GREEN TOKEN"))
                    {
                        if (currentPlayer == RedToken1.redToken1Collider && currentPlayer != "Safe_Spot")
                        {
                            SoundManager.dismissalAudioSource.Play();
                            redTokens[0].transform.position = redTokensPos[0];
                            RedToken1.redToken1Collider = "none";
                            redSteps[0] = 0;
                            playerTurn = "GREEN";
                        }
                        if (currentPlayer == RedToken2.redToken2Collider && currentPlayer != "Safe_Spot")
                        {
                            SoundManager.dismissalAudioSource.Play();
                            redTokens[1].transform.position = redTokensPos[1];
                            RedToken2.redToken2Collider = "none";
                            redSteps[1] = 0;
                            playerTurn = "GREEN";
                        }
                        if (currentPlayer == RedToken3.redToken3Collider && currentPlayer != "Safe_Spot")
                        {
                            SoundManager.dismissalAudioSource.Play();
                            redTokens[2].transform.position = redTokensPos[2];
                            RedToken3.redToken3Collider = "none";
                            redSteps[2] = 0;
                            playerTurn = "GREEN";
                        }
                        if (currentPlayer == RedToken4.redToken4Collider && currentPlayer != "Safe_Spot")
                        {
                            SoundManager.dismissalAudioSource.Play();
                            redTokens[3].transform.position = redTokensPos[3];
                            RedToken4.redToken4Collider = "none";
                            redSteps[3] = 0;
                            playerTurn = "GREEN";
                        }
                    }
                    break;
                case 4: 
                    if(currentPlayerName.Contains("RED TOKEN"))
                    {
                        if (currentPlayer == BlueToken1.blueToken1Collider && currentPlayer != "Safe_Spot")
                        {
                            SoundManager.dismissalAudioSource.Play();
                            blueTokens[0].transform.position = blueTokensPos[0];
                            BlueToken1.blueToken1Collider = "none";
                            blueSteps[0] = 0;
                            playerTurn = "RED";
                        }
                        if (currentPlayer == BlueToken2.blueToken2Collider && currentPlayer != "Safe_Spot")
                        {
                            SoundManager.dismissalAudioSource.Play();
                            blueTokens[1].transform.position = blueTokensPos[1];
                            BlueToken2.blueToken2Collider = "none";
                            blueSteps[1] = 0;
                            playerTurn = "RED";
                        }
                        if (currentPlayer == BlueToken3.blueToken3Collider && currentPlayer != "Safe_Spot")
                        {
                            SoundManager.dismissalAudioSource.Play();
                            blueTokens[2].transform.position = blueTokensPos[2];
                            BlueToken3.blueToken3Collider = "none";
                            blueSteps[2] = 0;
                            playerTurn = "RED";
                        }
                        if (currentPlayer == BlueToken4.blueToken4Collider && currentPlayer != "Safe_Spot")
                        {
                            SoundManager.dismissalAudioSource.Play();
                            blueTokens[3].transform.position = blueTokensPos[3];
                            BlueToken4.blueToken4Collider = "none";
                            blueSteps[3] = 0;
                            playerTurn = "RED";
                        }
                        if (currentPlayer == GreenToken1.greenToken1Collider && currentPlayer != "Safe_Spot")
                        {
                            SoundManager.dismissalAudioSource.Play();
                            greenTokens[0].transform.position = greenTokensPos[0];
                            GreenToken1.greenToken1Collider = "none";
                            greenSteps[0] = 0;
                            playerTurn = "RED";
                        }
                        if (currentPlayer == GreenToken2.greenToken2Collider && currentPlayer != "Safe_Spot")
                        {
                            SoundManager.dismissalAudioSource.Play();
                            greenTokens[1].transform.position = greenTokensPos[1];
                            GreenToken2.greenToken2Collider = "none";
                            greenSteps[1] = 0;
                            playerTurn = "RED";
                        }
                        if (currentPlayer == GreenToken3.greenToken3Collider && currentPlayer != "Safe_Spot")
                        {
                            SoundManager.dismissalAudioSource.Play();
                            greenTokens[2].transform.position = greenTokensPos[2];
                            GreenToken3.greenToken3Collider = "none";
                            greenSteps[2] = 0;
                            playerTurn = "RED";
                        }
                        if (currentPlayer == GreenToken4.greenToken4Collider && currentPlayer != "Safe_Spot")
                        {
                            SoundManager.dismissalAudioSource.Play();
                            greenTokens[3].transform.position = greenTokensPos[3];
                            GreenToken4.greenToken4Collider = "none";
                            greenSteps[3] = 0;
                            playerTurn = "RED";
                        }
                        if (currentPlayer == YellowToken1.yellowToken1Collider && currentPlayer != "Safe_Spot")
                        {
                            SoundManager.dismissalAudioSource.Play();
                            yellowTokens[0].transform.position = yellowTokensPos[0];
                            YellowToken1.yellowToken1Collider = "none";
                            yellowSteps[0] = 0;
                            playerTurn = "RED";
                        }
                        if (currentPlayer == YellowToken2.yellowToken2Collider && currentPlayer != "Safe_Spot")
                        {
                            SoundManager.dismissalAudioSource.Play();
                            yellowTokens[1].transform.position = yellowTokensPos[1];
                            YellowToken2.yellowToken2Collider = "none";
                            yellowSteps[1] = 0;
                            playerTurn = "RED";
                        }
                        if (currentPlayer == YellowToken3.yellowToken3Collider && currentPlayer != "Safe_Spot")
                        {
                            SoundManager.dismissalAudioSource.Play();
                            yellowTokens[2].transform.position = yellowTokensPos[2];
                            YellowToken3.yellowToken3Collider = "none";
                            yellowSteps[2] = 0;
                            playerTurn = "RED";
                        }
                        if (currentPlayer == YellowToken4.yellowToken4Collider && currentPlayer != "Safe_Spot")
                        {
                            SoundManager.dismissalAudioSource.Play();
                            yellowTokens[3].transform.position = yellowTokensPos[3];
                            YellowToken4.yellowToken4Collider = "none";
                            yellowSteps[3] = 0;
                            playerTurn = "RED";
                        }
                    }
                    if (currentPlayerName.Contains("BLUE TOKEN"))
                    {
                        if (currentPlayer == GreenToken1.greenToken1Collider && currentPlayer != "Safe_Spot")
                        {
                            SoundManager.dismissalAudioSource.Play();
                            greenTokens[0].transform.position = greenTokensPos[0];
                            GreenToken1.greenToken1Collider = "none";
                            greenSteps[0] = 0;
                            playerTurn = "BLUE";
                        }
                        if (currentPlayer == GreenToken2.greenToken2Collider && currentPlayer != "Safe_Spot")
                        {
                            SoundManager.dismissalAudioSource.Play();
                            greenTokens[1].transform.position = greenTokensPos[1];
                            GreenToken2.greenToken2Collider = "none";
                            greenSteps[1] = 0;
                            playerTurn = "BLUE";
                        }
                        if (currentPlayer == GreenToken3.greenToken3Collider && currentPlayer != "Safe_Spot")
                        {
                            SoundManager.dismissalAudioSource.Play();
                            greenTokens[2].transform.position = greenTokensPos[2];
                            GreenToken3.greenToken3Collider = "none";
                            greenSteps[2] = 0;
                            playerTurn = "BLUE";
                        }
                        if (currentPlayer == GreenToken4.greenToken4Collider && currentPlayer != "Safe_Spot")
                        {
                            SoundManager.dismissalAudioSource.Play();
                            greenTokens[3].transform.position = greenTokensPos[3];
                            GreenToken4.greenToken4Collider = "none";
                            greenSteps[3] = 0;
                            playerTurn = "BLUE";
                        }
                        if (currentPlayer == YellowToken1.yellowToken1Collider && currentPlayer != "Safe_Spot")
                        {
                            SoundManager.dismissalAudioSource.Play();
                            yellowTokens[0].transform.position = yellowTokensPos[0];
                            YellowToken1.yellowToken1Collider = "none";
                            yellowSteps[0] = 0;
                            playerTurn = "BLUE";
                        }
                        if (currentPlayer == YellowToken2.yellowToken2Collider && currentPlayer != "Safe_Spot")
                        {
                            SoundManager.dismissalAudioSource.Play();
                            yellowTokens[1].transform.position = yellowTokensPos[1];
                            YellowToken2.yellowToken2Collider = "none";
                            yellowSteps[1] = 0;
                            playerTurn = "BLUE";
                        }
                        if (currentPlayer == YellowToken3.yellowToken3Collider && currentPlayer != "Safe_Spot")
                        {
                            SoundManager.dismissalAudioSource.Play();
                            yellowTokens[2].transform.position = yellowTokensPos[2];
                            YellowToken3.yellowToken3Collider = "none";
                            yellowSteps[2] = 0;
                            playerTurn = "BLUE";
                        }
                        if (currentPlayer == YellowToken4.yellowToken4Collider && currentPlayer != "Safe_Spot")
                        {
                            SoundManager.dismissalAudioSource.Play();
                            yellowTokens[3].transform.position = yellowTokensPos[3];
                            YellowToken4.yellowToken4Collider = "none";
                            yellowSteps[3] = 0;
                            playerTurn = "BLUE";
                        }
                        if (currentPlayer == RedToken1.redToken1Collider && currentPlayer != "Safe_Spot")
                        {
                            SoundManager.dismissalAudioSource.Play();
                            redTokens[0].transform.position = redTokensPos[0];
                            RedToken1.redToken1Collider = "none";
                            redSteps[0] = 0;
                            playerTurn = "BLUE";
                        }
                        if (currentPlayer == RedToken2.redToken2Collider && currentPlayer != "Safe_Spot")
                        {
                            SoundManager.dismissalAudioSource.Play();
                            redTokens[1].transform.position = redTokensPos[1];
                            RedToken2.redToken2Collider = "none";
                            redSteps[1] = 0;
                            playerTurn = "BLUE";
                        }
                        if (currentPlayer == RedToken3.redToken3Collider && currentPlayer != "Safe_Spot")
                        {
                            SoundManager.dismissalAudioSource.Play();
                            redTokens[2].transform.position = redTokensPos[2];
                            RedToken3.redToken3Collider = "none";
                            redSteps[2] = 0;
                            playerTurn = "BLUE";
                        }
                        if (currentPlayer == RedToken4.redToken4Collider && currentPlayer != "Safe_Spot")
                        {
                            SoundManager.dismissalAudioSource.Play();
                            redTokens[3].transform.position = redTokensPos[3];
                            RedToken4.redToken4Collider = "none";
                            redSteps[3] = 0;
                            playerTurn = "BLUE";
                        }
                    }
                    if (currentPlayerName.Contains("GREEN TOKEN"))
                    {
                        if (currentPlayer == YellowToken1.yellowToken1Collider && currentPlayer != "Safe_Spot")
                        {
                            SoundManager.dismissalAudioSource.Play();
                            yellowTokens[0].transform.position = yellowTokensPos[0];
                            YellowToken1.yellowToken1Collider = "none";
                            yellowSteps[0] = 0;
                            playerTurn = "GREEN";
                        }
                        if (currentPlayer == YellowToken2.yellowToken2Collider && currentPlayer != "Safe_Spot")
                        {
                            SoundManager.dismissalAudioSource.Play();
                            yellowTokens[1].transform.position = yellowTokensPos[1];
                            YellowToken2.yellowToken2Collider = "none";
                            yellowSteps[1] = 0;
                            playerTurn = "GREEN";
                        }
                        if (currentPlayer == YellowToken3.yellowToken3Collider && currentPlayer != "Safe_Spot")
                        {
                            SoundManager.dismissalAudioSource.Play();
                            yellowTokens[2].transform.position = yellowTokensPos[2];
                            YellowToken3.yellowToken3Collider = "none";
                            yellowSteps[2] = 0;
                            playerTurn = "GREEN";
                        }
                        if (currentPlayer == YellowToken4.yellowToken4Collider && currentPlayer != "Safe_Spot")
                        {
                            SoundManager.dismissalAudioSource.Play();
                            yellowTokens[3].transform.position = yellowTokensPos[3];
                            YellowToken4.yellowToken4Collider = "none";
                            yellowSteps[3] = 0;
                            playerTurn = "GREEN";
                        }
                        if (currentPlayer == RedToken1.redToken1Collider && currentPlayer != "Safe_Spot")
                        {
                            SoundManager.dismissalAudioSource.Play();
                            redTokens[0].transform.position = redTokensPos[0];
                            RedToken1.redToken1Collider = "none";
                            redSteps[0] = 0;
                            playerTurn = "GREEN";
                        }
                        if (currentPlayer == RedToken2.redToken2Collider && currentPlayer != "Safe_Spot")
                        {
                            SoundManager.dismissalAudioSource.Play();
                            redTokens[1].transform.position = redTokensPos[1];
                            RedToken2.redToken2Collider = "none";
                            redSteps[1] = 0;
                            playerTurn = "GREEN";
                        }
                        if (currentPlayer == RedToken3.redToken3Collider && currentPlayer != "Safe_Spot")
                        {
                            SoundManager.dismissalAudioSource.Play();
                            redTokens[2].transform.position = redTokensPos[2];
                            RedToken3.redToken3Collider = "none";
                            redSteps[2] = 0;
                            playerTurn = "GREEN";
                        }
                        if (currentPlayer == RedToken4.redToken4Collider && currentPlayer != "Safe_Spot")
                        {
                            SoundManager.dismissalAudioSource.Play();
                            redTokens[3].transform.position = redTokensPos[3];
                            RedToken4.redToken4Collider = "none";
                            redSteps[3] = 0;
                            playerTurn = "GREEN";
                        }
                        if (currentPlayer == BlueToken1.blueToken1Collider && currentPlayer != "Safe_Spot")
                        {
                            SoundManager.dismissalAudioSource.Play();
                            blueTokens[0].transform.position = blueTokensPos[0];
                            BlueToken1.blueToken1Collider = "none";
                            blueSteps[0] = 0;
                            playerTurn = "GREEN";
                        }
                        if (currentPlayer == BlueToken2.blueToken2Collider && currentPlayer != "Safe_Spot")
                        {
                            SoundManager.dismissalAudioSource.Play();
                            blueTokens[1].transform.position = blueTokensPos[1];
                            BlueToken2.blueToken2Collider = "none";
                            blueSteps[1] = 0;
                            playerTurn = "GREEN";
                        }
                        if (currentPlayer == BlueToken3.blueToken3Collider && currentPlayer != "Safe_Spot")
                        {
                            SoundManager.dismissalAudioSource.Play();
                            blueTokens[2].transform.position = blueTokensPos[2];
                            BlueToken3.blueToken3Collider = "none";
                            blueSteps[2] = 0;
                            playerTurn = "GREEN";
                        }
                        if (currentPlayer == BlueToken4.blueToken4Collider && currentPlayer != "Safe_Spot")
                        {
                            SoundManager.dismissalAudioSource.Play();
                            blueTokens[3].transform.position = blueTokensPos[3];
                            BlueToken4.blueToken4Collider = "none";
                            blueSteps[3] = 0;
                            playerTurn = "GREEN";
                        }
                    }
                    if (currentPlayerName.Contains("YELLOW TOKEN"))
                    {
                        if (currentPlayer == RedToken1.redToken1Collider && currentPlayer != "Safe_Spot")
                        {
                            SoundManager.dismissalAudioSource.Play();
                            redTokens[0].transform.position = redTokensPos[0];
                            RedToken1.redToken1Collider = "none";
                            redSteps[0] = 0;
                            playerTurn = "YELLOW";
                        }
                        if (currentPlayer == RedToken2.redToken2Collider && currentPlayer != "Safe_Spot")
                        {
                            SoundManager.dismissalAudioSource.Play();
                            redTokens[1].transform.position = redTokensPos[1];
                            RedToken2.redToken2Collider = "none";
                            redSteps[1] = 0;
                            playerTurn = "YELLOW";
                        }
                        if (currentPlayer == RedToken3.redToken3Collider && currentPlayer != "Safe_Spot")
                        {
                            SoundManager.dismissalAudioSource.Play();
                            redTokens[2].transform.position = redTokensPos[2];
                            RedToken3.redToken3Collider = "none";
                            redSteps[2] = 0;
                            playerTurn = "YELLOW";
                        }
                        if (currentPlayer == RedToken4.redToken4Collider && currentPlayer != "Safe_Spot")
                        {
                            SoundManager.dismissalAudioSource.Play();
                            redTokens[3].transform.position = redTokensPos[3];
                            RedToken4.redToken4Collider = "none";
                            redSteps[3] = 0;
                            playerTurn = "YELLOW";
                        }
                        if (currentPlayer == BlueToken1.blueToken1Collider && currentPlayer != "Safe_Spot")
                        {
                            SoundManager.dismissalAudioSource.Play();
                            blueTokens[0].transform.position = blueTokensPos[0];
                            BlueToken1.blueToken1Collider = "none";
                            blueSteps[0] = 0;
                            playerTurn = "YELLOW";
                        }
                        if (currentPlayer == BlueToken2.blueToken2Collider && currentPlayer != "Safe_Spot")
                        {
                            SoundManager.dismissalAudioSource.Play();
                            blueTokens[1].transform.position = blueTokensPos[1];
                            BlueToken2.blueToken2Collider = "none";
                            blueSteps[1] = 0;
                            playerTurn = "YELLOW";
                        }
                        if (currentPlayer == BlueToken3.blueToken3Collider && currentPlayer != "Safe_Spot")
                        {
                            SoundManager.dismissalAudioSource.Play();
                            blueTokens[2].transform.position = blueTokensPos[2];
                            BlueToken3.blueToken3Collider = "none";
                            blueSteps[2] = 0;
                            playerTurn = "YELLOW";
                        }
                        if (currentPlayer == BlueToken4.blueToken4Collider && currentPlayer != "Safe_Spot")
                        {
                            SoundManager.dismissalAudioSource.Play();
                            blueTokens[3].transform.position = blueTokensPos[3];
                            BlueToken4.blueToken4Collider = "none";
                            blueSteps[3] = 0;
                            playerTurn = "YELLOW";
                        }
                        if (currentPlayer == GreenToken1.greenToken1Collider && currentPlayer != "Safe_Spot")
                        {
                            SoundManager.dismissalAudioSource.Play();
                            greenTokens[0].transform.position = greenTokensPos[0];
                            GreenToken1.greenToken1Collider = "none";
                            greenSteps[0] = 0;
                            playerTurn = "YELLOW";
                        }
                        if (currentPlayer == GreenToken2.greenToken2Collider && currentPlayer != "Safe_Spot")
                        {
                            SoundManager.dismissalAudioSource.Play();
                            greenTokens[1].transform.position = greenTokensPos[1];
                            GreenToken2.greenToken2Collider = "none";
                            greenSteps[1] = 0;
                            playerTurn = "YELLOW";
                        }
                        if (currentPlayer == GreenToken3.greenToken3Collider && currentPlayer != "Safe_Spot")
                        {
                            SoundManager.dismissalAudioSource.Play();
                            greenTokens[2].transform.position = greenTokensPos[2];
                            GreenToken3.greenToken3Collider = "none";
                            greenSteps[2] = 0;
                            playerTurn = "YELLOW";
                        }
                        if (currentPlayer == GreenToken4.greenToken4Collider && currentPlayer != "Safe_Spot")
                        {
                            SoundManager.dismissalAudioSource.Play();
                            greenTokens[3].transform.position = greenTokensPos[3];
                            GreenToken4.greenToken4Collider = "none";
                            greenSteps[3] = 0;
                            playerTurn = "YELLOW";
                        }
                    }
                    break;
            }
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
                    for (int i = 1; i <= 3; i++)
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
        //DiceNumAnimation = 6;

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
                for(int i = 0; i <= 3; i++)
                {
                    if ((redMovementBlock.Count - redSteps[i]) >= DiceNumAnimation && redSteps[i] > 0 && (redMovementBlock.Count > redSteps[i]))
                    {
                        redBorder[i].SetActive(true);
                        redButtons[i].interactable = true;
                    }
                    else
                    {

                        redBorder[i].SetActive(false);
                        redButtons[i].interactable = false;
                    }
                }
                

                //Red Players border enables when they are about to come out
                for (int i = 0; i <= 3; i++)
                {
                    if (DiceNumAnimation == 6 && redSteps[i] == 0)
                    {
                        redBorder[i].SetActive(true);
                        redButtons[i].interactable = true;
                    }
                }

                // When player has no move then switch the turn to next player
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
                for (int i = 0; i <= 3; i++)
                {
                    if ((greenMovementBlock.Count - greenSteps[i]) >= DiceNumAnimation && greenSteps[i] > 0 && (greenMovementBlock.Count > greenSteps[i]))
                    {
                        greenBorder[i].SetActive(true);
                        greenButtons[i].interactable = true;
                    }
                    else
                    {

                        greenBorder[i].SetActive(false);
                        greenButtons[i].interactable = false;
                    }
                }
                //Green Players border enables when they are about to come out
                for (int i = 0; i <= 3; i++)
                {
                    if (DiceNumAnimation == 6 && greenSteps[i] == 0)
                    {
                        greenBorder[i].SetActive(true);
                        greenButtons[i].interactable = true;
                    }
                }
                
                // When player has no move then switch the turn to next player
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
                for (int i = 0; i <= 3; i++)
                {
                    if ((blueMovementBlock.Count - blueSteps[i]) >= DiceNumAnimation && blueSteps[i] > 0 && (blueMovementBlock.Count > blueSteps[i]))
                    {
                        blueBorder[i].SetActive(true);
                        blueButtons[i].interactable = true;
                    }
                    else
                    {

                        blueBorder[i].SetActive(false);
                        blueButtons[i].interactable = false;
                    }
                }
                //Blue Players border enables when they are about to come out
                for (int i = 0; i <= 3; i++)
                {
                    if (DiceNumAnimation == 6 && blueSteps[i] == 0)
                    {
                        blueBorder[i].SetActive(true);
                        blueButtons[i].interactable = true;
                    }
                }

                // When player has no move then switch the turn to next player
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
                for (int i = 0; i <= 3; i++)
                {
                    if ((yellowMovementBlock.Count - yellowSteps[i]) >= DiceNumAnimation && yellowSteps[i] > 0 && (yellowMovementBlock.Count > yellowSteps[i]))
                    {
                        yellowBorder[i].SetActive(true);
                        yellowButtons[i].interactable = true;
                    }
                    else
                    {

                        yellowBorder[i].SetActive(false);
                        yellowButtons[i].interactable = false;
                    }
                }
                //yellow Players border enables when they are about to come out
                for (int i = 0; i <= 3; i++)
                {
                    if (DiceNumAnimation == 6 && yellowSteps[i] == 0)
                    {
                        yellowBorder[i].SetActive(true);
                        yellowButtons[i].interactable = true;
                    }
                }

                // When player has no move then switch the turn to next player
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

    public void RedToken1Movement()
    {
        SoundManager.playerAudioSource.Play();
        for (int i = 0; i <= 3; i++)
        {
            redBorder[i].SetActive(false);
            redButtons[i].interactable = false;
        }
        if (playerTurn == "RED" && (redMovementBlock.Count - redSteps[0]) > DiceNumAnimation)
        {
            if (redSteps[0] > 0)
            {
                Vector3[] redToken1Path = new Vector3[DiceNumAnimation];

                for (int i = 0; i < DiceNumAnimation; i++)
                {
                    redToken1Path[i] = redMovementBlock[redSteps[0] + i].transform.position;
                }
                redSteps[0] += DiceNumAnimation;
                if (DiceNumAnimation == 6)
                {
                    playerTurn = "RED";
                }
                else
                {
                    switch (MainMenuManager.numberOfPlayers)
                    {
                        case 2:
                            playerTurn = "GREEN";
                            break;

                        case 4:
                            playerTurn = "BLUE";
                            break;
                    }
                }
                if (redToken1Path.Length > 1)
                {
                    iTween.MoveTo(redTokens[0], iTween.Hash("path", redToken1Path, "speed", 125, "time", 2.0f, "easetype", "elastic", "oncomplete", "IntializeDice", "oncompletetarget", this.gameObject));
                }
                else
                {
                    iTween.MoveTo(redTokens[0], iTween.Hash("position", redToken1Path[0], "speed", 125, "time", 2.0f, "easetype", "elastic", "oncomplete", "IntializeDice", "oncompletetarget", this.gameObject));
                }
                currentPlayerName = "RED TOKEN 1";
            }
            else
            {
                if (DiceNumAnimation == 6 && redSteps[0] == 0)
                {
                    Vector3[] redToken1Path = new Vector3[1];
                    redToken1Path[0] = redMovementBlock[redSteps[0]].transform.position;
                    redSteps[0] += 1;
                    playerTurn = "RED";
                    currentPlayerName = "RED TOKEN 1";
                    iTween.MoveTo(redTokens[0], iTween.Hash("position", redToken1Path[0], "speed", 125, "time", 2.0f, "easetype", "elastic", "oncomplete", "IntializeDice", "oncompletetarget", this.gameObject));
                }
            }
        }
        else
        {   // Moves to enter house
            if (playerTurn == "RED" && (redMovementBlock.Count - redSteps[0]) == DiceNumAnimation)
            {
                Vector3[] redToken1Path = new Vector3[DiceNumAnimation];
                for (int i = 0; i < DiceNumAnimation; i++)
                {
                    redToken1Path[i] = redMovementBlock[redSteps[0] + i].transform.position;
                }
                redSteps[0] += DiceNumAnimation;
                if (redToken1Path.Length > 1)
                {
                    iTween.MoveTo(redTokens[0], iTween.Hash("path", redToken1Path, "speed", 125, "time", 2.0f, "easetype", "elastic", "oncomplete", "IntializeDice", "oncompletetarget", this.gameObject));
                }
                else
                {
                    iTween.MoveTo(redTokens[0], iTween.Hash("position", redToken1Path[0], "speed", 125, "time", 2.0f, "easetype", "elastic", "oncomplete", "IntializeDice", "oncompletetarget", this.gameObject));
                }
                playerTurn = "RED";
                totalRedInHouse += 1;
                redButtons[0].enabled = false;
            }
            else
            {
                if (redSteps[1] + redSteps[2] + redSteps[3] == 0 && DiceNumAnimation != 6)
                {
                    switch (MainMenuManager.numberOfPlayers)
                    {
                        case 2:
                            playerTurn = "GREEN";
                            break;

                        case 4:
                            playerTurn = "BLUE";
                            break;
                    }
                }
                IntializeDice();
            }
        }
    }

    public void RedToken2Movement()
    {
        SoundManager.playerAudioSource.Play();
        for (int i = 0; i <= 3; i++)
        {
            redBorder[i].SetActive(false);
            redButtons[i].interactable = false;
        }
        if (playerTurn == "RED" && (redMovementBlock.Count - redSteps[1]) > DiceNumAnimation)
        {
            if (redSteps[1] > 0)
            {
                Vector3[] redToken2Path = new Vector3[DiceNumAnimation];

                for (int i = 0; i < DiceNumAnimation; i++)
                {
                    redToken2Path[i] = redMovementBlock[redSteps[1] + i].transform.position;
                }
                redSteps[1] += DiceNumAnimation;
                if (DiceNumAnimation == 6)
                {
                    playerTurn = "RED";
                }
                else
                {
                    switch (MainMenuManager.numberOfPlayers)
                    {
                        case 2:
                            playerTurn = "GREEN";
                            break;

                        case 4:
                            playerTurn = "BLUE";
                            break;
                    }
                }
                if (redToken2Path.Length > 1)
                {
                    iTween.MoveTo(redTokens[1], iTween.Hash("path", redToken2Path, "speed", 125, "time", 2.0f, "easetype", "elastic", "oncomplete", "IntializeDice", "oncompletetarget", this.gameObject));
                }
                else
                {
                    iTween.MoveTo(redTokens[1], iTween.Hash("position", redToken2Path[0], "speed", 125, "time", 2.0f, "easetype", "elastic", "oncomplete", "IntializeDice", "oncompletetarget", this.gameObject));
                }
                currentPlayerName = "RED TOKEN 2";
            }
            else
            {
                if (DiceNumAnimation == 6 && redSteps[1] == 0)
                {
                    Vector3[] redToken2Path = new Vector3[1];
                    redToken2Path[0] = redMovementBlock[redSteps[1]].transform.position;
                    redSteps[1] += 1;
                    playerTurn = "RED";
                    currentPlayerName = "RED TOKEN 2";
                    iTween.MoveTo(redTokens[1], iTween.Hash("position", redToken2Path[0], "speed", 125, "time", 2.0f, "easetype", "elastic", "oncomplete", "IntializeDice", "oncompletetarget", this.gameObject));
                }
            }
        }
        else
        {   // Moves to enter house
            if (playerTurn == "RED" && (redMovementBlock.Count - redSteps[1]) == DiceNumAnimation)
            {
                Vector3[] redToken2Path = new Vector3[DiceNumAnimation];
                for (int i = 0; i < DiceNumAnimation; i++)
                {
                    redToken2Path[i] = redMovementBlock[redSteps[1] + i].transform.position;
                }
                redSteps[1] += DiceNumAnimation;
                if (redToken2Path.Length > 1)
                {
                    iTween.MoveTo(redTokens[1], iTween.Hash("path", redToken2Path, "speed", 125, "time", 2.0f, "easetype", "elastic", "oncomplete", "IntializeDice", "oncompletetarget", this.gameObject));
                }
                else
                {
                    iTween.MoveTo(redTokens[1], iTween.Hash("position", redToken2Path[0], "speed", 125, "time", 2.0f, "easetype", "elastic", "oncomplete", "IntializeDice", "oncompletetarget", this.gameObject));
                }
                playerTurn = "RED";
                totalRedInHouse += 1;
                redButtons[1].enabled = false;
            }
            else
            {
                if (redSteps[0] + redSteps[2] + redSteps[3] == 0 && DiceNumAnimation != 6)
                {
                    switch (MainMenuManager.numberOfPlayers)
                    {
                        case 2:
                            playerTurn = "GREEN";
                            break;

                        case 4:
                            playerTurn = "BLUE";
                            break;
                    }
                }
                IntializeDice();
            }
        }
    }

    public void RedToken3Movement()
    {
        SoundManager.playerAudioSource.Play();
        for (int i = 0; i <= 3; i++)
        {
            redBorder[i].SetActive(false);
            redButtons[i].interactable = false;
        }
        if (playerTurn == "RED" && (redMovementBlock.Count - redSteps[2]) > DiceNumAnimation)
        {
            if (redSteps[2] > 0)
            {
                Vector3[] redToken3Path = new Vector3[DiceNumAnimation];

                for (int i = 0; i < DiceNumAnimation; i++)
                {
                    redToken3Path[i] = redMovementBlock[redSteps[2] + i].transform.position;
                }
                redSteps[2] += DiceNumAnimation;
                if (DiceNumAnimation == 6)
                {
                    playerTurn = "RED";
                }
                else
                {
                    switch (MainMenuManager.numberOfPlayers)
                    {
                        case 2:
                            playerTurn = "GREEN";
                            break;

                        case 4:
                            playerTurn = "BLUE";
                            break;
                    }
                }
                if (redToken3Path.Length > 1)
                {
                    iTween.MoveTo(redTokens[2], iTween.Hash("path", redToken3Path, "speed", 125, "time", 2.0f, "easetype", "elastic", "oncomplete", "IntializeDice", "oncompletetarget", this.gameObject));
                }
                else
                {
                    iTween.MoveTo(redTokens[2], iTween.Hash("position", redToken3Path[0], "speed", 125, "time", 2.0f, "easetype", "elastic", "oncomplete", "IntializeDice", "oncompletetarget", this.gameObject));
                }
                currentPlayerName = "RED TOKEN 3";
            }
            else
            {
                if (DiceNumAnimation == 6 && redSteps[2] == 0)
                {
                    Vector3[] redToken3Path = new Vector3[1];
                    redToken3Path[0] = redMovementBlock[redSteps[2]].transform.position;
                    redSteps[2] += 1;
                    playerTurn = "RED";
                    currentPlayerName = "RED TOKEN 3";
                    iTween.MoveTo(redTokens[2], iTween.Hash("position", redToken3Path[0], "speed", 125, "time", 2.0f, "easetype", "elastic", "oncomplete", "IntializeDice", "oncompletetarget", this.gameObject));
                }
            }
        }
        else
        {   // Moves to enter house
            if (playerTurn == "RED" && (redMovementBlock.Count - redSteps[2]) == DiceNumAnimation)
            {
                Vector3[] redToken3Path = new Vector3[DiceNumAnimation];
                for (int i = 0; i < DiceNumAnimation; i++)
                {
                    redToken3Path[i] = redMovementBlock[redSteps[2] + i].transform.position;
                }
                redSteps[2] += DiceNumAnimation;
                if (redToken3Path.Length > 1)
                {
                    iTween.MoveTo(redTokens[2], iTween.Hash("path", redToken3Path, "speed", 125, "time", 2.0f, "easetype", "elastic", "oncomplete", "IntializeDice", "oncompletetarget", this.gameObject));
                }
                else
                {
                    iTween.MoveTo(redTokens[2], iTween.Hash("position", redToken3Path[0], "speed", 125, "time", 2.0f, "easetype", "elastic", "oncomplete", "IntializeDice", "oncompletetarget", this.gameObject));
                }
                playerTurn = "RED";
                totalRedInHouse += 1;
                redButtons[2].enabled = false;
            }
            else
            {
                if (redSteps[0] + redSteps[1] + redSteps[3] == 0 && DiceNumAnimation != 6)
                {
                    switch (MainMenuManager.numberOfPlayers)
                    {
                        case 2:
                            playerTurn = "GREEN";
                            break;

                        case 4:
                            playerTurn = "BLUE";
                            break;
                    }
                }
                IntializeDice();
            }
        }
    }

    public void RedToken4Movement()
    {
        SoundManager.playerAudioSource.Play();
        for (int i = 0; i <= 3; i++)
        {
            redBorder[i].SetActive(false);
            redButtons[i].interactable = false;
        }
        if (playerTurn == "RED" && (redMovementBlock.Count - redSteps[3]) > DiceNumAnimation)
        {
            if (redSteps[3] > 0)
            {
                Vector3[] redToken4Path = new Vector3[DiceNumAnimation];

                for (int i = 0; i < DiceNumAnimation; i++)
                {
                    redToken4Path[i] = redMovementBlock[redSteps[3] + i].transform.position;
                }
                redSteps[3] += DiceNumAnimation;
                if (DiceNumAnimation == 6)
                {
                    playerTurn = "RED";
                }
                else
                {
                    switch (MainMenuManager.numberOfPlayers)
                    {
                        case 2:
                            playerTurn = "GREEN";
                            break;

                        case 4:
                            playerTurn = "BLUE";
                            break;
                    }
                }
                if (redToken4Path.Length > 1)
                {
                    iTween.MoveTo(redTokens[3], iTween.Hash("path", redToken4Path, "speed", 125, "time", 2.0f, "easetype", "elastic", "oncomplete", "IntializeDice", "oncompletetarget", this.gameObject));
                }
                else
                {
                    iTween.MoveTo(redTokens[3], iTween.Hash("position", redToken4Path[0], "speed", 125, "time", 2.0f, "easetype", "elastic", "oncomplete", "IntializeDice", "oncompletetarget", this.gameObject));
                }
                currentPlayerName = "RED TOKEN 4";
            }
            else
            {
                if (DiceNumAnimation == 6 && redSteps[3] == 0)
                {
                    Vector3[] redToken4Path = new Vector3[1];
                    redToken4Path[0] = redMovementBlock[redSteps[3]].transform.position;
                    redSteps[3] += 1;
                    playerTurn = "RED";
                    currentPlayerName = "RED TOKEN 4";
                    iTween.MoveTo(redTokens[3], iTween.Hash("position", redToken4Path[0], "speed", 125, "time", 2.0f, "easetype", "elastic", "oncomplete", "IntializeDice", "oncompletetarget", this.gameObject));
                }
            }
        }
        else
        {   // Moves to enter house
            if (playerTurn == "RED" && (redMovementBlock.Count - redSteps[3]) == DiceNumAnimation)
            {
                Vector3[] redToken4Path = new Vector3[DiceNumAnimation];
                for (int i = 0; i < DiceNumAnimation; i++)
                {
                    redToken4Path[i] = redMovementBlock[redSteps[3] + i].transform.position;
                }
                redSteps[3] += DiceNumAnimation;
                if (redToken4Path.Length > 1)
                {
                    iTween.MoveTo(redTokens[3], iTween.Hash("path", redToken4Path, "speed", 125, "time", 2.0f, "easetype", "elastic", "oncomplete", "IntializeDice", "oncompletetarget", this.gameObject));
                }
                else
                {
                    iTween.MoveTo(redTokens[3], iTween.Hash("position", redToken4Path[0], "speed", 125, "time", 2.0f, "easetype", "elastic", "oncomplete", "IntializeDice", "oncompletetarget", this.gameObject));
                }
                playerTurn = "RED";
                totalRedInHouse += 1;
                redButtons[3].enabled = false;
            }
            else
            {
                if (redSteps[0] + redSteps[1] + redSteps[2] == 0 && DiceNumAnimation != 6)
                {
                    switch (MainMenuManager.numberOfPlayers)
                    {
                        case 2:
                            playerTurn = "GREEN";
                            break;

                        case 4:
                            playerTurn = "BLUE";
                            break;
                    }
                }
                IntializeDice();
            }
        }
    }

    public void GreenToken1Movement()
    {
        SoundManager.playerAudioSource.Play();
        for (int i = 0; i <= 3; i++)
        {
            greenBorder[i].SetActive(false);
            greenButtons[i].interactable = false;
        }
        if (playerTurn == "GREEN" && (greenMovementBlock.Count - greenSteps[0]) > DiceNumAnimation)
        {
            if (greenSteps[0] > 0)
            {
                Vector3[] greenToken1Path = new Vector3[DiceNumAnimation];

                for (int i = 0; i < DiceNumAnimation; i++)
                {
                    greenToken1Path[i] = greenMovementBlock[greenSteps[0] + i].transform.position;
                }
                greenSteps[0] += DiceNumAnimation;
                if (DiceNumAnimation == 6)
                {
                    playerTurn = "GREEN";
                }
                else
                {
                    switch (MainMenuManager.numberOfPlayers)
                    {
                        case 2:
                            playerTurn = "RED";
                            break;

                        case 4:
                            playerTurn = "YELLOW";
                            break;
                    }
                }
                if (greenToken1Path.Length > 1)
                {
                    iTween.MoveTo(greenTokens[0], iTween.Hash("path", greenToken1Path, "speed", 125, "time", 2.0f, "easetype", "elastic", "oncomplete", "IntializeDice", "oncompletetarget", this.gameObject));
                }
                else
                {
                    iTween.MoveTo(greenTokens[0], iTween.Hash("position", greenToken1Path[0], "speed", 125, "time", 2.0f, "easetype", "elastic", "oncomplete", "IntializeDice", "oncompletetarget", this.gameObject));
                }
                currentPlayerName = "GREEN TOKEN 1";
            }
            else
            {
                if (DiceNumAnimation == 6 && greenSteps[0] == 0)
                {
                    Vector3[] greenToken1Path = new Vector3[1];
                    greenToken1Path[0] = greenMovementBlock[greenSteps[0]].transform.position;
                    greenSteps[0] += 1;
                    playerTurn = "GREEN";
                    currentPlayerName = "GREEN TOKEN 1";
                    iTween.MoveTo(greenTokens[0], iTween.Hash("position", greenToken1Path[0], "speed", 125, "time", 2.0f, "easetype", "elastic", "oncomplete", "IntializeDice", "oncompletetarget", this.gameObject));
                }
            }
        }
        else
        {   // Moves to enter house
            if (playerTurn == "GREEN" && (greenMovementBlock.Count - greenSteps[0]) == DiceNumAnimation)
            {
                Vector3[] greenToken1Path = new Vector3[DiceNumAnimation];
                for (int i = 0; i < DiceNumAnimation; i++)
                {
                    greenToken1Path[i] = greenMovementBlock[greenSteps[0] + i].transform.position;
                }
                greenSteps[0] += DiceNumAnimation;
                if (greenToken1Path.Length > 1)
                {
                    iTween.MoveTo(greenTokens[0], iTween.Hash("path", greenToken1Path, "speed", 125, "time", 2.0f, "easetype", "elastic", "oncomplete", "IntializeDice", "oncompletetarget", this.gameObject));
                }
                else
                {
                    iTween.MoveTo(greenTokens[0], iTween.Hash("position", greenToken1Path[0], "speed", 125, "time", 2.0f, "easetype", "elastic", "oncomplete", "IntializeDice", "oncompletetarget", this.gameObject));
                }
                playerTurn = "GREEN";
                totalGreenInHouse += 1;
                greenButtons[0].enabled = false;
            }
            else
            {
                if (greenSteps[1] + greenSteps[2] + greenSteps[3] == 0 && DiceNumAnimation != 6)
                {
                    switch (MainMenuManager.numberOfPlayers)
                    {
                        case 2:
                            playerTurn = "RED";
                            break;

                        case 4:
                            playerTurn = "YELLOW";
                            break;
                    }
                }
                IntializeDice();
            }
        }
    }

    public void GreenToken2Movement()
    {
        SoundManager.playerAudioSource.Play();
        for (int i = 0; i <= 3; i++)
        {
            greenBorder[i].SetActive(false);
            greenButtons[i].interactable = false;
        }
        if (playerTurn == "GREEN" && (greenMovementBlock.Count - greenSteps[1]) > DiceNumAnimation)
        {
            if (greenSteps[1] > 0)
            {
                Vector3[] greenToken2Path = new Vector3[DiceNumAnimation];

                for (int i = 0; i < DiceNumAnimation; i++)
                {
                    greenToken2Path[i] = greenMovementBlock[greenSteps[1] + i].transform.position;
                }
                greenSteps[1] += DiceNumAnimation;
                if (DiceNumAnimation == 6)
                {
                    playerTurn = "GREEN";
                }
                else
                {
                    switch (MainMenuManager.numberOfPlayers)
                    {
                        case 2:
                            playerTurn = "RED";
                            break;

                        case 4:
                            playerTurn = "YELLOW";
                            break;
                    }
                }
                if (greenToken2Path.Length > 1)
                {
                    iTween.MoveTo(greenTokens[1], iTween.Hash("path", greenToken2Path, "speed", 125, "time", 2.0f, "easetype", "elastic", "oncomplete", "IntializeDice", "oncompletetarget", this.gameObject));
                }
                else
                {
                    iTween.MoveTo(greenTokens[1], iTween.Hash("position", greenToken2Path[0], "speed", 125, "time", 2.0f, "easetype", "elastic", "oncomplete", "IntializeDice", "oncompletetarget", this.gameObject));
                }
                currentPlayerName = "GREEN TOKEN 2";
            }
            else
            {
                if (DiceNumAnimation == 6 && greenSteps[1] == 0)
                {
                    Vector3[] greenToken2Path = new Vector3[1];
                    greenToken2Path[0] = greenMovementBlock[greenSteps[1]].transform.position;
                    greenSteps[1] += 1;
                    playerTurn = "GREEN";
                    currentPlayerName = "GREEN TOKEN 2";
                    iTween.MoveTo(greenTokens[1], iTween.Hash("position", greenToken2Path[0], "speed", 125, "time", 2.0f, "easetype", "elastic", "oncomplete", "IntializeDice", "oncompletetarget", this.gameObject));
                }
            }
        }
        else
        {   // Moves to enter house
            if (playerTurn == "GREEN" && (greenMovementBlock.Count - greenSteps[1]) == DiceNumAnimation)
            {
                Vector3[] greenToken2Path = new Vector3[DiceNumAnimation];
                for (int i = 0; i < DiceNumAnimation; i++)
                {
                    greenToken2Path[i] = greenMovementBlock[greenSteps[1] + i].transform.position;
                }
                greenSteps[1] += DiceNumAnimation;
                if (greenToken2Path.Length > 1)
                {
                    iTween.MoveTo(greenTokens[1], iTween.Hash("path", greenToken2Path, "speed", 125, "time", 2.0f, "easetype", "elastic", "oncomplete", "IntializeDice", "oncompletetarget", this.gameObject));
                }
                else
                {
                    iTween.MoveTo(greenTokens[1], iTween.Hash("position", greenToken2Path[0], "speed", 125, "time", 2.0f, "easetype", "elastic", "oncomplete", "IntializeDice", "oncompletetarget", this.gameObject));
                }
                playerTurn = "GREEN";
                totalGreenInHouse += 1;
                greenButtons[1].enabled = false;
            }
            else
            {
                if (greenSteps[0] + greenSteps[2] + greenSteps[3] == 0 && DiceNumAnimation != 6)
                {
                    switch (MainMenuManager.numberOfPlayers)
                    {
                        case 2:
                            playerTurn = "RED";
                            break;

                        case 4:
                            playerTurn = "YELLOW";
                            break;
                    }
                }
                IntializeDice();
            }
        }
    }

    public void GreenToken3Movement()
    {
        SoundManager.playerAudioSource.Play();
        for (int i = 0; i <= 3; i++)
        {
            greenBorder[i].SetActive(false);
            greenButtons[i].interactable = false;
        }
        if (playerTurn == "GREEN" && (greenMovementBlock.Count - greenSteps[2]) > DiceNumAnimation)
        {
            if (greenSteps[2] > 0)
            {
                Vector3[] greenToken3Path = new Vector3[DiceNumAnimation];

                for (int i = 0; i < DiceNumAnimation; i++)
                {
                    greenToken3Path[i] = greenMovementBlock[greenSteps[2] + i].transform.position;
                }
                greenSteps[2] += DiceNumAnimation;
                if (DiceNumAnimation == 6)
                {
                    playerTurn = "GREEN";
                }
                else
                {
                    switch (MainMenuManager.numberOfPlayers)
                    {
                        case 2:
                            playerTurn = "RED";
                            break;

                        case 4:
                            playerTurn = "YELLOW";
                            break;
                    }
                }
                if (greenToken3Path.Length > 1)
                {
                    iTween.MoveTo(greenTokens[2], iTween.Hash("path", greenToken3Path, "speed", 125, "time", 2.0f, "easetype", "elastic", "oncomplete", "IntializeDice", "oncompletetarget", this.gameObject));
                }
                else
                {
                    iTween.MoveTo(greenTokens[2], iTween.Hash("position", greenToken3Path[0], "speed", 125, "time", 2.0f, "easetype", "elastic", "oncomplete", "IntializeDice", "oncompletetarget", this.gameObject));
                }
                currentPlayerName = "GREEN TOKEN 3";
            }
            else
            {
                if (DiceNumAnimation == 6 && greenSteps[2] == 0)
                {
                    Vector3[] greenToken3Path = new Vector3[1];
                    greenToken3Path[0] = greenMovementBlock[greenSteps[2]].transform.position;
                    greenSteps[2] += 1;
                    playerTurn = "GREEN";
                    currentPlayerName = "GREEN TOKEN 3";
                    iTween.MoveTo(greenTokens[2], iTween.Hash("position", greenToken3Path[0], "speed", 125, "time", 2.0f, "easetype", "elastic", "oncomplete", "IntializeDice", "oncompletetarget", this.gameObject));
                }
            }
        }
        else
        {   // Moves to enter house
            if (playerTurn == "GREEN" && (greenMovementBlock.Count - greenSteps[2]) == DiceNumAnimation)
            {
                Vector3[] greenToken3Path = new Vector3[DiceNumAnimation];
                for (int i = 0; i < DiceNumAnimation; i++)
                {
                    greenToken3Path[i] = greenMovementBlock[greenSteps[2] + i].transform.position;
                }
                greenSteps[2] += DiceNumAnimation;
                if (greenToken3Path.Length > 1)
                {
                    iTween.MoveTo(greenTokens[2], iTween.Hash("path", greenToken3Path, "speed", 125, "time", 2.0f, "easetype", "elastic", "oncomplete", "IntializeDice", "oncompletetarget", this.gameObject));
                }
                else
                {
                    iTween.MoveTo(greenTokens[2], iTween.Hash("position", greenToken3Path[0], "speed", 125, "time", 2.0f, "easetype", "elastic", "oncomplete", "IntializeDice", "oncompletetarget", this.gameObject));
                }
                playerTurn = "GREEN";
                totalGreenInHouse += 1;
                greenButtons[2].enabled = false;
            }
            else
            {
                if (greenSteps[0] + greenSteps[1] + greenSteps[3] == 0 && DiceNumAnimation != 6)
                {
                    switch (MainMenuManager.numberOfPlayers)
                    {
                        case 2:
                            playerTurn = "RED";
                            break;

                        case 4:
                            playerTurn = "YELLOW";
                            break;
                    }
                }
                IntializeDice();
            }
        }
    }

    public void GreenToken4Movement()
    {
        SoundManager.playerAudioSource.Play();
        for (int i = 0; i <= 3; i++)
        {
            greenBorder[i].SetActive(false);
            greenButtons[i].interactable = false;
        }
        if (playerTurn == "GREEN" && (greenMovementBlock.Count - greenSteps[3]) > DiceNumAnimation)
        {
            if (greenSteps[3] > 0)
            {
                Vector3[] greenToken4Path = new Vector3[DiceNumAnimation];

                for (int i = 0; i < DiceNumAnimation; i++)
                {
                    greenToken4Path[i] = greenMovementBlock[greenSteps[3] + i].transform.position;
                }
                greenSteps[3] += DiceNumAnimation;
                if (DiceNumAnimation == 6)
                {
                    playerTurn = "GREEN";
                }
                else
                {
                    switch (MainMenuManager.numberOfPlayers)
                    {
                        case 2:
                            playerTurn = "RED";
                            break;

                        case 4:
                            playerTurn = "YELLOW";
                            break;
                    }
                }
                if (greenToken4Path.Length > 1)
                {
                    iTween.MoveTo(greenTokens[3], iTween.Hash("path", greenToken4Path, "speed", 125, "time", 2.0f, "easetype", "elastic", "oncomplete", "IntializeDice", "oncompletetarget", this.gameObject));
                }
                else
                {
                    iTween.MoveTo(greenTokens[3], iTween.Hash("position", greenToken4Path[0], "speed", 125, "time", 2.0f, "easetype", "elastic", "oncomplete", "IntializeDice", "oncompletetarget", this.gameObject));
                }
                currentPlayerName = "GREEN TOKEN 4";
            }
            else
            {
                if (DiceNumAnimation == 6 && greenSteps[3] == 0)
                {
                    Vector3[] greenToken4Path = new Vector3[1];
                    greenToken4Path[0] = greenMovementBlock[greenSteps[3]].transform.position;
                    greenSteps[3] += 1;
                    playerTurn = "GREEN";
                    currentPlayerName = "GREEN TOKEN 4";
                    iTween.MoveTo(greenTokens[3], iTween.Hash("position", greenToken4Path[0], "speed", 125, "time", 2.0f, "easetype", "elastic", "oncomplete", "IntializeDice", "oncompletetarget", this.gameObject));
                }
            }
        }
        else
        {   // Moves to enter house
            if (playerTurn == "GREEN" && (greenMovementBlock.Count - greenSteps[3]) == DiceNumAnimation)
            {
                Vector3[] greenToken4Path = new Vector3[DiceNumAnimation];
                for (int i = 0; i < DiceNumAnimation; i++)
                {
                    greenToken4Path[i] = greenMovementBlock[greenSteps[3] + i].transform.position;
                }
                greenSteps[3] += DiceNumAnimation;
                if (greenToken4Path.Length > 1)
                {
                    iTween.MoveTo(greenTokens[3], iTween.Hash("path", greenToken4Path, "speed", 125, "time", 2.0f, "easetype", "elastic", "oncomplete", "IntializeDice", "oncompletetarget", this.gameObject));
                }
                else
                {
                    iTween.MoveTo(greenTokens[3], iTween.Hash("position", greenToken4Path[0], "speed", 125, "time", 2.0f, "easetype", "elastic", "oncomplete", "IntializeDice", "oncompletetarget", this.gameObject));
                }
                playerTurn = "GREEN";
                totalGreenInHouse += 1;
                greenButtons[3].enabled = false;
            }
            else
            {
                if (greenSteps[0] + greenSteps[1] + greenSteps[2] == 0 && DiceNumAnimation != 6)
                {
                    switch (MainMenuManager.numberOfPlayers)
                    {
                        case 2:
                            playerTurn = "RED";
                            break;

                        case 4:
                            playerTurn = "YELLOW";
                            break;
                    }
                }
                IntializeDice();
            }
        }
    }

    public void BlueToken1Movement()
    {
        SoundManager.playerAudioSource.Play();
        for (int i = 0; i <= 3; i++)
        {
            blueBorder[i].SetActive(false);
            blueButtons[i].interactable = false;
        }
        if (playerTurn == "BLUE" && (blueMovementBlock.Count - blueSteps[0]) > DiceNumAnimation)
        {
            if (blueSteps[0] > 0)
            {
                Vector3[] blueToken1Path = new Vector3[DiceNumAnimation];

                for (int i = 0; i < DiceNumAnimation; i++)
                {
                    blueToken1Path[i] = blueMovementBlock[blueSteps[0] + i].transform.position;
                }
                blueSteps[0] += DiceNumAnimation;
                if (DiceNumAnimation == 6)
                {
                    playerTurn = "BLUE";
                }
                else
                {
                    switch (MainMenuManager.numberOfPlayers)
                    {
                        case 2:
                            //player not available
                            break;

                        case 4:
                            playerTurn = "GREEN";
                            break;
                    }
                }
                if (blueToken1Path.Length > 1)
                {
                    iTween.MoveTo(blueTokens[0], iTween.Hash("path", blueToken1Path, "speed", 125, "time", 2.0f, "easetype", "elastic", "oncomplete", "IntializeDice", "oncompletetarget", this.gameObject));
                }
                else
                {
                    iTween.MoveTo(blueTokens[0], iTween.Hash("position", blueToken1Path[0], "speed", 125, "time", 2.0f, "easetype", "elastic", "oncomplete", "IntializeDice", "oncompletetarget", this.gameObject));
                }
                currentPlayerName = "BLUE TOKEN 1";
            }
            else
            {
                if (DiceNumAnimation == 6 && blueSteps[0] == 0)
                {
                    Vector3[] blueToken1Path = new Vector3[1];
                    blueToken1Path[0] = blueMovementBlock[blueSteps[0]].transform.position;
                    blueSteps[0] += 1;
                    playerTurn = "BLUE";
                    currentPlayerName = "BLUE TOKEN 1";
                    iTween.MoveTo(blueTokens[0], iTween.Hash("position", blueToken1Path[0], "speed", 125, "time", 2.0f, "easetype", "elastic", "oncomplete", "IntializeDice", "oncompletetarget", this.gameObject));
                }
            }
        }
        else
        {   // Moves to enter house
            if (playerTurn == "BLUE" && (blueMovementBlock.Count - blueSteps[0]) == DiceNumAnimation)
            {
                Vector3[] blueToken1Path = new Vector3[DiceNumAnimation];
                for (int i = 0; i < DiceNumAnimation; i++)
                {
                    blueToken1Path[i] = blueMovementBlock[blueSteps[0] + i].transform.position;
                }
                blueSteps[0] += DiceNumAnimation;
                if (blueToken1Path.Length > 1)
                {
                    iTween.MoveTo(blueTokens[0], iTween.Hash("path", blueToken1Path, "speed", 125, "time", 2.0f, "easetype", "elastic", "oncomplete", "IntializeDice", "oncompletetarget", this.gameObject));
                }
                else
                {
                    iTween.MoveTo(blueTokens[0], iTween.Hash("position", blueToken1Path[0], "speed", 125, "time", 2.0f, "easetype", "elastic", "oncomplete", "IntializeDice", "oncompletetarget", this.gameObject));
                }
                playerTurn = "BLUE";
                totalBlueInHouse += 1;
                blueButtons[0].enabled = false;
            }
            else
            {
                if (blueSteps[1] + blueSteps[2] + blueSteps[3] == 0 && DiceNumAnimation != 6)
                {
                    switch (MainMenuManager.numberOfPlayers)
                    {
                        case 2:
                           //not available
                            break;

                        case 4:
                            playerTurn = "GREEN";
                            break;
                    }
                }
                IntializeDice();
            }
        }
    }

    public void BlueToken2Movement()
    {
        SoundManager.playerAudioSource.Play();
        for (int i = 0; i <= 3; i++)
        {
            blueBorder[i].SetActive(false);
            blueButtons[i].interactable = false;
        }
        if (playerTurn == "BLUE" && (blueMovementBlock.Count - blueSteps[1]) > DiceNumAnimation)
        {
            if (blueSteps[1] > 0)
            {
                Vector3[] blueToken2Path = new Vector3[DiceNumAnimation];

                for (int i = 0; i < DiceNumAnimation; i++)
                {
                    blueToken2Path[i] = blueMovementBlock[blueSteps[1] + i].transform.position;
                }
                blueSteps[1] += DiceNumAnimation;
                if (DiceNumAnimation == 6)
                {
                    playerTurn = "BLUE";
                }
                else
                {
                    switch (MainMenuManager.numberOfPlayers)
                    {
                        case 2:
                            //player not available
                            break;

                        case 4:
                            playerTurn = "GREEN";
                            break;
                    }
                }
                if (blueToken2Path.Length > 1)
                {
                    iTween.MoveTo(blueTokens[1], iTween.Hash("path", blueToken2Path, "speed", 125, "time", 2.0f, "easetype", "elastic", "oncomplete", "IntializeDice", "oncompletetarget", this.gameObject));
                }
                else
                {
                    iTween.MoveTo(blueTokens[1], iTween.Hash("position", blueToken2Path[0], "speed", 125, "time", 2.0f, "easetype", "elastic", "oncomplete", "IntializeDice", "oncompletetarget", this.gameObject));
                }
                currentPlayerName = "BLUE TOKEN 2";
            }
            else
            {
                if (DiceNumAnimation == 6 && blueSteps[1] == 0)
                {
                    Vector3[] blueToken2Path = new Vector3[1];
                    blueToken2Path[0] = blueMovementBlock[blueSteps[1]].transform.position;
                    blueSteps[1] += 1;
                    playerTurn = "BLUE";
                    currentPlayerName = "BLUE TOKEN 2";
                    iTween.MoveTo(blueTokens[1], iTween.Hash("position", blueToken2Path[0], "speed", 125, "time", 2.0f, "easetype", "elastic", "oncomplete", "IntializeDice", "oncompletetarget", this.gameObject));
                }
            }
        }
        else
        {   // Moves to enter house
            if (playerTurn == "BLUE" && (blueMovementBlock.Count - blueSteps[1]) == DiceNumAnimation)
            {
                Vector3[] blueToken2Path = new Vector3[DiceNumAnimation];
                for (int i = 0; i < DiceNumAnimation; i++)
                {
                    blueToken2Path[i] = blueMovementBlock[blueSteps[1] + i].transform.position;
                }
                blueSteps[1] += DiceNumAnimation;
                if (blueToken2Path.Length > 1)
                {
                    iTween.MoveTo(blueTokens[1], iTween.Hash("path", blueToken2Path, "speed", 125, "time", 2.0f, "easetype", "elastic", "oncomplete", "IntializeDice", "oncompletetarget", this.gameObject));
                }
                else
                {
                    iTween.MoveTo(blueTokens[1], iTween.Hash("position", blueToken2Path[0], "speed", 125, "time", 2.0f, "easetype", "elastic", "oncomplete", "IntializeDice", "oncompletetarget", this.gameObject));
                }
                playerTurn = "BLUE";
                totalBlueInHouse += 1;
                blueButtons[1].enabled = false;
            }
            else
            {
                if (blueSteps[0] + blueSteps[2] + blueSteps[3] == 0 && DiceNumAnimation != 6)
                {
                    switch (MainMenuManager.numberOfPlayers)
                    {
                        case 2:
                            //not available
                            break;

                        case 4:
                            playerTurn = "GREEN";
                            break;
                    }
                }
                IntializeDice();
            }
        }
    }

    public void BlueToken3Movement()
    {
        SoundManager.playerAudioSource.Play();
        for (int i = 0; i <= 3; i++)
        {
            blueBorder[i].SetActive(false);
            blueButtons[i].interactable = false;
        }
        if (playerTurn == "BLUE" && (blueMovementBlock.Count - blueSteps[2]) > DiceNumAnimation)
        {
            if (blueSteps[2] > 0)
            {
                Vector3[] blueToken3Path = new Vector3[DiceNumAnimation];

                for (int i = 0; i < DiceNumAnimation; i++)
                {
                    blueToken3Path[i] = blueMovementBlock[blueSteps[2] + i].transform.position;
                }
                blueSteps[2] += DiceNumAnimation;
                if (DiceNumAnimation == 6)
                {
                    playerTurn = "BLUE";
                }
                else
                {
                    switch (MainMenuManager.numberOfPlayers)
                    {
                        case 2:
                            //player not available
                            break;

                        case 4:
                            playerTurn = "GREEN";
                            break;
                    }
                }
                if (blueToken3Path.Length > 1)
                {
                    iTween.MoveTo(blueTokens[2], iTween.Hash("path", blueToken3Path, "speed", 125, "time", 2.0f, "easetype", "elastic", "oncomplete", "IntializeDice", "oncompletetarget", this.gameObject));
                }
                else
                {
                    iTween.MoveTo(blueTokens[2], iTween.Hash("position", blueToken3Path[0], "speed", 125, "time", 2.0f, "easetype", "elastic", "oncomplete", "IntializeDice", "oncompletetarget", this.gameObject));
                }
                currentPlayerName = "BLUE TOKEN 3";
            }
            else
            {
                if (DiceNumAnimation == 6 && blueSteps[2] == 0)
                {
                    Vector3[] blueToken3Path = new Vector3[1];
                    blueToken3Path[0] = blueMovementBlock[blueSteps[2]].transform.position;
                    blueSteps[2] += 1;
                    playerTurn = "BLUE";
                    currentPlayerName = "BLUE TOKEN 3";
                    iTween.MoveTo(blueTokens[2], iTween.Hash("position", blueToken3Path[0], "speed", 125, "time", 2.0f, "easetype", "elastic", "oncomplete", "IntializeDice", "oncompletetarget", this.gameObject));
                }
            }
        }
        else
        {   // Moves to enter house
            if (playerTurn == "BLUE" && (blueMovementBlock.Count - blueSteps[2]) == DiceNumAnimation)
            {
                Vector3[] blueToken3Path = new Vector3[DiceNumAnimation];
                for (int i = 0; i < DiceNumAnimation; i++)
                {
                    blueToken3Path[i] = blueMovementBlock[blueSteps[2] + i].transform.position;
                }
                blueSteps[2] += DiceNumAnimation;
                if (blueToken3Path.Length > 1)
                {
                    iTween.MoveTo(blueTokens[2], iTween.Hash("path", blueToken3Path, "speed", 125, "time", 2.0f, "easetype", "elastic", "oncomplete", "IntializeDice", "oncompletetarget", this.gameObject));
                }
                else
                {
                    iTween.MoveTo(blueTokens[2], iTween.Hash("position", blueToken3Path[0], "speed", 125, "time", 2.0f, "easetype", "elastic", "oncomplete", "IntializeDice", "oncompletetarget", this.gameObject));
                }
                playerTurn = "BLUE";
                totalBlueInHouse += 1;
                blueButtons[2].enabled = false;
            }
            else
            {
                if (blueSteps[0] + blueSteps[1] + blueSteps[3] == 0 && DiceNumAnimation != 6)
                {
                    switch (MainMenuManager.numberOfPlayers)
                    {
                        case 2:
                            //not available
                            break;

                        case 4:
                            playerTurn = "GREEN";
                            break;
                    }
                }
                IntializeDice();
            }
        }
    }

    public void BlueToken4Movement()
    {
        SoundManager.playerAudioSource.Play();
        for (int i = 0; i <= 3; i++)
        {
            blueBorder[i].SetActive(false);
            blueButtons[i].interactable = false;
        }
        if (playerTurn == "BLUE" && (blueMovementBlock.Count - blueSteps[3]) > DiceNumAnimation)
        {
            if (blueSteps[3] > 0)
            {
                Vector3[] blueToken4Path = new Vector3[DiceNumAnimation];

                for (int i = 0; i < DiceNumAnimation; i++)
                {
                    blueToken4Path[i] = blueMovementBlock[blueSteps[3] + i].transform.position;
                }
                blueSteps[3] += DiceNumAnimation;
                if (DiceNumAnimation == 6)
                {
                    playerTurn = "BLUE";
                }
                else
                {
                    switch (MainMenuManager.numberOfPlayers)
                    {
                        case 2:
                            //player not available
                            break;

                        case 4:
                            playerTurn = "GREEN";
                            break;
                    }
                }
                if (blueToken4Path.Length > 1)
                {
                    iTween.MoveTo(blueTokens[3], iTween.Hash("path", blueToken4Path, "speed", 125, "time", 2.0f, "easetype", "elastic", "oncomplete", "IntializeDice", "oncompletetarget", this.gameObject));
                }
                else
                {
                    iTween.MoveTo(blueTokens[3], iTween.Hash("position", blueToken4Path[0], "speed", 125, "time", 2.0f, "easetype", "elastic", "oncomplete", "IntializeDice", "oncompletetarget", this.gameObject));
                }
                currentPlayerName = "BLUE TOKEN 4";
            }
            else
            {
                if (DiceNumAnimation == 6 && blueSteps[3] == 0)
                {
                    Vector3[] blueToken4Path = new Vector3[1];
                    blueToken4Path[0] = blueMovementBlock[blueSteps[3]].transform.position;
                    blueSteps[3] += 1;
                    playerTurn = "BLUE";
                    currentPlayerName = "BLUE TOKEN 4";
                    iTween.MoveTo(blueTokens[3], iTween.Hash("position", blueToken4Path[0], "speed", 125, "time", 2.0f, "easetype", "elastic", "oncomplete", "IntializeDice", "oncompletetarget", this.gameObject));
                }
            }
        }
        else
        {   // Moves to enter house
            if (playerTurn == "BLUE" && (blueMovementBlock.Count - blueSteps[2]) == DiceNumAnimation)
            {
                Vector3[] blueToken4Path = new Vector3[DiceNumAnimation];
                for (int i = 0; i < DiceNumAnimation; i++)
                {
                    blueToken4Path[i] = blueMovementBlock[blueSteps[3] + i].transform.position;
                }
                blueSteps[3] += DiceNumAnimation;
                if (blueToken4Path.Length > 1)
                {
                    iTween.MoveTo(blueTokens[3], iTween.Hash("path", blueToken4Path, "speed", 125, "time", 2.0f, "easetype", "elastic", "oncomplete", "IntializeDice", "oncompletetarget", this.gameObject));
                }
                else
                {
                    iTween.MoveTo(blueTokens[3], iTween.Hash("position", blueToken4Path[0], "speed", 125, "time", 2.0f, "easetype", "elastic", "oncomplete", "IntializeDice", "oncompletetarget", this.gameObject));
                }
                playerTurn = "BLUE";
                totalBlueInHouse += 1;
                blueButtons[3].enabled = false;
            }
            else
            {
                if (blueSteps[0] + blueSteps[1] + blueSteps[2] == 0 && DiceNumAnimation != 6)
                {
                    switch (MainMenuManager.numberOfPlayers)
                    {
                        case 2:
                            //not available
                            break;

                        case 4:
                            playerTurn = "GREEN";
                            break;
                    }
                }
                IntializeDice();
            }
        }
    }

    public void YellowToken1Movement()
    {
        SoundManager.playerAudioSource.Play();
        for (int i = 0; i <= 3; i++)
        {
            yellowBorder[i].SetActive(false);
            yellowButtons[i].interactable = false;
        }
        if (playerTurn == "YELLOW" && (yellowMovementBlock.Count - yellowSteps[0]) > DiceNumAnimation)
        {
            if (yellowSteps[0] > 0)
            {
                Vector3[] yellowToken1Path = new Vector3[DiceNumAnimation];

                for (int i = 0; i < DiceNumAnimation; i++)
                {
                    yellowToken1Path[i] = yellowMovementBlock[yellowSteps[0] + i].transform.position;
                }
                yellowSteps[0] += DiceNumAnimation;
                if (DiceNumAnimation == 6)
                {
                    playerTurn = "YELLOW";
                }
                else
                {
                    switch (MainMenuManager.numberOfPlayers)
                    {
                        case 2:
                            //Not available
                            break;

                        case 4:
                            playerTurn = "RED";
                            break;
                    }
                }
                if (yellowToken1Path.Length > 1)
                {
                    iTween.MoveTo(yellowTokens[0], iTween.Hash("path", yellowToken1Path, "speed", 125, "time", 2.0f, "easetype", "elastic", "oncomplete", "IntializeDice", "oncompletetarget", this.gameObject));
                }
                else
                {
                    iTween.MoveTo(yellowTokens[0], iTween.Hash("position", yellowToken1Path[0], "speed", 125, "time", 2.0f, "easetype", "elastic", "oncomplete", "IntializeDice", "oncompletetarget", this.gameObject));
                }
                currentPlayerName = "YELLOW TOKEN 1";
            }
            else
            {
                if (DiceNumAnimation == 6 && yellowSteps[0] == 0)
                {
                    Vector3[] yellowToken1Path = new Vector3[1];
                    yellowToken1Path[0] = yellowMovementBlock[yellowSteps[0]].transform.position;
                    yellowSteps[0] += 1;
                    playerTurn = "YELLOW";
                    currentPlayerName = "YELLOW TOKEN 1";
                    iTween.MoveTo(yellowTokens[0], iTween.Hash("position", yellowToken1Path[0], "speed", 125, "time", 2.0f, "easetype", "elastic", "oncomplete", "IntializeDice", "oncompletetarget", this.gameObject));
                }
            }
        }
        else
        {   // Moves to enter house
            if (playerTurn == "YELLOW" && (yellowMovementBlock.Count - yellowSteps[0]) == DiceNumAnimation)
            {
                Vector3[] yellowToken1Path = new Vector3[DiceNumAnimation];
                for (int i = 0; i < DiceNumAnimation; i++)
                {
                    yellowToken1Path[i] = yellowMovementBlock[yellowSteps[0] + i].transform.position;
                }
                yellowSteps[0] += DiceNumAnimation;
                if (yellowToken1Path.Length > 1)
                {
                    iTween.MoveTo(yellowTokens[0], iTween.Hash("path", yellowToken1Path, "speed", 125, "time", 2.0f, "easetype", "elastic", "oncomplete", "IntializeDice", "oncompletetarget", this.gameObject));
                }
                else
                {
                    iTween.MoveTo(yellowTokens[0], iTween.Hash("position", yellowToken1Path[0], "speed", 125, "time", 2.0f, "easetype", "elastic", "oncomplete", "IntializeDice", "oncompletetarget", this.gameObject));
                }
                playerTurn = "YELLOW";
                totalYellowInHouse += 1;
                yellowButtons[0].enabled = false;
            }
            else
            {
                if (yellowSteps[1] + yellowSteps[2] + yellowSteps[3] == 0 && DiceNumAnimation != 6)
                {
                    switch (MainMenuManager.numberOfPlayers)
                    {
                        case 2:
                            //not available
                            break;

                        case 4:
                            playerTurn = "RED";
                            break;
                    }
                }
                IntializeDice();
            }
        }
    }

    public void YellowToken2Movement()
    {
        SoundManager.playerAudioSource.Play();
        for (int i = 0; i <= 3; i++)
        {
            yellowBorder[i].SetActive(false);
            yellowButtons[i].interactable = false;
        }
        if (playerTurn == "YELLOW" && (yellowMovementBlock.Count - yellowSteps[1]) > DiceNumAnimation)
        {
            if (yellowSteps[1] > 0)
            {
                Vector3[] yellowToken2Path = new Vector3[DiceNumAnimation];

                for (int i = 0; i < DiceNumAnimation; i++)
                {
                    yellowToken2Path[i] = yellowMovementBlock[yellowSteps[1] + i].transform.position;
                }
                yellowSteps[1] += DiceNumAnimation;
                if (DiceNumAnimation == 6)
                {
                    playerTurn = "YELLOW";
                }
                else
                {
                    switch (MainMenuManager.numberOfPlayers)
                    {
                        case 2:
                            //Not available
                            break;

                        case 4:
                            playerTurn = "RED";
                            break;
                    }
                }
                if (yellowToken2Path.Length > 1)
                {
                    iTween.MoveTo(yellowTokens[1], iTween.Hash("path", yellowToken2Path, "speed", 125, "time", 2.0f, "easetype", "elastic", "oncomplete", "IntializeDice", "oncompletetarget", this.gameObject));
                }
                else
                {
                    iTween.MoveTo(yellowTokens[1], iTween.Hash("position", yellowToken2Path[0], "speed", 125, "time", 2.0f, "easetype", "elastic", "oncomplete", "IntializeDice", "oncompletetarget", this.gameObject));
                }
                currentPlayerName = "YELLOW TOKEN 2";
            }
            else
            {
                if (DiceNumAnimation == 6 && yellowSteps[1] == 0)
                {
                    Vector3[] yellowToken2Path = new Vector3[1];
                    yellowToken2Path[0] = yellowMovementBlock[yellowSteps[1]].transform.position;
                    yellowSteps[1] += 1;
                    playerTurn = "YELLOW";
                    currentPlayerName = "YELLOW TOKEN 2";
                    iTween.MoveTo(yellowTokens[1], iTween.Hash("position", yellowToken2Path[0], "speed", 125, "time", 2.0f, "easetype", "elastic", "oncomplete", "IntializeDice", "oncompletetarget", this.gameObject));
                }
            }
        }
        else
        {   // Moves to enter house
            if (playerTurn == "YELLOW" && (yellowMovementBlock.Count - yellowSteps[1]) == DiceNumAnimation)
            {
                Vector3[] yellowToken2Path = new Vector3[DiceNumAnimation];
                for (int i = 0; i < DiceNumAnimation; i++)
                {
                    yellowToken2Path[i] = yellowMovementBlock[yellowSteps[1] + i].transform.position;
                }
                yellowSteps[1] += DiceNumAnimation;
                if (yellowToken2Path.Length > 1)
                {
                    iTween.MoveTo(yellowTokens[1], iTween.Hash("path", yellowToken2Path, "speed", 125, "time", 2.0f, "easetype", "elastic", "oncomplete", "IntializeDice", "oncompletetarget", this.gameObject));
                }
                else
                {
                    iTween.MoveTo(yellowTokens[1], iTween.Hash("position", yellowToken2Path[0], "speed", 125, "time", 2.0f, "easetype", "elastic", "oncomplete", "IntializeDice", "oncompletetarget", this.gameObject));
                }
                playerTurn = "YELLOW";
                totalYellowInHouse += 1;
                yellowButtons[1].enabled = false;
            }
            else
            {
                if (yellowSteps[0] + yellowSteps[2] + yellowSteps[3] == 0 && DiceNumAnimation != 6)
                {
                    switch (MainMenuManager.numberOfPlayers)
                    {
                        case 2:
                            //not available
                            break;

                        case 4:
                            playerTurn = "RED";
                            break;
                    }
                }
                IntializeDice();
            }
        }
    }

    public void YellowToken3Movement()
    {
        SoundManager.playerAudioSource.Play();
        for (int i = 0; i <= 3; i++)
        {
            yellowBorder[i].SetActive(false);
            yellowButtons[i].interactable = false;
        }
        if (playerTurn == "YELLOW" && (yellowMovementBlock.Count - yellowSteps[2]) > DiceNumAnimation)
        {
            if (yellowSteps[2] > 0)
            {
                Vector3[] yellowToken3Path = new Vector3[DiceNumAnimation];

                for (int i = 0; i < DiceNumAnimation; i++)
                {
                    yellowToken3Path[i] = yellowMovementBlock[yellowSteps[2] + i].transform.position;
                }
                yellowSteps[2] += DiceNumAnimation;
                if (DiceNumAnimation == 6)
                {
                    playerTurn = "YELLOW";
                }
                else
                {
                    switch (MainMenuManager.numberOfPlayers)
                    {
                        case 2:
                            //Not available
                            break;

                        case 4:
                            playerTurn = "RED";
                            break;
                    }
                }
                if (yellowToken3Path.Length > 1)
                {
                    iTween.MoveTo(yellowTokens[2], iTween.Hash("path", yellowToken3Path, "speed", 125, "time", 2.0f, "easetype", "elastic", "oncomplete", "IntializeDice", "oncompletetarget", this.gameObject));
                }
                else
                {
                    iTween.MoveTo(yellowTokens[2], iTween.Hash("position", yellowToken3Path[0], "speed", 125, "time", 2.0f, "easetype", "elastic", "oncomplete", "IntializeDice", "oncompletetarget", this.gameObject));
                }
                currentPlayerName = "YELLOW TOKEN 3";
            }
            else
            {
                if (DiceNumAnimation == 6 && yellowSteps[2] == 0)
                {
                    Vector3[] yellowToken3Path = new Vector3[1];
                    yellowToken3Path[0] = yellowMovementBlock[yellowSteps[2]].transform.position;
                    yellowSteps[2] += 1;
                    playerTurn = "YELLOW";
                    currentPlayerName = "YELLOW TOKEN 3";
                    iTween.MoveTo(yellowTokens[2], iTween.Hash("position", yellowToken3Path[0], "speed", 125, "time", 2.0f, "easetype", "elastic", "oncomplete", "IntializeDice", "oncompletetarget", this.gameObject));
                }
            }
        }
        else
        {   // Moves to enter house
            if (playerTurn == "YELLOW" && (yellowMovementBlock.Count - yellowSteps[2]) == DiceNumAnimation)
            {
                Vector3[] yellowToken3Path = new Vector3[DiceNumAnimation];
                for (int i = 0; i < DiceNumAnimation; i++)
                {
                    yellowToken3Path[i] = yellowMovementBlock[yellowSteps[2] + i].transform.position;
                }
                yellowSteps[2] += DiceNumAnimation;
                if (yellowToken3Path.Length > 1)
                {
                    iTween.MoveTo(yellowTokens[2], iTween.Hash("path", yellowToken3Path, "speed", 125, "time", 2.0f, "easetype", "elastic", "oncomplete", "IntializeDice", "oncompletetarget", this.gameObject));
                }
                else
                {
                    iTween.MoveTo(yellowTokens[2], iTween.Hash("position", yellowToken3Path[0], "speed", 125, "time", 2.0f, "easetype", "elastic", "oncomplete", "IntializeDice", "oncompletetarget", this.gameObject));
                }
                playerTurn = "YELLOW";
                totalYellowInHouse += 1;
                yellowButtons[2].enabled = false;
            }
            else
            {
                if (yellowSteps[0] + yellowSteps[1] + yellowSteps[3] == 0 && DiceNumAnimation != 6)
                {
                    switch (MainMenuManager.numberOfPlayers)
                    {
                        case 2:
                            //not available
                            break;

                        case 4:
                            playerTurn = "RED";
                            break;
                    }
                }
                IntializeDice();
            }
        }
    }

    public void YellowToken4Movement()
    {
        SoundManager.playerAudioSource.Play();
        for (int i = 0; i <= 3; i++)
        {
            yellowBorder[i].SetActive(false);
            yellowButtons[i].interactable = false;
        }
        if (playerTurn == "YELLOW" && (yellowMovementBlock.Count - yellowSteps[3]) > DiceNumAnimation)
        {
            if (yellowSteps[3] > 0)
            {
                Vector3[] yellowToken4Path = new Vector3[DiceNumAnimation];

                for (int i = 0; i < DiceNumAnimation; i++)
                {
                    yellowToken4Path[i] = yellowMovementBlock[yellowSteps[3] + i].transform.position;
                }
                yellowSteps[3] += DiceNumAnimation;
                if (DiceNumAnimation == 6)
                {
                    playerTurn = "YELLOW";
                }
                else
                {
                    switch (MainMenuManager.numberOfPlayers)
                    {
                        case 2:
                            //Not available
                            break;

                        case 4:
                            playerTurn = "RED";
                            break;
                    }
                }
                if (yellowToken4Path.Length > 1)
                {
                    iTween.MoveTo(yellowTokens[3], iTween.Hash("path", yellowToken4Path, "speed", 125, "time", 2.0f, "easetype", "elastic", "oncomplete", "IntializeDice", "oncompletetarget", this.gameObject));
                }
                else
                {
                    iTween.MoveTo(yellowTokens[3], iTween.Hash("position", yellowToken4Path[0], "speed", 125, "time", 2.0f, "easetype", "elastic", "oncomplete", "IntializeDice", "oncompletetarget", this.gameObject));
                }
                currentPlayerName = "YELLOW TOKEN 4";
            }
            else
            {
                if (DiceNumAnimation == 6 && yellowSteps[3] == 0)
                {
                    Vector3[] yellowToken4Path = new Vector3[1];
                    yellowToken4Path[0] = yellowMovementBlock[yellowSteps[3]].transform.position;
                    yellowSteps[3] += 1;
                    playerTurn = "YELLOW";
                    currentPlayerName = "YELLOW TOKEN 4";
                    iTween.MoveTo(yellowTokens[3], iTween.Hash("position", yellowToken4Path[0], "speed", 125, "time", 2.0f, "easetype", "elastic", "oncomplete", "IntializeDice", "oncompletetarget", this.gameObject));
                }
            }
        }
        else
        {   // Moves to enter house
            if (playerTurn == "YELLOW" && (yellowMovementBlock.Count - yellowSteps[3]) == DiceNumAnimation)
            {
                Vector3[] yellowToken4Path = new Vector3[DiceNumAnimation];
                for (int i = 0; i < DiceNumAnimation; i++)
                {
                    yellowToken4Path[i] = yellowMovementBlock[yellowSteps[3] + i].transform.position;
                }
                yellowSteps[2] += DiceNumAnimation;
                if (yellowToken4Path.Length > 1)
                {
                    iTween.MoveTo(yellowTokens[3], iTween.Hash("path", yellowToken4Path, "speed", 125, "time", 2.0f, "easetype", "elastic", "oncomplete", "IntializeDice", "oncompletetarget", this.gameObject));
                }
                else
                {
                    iTween.MoveTo(yellowTokens[3], iTween.Hash("position", yellowToken4Path[0], "speed", 125, "time", 2.0f, "easetype", "elastic", "oncomplete", "IntializeDice", "oncompletetarget", this.gameObject));
                }
                playerTurn = "YELLOW";
                totalYellowInHouse += 1;
                yellowButtons[3].enabled = false;
            }
            else
            {
                if (yellowSteps[0] + yellowSteps[1] + yellowSteps[2] == 0 && DiceNumAnimation != 6)
                {
                    switch (MainMenuManager.numberOfPlayers)
                    {
                        case 2:
                            //not available
                            break;

                        case 4:
                            playerTurn = "RED";
                            break;
                    }
                }
                IntializeDice();
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        QualitySettings.vSyncCount = 1;
        Application.targetFrameRate = 30;

        redSteps = new int[4];
        blueSteps = new int[4];
        greenSteps = new int[4];
        yellowSteps = new int[4];

        randomNum = new System.Random();
        for (int i = 0; i <= 5; i++)
        {
            diceAnimations[i].SetActive(false);
        }

        //Set initial position for players
        for (int i = 0; i <= 3; i++)
        {
            redTokensPos[i] = redTokens[i].transform.position;
            blueTokensPos[i] = blueTokens[i].transform.position;
            greenTokensPos[i] = greenTokens[i].transform.position;
            yellowTokensPos[i] = yellowTokens[i].transform.position;
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
                    blueTokens[i].SetActive(false);
                    yellowTokens[i].SetActive(false);
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
