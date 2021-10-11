using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    [SerializeField] GameObject DeathPanel;
    [SerializeField] Text ScoreText;
    [SerializeField] Text HealthText;
    [SerializeField] Text HighScore;

    private void Awake()
    {
        SetHighScore();
    }

    private void FixedUpdate()
    {
        ScoreText.text = "Score: " + gameManager._score.ToString();
        HealthText.text = "Health: " + gameManager._health.ToString();
    }

    private void OnEnable()
    {
        gameManager.OnGameEnd += () => { DeathPanel.SetActive(true); };
    }

    private void OnDisable()
    {
        gameManager.OnGameEnd -= () => { DeathPanel.SetActive(true); }; 
    }

    public void TurnOffDeathPanel()
    {
        DeathPanel.SetActive(false);
    }

    public void SetHighScore()
    {
        if(PlayerPrefs.HasKey("High Score"))
        {
            HighScore.text = "High Score: " + PlayerPrefs.GetInt("High Score").ToString();
        }
    }
}
