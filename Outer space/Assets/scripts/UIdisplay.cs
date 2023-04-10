using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIdisplay : MonoBehaviour
{
    Health playerHealth;
    ScoreKeeper playerScore;
    [SerializeField]TextMeshProUGUI scoreText;
    [SerializeField] Slider healthBar;
    private void Awake()
    {
        playerHealth = FindObjectOfType<Health>();
        playerScore = FindObjectOfType<ScoreKeeper>();
    }
    private void Start()
    {
        healthBar =FindObjectOfType<Slider>();
        healthBar.maxValue = playerHealth.GetHealth();
      
    }
    // Update is called once per frame
    void Update()
    {
       
        scoreText.text = playerScore.GetScore().ToString("00000000000");
         healthBar.value = playerHealth.GetHealth();
        
    }
}
