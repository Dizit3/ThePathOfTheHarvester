using TMPro;
using UnityEngine;

class GUIController : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI ScoreLabel;

    private ScoreManager scoreManager;

    private void Awake()
    {
        scoreManager = gameObject.GetComponent<ScoreManager>();

        scoreManager.OnScoreChange += ChangeScoreText;
    }

    private void ChangeScoreText(int score)
    {
        ScoreLabel.SetText(score.ToString());
    }
}

