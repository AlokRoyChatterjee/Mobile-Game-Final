using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Menu : MonoBehaviour
{
    public void startgame(string sceneName)
    {
        SceneManager.LoadScene("Easy Level");
    }
    public void quitgame(string sceneName)
    {
        SceneManager.LoadScene("Game Start");
    }
}
