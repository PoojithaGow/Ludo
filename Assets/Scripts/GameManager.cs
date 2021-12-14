using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
