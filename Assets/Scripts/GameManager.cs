using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private Text scoreText;
    [SerializeField] private Text finalScore;

    private bool playerActive = false;
    private bool gameOver = false;
    private bool gameStarted = false;
    private int score = 0;

    public bool PlayerActive {
        get { return playerActive; }
    }

    public bool GameOver {
        get { return gameOver; }
    }

    public bool GameStarted {
        get { return gameStarted; }
    }

    public int GetScore {
        get { return score; }
    }

    private void Awake()
    {
        
        if (instance == null){
            instance = this;
        } else if(instance != this){
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);

        Assert.IsNotNull(mainMenu);
    }

    // Start is called before the first frame update
    void Start(){
        
    }

    // Update is called once per frame
    void Update(){
        //Debug.Log(score);
    }

    public void PlayerCollided(){
        gameOver = true;
        playerActive = false;
        gameStarted = false;
        scoreText.gameObject.SetActive(false);
        finalScore.text = score.ToString();
        gameOverScreen.gameObject.SetActive(true);
    }

    public void GameStart() {
        playerActive = true;
    }

    public void EnterGame() {
        mainMenu.SetActive(false);
        scoreText.gameObject.SetActive(true);
        gameStarted = true;
    }

    public void IncreaseScore() {
        score += 1;
        scoreText.text = "Score: " + score;
    }
}
