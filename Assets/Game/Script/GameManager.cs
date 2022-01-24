using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private bool _isGameOver;
    public bool isCoopMode=false;
    public bool gameOver = true;
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private GameObject _coopPlayer;
    [SerializeField]
    private GameObject _pauseMenuPanel;
    private UIManager _uiManager;
    private SpawnManager _spawnManager;

    private Animator _PauseAnimator;



  /*  public void GameOver()
    {
        _isGameOver = true;
    }
  */

    private void Start()
    {
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        _spawnManager = GameObject.Find("Spawn_Manager").GetComponent<SpawnManager>();
        _PauseAnimator = GameObject.Find("Pause_Menu_Panel").GetComponent<Animator>();
        _PauseAnimator.updateMode = AnimatorUpdateMode.UnscaledTime;
    }
    //if game over is true
    //if space key pressed
    //spawn the player
    //gameOver is false
    //hide title screen

    void Update()
    {
        if (gameOver == true)
        {
         
    
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (isCoopMode == false)
                {
                    Instantiate(player, Vector3.zero, Quaternion.identity);
                }
                else
                {
                    Instantiate(_coopPlayer, Vector3.zero, Quaternion.identity);
                }

                gameOver = false;
                _uiManager.HideTitleScreen();
                _spawnManager.StartSpawnRoutines();
            }

          else  if (Input.GetKeyDown(KeyCode.Escape))
            {
                SceneManager.LoadScene("Main_Menu");
            }
        }

        if(Input.GetKeyDown(KeyCode.P))
        {
            _pauseMenuPanel.SetActive(true);
            _PauseAnimator.SetBool("isPaused", true);
           Time.timeScale = 0;
        }
   /*    if (Input.GetKeyDown(KeyCode.R) && _isGameOver == true)
        {
            if (isCoopMode == false)
            {
                SceneManager.LoadScene(0);
            }
            if (isCoopMode == true)
            {
                SceneManager.LoadScene(1);
            }
        }
   */
    }
 public void ResumeGame()
    {
        _pauseMenuPanel.SetActive(false);
        Time.timeScale = 1;
    }
}
