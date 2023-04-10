using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class startGame : MonoBehaviour
{
    ScoreKeeper scoreKeeper;
     void Awake()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }
    public void loadScene()
    {

        SceneManager.LoadScene(0);
        scoreKeeper.ResetScore();
    }
    public void mainScene()
    {
        SceneManager.LoadScene(1);
    }
    public void EndScene()
    {
        SceneManager.LoadScene(2);
    }
    public void Quit()
    {
        Application.Quit();
    }

}
