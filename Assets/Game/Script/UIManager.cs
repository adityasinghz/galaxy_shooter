using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UIManager : MonoBehaviour
{
   public Sprite[] lives;
    public Image livesImageDisplay;
    public GameObject titleScreen;

    public Text highestkillsText;
    public Text killText;
    public int kills;
    public int bestkills;
    [SerializeField]
    private Text _gameOverText;
    [SerializeField]
    private Text _restartText;
  //  private GameManager _gameManager;
    private void Start() 
    {
        bestkills = PlayerPrefs.GetInt("Highest Kills", 0);
        highestkillsText.text = "Highest kills " + bestkills;
        _gameOverText.gameObject.SetActive(false);
       // _gameManager = GameObject.Find("Game_Manager").GetComponent<GameManager>();
    }
   public void UpdateLives(int currentLives)
    {
        Debug.Log("Player lives : " + currentLives);
        livesImageDisplay.sprite = lives[currentLives];

        if(currentLives==0)
        {
            GameOverSequence();
        }
    }
    void GameOverSequence()
    {
       // _gameManager.GameOver();
        _gameOverText.gameObject.SetActive(true);
        _restartText.gameObject.SetActive(true);
        StartCoroutine(GameOverFlickerRoutine());
    }

    IEnumerator GameOverFlickerRoutine()
    {
        while(true)
        {
            _gameOverText.text = "GAME OVER";
            yield return new WaitForSeconds(0.5f);
            _gameOverText.text = "";
            yield return new WaitForSeconds(0.5f);
        }
    }

    public void UpdateScore()
    {
        kills++;
        killText.text = "Kills: " + kills;
    }
    public void CheckForBestkills()
    {
        if(kills > bestkills)
        {
            bestkills = kills;
            PlayerPrefs.SetInt("Highest Kills", bestkills);
            highestkillsText.text="Highest Kills: " + bestkills;
        }
    }



    public void ShowTitleScreen()
    {
        titleScreen.SetActive(true);
        kills=0;
    }
    public void HideTitleScreen()
    {
        titleScreen.SetActive(false);
    }
    //Resume Play
    public void ResumePlay()
    {
        GameManager gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        gm.ResumeGame();
    }
    public void BackToMainMenu()
    {
        SceneManager.LoadScene("Main_Menu");
    }
    //BackToMenu

}
