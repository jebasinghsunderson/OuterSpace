using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ScoreKeeper : MonoBehaviour
{
    int score= 0;
     void Start()
    {
        singletonScore();  
    }
    void singletonScore()
    {
        int instances = FindObjectsOfType(GetType()).Length;
        if (instances > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
            DontDestroyOnLoad(gameObject);
    }
    public int GetScore()
    {
        return score;
    }

    public void IncreaseScore(int value)
    {
        score += value;
        Mathf.Clamp(score, 0, int.MaxValue);
      
    }
    public void ResetScore()
    {
        score = 0;
    }
 
}
