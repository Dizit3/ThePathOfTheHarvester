using System;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{

    private int currentScore;
    private int totalScore;

    public event Action<int> OnScoreChange;

    private Ship ship;

    private void Awake()
    {
        currentScore = 0;
        ship = GameObject.FindGameObjectWithTag("ShipScript").GetComponent<Ship>();

        ship.OnAddMoney += AddPoints;
    }

    public void AddPoints(int points)
    { 
        currentScore += points;

        OnScoreChange?.Invoke(currentScore);
    }

    public int GetScore() { return currentScore; }

    public void SaveScoreOnGameover()
    {
        PlayerPrefs.SetInt("Score", currentScore);
        PlayerPrefs.Save();
    }

    public int LoadTotalScore()
    {
        if (PlayerPrefs.HasKey("Score"))
        {
            return totalScore = PlayerPrefs.GetInt("Score");
        }
        else { return totalScore = 0; }
    }
}

