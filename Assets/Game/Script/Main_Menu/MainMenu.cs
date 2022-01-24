using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public void LoadSinglePlayerGame()
    {
        Debug.Log("Single Player Game Loading...");
        SceneManager.LoadScene("Single_Player");
    }
    public void LoadCoOpPlayerGame()
    {
        Debug.Log("Co-Op Player Game Loading...");
        SceneManager.LoadScene("Co-Op-Mode");
    }
}
