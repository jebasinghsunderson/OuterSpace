using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Endscore : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreMesh;
    ScoreKeeper score;
    void Awake()
    {
        score = FindObjectOfType<ScoreKeeper>();    
        }
     void Start()
     {
        scoreMesh.text =" Scored   " +
            ""   + score.GetScore();   
    }
  
}
